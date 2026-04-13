using UnityEngine;
using BM.Shaft;
using BM.Gatherer;

namespace BM.Core
{
    public sealed class BM_SaveManager : MonoBehaviour
    {
        private const string SAVE_FILE = "BM_Save.es3";

        [Header("References")]
        [SerializeField] private BloodManager _bloodManager;
        [SerializeField] private ShaftManager _shaftManager;
        [SerializeField] private GathererManager _gathererManager;

        private void Start()
        {
            Load();
        }

        [ContextMenu("Save Game")]
        public void Save()
        {
            ES3.Save("bloodBalance", _bloodManager.BloodBalance, SAVE_FILE);
            ES3.Save("lifetimeBlood", _bloodManager.LifetimeBloodHarvested, SAVE_FILE);
            ES3.Save("ghoulRow", _shaftManager.GhoulRowIndex, SAVE_FILE);
            ES3.Save("gathererCount", _gathererManager.Count, SAVE_FILE);
            ES3.Save("gathererSpeedTier", _gathererManager.SpeedTier, SAVE_FILE);
            ES3.Save("gathererSlots", _shaftManager.GathererSlotsAvailable, SAVE_FILE);

            int rowCount = _shaftManager.RowCount;
            ES3.Save("rowCount", rowCount, SAVE_FILE);

            for (int i = 0; i < rowCount; i++)
            {
                Row row = _shaftManager.GetRow(i);
                if (row == null) continue;
                string prefix = "row_" + i + "_";
                ES3.Save(prefix + "outlets", row.OutletCount, SAVE_FILE);
                ES3.Save(prefix + "minions", row.ChopMinionCount, SAVE_FILE);
                ES3.Save(prefix + "toolTier", row.ToolUpgrade != null ? row.ToolUpgrade.ToolTier : 0, SAVE_FILE);
                ES3.Save(prefix + "gaugeFill", row.LeftoversGauge != null ? row.LeftoversGauge.Current : 0f, SAVE_FILE);
            }

            Debug.Log("[BM] SaveManager: saved " + rowCount + " rows, ghoul at row " + _shaftManager.GhoulRowIndex);
        }

        [ContextMenu("Load Game")]
        public void Load()
        {
            if (!ES3.FileExists(SAVE_FILE))
            {
                Debug.Log("[BM] SaveManager: no save file, starting fresh");
                return;
            }

            double balance = ES3.Load<double>("bloodBalance", SAVE_FILE, 0.0);
            double lifetime = ES3.Load<double>("lifetimeBlood", SAVE_FILE, 0.0);
            _bloodManager.SetState(balance, lifetime);

            int savedRowCount = ES3.Load<int>("rowCount", SAVE_FILE, 1);
            int ghoulRow = ES3.Load<int>("ghoulRow", SAVE_FILE, 0);
            int gathererCount = ES3.Load<int>("gathererCount", SAVE_FILE, 1);
            int gathererSpeed = ES3.Load<int>("gathererSpeedTier", SAVE_FILE, 1);
            int gathererSlots = ES3.Load<int>("gathererSlots", SAVE_FILE, 0);

            // Unlock rows up to saved count (row 0 already exists in scene)
            for (int i = _shaftManager.RowCount; i < savedRowCount; i++)
            {
                _shaftManager.UnlockNextRow();
            }

            // Restore per-row state
            for (int i = 0; i < savedRowCount; i++)
            {
                Row row = _shaftManager.GetRow(i);
                if (row == null) continue;
                string prefix = "row_" + i + "_";

                int savedOutlets = ES3.Load<int>(prefix + "outlets", SAVE_FILE, 1);
                while (row.OutletCount < savedOutlets) row.BuyOutlet();

                int savedMinions = ES3.Load<int>(prefix + "minions", SAVE_FILE, 0);
                while (row.ChopMinionCount < savedMinions) row.BuyMinion();

                int savedTier = ES3.Load<int>(prefix + "toolTier", SAVE_FILE, 0);
                if (row.ToolUpgrade != null)
                {
                    for (int t = 0; t < savedTier; t++)
                    {
                        // Force tier up without requiring gauge full
                        System.Reflection.BindingFlags bf = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
                        var field = typeof(ToolUpgradeController).GetField("_toolTier", bf);
                        field.SetValue(row.ToolUpgrade, savedTier);
                    }
                }

                float savedFill = ES3.Load<float>(prefix + "gaugeFill", SAVE_FILE, 0f);
                if (row.LeftoversGauge != null && savedFill > 0f)
                {
                    row.LeftoversGauge.Add(savedFill);
                }
            }

            // Descend ghoul to saved row
            for (int i = 0; i < ghoulRow; i++)
            {
                _shaftManager.Descend();
            }

            // Restore gatherer state
            _gathererManager.SetSpeedTier(gathererSpeed);
            _gathererManager.SetCount(gathererCount);

            // Restore gatherer slots
            System.Reflection.BindingFlags bfSlots = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
            typeof(ShaftManager).GetField("_gathererSlotsAvailable", bfSlots).SetValue(_shaftManager, gathererSlots);

            Debug.Log("[BM] SaveManager: loaded " + savedRowCount + " rows, ghoul at row " + ghoulRow
                + ", blood=" + balance + ", gatherers=" + gathererCount);
        }

        [ContextMenu("Clear Save Data")]
        public void ClearSaveData()
        {
            if (ES3.FileExists(SAVE_FILE))
            {
                ES3.DeleteFile(SAVE_FILE);
                Debug.Log("[BM] SaveManager: save data cleared");
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}

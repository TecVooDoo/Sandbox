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
                ES3.Save(prefix + "gaugeCapacity", row.LeftoversGauge != null ? row.LeftoversGauge.Capacity : 100f, SAVE_FILE);
                ES3.Save(prefix + "hasAutoButton", row.HasAutoButton, SAVE_FILE);
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

            // Interleave UnlockNextRow + Descend so the safeguard in UnlockNextRow
            // (which refuses to create a second row below the ghoul) doesn't block us.
            // After this loop: rows = ghoulRow+1, ghoul sits at ghoulRow.
            for (int i = 1; i <= ghoulRow && i < savedRowCount; i++)
            {
                _shaftManager.UnlockNextRow();
                _shaftManager.Descend();
            }
            // If the save had one extra row unlocked below the ghoul (the normal "next row
            // is ready, pending descend" state), create it too. Safeguard allows exactly one.
            if (_shaftManager.RowCount < savedRowCount)
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

                // Restore gauge capacity BEFORE adding fill so capacity cap applies correctly
                float savedCapacity = ES3.Load<float>(prefix + "gaugeCapacity", SAVE_FILE, 100f);
                if (row.LeftoversGauge != null) row.LeftoversGauge.SetCapacity(savedCapacity);

                float savedFill = ES3.Load<float>(prefix + "gaugeFill", SAVE_FILE, 0f);
                if (row.LeftoversGauge != null && savedFill > 0f)
                {
                    row.LeftoversGauge.Add(savedFill);
                }

                bool savedAutoButton = ES3.Load<bool>(prefix + "hasAutoButton", SAVE_FILE, false);
                if (savedAutoButton && !row.HasAutoButton)
                {
                    row.BuyAutoButton();
                    // Also hide the world-space auto-upgrade purchase button
                    if (row.ToolUpgrade != null)
                    {
                        Transform autoBtn = row.ToolUpgrade.transform.Find("AutoUpgradeButton");
                        if (autoBtn != null) autoBtn.gameObject.SetActive(false);
                    }
                }
            }

            // Gatherer state
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

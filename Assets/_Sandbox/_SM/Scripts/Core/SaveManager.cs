using System;
using System.Collections.Generic;
using UnityEngine;
using SM.Mine;
using SM.Upgrade;

namespace SM.Core
{
    public sealed class SaveManager : MonoBehaviour
    {
        private const string KEY_SOUL_BALANCE = "SM_SoulBalance";
        private const string KEY_LIFETIME_SOULS = "SM_LifetimeSouls";
        private const string KEY_RANK_INDEX = "SM_RankIndex";
        private const string KEY_ACTIVE_ZONE = "SM_ActiveZone";
        private const string KEY_LAST_SAVE_TIME = "SM_LastSaveTime";
        private const string KEY_ELEVATOR_LEVEL = "SM_ElevatorLevel";
        private const string KEY_WAREHOUSE_LEVEL = "SM_WarehouseLevel";
        private const string KEY_MINE_LEVELS = "SM_MineLevels";
        private const float AUTO_SAVE_INTERVAL = 30f;

        [Header("References")]
        [SerializeField] private GameState _gameState;
        [SerializeField] private UpgradeSystem _upgradeSystem;
        [SerializeField] private bool _autoLoadOnStart = true;

        [Header("Upgrade Reapply")]
        [SerializeField] private MineLevel[] _mineLevels;
        [SerializeField] private UpgradeConfigSO _mineConfig;
        [SerializeField] private Elevator _elevator;
        [SerializeField] private UpgradeConfigSO _elevatorConfig;
        [SerializeField] private Warehouse _warehouse;
        [SerializeField] private UpgradeConfigSO _warehouseConfig;

        private float _timeSinceLastSave;

        private void Start()
        {
            if (_autoLoadOnStart && HasSaveData())
                Load();
        }

        private void Update()
        {
            _timeSinceLastSave += Time.unscaledDeltaTime;
            if (_timeSinceLastSave >= AUTO_SAVE_INTERVAL)
            {
                Save();
                _timeSinceLastSave = 0f;
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

        public void Save()
        {
            if (_gameState == null || _gameState.SoulManager == null) return;

            ES3.Save(KEY_SOUL_BALANCE, _gameState.SoulManager.SoulBalance);
            ES3.Save(KEY_LIFETIME_SOULS, _gameState.SoulManager.LifetimeSoulsHarvested);
            ES3.Save(KEY_RANK_INDEX, _gameState.RankSystem.CurrentRankIndex);
            ES3.Save(KEY_ACTIVE_ZONE, _gameState.ActiveZoneIndex);
            ES3.Save(KEY_LAST_SAVE_TIME, DateTime.UtcNow.ToBinary());

            if (_upgradeSystem != null)
            {
                ES3.Save(KEY_ELEVATOR_LEVEL, _upgradeSystem.ElevatorUpgradeLevel);
                ES3.Save(KEY_WAREHOUSE_LEVEL, _upgradeSystem.WarehouseUpgradeLevel);
                ES3.Save(KEY_MINE_LEVELS, _upgradeSystem.GetMineUpgradeSnapshot());
            }
        }

        public void Load()
        {
            if (_gameState == null) return;

            double balance = 0;
            double lifetime = 0;
            int rankIndex = 0;
            int zoneIndex = 0;

            if (ES3.KeyExists(KEY_SOUL_BALANCE)) balance = ES3.Load<double>(KEY_SOUL_BALANCE);
            if (ES3.KeyExists(KEY_LIFETIME_SOULS)) lifetime = ES3.Load<double>(KEY_LIFETIME_SOULS);
            if (ES3.KeyExists(KEY_RANK_INDEX)) rankIndex = ES3.Load<int>(KEY_RANK_INDEX);
            if (ES3.KeyExists(KEY_ACTIVE_ZONE)) zoneIndex = ES3.Load<int>(KEY_ACTIVE_ZONE);

            _gameState.SoulManager.SetState(balance, lifetime);
            _gameState.RankSystem.SetRank(rankIndex);
            _gameState.TrySwitchZone(zoneIndex);

            if (_upgradeSystem != null)
            {
                int elevLevel = ES3.KeyExists(KEY_ELEVATOR_LEVEL) ? ES3.Load<int>(KEY_ELEVATOR_LEVEL) : 0;
                int whLevel = ES3.KeyExists(KEY_WAREHOUSE_LEVEL) ? ES3.Load<int>(KEY_WAREHOUSE_LEVEL) : 0;
                Dictionary<int, int> mineUpgrades = ES3.KeyExists(KEY_MINE_LEVELS)
                    ? ES3.Load<Dictionary<int, int>>(KEY_MINE_LEVELS)
                    : new Dictionary<int, int>();

                _upgradeSystem.RestoreState(elevLevel, whLevel, mineUpgrades);
                _upgradeSystem.ReapplyAllUpgrades(_mineLevels, _mineConfig, _elevator, _elevatorConfig, _warehouse, _warehouseConfig);
            }
        }

        public double GetOfflineSeconds()
        {
            if (!ES3.KeyExists(KEY_LAST_SAVE_TIME)) return 0;
            long lastSaveBinary = ES3.Load<long>(KEY_LAST_SAVE_TIME);
            if (lastSaveBinary == 0) return 0;
            DateTime lastSave = DateTime.FromBinary(lastSaveBinary);
            double seconds = (DateTime.UtcNow - lastSave).TotalSeconds;
            return Math.Min(seconds, 28800);
        }

        public bool HasSaveData()
        {
            return ES3.KeyExists(KEY_SOUL_BALANCE);
        }

        [ContextMenu("Clear Save Data")]
        public void ClearSaveData()
        {
            ES3.DeleteKey(KEY_SOUL_BALANCE);
            ES3.DeleteKey(KEY_LIFETIME_SOULS);
            ES3.DeleteKey(KEY_RANK_INDEX);
            ES3.DeleteKey(KEY_ACTIVE_ZONE);
            ES3.DeleteKey(KEY_LAST_SAVE_TIME);
            ES3.DeleteKey(KEY_ELEVATOR_LEVEL);
            ES3.DeleteKey(KEY_WAREHOUSE_LEVEL);
            ES3.DeleteKey(KEY_MINE_LEVELS);
            Debug.Log("Save data cleared.");
        }
    }
}
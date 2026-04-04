using System;
using UnityEngine;

namespace SM.Core
{
    public sealed class SaveManager : MonoBehaviour
    {
        private const string KEY_SOUL_BALANCE = "SM_SoulBalance";
        private const string KEY_LIFETIME_SOULS = "SM_LifetimeSouls";
        private const string KEY_RANK_INDEX = "SM_RankIndex";
        private const string KEY_ACTIVE_ZONE = "SM_ActiveZone";
        private const string KEY_LAST_SAVE_TIME = "SM_LastSaveTime";
        private const float AUTO_SAVE_INTERVAL = 30f;

        [Header("References")]
        [SerializeField] private GameState _gameState;

        private float _timeSinceLastSave;

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

#if EASY_SAVE_3
            ES3.Save(KEY_SOUL_BALANCE, _gameState.SoulManager.SoulBalance);
            ES3.Save(KEY_LIFETIME_SOULS, _gameState.SoulManager.LifetimeSoulsHarvested);
            ES3.Save(KEY_RANK_INDEX, _gameState.RankSystem.CurrentRankIndex);
            ES3.Save(KEY_ACTIVE_ZONE, _gameState.ActiveZoneIndex);
            ES3.Save(KEY_LAST_SAVE_TIME, DateTime.UtcNow.ToBinary());
#else
            PlayerPrefs.SetString(KEY_SOUL_BALANCE, _gameState.SoulManager.SoulBalance.ToString("R"));
            PlayerPrefs.SetString(KEY_LIFETIME_SOULS, _gameState.SoulManager.LifetimeSoulsHarvested.ToString("R"));
            PlayerPrefs.SetInt(KEY_RANK_INDEX, _gameState.RankSystem.CurrentRankIndex);
            PlayerPrefs.SetInt(KEY_ACTIVE_ZONE, _gameState.ActiveZoneIndex);
            PlayerPrefs.SetString(KEY_LAST_SAVE_TIME, DateTime.UtcNow.ToBinary().ToString());
            PlayerPrefs.Save();
#endif
        }

        public void Load()
        {
            if (_gameState == null) return;

            double balance = 0;
            double lifetime = 0;
            int rankIndex = 0;
            int zoneIndex = 0;

#if EASY_SAVE_3
            if (ES3.KeyExists(KEY_SOUL_BALANCE))
            {
                balance = ES3.Load<double>(KEY_SOUL_BALANCE);
                lifetime = ES3.Load<double>(KEY_LIFETIME_SOULS);
                rankIndex = ES3.Load<int>(KEY_RANK_INDEX);
                zoneIndex = ES3.Load<int>(KEY_ACTIVE_ZONE);
            }
#else
            if (PlayerPrefs.HasKey(KEY_SOUL_BALANCE))
            {
                double.TryParse(PlayerPrefs.GetString(KEY_SOUL_BALANCE), out balance);
                double.TryParse(PlayerPrefs.GetString(KEY_LIFETIME_SOULS), out lifetime);
                rankIndex = PlayerPrefs.GetInt(KEY_RANK_INDEX);
                zoneIndex = PlayerPrefs.GetInt(KEY_ACTIVE_ZONE);
            }
#endif

            _gameState.SoulManager.SetState(balance, lifetime);
            _gameState.RankSystem.SetRank(rankIndex);
            _gameState.TrySwitchZone(zoneIndex);
        }

        public double GetOfflineSeconds()
        {
            long lastSaveBinary = 0;

#if EASY_SAVE_3
            if (ES3.KeyExists(KEY_LAST_SAVE_TIME))
                lastSaveBinary = ES3.Load<long>(KEY_LAST_SAVE_TIME);
#else
            if (PlayerPrefs.HasKey(KEY_LAST_SAVE_TIME))
                long.TryParse(PlayerPrefs.GetString(KEY_LAST_SAVE_TIME), out lastSaveBinary);
#endif

            if (lastSaveBinary == 0) return 0;

            DateTime lastSave = DateTime.FromBinary(lastSaveBinary);
            double seconds = (DateTime.UtcNow - lastSave).TotalSeconds;
            return Math.Min(seconds, 28800); // Cap at 8 hours
        }

        public bool HasSaveData()
        {
#if EASY_SAVE_3
            return ES3.KeyExists(KEY_SOUL_BALANCE);
#else
            return PlayerPrefs.HasKey(KEY_SOUL_BALANCE);
#endif
        }
    }
}

using UnityEngine;
using SM.Core;

namespace SM.Mine
{
    public sealed class Warehouse : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private double _storageCapacity = 100;
        [SerializeField] private float _autoCollectRate; // souls per second, 0 = manual only

        [Header("References")]
        [SerializeField] private SoulManager _soulManager;

        [Header("Events")]
        [SerializeField] private GameEvent _onWarehouseFull;
        [SerializeField] private DoubleGameEvent _onStorageChanged;

        private double _storedSouls;
        private float _autoCollectTimer;
        private int _upgradeLevel;
        private bool _fullNotified;

        public double StoredSouls => _storedSouls;
        public double StorageCapacity => _storageCapacity;
        public int UpgradeLevel => _upgradeLevel;
        public float FillPercent => _storageCapacity > 0 ? (float)(_storedSouls / _storageCapacity) : 0f;

        private void Update()
        {
            if (_autoCollectRate <= 0f || _storedSouls <= 0) return;

            _autoCollectTimer += Time.deltaTime;
            if (_autoCollectTimer >= 1f)
            {
                _autoCollectTimer = 0f;
                double toCollect = System.Math.Min(_autoCollectRate, _storedSouls);
                _storedSouls -= toCollect;
                _soulManager.AddSouls(toCollect);

                if (_onStorageChanged != null)
                    _onStorageChanged.Raise(_storedSouls);

                _fullNotified = false;
            }
        }

        public void ReceiveSouls(double amount)
        {
            double spaceAvailable = _storageCapacity - _storedSouls;
            double received = System.Math.Min(amount, spaceAvailable);
            _storedSouls += received;

            if (_onStorageChanged != null)
                _onStorageChanged.Raise(_storedSouls);

            if (_storedSouls >= _storageCapacity && !_fullNotified)
            {
                _fullNotified = true;
                if (_onWarehouseFull != null)
                    _onWarehouseFull.Raise();
            }
        }

        public void CollectAll()
        {
            if (_storedSouls <= 0 || _soulManager == null) return;

            double collected = _storedSouls;
            _storedSouls = 0;
            _fullNotified = false;
            _soulManager.AddSouls(collected);

            if (_onStorageChanged != null)
                _onStorageChanged.Raise(_storedSouls);
        }

        public void ApplyUpgrade(int newLevel, double newCapacity, float newAutoRate)
        {
            _upgradeLevel = newLevel;
            _storageCapacity = newCapacity;
            _autoCollectRate = Mathf.Max(0f, newAutoRate);
        }
    }
}

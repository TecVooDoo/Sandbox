using UnityEngine;
using SM.Core;

namespace SM.Mine
{
    public sealed class Elevator : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private double _capacity = 10;
        [SerializeField] private float _tripDuration = 3f;

        [Header("Events")]
        [SerializeField] private DoubleGameEvent _onSoulDelivered;

        private double _currentLoad;
        private float _tripTimer;
        private bool _inTransit;
        private int _upgradeLevel;

        public double Capacity => _capacity;
        public double CurrentLoad => _currentLoad;
        public bool InTransit => _inTransit;
        public int UpgradeLevel => _upgradeLevel;

        private void Update()
        {
            if (!_inTransit) return;

            _tripTimer += Time.deltaTime;
            if (_tripTimer >= _tripDuration)
            {
                DeliverSouls();
            }
        }

        public bool TryLoadSouls(double amount)
        {
            if (_inTransit) return false;

            double spaceAvailable = _capacity - _currentLoad;
            if (spaceAvailable <= 0) return false;

            double loaded = System.Math.Min(amount, spaceAvailable);
            _currentLoad += loaded;

            if (_currentLoad >= _capacity)
            {
                StartTrip();
            }

            return true;
        }

        public void StartTrip()
        {
            if (_inTransit || _currentLoad <= 0) return;

            _inTransit = true;
            _tripTimer = 0f;
        }

        private void DeliverSouls()
        {
            _inTransit = false;
            _tripTimer = 0f;

            double delivered = _currentLoad;
            _currentLoad = 0;

            if (_onSoulDelivered != null)
                _onSoulDelivered.Raise(delivered);
        }

        public void ApplyUpgrade(int newLevel, double newCapacity, float newTripDuration)
        {
            _upgradeLevel = newLevel;
            _capacity = newCapacity;
            _tripDuration = Mathf.Max(0.5f, newTripDuration);
        }
    }
}

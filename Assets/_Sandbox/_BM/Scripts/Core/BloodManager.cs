using UnityEngine;

namespace BM.Core
{
    public sealed class BloodManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private DoubleGameEvent _onBloodBalanceChanged;
        [SerializeField] private DoubleGameEvent _onBloodSpent;
        [SerializeField] private DoubleGameEvent _onLifetimeBloodChanged;

        private double _bloodBalance;
        private double _lifetimeBloodHarvested;

        public double BloodBalance => _bloodBalance;
        public double LifetimeBloodHarvested => _lifetimeBloodHarvested;

        public void AddBlood(double amount)
        {
            if (amount <= 0) return;

            _bloodBalance += amount;
            _lifetimeBloodHarvested += amount;

            if (_onBloodBalanceChanged != null)
                _onBloodBalanceChanged.Raise(_bloodBalance);

            if (_onLifetimeBloodChanged != null)
                _onLifetimeBloodChanged.Raise(_lifetimeBloodHarvested);
        }

        public bool TrySpend(double amount)
        {
            if (amount <= 0 || _bloodBalance < amount) return false;

            _bloodBalance -= amount;

            if (_onBloodBalanceChanged != null)
                _onBloodBalanceChanged.Raise(_bloodBalance);

            if (_onBloodSpent != null)
                _onBloodSpent.Raise(amount);

            return true;
        }

        public bool CanAfford(double amount)
        {
            return _bloodBalance >= amount;
        }

        public void SetState(double balance, double lifetime)
        {
            _bloodBalance = balance;
            _lifetimeBloodHarvested = lifetime;

            if (_onBloodBalanceChanged != null)
                _onBloodBalanceChanged.Raise(_bloodBalance);

            if (_onLifetimeBloodChanged != null)
                _onLifetimeBloodChanged.Raise(_lifetimeBloodHarvested);
        }
    }
}
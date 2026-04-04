using UnityEngine;

namespace SM.Core
{
    public sealed class SoulManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private DoubleGameEvent _onSoulBalanceChanged;
        [SerializeField] private DoubleGameEvent _onSoulSpent;
        [SerializeField] private DoubleGameEvent _onLifetimeSoulsChanged;

        private double _soulBalance;
        private double _lifetimeSoulsHarvested;

        public double SoulBalance => _soulBalance;
        public double LifetimeSoulsHarvested => _lifetimeSoulsHarvested;

        public void AddSouls(double amount)
        {
            if (amount <= 0) return;

            _soulBalance += amount;
            _lifetimeSoulsHarvested += amount;

            if (_onSoulBalanceChanged != null)
                _onSoulBalanceChanged.Raise(_soulBalance);

            if (_onLifetimeSoulsChanged != null)
                _onLifetimeSoulsChanged.Raise(_lifetimeSoulsHarvested);
        }

        public bool TrySpend(double amount)
        {
            if (amount <= 0 || _soulBalance < amount) return false;

            _soulBalance -= amount;

            if (_onSoulBalanceChanged != null)
                _onSoulBalanceChanged.Raise(_soulBalance);

            if (_onSoulSpent != null)
                _onSoulSpent.Raise(amount);

            return true;
        }

        public bool CanAfford(double amount)
        {
            return _soulBalance >= amount;
        }

        public void SetState(double balance, double lifetime)
        {
            _soulBalance = balance;
            _lifetimeSoulsHarvested = lifetime;

            if (_onSoulBalanceChanged != null)
                _onSoulBalanceChanged.Raise(_soulBalance);

            if (_onLifetimeSoulsChanged != null)
                _onLifetimeSoulsChanged.Raise(_lifetimeSoulsHarvested);
        }
    }
}
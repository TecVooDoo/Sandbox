using UnityEngine;
using SM.Core;

namespace SM.Mine
{
    public sealed class MineLevel : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private int _levelIndex;
        [SerializeField] private float _baseSoulYield = 1f;
        [SerializeField] private float _harvestSpeedMultiplier = 1f;

        [Header("References")]
        [SerializeField] private BodyPile _bodyPile;
        [SerializeField] private Transform _elevatorPickupPoint;

        private int _upgradeLevel;
        private float _soulYieldMultiplier = 1f;
        private double _pendingSouls;

        public int LevelIndex => _levelIndex;
        public int UpgradeLevel => _upgradeLevel;
        public float SoulYieldMultiplier => _soulYieldMultiplier;
        public double PendingSouls => _pendingSouls;
        public BodyPile BodyPile => _bodyPile;
        public Transform ElevatorPickupPoint => _elevatorPickupPoint;

        public void Initialize(BodyConfigSO[] bodyPool)
        {
            if (_bodyPile != null)
                _bodyPile.Initialize(bodyPool);
        }

        public void AddPendingSouls(double amount)
        {
            _pendingSouls += amount * _soulYieldMultiplier;
        }

        public double CollectPendingSouls()
        {
            double collected = _pendingSouls;
            _pendingSouls = 0;
            return collected;
        }

        public void ApplyUpgrade(int newLevel, float newYieldMultiplier)
        {
            _upgradeLevel = newLevel;
            _soulYieldMultiplier = newYieldMultiplier;
        }
    }
}

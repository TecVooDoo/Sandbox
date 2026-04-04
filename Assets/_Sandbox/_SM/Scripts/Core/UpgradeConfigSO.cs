using UnityEngine;

namespace SM.Core
{
    public enum UpgradeTarget
    {
        MineLevel,
        Elevator,
        Warehouse,
        TapPower,
        ComboMultiplier,
        MinionSpeed,
        MinionCount
    }

    [CreateAssetMenu(menuName = "SM/Upgrade Config", fileName = "NewUpgradeConfig")]
    public sealed class UpgradeConfigSO : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private string _upgradeName = "New Upgrade";
        [SerializeField] private UpgradeTarget _target;

        [Header("Cost Curve")]
        [SerializeField] private double _baseCost = 10;
        [SerializeField] private float _costMultiplier = 1.15f;

        [Header("Output")]
        [SerializeField] private double _baseOutput = 1;
        [SerializeField] private double _outputPerLevel = 0.5;
        [SerializeField] private int _maxLevel = 100;

        public string UpgradeName => _upgradeName;
        public UpgradeTarget Target => _target;
        public double BaseCost => _baseCost;
        public float CostMultiplier => _costMultiplier;
        public double BaseOutput => _baseOutput;
        public double OutputPerLevel => _outputPerLevel;
        public int MaxLevel => _maxLevel;
    }
}
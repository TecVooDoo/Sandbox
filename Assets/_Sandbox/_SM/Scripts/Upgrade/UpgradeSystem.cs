using UnityEngine;
using SM.Core;
using SM.Mine;

namespace SM.Upgrade
{
    public sealed class UpgradeSystem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SoulManager _soulManager;

        [Header("Events")]
        [SerializeField] private GameEvent _onUpgradePurchased;

        // Level upgrade states -- keyed by level index
        private readonly System.Collections.Generic.Dictionary<int, int> _mineLevelUpgrades =
            new System.Collections.Generic.Dictionary<int, int>();

        private int _elevatorUpgradeLevel;
        private int _warehouseUpgradeLevel;

        public int ElevatorUpgradeLevel => _elevatorUpgradeLevel;
        public int WarehouseUpgradeLevel => _warehouseUpgradeLevel;

        public System.Collections.Generic.Dictionary<int, int> GetMineUpgradeSnapshot()
        {
            return new System.Collections.Generic.Dictionary<int, int>(_mineLevelUpgrades);
        }

        public void RestoreState(int elevatorLevel, int warehouseLevel, System.Collections.Generic.Dictionary<int, int> mineLevels)
        {
            _elevatorUpgradeLevel = elevatorLevel;
            _warehouseUpgradeLevel = warehouseLevel;
            _mineLevelUpgrades.Clear();
            if (mineLevels != null)
            {
                foreach (var kvp in mineLevels)
                    _mineLevelUpgrades[kvp.Key] = kvp.Value;
            }
        }

        public bool TryUpgradeMineLevel(UpgradeConfigSO config, MineLevel level)
        {
            if (config == null || level == null || _soulManager == null) return false;

            int currentLevel = GetMineLevelUpgrade(level.LevelIndex);
            if (UpgradeCurve.IsMaxLevel(config, currentLevel)) return false;

            double cost = UpgradeCurve.GetCostAtLevel(config, currentLevel);
            if (!_soulManager.TrySpend(cost)) return false;

            int newLevel = currentLevel + 1;
            _mineLevelUpgrades[level.LevelIndex] = newLevel;

            float newYield = (float)UpgradeCurve.GetOutputAtLevel(config, newLevel);
            level.ApplyUpgrade(newLevel, newYield);

            if (_onUpgradePurchased != null)
                _onUpgradePurchased.Raise();

            return true;
        }

        public bool TryUpgradeElevator(UpgradeConfigSO config, Elevator elevator)
        {
            if (config == null || elevator == null || _soulManager == null) return false;
            if (UpgradeCurve.IsMaxLevel(config, _elevatorUpgradeLevel)) return false;

            double cost = UpgradeCurve.GetCostAtLevel(config, _elevatorUpgradeLevel);
            if (!_soulManager.TrySpend(cost)) return false;

            _elevatorUpgradeLevel++;

            double newCapacity = UpgradeCurve.GetOutputAtLevel(config, _elevatorUpgradeLevel);
            float newSpeed = Mathf.Max(0.5f, 3f - _elevatorUpgradeLevel * 0.1f);
            elevator.ApplyUpgrade(_elevatorUpgradeLevel, newCapacity, newSpeed);

            if (_onUpgradePurchased != null)
                _onUpgradePurchased.Raise();

            return true;
        }

        public bool TryUpgradeWarehouse(UpgradeConfigSO config, Warehouse warehouse)
        {
            if (config == null || warehouse == null || _soulManager == null) return false;
            if (UpgradeCurve.IsMaxLevel(config, _warehouseUpgradeLevel)) return false;

            double cost = UpgradeCurve.GetCostAtLevel(config, _warehouseUpgradeLevel);
            if (!_soulManager.TrySpend(cost)) return false;

            _warehouseUpgradeLevel++;

            double newCapacity = UpgradeCurve.GetOutputAtLevel(config, _warehouseUpgradeLevel);
            warehouse.ApplyUpgrade(_warehouseUpgradeLevel, newCapacity, 0f);

            if (_onUpgradePurchased != null)
                _onUpgradePurchased.Raise();

            return true;
        }

        public int GetMineLevelUpgrade(int levelIndex)
        {
            return _mineLevelUpgrades.TryGetValue(levelIndex, out int level) ? level : 0;
        }

        public double GetMineLevelUpgradeCost(UpgradeConfigSO config, int levelIndex)
        {
            return UpgradeCurve.GetCostAtLevel(config, GetMineLevelUpgrade(levelIndex));
        }

        public double GetElevatorUpgradeCost(UpgradeConfigSO config)
        {
            return UpgradeCurve.GetCostAtLevel(config, _elevatorUpgradeLevel);
        }

        public double GetWarehouseUpgradeCost(UpgradeConfigSO config)
        {
            return UpgradeCurve.GetCostAtLevel(config, _warehouseUpgradeLevel);
        }

        public void ReapplyAllUpgrades(
            MineLevel[] mineLevels, UpgradeConfigSO mineConfig,
            Elevator elevator, UpgradeConfigSO elevatorConfig,
            Warehouse warehouse, UpgradeConfigSO warehouseConfig)
        {
            if (mineLevels != null && mineConfig != null)
            {
                foreach (MineLevel ml in mineLevels)
                {
                    if (ml == null) continue;
                    int lvl = GetMineLevelUpgrade(ml.LevelIndex);
                    if (lvl <= 0) continue;
                    float yield = (float)UpgradeCurve.GetOutputAtLevel(mineConfig, lvl);
                    ml.ApplyUpgrade(lvl, yield);
                }
            }
            if (elevator != null && elevatorConfig != null && _elevatorUpgradeLevel > 0)
            {
                double cap = UpgradeCurve.GetOutputAtLevel(elevatorConfig, _elevatorUpgradeLevel);
                float speed = Mathf.Max(0.5f, 3f - _elevatorUpgradeLevel * 0.1f);
                elevator.ApplyUpgrade(_elevatorUpgradeLevel, cap, speed);
            }
            if (warehouse != null && warehouseConfig != null && _warehouseUpgradeLevel > 0)
            {
                double cap = UpgradeCurve.GetOutputAtLevel(warehouseConfig, _warehouseUpgradeLevel);
                warehouse.ApplyUpgrade(_warehouseUpgradeLevel, cap, 0f);
            }
        }
    }
}

using SM.Core;

namespace SM.Upgrade
{
    public static class UpgradeCurve
    {
        public static double GetCostAtLevel(UpgradeConfigSO config, int level)
        {
            if (config == null || level < 0) return 0;
            return config.BaseCost * System.Math.Pow(config.CostMultiplier, level);
        }

        public static double GetOutputAtLevel(UpgradeConfigSO config, int level)
        {
            if (config == null || level < 0) return 0;
            return config.BaseOutput + config.OutputPerLevel * level;
        }

        public static bool IsMaxLevel(UpgradeConfigSO config, int level)
        {
            if (config == null) return true;
            return level >= config.MaxLevel;
        }
    }
}

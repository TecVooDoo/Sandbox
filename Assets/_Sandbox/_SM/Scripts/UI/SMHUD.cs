using UnityEngine;
using UnityEngine.UIElements;
using SM.Core;
using SM.Mine;
using SM.Upgrade;

namespace SM.UI
{
    public sealed class SMHUD : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private SoulManager _soulManager;
        [SerializeField] private RankSystem _rankSystem;
        [SerializeField] private UpgradeSystem _upgradeSystem;
        [SerializeField] private Warehouse _warehouse;

        [Header("Upgrade Configs")]
        [SerializeField] private UpgradeConfigSO _mineLevelConfig;
        [SerializeField] private UpgradeConfigSO _elevatorConfig;
        [SerializeField] private UpgradeConfigSO _warehouseConfig;

        [Header("Mine References")]
        [SerializeField] private MineLevel _mineLevel0;
        [SerializeField] private Elevator _elevator;

        private Label _soulCounter;
        private Label _rankLabel;
        private VisualElement _rankProgressFill;
        private Label _comboLabel;
        private Label _mineCost;
        private Label _mineLevel;
        private Label _elevatorCost;
        private Label _elevatorLevel;
        private Label _warehouseCost;
        private Label _warehouseLevel;
        private Label _collectLabel;
        private Button _collectBtn;

        private float _comboFadeTimer;

        private void OnEnable()
        {
            VisualElement root = _uiDocument.rootVisualElement;
            root.pickingMode = PickingMode.Ignore;

            _soulCounter = root.Q<Label>("soul-counter");
            _rankLabel = root.Q<Label>("rank-label");
            _rankProgressFill = root.Q<VisualElement>("rank-progress-fill");
            _comboLabel = root.Q<Label>("combo-label");
            _mineCost = root.Q<Label>("mine-cost");
            _mineLevel = root.Q<Label>("mine-level");
            _elevatorCost = root.Q<Label>("elevator-cost");
            _elevatorLevel = root.Q<Label>("elevator-level");
            _warehouseCost = root.Q<Label>("warehouse-cost");
            _warehouseLevel = root.Q<Label>("warehouse-level");
            _collectLabel = root.Q<Label>("collect-label");
            _collectBtn = root.Q<Button>("btn-collect");

            root.Q<Button>("btn-upgrade-mine").clicked += OnUpgradeMine;
            root.Q<Button>("btn-upgrade-elevator").clicked += OnUpgradeElevator;
            root.Q<Button>("btn-upgrade-warehouse").clicked += OnUpgradeWarehouse;
            _collectBtn.clicked += OnCollect;
        }

        private void Update()
        {
            if (_soulManager == null) return;

            _soulCounter.text = FormatNumber(_soulManager.SoulBalance);

            if (_rankSystem != null)
            {
                RankConfigSO rank = _rankSystem.CurrentRank;
                if (rank != null)
                    _rankLabel.text = rank.Title;

                float progress = _rankSystem.GetProgressToNextRank();
                _rankProgressFill.style.width = new StyleLength(new Length(progress * 100f, LengthUnit.Percent));
            }

            UpdateUpgradeButtons();
            UpdateCollectButton();
            UpdateComboFade();
        }

        private void UpdateUpgradeButtons()
        {
            if (_upgradeSystem == null) return;

            int mineLvl = _upgradeSystem.GetMineLevelUpgrade(0);
            double mineCost = _upgradeSystem.GetMineLevelUpgradeCost(_mineLevelConfig, 0);
            _mineLevel.text = "Lv " + mineLvl;
            _mineCost.text = "Cost: " + FormatNumber(mineCost);

            double elevCost = _upgradeSystem.GetElevatorUpgradeCost(_elevatorConfig);
            _elevatorLevel.text = "Lv " + (_elevator != null ? _elevator.UpgradeLevel : 0);
            _elevatorCost.text = "Cost: " + FormatNumber(elevCost);

            double whCost = _upgradeSystem.GetWarehouseUpgradeCost(_warehouseConfig);
            _warehouseLevel.text = "Lv " + (_warehouse != null ? _warehouse.UpgradeLevel : 0);
            _warehouseCost.text = "Cost: " + FormatNumber(whCost);
        }

        private void UpdateCollectButton()
        {
            if (_warehouse == null) return;
            double stored = _warehouse.StoredSouls;
            _collectLabel.text = "Collect (" + FormatNumber(stored) + ")";
            _collectBtn.style.display = stored > 0 ? DisplayStyle.Flex : DisplayStyle.None;
        }

        private void UpdateComboFade()
        {
            if (_comboFadeTimer > 0)
            {
                _comboFadeTimer -= Time.deltaTime;
                float alpha = Mathf.Clamp01(_comboFadeTimer / 0.5f);
                _comboLabel.style.opacity = alpha;
            }
        }

        public void ShowCombo(int comboCount)
        {
            if (comboCount <= 1) return;
            _comboLabel.text = "x" + comboCount + "!";
            _comboLabel.style.opacity = 1f;
            _comboFadeTimer = 1.5f;
        }

        private void OnUpgradeMine()
        {
            if (_upgradeSystem != null && _mineLevel0 != null)
                _upgradeSystem.TryUpgradeMineLevel(_mineLevelConfig, _mineLevel0);
        }

        private void OnUpgradeElevator()
        {
            if (_upgradeSystem != null && _elevator != null)
                _upgradeSystem.TryUpgradeElevator(_elevatorConfig, _elevator);
        }

        private void OnUpgradeWarehouse()
        {
            if (_upgradeSystem != null && _warehouse != null)
                _upgradeSystem.TryUpgradeWarehouse(_warehouseConfig, _warehouse);
        }

        private void OnCollect()
        {
            if (_warehouse != null)
                _warehouse.CollectAll();
        }

        private static string FormatNumber(double value)
        {
            if (value >= 1000000000) return (value / 1000000000).ToString("F1") + "B";
            if (value >= 1000000) return (value / 1000000).ToString("F1") + "M";
            if (value >= 10000) return (value / 1000).ToString("F1") + "K";
            return ((long)value).ToString();
        }
    }
}
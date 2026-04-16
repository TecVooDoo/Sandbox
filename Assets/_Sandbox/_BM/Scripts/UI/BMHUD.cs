using UnityEngine;
using UnityEngine.UIElements;
using BM.Core;
using BM.Shaft;

namespace BM.UI
{
    public sealed class BMHUD : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private ShaftManager _shaftManager;
        [SerializeField] private BloodManager _bloodManager;

        private Label _bloodCounter;
        private Label _rowLabel;
        private Label _outletLabel;
        private Label _outletCost;
        private Label _minionCost;
        private Label _descendStatus;
        private Label _gathererSpeedLabel;
        private Label _gathererSpeedCost;
        private Label _gathererCountLabel;
        private Label _gathererCountCost;
        private Button _btnBuyOutlet;
        private Button _btnBuyMinion;
        private Button _btnDescend;
        private Button _btnGathererSpeed;
        private Button _btnGathererCount;

        private void OnEnable()
        {
            if (_uiDocument == null) return;
            VisualElement root = _uiDocument.rootVisualElement;

            _bloodCounter = root.Q<Label>("blood-counter");
            _rowLabel = root.Q<Label>("row-label");
            _outletLabel = root.Q<Label>("outlet-label");
            _outletCost = root.Q<Label>("outlet-cost");
            _minionCost = root.Q<Label>("minion-cost");
            _descendStatus = root.Q<Label>("descend-status");
            _gathererSpeedLabel = root.Q<Label>("gatherer-speed-label");
            _gathererSpeedCost = root.Q<Label>("gatherer-speed-cost");
            _gathererCountLabel = root.Q<Label>("gatherer-count-label");
            _gathererCountCost = root.Q<Label>("gatherer-count-cost");
            _btnBuyOutlet = root.Q<Button>("btn-buy-outlet");
            _btnBuyMinion = root.Q<Button>("btn-buy-minion");
            _btnDescend = root.Q<Button>("btn-descend");
            _btnGathererSpeed = root.Q<Button>("btn-gatherer-speed");
            _btnGathererCount = root.Q<Button>("btn-gatherer-count");

            if (_btnBuyOutlet != null) _btnBuyOutlet.clicked += OnBuyOutlet;
            if (_btnBuyMinion != null) _btnBuyMinion.clicked += OnBuyMinion;
            if (_btnDescend != null) _btnDescend.clicked += OnDescend;
            if (_btnGathererSpeed != null) _btnGathererSpeed.clicked += OnBuyGathererSpeed;
            if (_btnGathererCount != null) _btnGathererCount.clicked += OnBuyGathererCount;
        }

        private void OnDisable()
        {
            if (_btnBuyOutlet != null) _btnBuyOutlet.clicked -= OnBuyOutlet;
            if (_btnBuyMinion != null) _btnBuyMinion.clicked -= OnBuyMinion;
            if (_btnDescend != null) _btnDescend.clicked -= OnDescend;
            if (_btnGathererSpeed != null) _btnGathererSpeed.clicked -= OnBuyGathererSpeed;
            if (_btnGathererCount != null) _btnGathererCount.clicked -= OnBuyGathererCount;
        }

        private void LateUpdate()
        {
            if (_shaftManager == null || _bloodManager == null) return;

            Row row = _shaftManager.ActiveRow;
            if (row == null) return;

            // Show info for the viewed row
            Row viewedRow = _shaftManager.ViewedRow ?? row;

            if (_bloodCounter != null)
                _bloodCounter.text = FormatNumber(_bloodManager.BloodBalance);

            bool viewing = _shaftManager.ViewedRowIndex != _shaftManager.GhoulRowIndex;
            if (_rowLabel != null)
                _rowLabel.text = viewing
                    ? "Row " + _shaftManager.ViewedRowIndex
                    : "Row " + _shaftManager.GhoulRowIndex;

            if (_outletLabel != null)
                _outletLabel.text = "Outlets:" + viewedRow.OutletCount + "/" + viewedRow.MaxOutlets + "  Minions:" + viewedRow.ChopMinionCount + "/" + viewedRow.OutletCount;

            // Purchases only work on the active row
            bool onActiveRow = !viewing;
            bool outletAtMax = row.OutletCount >= row.MaxOutlets;
            bool canBuyOutlet = onActiveRow && !outletAtMax && _bloodManager.CanAfford(_shaftManager.GetOutletCost(row));
            if (_btnBuyOutlet != null) _btnBuyOutlet.SetEnabled(canBuyOutlet);
            if (_outletCost != null) _outletCost.text = outletAtMax ? "MAX" : "Cost: " + FormatNumber(_shaftManager.GetOutletCost(row));

            bool hasUnminioned = row.GetNextUnminionedOutlet() != null;
            bool canBuyMinion = onActiveRow && hasUnminioned && _bloodManager.CanAfford(_shaftManager.GetMinionCost(row));
            if (_btnBuyMinion != null) _btnBuyMinion.SetEnabled(canBuyMinion);
            if (_minionCost != null) _minionCost.text = !hasUnminioned ? "ALL STAFFED" : "Cost: " + FormatNumber(_shaftManager.GetMinionCost(row));

            bool canDescend = _shaftManager.CanDescend;
            if (_btnDescend != null) _btnDescend.SetEnabled(canDescend);
            if (_descendStatus != null) _descendStatus.text = canDescend ? "Ready!" : "Build row first";

            Gatherer.GathererManager gm = _shaftManager.GathererMgr;
            if (gm != null)
            {
                bool speedAtMax = gm.SpeedTier >= 5;
                bool canBuySpeed = !speedAtMax && _bloodManager.CanAfford(_shaftManager.GetGathererSpeedCost());
                if (_btnGathererSpeed != null) _btnGathererSpeed.SetEnabled(canBuySpeed);
                if (_gathererSpeedLabel != null) _gathererSpeedLabel.text = speedAtMax ? "Speed MAX" : "Speed Lv" + gm.SpeedTier;
                if (_gathererSpeedCost != null) _gathererSpeedCost.text = speedAtMax ? "MAX" : "Cost: " + FormatNumber(_shaftManager.GetGathererSpeedCost());

                bool canBuyCount = _shaftManager.CanBuyGatherer && _bloodManager.CanAfford(_shaftManager.GetGathererCountCost());
                if (_btnGathererCount != null) _btnGathererCount.SetEnabled(canBuyCount);
                if (_gathererCountLabel != null) _gathererCountLabel.text = "Gatherers: " + gm.Count + (gm.Count >= 10 ? " MAX" : "");
                if (_gathererCountCost != null)
                {
                    if (gm.Count >= 10) _gathererCountCost.text = "MAX";
                    else if (_shaftManager.GathererSlotsAvailable <= 0) _gathererCountCost.text = "New row needed";
                    else _gathererCountCost.text = "Cost: " + FormatNumber(_shaftManager.GetGathererCountCost());
                }
            }
        }

        private void OnBuyOutlet() { if (_shaftManager != null) _shaftManager.TryBuyOutlet(); }
        private void OnBuyMinion() { if (_shaftManager != null) _shaftManager.TryBuyMinion(); }
        private void OnDescend() { if (_shaftManager != null) _shaftManager.Descend(); }
        private void OnBuyGathererSpeed() { if (_shaftManager != null) _shaftManager.TryBuyGathererSpeed(); }
        private void OnBuyGathererCount() { if (_shaftManager != null) _shaftManager.TryBuyGathererCount(); }

        private string FormatNumber(double value)
        {
            if (value >= 1000000) return (value / 1000000).ToString("F1") + "M";
            if (value >= 1000) return (value / 1000).ToString("F1") + "K";
            return ((int)value).ToString();
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BM.Shaft
{
    public sealed class Row : MonoBehaviour
    {
        [SerializeField] private int _rowIndex;
        [SerializeField] private List<RowOutlet> _outlets = new List<RowOutlet>();
        [SerializeField] private List<RowWorker> _workers = new List<RowWorker>();
        [FormerlySerializedAs("_bloodBar")]
        [SerializeField] private LeftoversGauge _leftoversGauge;
        [SerializeField] private ToolUpgradeController _toolUpgrade;

        public int RowIndex => _rowIndex;
        public int OutletCount => _outlets.Count;
        public bool IsFullyBuilt => _outlets.Count >= 4 && _workers.Count >= 4;
        public LeftoversGauge LeftoversGauge => _leftoversGauge;
        public ToolUpgradeController ToolUpgrade => _toolUpgrade;

        public RowOutlet GetOutlet(int index)
        {
            if (index < 0 || index >= _outlets.Count) return null;
            return _outlets[index];
        }

        public void OnChop(float amount)
        {
            if (_leftoversGauge != null) _leftoversGauge.Add(amount);
        }
    }
}

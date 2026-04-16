using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace BM.Shaft
{
    public sealed class ToolUpgradeController : MonoBehaviour
    {
        [FormerlySerializedAs("_bloodBar")]
        [SerializeField] private LeftoversGauge _leftoversGauge;
        [SerializeField] private int _toolTier;

        public UnityEvent OnReady = new UnityEvent();
        public UnityEvent<int> OnTierChanged = new UnityEvent<int>();

        public int ToolTier => _toolTier;
        public bool IsReady => _leftoversGauge != null && _leftoversGauge.IsFull;

        private void Awake()
        {
            if (_leftoversGauge != null) _leftoversGauge.OnFilled.AddListener(HandleGaugeFilled);
        }

        private void OnDestroy()
        {
            if (_leftoversGauge != null) _leftoversGauge.OnFilled.RemoveListener(HandleGaugeFilled);
        }

        private void HandleGaugeFilled()
        {
            if (OnReady != null) OnReady.Invoke();
        }

        [SerializeField] private float _baseCapacity = 100f;
        [SerializeField] private float _capacityGrowth = 1.5f;

        public void TryUpgrade()
        {
            if (!IsReady) return;
            _toolTier++;
            _leftoversGauge.Empty();
            // Each tier makes the gauge harder to fill
            float newCapacity = _baseCapacity * Mathf.Pow(_capacityGrowth, _toolTier);
            _leftoversGauge.SetCapacity(newCapacity);
            if (OnTierChanged != null) OnTierChanged.Invoke(_toolTier);
        }
    }
}

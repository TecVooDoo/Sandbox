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

        public UnityEvent OnReady;
        public UnityEvent<int> OnTierChanged;

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

        public void TryUpgrade()
        {
            if (!IsReady) return;
            _toolTier++;
            _leftoversGauge.Empty();
            if (OnTierChanged != null) OnTierChanged.Invoke(_toolTier);
        }
    }
}

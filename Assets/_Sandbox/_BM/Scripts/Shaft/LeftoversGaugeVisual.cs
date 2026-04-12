using UnityEngine;
using UnityEngine.Serialization;

namespace BM.Shaft
{
    [RequireComponent(typeof(LeftoversGauge))]
    public sealed class LeftoversGaugeVisual : MonoBehaviour
    {
        [FormerlySerializedAs("_bloodBar")]
        [SerializeField] private LeftoversGauge _leftoversGauge;
        [SerializeField] private Transform _fill;
        [SerializeField] private float _fullWidth = 6f;
        [SerializeField] private float _fillHeight = 0.25f;
        [SerializeField] private float _fillDepth = 2f;
        [SerializeField] private float _yOffset = 0.15f;

        private void Reset()
        {
            _leftoversGauge = GetComponent<LeftoversGauge>();
        }

        private void LateUpdate()
        {
            if (_leftoversGauge == null || _fill == null) return;
            float n = Mathf.Clamp01(_leftoversGauge.Normalized);
            float w = n * _fullWidth;
            _fill.localScale = new Vector3(w, _fillHeight, _fillDepth);
            _fill.localPosition = new Vector3((w - _fullWidth) * 0.5f, _yOffset, 0f);
        }
    }
}

using UnityEngine;
using SM.Core;

namespace SM.Harvest
{
    public sealed class ComboSystem : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float _comboTimeout = 1.5f;
        [SerializeField] private float _multiplierPerTap = 0.1f;
        [SerializeField] private float _maxMultiplier = 5f;

        [Header("Events")]
        [SerializeField] private IntGameEvent _onComboChanged;

        private int _comboCount;
        private float _timeSinceLastTap;

        public int ComboCount => _comboCount;
        public float CurrentMultiplier => Mathf.Min(1f + _comboCount * _multiplierPerTap, _maxMultiplier);

        private void Update()
        {
            if (_comboCount <= 0) return;

            _timeSinceLastTap += Time.deltaTime;
            if (_timeSinceLastTap >= _comboTimeout)
            {
                ResetCombo();
            }
        }

        public float RegisterTap()
        {
            _comboCount++;
            _timeSinceLastTap = 0f;

            if (_onComboChanged != null)
                _onComboChanged.Raise(_comboCount);

            return CurrentMultiplier;
        }

        private void ResetCombo()
        {
            _comboCount = 0;

            if (_onComboChanged != null)
                _onComboChanged.Raise(0);
        }
    }
}

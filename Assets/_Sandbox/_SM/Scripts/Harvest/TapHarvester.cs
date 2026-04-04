using UnityEngine;
using UnityEngine.InputSystem;
using SM.Core;
using SM.Mine;

namespace SM.Harvest
{
    public sealed class TapHarvester : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float _baseTapPower = 1f;
        [SerializeField] private LayerMask _bodyLayer;

        [Header("References")]
        [SerializeField] private SoulManager _soulManager;
        [SerializeField] private ComboSystem _comboSystem;
        [SerializeField] private Camera _camera;

        [Header("Events")]
        [SerializeField] private DoubleGameEvent _onSoulHarvested;
        [SerializeField] private GameEvent _onTapPerformed;

        private float _tapPowerMultiplier = 1f;

        public float TapPowerMultiplier
        {
            get => _tapPowerMultiplier;
            set => _tapPowerMultiplier = Mathf.Max(0f, value);
        }

        private void Awake()
        {
            if (_camera == null)
                _camera = Camera.main;
        }

        private void Update()
        {
            bool tapped = false;

            // Touch input (mobile)
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                tapped = TryHarvestAt(touchPos);
            }
            // Mouse fallback (editor)
            else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                tapped = TryHarvestAt(mousePos);
            }

            if (tapped && _onTapPerformed != null)
            {
                _onTapPerformed.Raise();
            }
        }

        private bool TryHarvestAt(Vector2 screenPosition)
        {
            if (_camera == null) return false;

            Ray ray = _camera.ScreenPointToRay(screenPosition);

            if (!Physics.Raycast(ray, out RaycastHit hit, 100f, _bodyLayer))
                return false;

            BodyPile bodyPile = hit.collider.GetComponentInParent<BodyPile>();
            if (bodyPile == null) return false;

            BodyConfigSO harvestedBody = bodyPile.TryHarvest(hit.point);
            if (harvestedBody == null) return false;

            float comboMultiplier = _comboSystem != null ? _comboSystem.RegisterTap() : 1f;
            double soulValue = harvestedBody.BaseSoulValue * _baseTapPower * _tapPowerMultiplier * comboMultiplier;

            _soulManager.AddSouls(soulValue);

            if (_onSoulHarvested != null)
                _onSoulHarvested.Raise(soulValue);

            return true;
        }
    }
}

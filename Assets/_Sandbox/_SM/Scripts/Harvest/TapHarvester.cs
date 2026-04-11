using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using SM.Core;
using SM.Mine;
using SM.VFX;

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
        [SerializeField] private NumberPop _numberPop;
        [SerializeField] private UIDocument _uiDocument;

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

            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                if (!IsOverUI(touchPos))
                    tapped = TryHarvestAt(touchPos);
            }
            else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                if (!IsOverUI(mousePos))
                    tapped = TryHarvestAt(mousePos);
            }

            if (tapped && _onTapPerformed != null)
            {
                _onTapPerformed.Raise();
            }
        }

        private bool IsOverUI(Vector2 screenPosition)
        {
            if (_uiDocument == null || _uiDocument.rootVisualElement == null) return false;

            // UI Toolkit panel is Y-down; Input System screen is Y-up. Flip.
            Vector2 panelPos = new Vector2(screenPosition.x, Screen.height - screenPosition.y);
            VisualElement picked = _uiDocument.rootVisualElement.panel.Pick(panelPos);
            // Pick() respects pickingMode, so any non-null result means the click is on pickable UI.
            return picked != null;
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

            // Get mine level yield multiplier if available
            float levelMultiplier = 1f;
            MineLevel mineLevel = bodyPile.GetComponentInParent<MineLevel>();
            if (mineLevel != null)
                levelMultiplier = mineLevel.SoulYieldMultiplier;

            float comboMultiplier = _comboSystem != null ? _comboSystem.RegisterTap() : 1f;
            double soulValue = harvestedBody.BaseSoulValue * _baseTapPower * _tapPowerMultiplier * levelMultiplier * comboMultiplier;

            _soulManager.AddSouls(soulValue);

            if (_numberPop != null)
                _numberPop.Show(hit.point, soulValue, comboMultiplier >= 2f);

            if (_onSoulHarvested != null)
                _onSoulHarvested.Raise(soulValue);

            return true;
        }
    }
}
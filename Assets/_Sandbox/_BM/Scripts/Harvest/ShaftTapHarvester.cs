using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using BM.Shaft;

namespace BM.Harvest
{
    public sealed class ShaftTapHarvester : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private LayerMask _bodyLayer;

        [Header("References")]
        [FormerlySerializedAs("_reaper")]
        [SerializeField] private Ghoul _ghoul;
        [SerializeField] private Camera _camera;
        [SerializeField] private UIDocument _uiDocument;

        private void Awake()
        {
            if (_camera == null) _camera = Camera.main;
        }

        private void Update()
        {
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                if (!IsOverUI(touchPos)) TryChopAt(touchPos);
                return;
            }

            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                if (!IsOverUI(mousePos)) TryChopAt(mousePos);
            }
        }

        private bool IsOverUI(Vector2 screenPosition)
        {
            if (_uiDocument == null || _uiDocument.rootVisualElement == null) return false;
            Vector2 panelPos = new Vector2(screenPosition.x, Screen.height - screenPosition.y);
            VisualElement picked = _uiDocument.rootVisualElement.panel.Pick(panelPos);
            return picked != null;
        }

        private bool TryChopAt(Vector2 screenPosition)
        {
            if (_camera == null || _ghoul == null) return false;

            Ray ray = _camera.ScreenPointToRay(screenPosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, 100f, _bodyLayer)) return false;

            _ghoul.Chop();

            ClickableBody clickable = hit.collider.GetComponentInParent<ClickableBody>();
            if (clickable != null && clickable.Owner != null)
            {
                clickable.Owner.ConsumeBody();
            }
            return true;
        }
    }
}

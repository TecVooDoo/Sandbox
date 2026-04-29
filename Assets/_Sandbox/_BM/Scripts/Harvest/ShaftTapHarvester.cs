using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using BM.Shaft;

namespace BM.Harvest
{
    /// <summary>
    /// Routes player click/tap (and keyboard "swing" key) to <see cref="Ghoul.Swing"/>.
    /// Movement is driven directly by <see cref="Ghoul"/> reading A/D from the keyboard.
    /// Click position is forwarded so the ghoul turns to face whichever side the player clicked.
    /// </summary>
    public sealed class ShaftTapHarvester : MonoBehaviour
    {
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
            if (_ghoul == null) return;

            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                if (!IsOverUI(touchPos)) _ghoul.SwingAt(touchPos, _camera);
                return;
            }

            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                if (!IsOverUI(mousePos)) _ghoul.SwingAt(mousePos, _camera);
            }

            // Space-bar swing for desktop testing -- no click position, swings in current facing.
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _ghoul.Swing();
            }
        }

        private bool IsOverUI(Vector2 screenPosition)
        {
            if (_uiDocument == null || _uiDocument.rootVisualElement == null) return false;
            Vector2 panelPos = new Vector2(screenPosition.x, Screen.height - screenPosition.y);
            VisualElement picked = _uiDocument.rootVisualElement.panel.Pick(panelPos);
            return picked != null;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

namespace AQS.Player
{
    /// <summary>
    /// Wires Input System actions to QuokkaController.
    /// Attach to the same GameObject as QuokkaController.
    /// Assign the AQS_InputActions asset in the PlayerInput component.
    /// </summary>
    [RequireComponent(typeof(QuokkaController))]
    [RequireComponent(typeof(PlayerInput))]
    public class QuokkaInputHandler : MonoBehaviour
    {
        private QuokkaController controller;

        private void Awake()
        {
            controller = GetComponent<QuokkaController>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            controller.OnMove(context);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            controller.OnJump(context);
        }
    }
}

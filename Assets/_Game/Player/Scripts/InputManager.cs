using UnityEngine;

namespace _Game.Player.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private PlayerControls playerControls;
        private Vector2 movementInput;

        public float verticalMovementInput;
        public float horizontalMovementInput;

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        public void HandleAllInputs()
        {
            HandleMovementInput();
        }

        private void HandleMovementInput()
        {
            verticalMovementInput = movementInput.y;
            horizontalMovementInput = movementInput.x;
        }
    }
}
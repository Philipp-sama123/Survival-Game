using UnityEngine;

namespace _Game.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private PlayerControls playerControls;
        private Vector2 movementInput;
        private AnimatorManager animatorManager;
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

        private void Awake()
        {
            animatorManager = GetComponent<AnimatorManager>();
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
            // use just for no weapon (!) 
            float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalMovementInput) + Mathf.Abs(verticalMovementInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount);
        }
    }
}
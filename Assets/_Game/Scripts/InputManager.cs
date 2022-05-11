using UnityEngine;

namespace _Game.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private PlayerControls playerControls;
        private AnimatorManager animatorManager;

        private Vector2 movementInput;
        private Vector2 cameraInput;

        public float verticalMovementInput;
        public float horizontalMovementInput;

        public float verticalCameraInput;
        public float horizontalCameraInput;

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
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
            HandleCameraInput();
        }

        private void HandleCameraInput()
        {
            horizontalCameraInput = cameraInput.x;
            verticalCameraInput = cameraInput.y;
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
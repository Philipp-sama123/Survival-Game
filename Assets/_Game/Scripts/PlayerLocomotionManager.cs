using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerLocomotionManager : MonoBehaviour
    {
        private InputManager inputManager;
        private Rigidbody playerRigidbody;
        private Transform cameraObject;

        private Vector3 moveDirection;

        [SerializeField] private float movementSpeed = 7;
        [SerializeField] private float rotationSpeed = 15;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerRigidbody = GetComponent<Rigidbody>();
            if (Camera.main != null) cameraObject = Camera.main.transform;
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            moveDirection = new Vector3(inputManager.horizontalMovementInput, 0,
                inputManager.verticalMovementInput);

            moveDirection *= movementSpeed;

            Vector3 movementVelocity = moveDirection;
            playerRigidbody.velocity = movementVelocity;
        }

        private void HandleRotation()
        {
            Vector3 targetDirection = Vector3.zero;
            targetDirection = cameraObject.forward * inputManager.verticalMovementInput;
            targetDirection += cameraObject.right * inputManager.horizontalMovementInput;
            targetDirection.Normalize();
            targetDirection.y = 0;
            if (targetDirection == Vector3.zero)
            {
                targetDirection = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation =
                Quaternion.SlerpUnclamped(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // transform.rotation = playerRotation;
        }
    }
}
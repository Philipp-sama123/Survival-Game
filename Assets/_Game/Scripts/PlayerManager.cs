using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager inputManager;
        private PlayerLocomotionManager playerLocomotionManager;
        private CameraManager cameraManager;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            cameraManager = FindObjectOfType<CameraManager>();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        private void Update()
        {
            inputManager.HandleAllInputs();
        }

        private void FixedUpdate()
        {
            playerLocomotionManager.HandleAllMovement();
        }

        private void LateUpdate()
        {
            // cameraManager.HandleAllCameraMovement(); 
        }
    }
}
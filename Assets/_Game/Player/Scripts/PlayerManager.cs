using UnityEngine;

namespace _Game.Player.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager inputManager;
        private PlayerLocomotionManager playerLocomotionManager;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
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
    }
}
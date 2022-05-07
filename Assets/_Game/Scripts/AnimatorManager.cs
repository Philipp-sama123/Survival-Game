using UnityEngine;

namespace _Game.Scripts
{
    public class AnimatorManager : MonoBehaviour
    {
        private Animator animator;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
        {
            float snappedHorizontal;
            float snappedVertical;

            #region SnappedHorizontal

            if (horizontalMovement > -0.25f && horizontalMovement < 0.25f)
            {
                snappedHorizontal = 0;
            }
            else if (horizontalMovement > 0.25f && horizontalMovement < 0.75f)
            {
                snappedHorizontal = 0.5f;
            }
            else if (horizontalMovement > 0.75f)
            {
                snappedHorizontal = 1;
            }
            else if (horizontalMovement < -0.25 && horizontalMovement > -0.75f)
            {
                snappedHorizontal = -0.5f;
            }
            else if (horizontalMovement < -0.75f)
            {
                snappedHorizontal = -1;
            }
            else
            {
                snappedHorizontal = 0;
            }

            #endregion

            #region SnappedVertical

            if (verticalMovement > -0.25f && verticalMovement < 0.25f)
            {
                snappedVertical = 0;
            }
            else if (verticalMovement > 0.25f && verticalMovement < 0.75f)
            {
                snappedVertical = 0.5f;
            }
            else if (verticalMovement > 0.75f)
            {
                snappedVertical = 1;
            }
            else if (verticalMovement < -0.25 && verticalMovement > -0.75f)
            {
                snappedVertical = -0.5f;
            }
            else if (verticalMovement < -0.75f)
            {
                snappedVertical = -1;
            }
            else
            {
                snappedVertical = 0;
            }

            #endregion


            animator.SetFloat(Horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
            animator.SetFloat(Vertical, snappedVertical, 0.1f, Time.deltaTime);
        }
    }
}
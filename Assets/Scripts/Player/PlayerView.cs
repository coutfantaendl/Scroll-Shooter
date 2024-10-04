using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int IsDead = Animator.StringToHash("isDead");

        public void UpdateMovementAnimation(float moveInput)
        {
            bool isMoving = Mathf.Abs(moveInput) > 0.01f;
            _animator.SetBool(IsRunning, isMoving);
        }

        public void UpdateJumpingAnimation(bool isGrounded)
        {
            _animator.SetBool(IsJumping, !isGrounded);
        }

        public void PlayDeadAnimation()
        {
            _animator.SetTrigger(IsDead);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsIdle = Animator.StringToHash("IsIdle");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    public void EnemyIdle(bool state) => _animator.SetBool(IsIdle, state);
    
    public void EnemyWalking(bool state) => _animator.SetBool(IsWalking, state);
    
    public void EnemyAttack() => _animator.SetTrigger(IsAttacking);

    public void EnemyDead() => _animator.SetTrigger(IsDead);
}

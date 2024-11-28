using UnityEngine;

public class MeleeEnemy : EnemyBase, IAttack
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _damage;

    protected override void EnterAttackState()
    {
        view.EnemyAttack();

        StopMoving();
    }

    public void Attack()
    {
        Collider2D playerHit = Physics2D.OverlapCircle
            (transform.position,
            _attackRadius,
            playerLayer);

        if (playerHit == null)
            return;

        playerHit.GetComponent<IDamageable>()?.TakeDamage(_damage);
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}

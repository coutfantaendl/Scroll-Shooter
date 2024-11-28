using Assets.Scripts.Weapon;
using UnityEngine;

public class RangedEnemy : EnemyBase, IAttack
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate;

    private float _fireCooldown;

    protected override void EnterAttackState()
    {
        StopMoving();
        LookAtPlayer();
        view.EnemyAttack();
    }

    public void Attack()
    {
        var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        var directionToPlayer = (player.position - _firePoint.position).normalized;
        bullet.GetComponent<Bullet>().Initialize(directionToPlayer);

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        var direction = player.position - transform.position;
        var scale = transform.localScale;

        if (direction.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z); 
        else
            transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
    }
}

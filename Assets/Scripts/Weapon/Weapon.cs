using Assets.Scripts.Weapon;
using UnityEngine;

public class Weapon : MonoBehaviour, IShootable
{
    [Header("Weapon Settings")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    //[SerializeField] private int _maxAmmo;
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _hitLayer;

    private PhysicsRay _physicsRay;

    private void Awake()
    {
        _physicsRay = new PhysicsRay(_rayDistance, _hitLayer);
    }

    public void Shoot(Vector2 direction)
    {
        RaycastHit2D hit = _physicsRay.CastRay(_firePoint.position,direction);
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(direction);
    }
}

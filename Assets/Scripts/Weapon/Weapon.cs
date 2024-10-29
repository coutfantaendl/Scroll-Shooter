using Assets.Scripts.Weapon;
using UnityEngine;

public class Weapon : MonoBehaviour, IShootable
{
    [Header("Weapon Settings")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    public void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(direction);
    }
}

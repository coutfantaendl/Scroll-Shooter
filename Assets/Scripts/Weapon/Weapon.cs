using Assets.Scripts.Weapon;
using System;
using UnityEngine;

public class Weapon : MonoBehaviour, IShootable
{
    [Header("Weapon Settings")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _maxAmmo;

    private IAmmo _ammo;

    public event Action<int> OnAmmoChanged;

    private void Awake()
    {
        _ammo = new Ammo(_maxAmmo);
        NotifyAmmoChanged();
    }

    public void Shoot(Vector2 direction)
    {
        if (_ammo.HasAmmo())
        {
            var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            bullet.Initialize(direction);

            _ammo.UseAmmo();
            NotifyAmmoChanged();
        }
        else
        {
            Debug.Log("No ammo");
        }
    }

    public void AddAmmo(int amount)
    {
        _ammo.AddAmmo(amount, _maxAmmo);
        NotifyAmmoChanged();
    }

    private void NotifyAmmoChanged()
    {
        OnAmmoChanged?.Invoke(_ammo.CurrentAmmo);
    }
}

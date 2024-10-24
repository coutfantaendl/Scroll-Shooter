using UnityEngine;

public class Weapon : MonoBehaviour, IShootable
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _shootForce;

    public void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * _shootForce, ForceMode2D.Impulse);
    }
}

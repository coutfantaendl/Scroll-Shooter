using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shootRange;

    [SerializeField] private LayerMask _hitLayers;
    [SerializeField] private Transform _firePoint;

    public void Shoot(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(_firePoint.position, direction, _shootRange, _hitLayers);
    }

    public void SetFirePointPosition(Vector2 direction)
    {
        _firePoint.localPosition = new Vector3(Mathf.Abs(_firePoint.localPosition.x) * direction.x, _firePoint.localPosition.y, 0f);
    }
}

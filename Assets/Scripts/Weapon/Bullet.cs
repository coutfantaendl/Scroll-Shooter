using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}

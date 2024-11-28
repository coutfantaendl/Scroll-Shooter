using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;

        private Vector2 _direction;
        private Rigidbody2D _rb;

        public void Initialize(Vector2 direction)
        {
            _direction = direction.normalized;
            _rb = GetComponent<Rigidbody2D>();
            _rb.AddForce(direction * _speed, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print(collision.gameObject.name);
            if(collision.TryGetComponent(out Health health))
            {
                print(collision.gameObject.name);
                health.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}

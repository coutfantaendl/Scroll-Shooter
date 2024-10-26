using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;

        private Vector2 _direction;

        public void Initialize(Vector2 direction)
        {
            _direction = direction.normalized;
        }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

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

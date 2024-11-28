using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyView _view;

    private void Awake()
    {
        _health.Die += OnDie;
    }

    private void OnDie()
    {
        _view.EnemyDead();
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

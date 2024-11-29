using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyView _view;
    [SerializeField] private ScoreDataConfig _scoreDataConfig;
    [SerializeField] private int _scoreReward;

    private void Awake()
    {
        _health.Die += OnDie;
    }

    private void OnDie()
    {
        _view.EnemyDead();
        _scoreDataConfig.AddScore(_scoreReward);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

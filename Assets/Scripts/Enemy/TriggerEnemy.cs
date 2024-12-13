using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBase enemy))
        {
            enemy.EnterIdleState();
            enemy.ChangeDirection();
        }
    }   
}

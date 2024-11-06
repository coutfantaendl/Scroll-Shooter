using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private float _healingAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Health health))
        {
            health.Heal(_healingAmount);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class FixedDamageDealer : MonoBehaviour, IDamageDealer
{
    [Header("Damage Settings")]
    [SerializeField, Range(1, 35)] private float _fixedDamage;

    public void ApplyDamage(Health health)
    {
        health.TakeDamage(_fixedDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        if(!collision.TryGetComponent(out Health health))
            return;
        ApplyDamage(health);
    }
}

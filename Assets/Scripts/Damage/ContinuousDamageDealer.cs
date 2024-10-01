using UnityEngine;

public class ContinuousDamageDealer : MonoBehaviour, IDamageDealer
{
    [Header("Damage Settings")]
    [SerializeField, Range(1, 15)] private float _continuousDamageRate;

    private bool _isPlayerIntrigger = false;

    private Health _health;
    private PlayerController _playerController;

    public void ApplyDamage(Health health)
    {
        _health.TakeDamage(_continuousDamageRate * Time.deltaTime);
    }

    private void Update()
    {
        if (!_isPlayerIntrigger)
            return;
        ApplyDamage(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        if (!collision.TryGetComponent(out Health health))
            return;

        _health = health;
        _playerController = collision.GetComponent<PlayerController>();

        _isPlayerIntrigger = true;
        _playerController.Speed = 1f;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        _isPlayerIntrigger = false;
        _playerController.Speed = 2f;
        _health = null;
    }
}

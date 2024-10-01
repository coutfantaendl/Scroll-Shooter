using UnityEngine;

public class ContinuousDamageDealer : MonoBehaviour, IDamageDealer
{
    [Header("Damage Settings")]
    [SerializeField, Range(1, 15)] private float _continuousDamageRate;

    private bool _isPlayerIntrigger = false;

    private PlayerHealth _playerHealth;
    private PlayerController _playerController;

    public void ApplyDamage(PlayerHealth playerHealth)
    {
        if(playerHealth != null)
        {
            _playerHealth.TakeDamage(_continuousDamageRate * Time.deltaTime);
        }
    }

    private void Update()
    {
        if(_isPlayerIntrigger)
        {
            ApplyDamage(_playerHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _playerHealth = collision.GetComponent<PlayerHealth>();
            _playerController = collision.GetComponent<PlayerController>();

            _isPlayerIntrigger = true;
            _playerController.Speed = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _isPlayerIntrigger = false;
            _playerController.Speed = 2f;
        }
    }
}

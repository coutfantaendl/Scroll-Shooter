using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private PlayerController _playerController;

    public event Action<float> HealthChanged;
    public event Action Die;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>(); 
        InitializeHealth();
    }

    private void InitializeHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if(_currentHealth <= 0 )
        {
            Die?.Invoke();
        }
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
    }     
}

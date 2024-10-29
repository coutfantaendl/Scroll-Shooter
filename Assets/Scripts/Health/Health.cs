using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Health Settings")]
    [SerializeField] private float _maxHealth;

    [SerializeField] private float _currentHealth;

    public event Action<float> HealthChanged;
    public event Action Die;

    private void Awake()
    {
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

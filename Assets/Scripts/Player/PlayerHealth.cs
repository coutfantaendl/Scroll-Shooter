using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float _maxHealth;

    [Header("UI Settings")]
    [SerializeField] private Image _healthBar;


    private float _currentHealth;
    private PlayerController _playerController;

    public event Action<float> HealthChanged;

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
        UpdateHealthBar();

        if(_currentHealth <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// ///////////////////// перенести ui в отдельный класс
    /// </summary>
    private void UpdateHealthBar()
    {
        if(_healthBar != null )
        {
            _healthBar.fillAmount = _currentHealth / _maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("Player Die");
    }
}

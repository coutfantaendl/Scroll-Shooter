using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health.HealthChanged += UpdateHealthBar;
    }
    private void UpdateHealthBar(float health)
    {
        _healthBar.fillAmount = health;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    private void UpdateHealthBar(float currentHealth, float maxHeatlth)
    {
        _healthBar.fillAmount = currentHealth / maxHeatlth;
    }
}

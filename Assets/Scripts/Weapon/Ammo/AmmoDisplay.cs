using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;

    private Weapon _weapon;

    private void Awake()
    {
        _weapon = FindObjectOfType<Weapon>();

        if (_weapon == null )
            return;

        _weapon.OnAmmoChanged += UpdateAmmoDisplay;
    }

    private void OnDestroy()
    {
        if(_weapon == null)
            return;

        _weapon.OnAmmoChanged -= UpdateAmmoDisplay;
    }

    private void UpdateAmmoDisplay(int currentAmmo)
    {
        _ammoText.text = currentAmmo.ToString();
    }
}

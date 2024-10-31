using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Weapon weapon))
        {
            weapon.AddAmmo(_ammoAmount);
            Destroy(gameObject);
        }
    }
}

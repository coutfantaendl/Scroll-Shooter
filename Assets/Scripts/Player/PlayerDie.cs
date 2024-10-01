using UnityEngine;
namespace Assets.Scripts.Player
{
    public class PlayerDie : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void Awake()
        {
            _health.Die += OnDie;
        }

        private void OnDie()
        {
            Debug.Log("PlayerDie");
        }
    }
}

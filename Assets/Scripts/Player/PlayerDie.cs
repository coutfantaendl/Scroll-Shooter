using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerDie : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private PlayerView _playerView;

        private void Awake()
        {
            _health.Die += OnDie;
        }

        private void OnDie()
        {
            _playerView.PlayDeadAnimation();
        }
    }
}

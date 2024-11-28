using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void SceneLose(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

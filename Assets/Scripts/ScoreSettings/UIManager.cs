using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ScoreDataConfig _scoreDataConfig;

    private void OnEnable()
    {
        _scoreDataConfig.OnScoreUpdate.AddListener(UpdateScore);
        UpdateScore(_scoreDataConfig.CurrentScore);
    }

    private void OnDisable()
    {
        _scoreDataConfig.OnScoreUpdate.RemoveListener(UpdateScore);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}

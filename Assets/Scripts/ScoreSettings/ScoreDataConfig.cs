using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "ScoreData", menuName = "Game/ScoreData")]
public class ScoreDataConfig : ScriptableObject
{
    public UnityEvent<int> OnScoreUpdate = new UnityEvent<int>();

    private int _currentScore;

    public int CurrentScore => _currentScore;

    public void AddScore(int points)
    {
        _currentScore += points;
        OnScoreUpdate.Invoke(_currentScore);
    }

    public void ResetScore()
    {
        _currentScore = 0;
        OnScoreUpdate.Invoke(_currentScore);
    }
}

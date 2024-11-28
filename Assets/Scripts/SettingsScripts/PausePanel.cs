using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        _pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void ResumGame()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }
}

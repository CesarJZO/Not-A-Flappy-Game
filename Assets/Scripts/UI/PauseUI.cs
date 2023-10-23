using UnityEngine;

public sealed class PauseUI : MonoBehaviour, IToggleable
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        PauseManager.OnPause += OnGamePaused;
        PauseManager.OnResume += OnGameResumed;
        Hide();
    }

    private void OnGamePaused()
    {
        Show();
    }

    private void OnGameResumed()
    {
        Hide();
    }
}

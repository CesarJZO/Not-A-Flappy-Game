using Management;
using UnityEngine;
using UnityEngine.UI;

public sealed class PauseUI : MonoBehaviour, IToggleable
{
    [SerializeField] private PauseManager pauseManager;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(() => pauseManager.Resume());
        exitButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));

        PauseManager.OnPause += OnGamePaused;
        PauseManager.OnResume += OnGameResumed;
        Hide();
    }

    private void OnDestroy()
    {
        PauseManager.OnPause -= OnGamePaused;
        PauseManager.OnResume -= OnGameResumed;
    }

    private void OnGamePaused()
    {
        Show();
    }

    private void OnGameResumed()
    {
        Hide();
    }

        public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

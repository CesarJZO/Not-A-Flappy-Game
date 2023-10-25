using System;
using UnityEngine;

public sealed class PauseManager : MonoBehaviour
{
    public static event Action OnPause;
    public static event Action OnResume;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        InputManager.Instance.OnPausePerformed += OnPausePerformed;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        _gameManager.CurrentState = GameState.Paused;
        Time.timeScale = 0f;
        OnPause?.Invoke();
    }

    public void Resume()
    {
        _gameManager.CurrentState = GameState.Playing;
        Time.timeScale = 1f;
        OnResume?.Invoke();
    }

    private void OnPausePerformed()
    {
        if (_gameManager.CurrentState is GameState.GameOver)
            return;

        if (_gameManager.CurrentState is GameState.Playing)
            Pause();
        else if (_gameManager.CurrentState is GameState.Paused)
            Resume();
    }
}

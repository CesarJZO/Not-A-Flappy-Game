using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public event Action OnPause;
    public event Action OnResume;

    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = GameManager.Instance;
        InputManager.Instance.OnPausePerformed += OnPausePerformed;
    }

    private void OnPausePerformed()
    {
        if (_gameManager.CurrentState is GameState.Playing)
        {
            _gameManager.CurrentState = GameState.Paused;
            Time.timeScale = 0f;
            OnPause?.Invoke();
        }
        else if (_gameManager.CurrentState is GameState.Paused)
        {
            _gameManager.CurrentState = GameState.Playing;
            Time.timeScale = 1f;
            OnResume?.Invoke();
        }
    }
}

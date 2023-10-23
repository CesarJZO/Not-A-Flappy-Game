using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<GameState> OnStateChanged;

    [SerializeField] private GameState currentState;

    public GameState CurrentState
    {
        get => currentState;
        set
        {
            currentState = value;
            OnStateChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentState = GameState.Playing;
    }

    private void Update()
    {
        switch(currentState)
        {
            case GameState.Playing:
                PlayingUpdate();
                break;
            case GameState.Paused:
                PausedUpdate();
                break;
            case GameState.GameOver:
                GameOverUpdate();
                break;
            default: break;
        }
    }

    private void PlayingUpdate()
    {
        
    }

    private void PausedUpdate()
    {

    }

    private void GameOverUpdate()
    {
        
    }
}

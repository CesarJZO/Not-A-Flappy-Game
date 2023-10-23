using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Management;

public class GameOverUI : MonoBehaviour, IToggleable
{
    [SerializeField] private BirdController player;

    [Header("Buttons")]
    [SerializeField] private Button replayButton;
    [SerializeField] private Button exitButton;

    // Start se llama si al iniciar la escena el objeto está activado
    private void Start()
    {
        replayButton.onClick.AddListener(() => {
            // SceneManager.LoadScene(SceneManager.CurrentSceneIndex);
            SceneManager.ReloadCurrentScene();
        });
        exitButton.onClick.AddListener(() => {
            // SceneManager.LoadScene(GameScene.MainMenu);
            SceneManager.LoadScene(0);
        });

        // player.OnDie += Show;
        player.OnDie += OnBirdDie;
        Hide();
    }

    private void OnDestroy()
    {
        // player.OnDie -= Show;
        player.OnDie -= OnBirdDie;
    }

    private void OnBirdDie()
    {
        // No recomendado, pasar a un GameOverManager
        GameManager.Instance.CurrentState = GameState.GameOver;
        Show();
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

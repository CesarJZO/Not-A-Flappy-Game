using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private string gameSceneName;

    private void Start()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene(gameSceneName));
        exitButton.onClick.AddListener(() => Application.Quit());
        // OnPlay += OnPlayPerformed;
        // playButton.onClick.AddListener(OnPlayPerformed);
        // OnPlay += () => { SceneManager.LoadScene(gameSceneName); };
    }
}

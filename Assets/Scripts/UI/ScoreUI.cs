using TMPro;
using UnityEngine;

public sealed class ScoreUI : MonoBehaviour
{
    [SerializeField] private GameObject scoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void OnPipePassed()
    {
        ScoreManager m = scoreManager.GetComponent<ScoreManager>();
        ulong score = m.Score;
        scoreText.text = score.ToString();
    }

    private void Start()
    {
        ScoreTrigger.OnPipePassed += OnPipePassed;
    }

    private void OnDestroy()
    {
        ScoreTrigger.OnPipePassed -= OnPipePassed;
    }
}

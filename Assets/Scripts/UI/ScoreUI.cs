using TMPro;
using UnityEngine;

public sealed class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void OnScoreUpdated(ulong currentScore)
    {
        scoreText.text = currentScore.ToString();
    }

    private void Start()
    {
        scoreManager.OnScoreUpdated += OnScoreUpdated;
    }

    private void OnDestroy()
    {
        scoreManager.OnScoreUpdated -= OnScoreUpdated;
    }
}

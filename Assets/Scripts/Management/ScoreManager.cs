using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private ulong score;
    public ulong Score => score;

    private void Start()
    {
        ScoreTrigger.OnPipePassed += OnPipePassed;
    }

    private void OnDestroy()
    {
        ScoreTrigger.OnPipePassed -= OnPipePassed;
    }

    private void OnPipePassed()
    {
        score++;
        Debug.Log($"Score: {score}");
        // Debug.Log("Score: " + score);
    }
}

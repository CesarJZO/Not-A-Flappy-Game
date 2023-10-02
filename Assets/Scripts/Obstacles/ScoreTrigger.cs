using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class ScoreTrigger : MonoBehaviour
{
    public static event Action OnPipePassed;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player")) return;
        
        OnPipePassed?.Invoke();

        // if (collider.CompareTag("Player"))
        // {
        //     OnPipePassed?.Invoke();
        // }
    }
}

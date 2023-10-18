using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public event Action OnPausePerformed;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // Pause button
        if (Input.GetKeyDown(KeyCode.Escape))
        {       
            OnPausePerformed?.Invoke();
        }
    }
}

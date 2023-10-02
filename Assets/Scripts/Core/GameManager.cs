using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnStart;

    private bool _started;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false) return;

        if (_started == true) return;

        _started = true;

        OnStart?.Invoke();
    }
}

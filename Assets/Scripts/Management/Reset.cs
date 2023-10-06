using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Reset : MonoBehaviour
{
    private void Update()
    {
        if (!Player.BirdController.Instance.Death)
            return;

        if (Input.touchCount is 0) return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase is TouchPhase.Began)
            ResetScene();
    }

    private static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

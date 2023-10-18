using UnityEngine;

namespace Management
{
    public static class SceneManager
    {
        public static int CurrentSceneIndex => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        public static void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        public static void LoadScene(int buildIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
        }

        /// <summary>
        ///     Carga la escena actual, pero tiene que estar configurada en Build Settings
        /// </summary>
        public static void ReloadCurrentScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(CurrentSceneIndex);
        }
    }
}

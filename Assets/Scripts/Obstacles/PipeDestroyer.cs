using UnityEngine;

namespace Obstacles
{
    public class PipeDestroyer : MonoBehaviour
    {
        /// <summary>
        ///     When any object exits this collider,
        ///     this function is triggered
        /// </summary>
        /// <param name="other">The collider that exited
        /// this object</param>
        private void OnTriggerExit2D(Collider2D other)
        {
            // Se destruye cualquier objeto
            Destroy(other.gameObject);
        }
    }
}

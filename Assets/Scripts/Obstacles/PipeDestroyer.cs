using UnityEngine;

namespace Obstacles
{
    public class PipeDestroyer : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}

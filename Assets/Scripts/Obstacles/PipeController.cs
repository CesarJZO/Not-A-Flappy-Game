using UnityEngine;

namespace Obstacles
{
    public sealed class PipeController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 direction;

        private void Update()
        {
            // transform.position = transform.position - new Vector3(speed, 0) * Time.deltaTime;
            // transform.position -= new Vector3(speed, 0) * Time.deltaTime;

            transform.Translate(direction * (speed * Time.deltaTime));
        }
    }
}

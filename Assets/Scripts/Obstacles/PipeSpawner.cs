using UnityEngine;

namespace Obstacles
{
    public sealed class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipesPrefab;
        [SerializeField] private float spawnRate;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnPipe), 0f, spawnRate);
        }

        private void SpawnPipe()
        {
            Instantiate(pipesPrefab, transform.position, Quaternion.identity);
        }
    }
}

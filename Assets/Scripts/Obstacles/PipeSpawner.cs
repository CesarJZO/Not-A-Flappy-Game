using UnityEngine;

namespace Obstacles
{
    public sealed class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipesPrefab;
        [SerializeField] private float spawnRate;
        [SerializeField] private float height;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnPipe), 0f, spawnRate);
        }

        private void SpawnPipe()
        {
            float heightOffset = Random.Range(-height, height);

            Instantiate(pipesPrefab, transform.position + Vector3.up * heightOffset, Quaternion.identity);
        }
    }
}

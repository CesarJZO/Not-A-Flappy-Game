using Player;
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
            BirdController.Instance.OnDie += OnPlayerDie;
        }

        private void OnPlayerDie()
        {
            CancelInvoke(nameof(SpawnPipe));
        }

        private void SpawnPipe()
        {
            float heightOffset = Random.Range(-height, height);

            Instantiate(
                original: pipesPrefab,
                position: transform.position + Vector3.up * heightOffset,
                rotation: Quaternion.identity
            );
        }
    }
}

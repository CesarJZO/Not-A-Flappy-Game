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
            // Mi punto de referencia
            float center = transform.position.y;
            // Obtengo un numero aleatorio con el desplazamiento
            float yRandom = Random.Range(center - height, center + height);
            // Genero mi vector de posicion
            Vector3 position = new Vector3(transform.position.x, yRandom);

            // Instancio en esa posicion
            Instantiate(pipesPrefab, position, Quaternion.identity);
        }
    }
}

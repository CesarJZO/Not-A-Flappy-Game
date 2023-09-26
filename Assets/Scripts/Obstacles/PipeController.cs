using System;
using UnityEngine;

namespace Obstacles
{
    public sealed class PipeController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 direction;
        [SerializeField] private float lifeTime;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            // transform.position = transform.position - new Vector3(speed, 0) * Time.deltaTime;
            // transform.position -= new Vector3(speed, 0) * Time.deltaTime;

            // Si el player esta muerto, no te muevas

            transform.Translate(direction * (speed * Time.deltaTime));
        }
    }
}

using UnityEngine;

namespace Player
{
    public sealed class BirdController : MonoBehaviour
    {
        [SerializeField] private float jumpStrength;
        [SerializeField] private float dieStrength;

        private Rigidbody2D _rigidbody2D;
        private bool _death = false;

        public bool Death => _death;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // if (!_death)
            // {
            //     if (Input.GetMouseButtonDown(0))
            //     {
            //         Jump();
            //     }
            // }

            if (_death) return;

            if (!Input.GetMouseButtonDown(0)) return;

            Jump();
        }

        private void Jump()
        {
            _rigidbody2D.velocity = Vector2.up * jumpStrength;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_death) return;

            // float x = 0;
            //
            // if (Random.value > 0.5f)
            //     x = 1f;
            // else
            //     x = -1f;

            float x = Random.value > 0.5f ? 1f : -1f;

            _rigidbody2D.AddForce(new Vector2(x, 1f) * dieStrength, ForceMode2D.Impulse);

            _death = true;
        }
    }
}

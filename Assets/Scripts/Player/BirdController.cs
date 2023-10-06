using System;
using UnityEngine;

namespace Player
{
    public sealed class BirdController : MonoBehaviour
    {
        public static BirdController Instance { get; private set; }

        /// <summary>
        ///     Invoked once when bird collided with anything
        /// </summary>
        public event Action OnDie;

        [SerializeField] private float jumpStrength;
        [SerializeField] private float dieStrength;
        [SerializeField] private LayerMask playableLayer;

        private Rigidbody2D _rigidbody2D;
        private bool _death = false;

        public bool Death => _death;

        // Awake es SIEMPRE el primero que se llama, una sola vez.
        private void Awake()
        {
            Instance = this;
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

        private bool IsInsidePlayableZone => Physics2D.OverlapCircle(
            point: transform.position,
            radius: transform.localScale.magnitude / 2f,
            layerMask: playableLayer
        );

        private void Jump()
        {
            if (!IsInsidePlayableZone) return;

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

            float x = UnityEngine.Random.value > 0.5f ? 1f : -1f;

            _rigidbody2D.AddForce(new Vector2(x, 1f) * dieStrength, ForceMode2D.Impulse);

            _death = true;
            
            // if (OnDie is not null)
            //     OnDie.Invoke();

            // if (OnDie is null) return;
            // OnDie.Invoke();

            OnDie?.Invoke();
        }
    }
}

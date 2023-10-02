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

        private Rigidbody2D _rigidbody2D;
        private bool _death = false;

        public bool Death => _death;

        // Awake es SIEMPRE el primero que se llama, una sola vez.
        private void Awake()
        {
            Instance = this;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        private void Start()
        {
            GameManager.OnStart += OnGameStart;
        }

        private void OnDestroy()
        {
            GameManager.OnStart -= OnGameStart;
        }

        private void OnGameStart()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
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

            if (!Input.GetKeyDown(KeyCode.Space)) return;

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

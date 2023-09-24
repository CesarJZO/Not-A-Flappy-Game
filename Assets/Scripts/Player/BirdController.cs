using UnityEngine;

namespace Player
{
    public sealed class BirdController : MonoBehaviour
    {
        [SerializeField] private float jumpStrength;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Jump();
        }

        private void Jump()
        {
            _rigidbody2D.velocity = Vector2.up * jumpStrength;
        }
    }
}

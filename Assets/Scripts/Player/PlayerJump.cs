using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kronos.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 500;
        [SerializeField] private Rigidbody2D _rigidbody;

        private bool _canJump = true;

        private void Update()
        {
            Jump();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                _rigidbody.AddForce(transform.up * _jumpForce);
                _canJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider is TilemapCollider2D)
            {
                _canJump = true;
            }
        }
    }
}

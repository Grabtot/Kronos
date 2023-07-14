using Kronos.State;
using Kronos.State.Player;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kronos.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 2;
        [SerializeField] private float _jumpForce = 2;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        private StateMachine _stateMachine;

        private PlayerDirection _direction = PlayerDirection.Left;
        private PlayerIdleState _idleState;
        private bool _canJump = true;

        private void Start()
        {
            _idleState = new(_animator);
            _stateMachine = new(_idleState);
        }

        private void Update()
        {
            Walk();
            Jump();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider is TilemapCollider2D)
            {
                _canJump = true;
            }
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                _rigidbody.AddForce(transform.up * _jumpForce);
                _canJump = false;
            }
        }

        private void Walk()
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput > 0 && _direction == PlayerDirection.Left)
            {
                Flip(PlayerDirection.Right);
            }
            else if (horizontalInput < 0 && _direction == PlayerDirection.Right)
            {
                Flip(PlayerDirection.Left);
            }

            _rigidbody.velocity = new Vector2(horizontalInput * _movementSpeed, _rigidbody.velocity.y);

            if (Mathf.Abs(horizontalInput) > 0)
            {
                PlayerWalkState walkState = new(_animator);
                _stateMachine.ChangeState(walkState);
            }
            else
            {
                _stateMachine.ChangeState(_idleState);
            }
        }

        private void Flip(PlayerDirection direction)
        {
            _direction = direction;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public enum PlayerDirection
    {
        Left,
        Right
    }
}
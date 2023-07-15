using Cainos.PixelArtPlatformer_VillageProps;
using Kronos.State;
using Kronos.State.Player;
using UnityEngine;

namespace Kronos.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 2;
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

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Chest chest))
            {
                chest.Open();
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
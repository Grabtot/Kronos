using UnityEngine;

namespace Kronos.State.Player
{
    public class PlayerIdleState : IState
    {
        private Animator _animator;

        public PlayerIdleState(Animator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            _animator.SetBool("Idle", true);
            Debug.Log("Idle state entered");
        }

        public void Exit()
        {
            _animator.SetBool("Idle", false);
            Debug.Log("Idle state exited");
        }

        public void Stay()
        {
            throw new System.NotImplementedException();
        }
    }
}

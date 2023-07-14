using UnityEngine;

namespace Kronos.State.Player
{
    public class PlayerWalkState : IState
    {
        private Animator _animator;

        public PlayerWalkState(Animator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            _animator.SetBool("Walk", true);
            Debug.Log("Walk state entered");
        }

        public void Exit()
        {
            _animator.SetBool("Walk", false);
            Debug.Log("Walk state exited");
        }

        public void Stay()
        {
            throw new System.NotImplementedException();
        }
    }
}

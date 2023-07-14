namespace Kronos.State
{
    public class StateMachine
    {
        private IState _currantState;
        public IState CurrantState => _currantState;
        public StateMachine(IState initialState)
        {
            _currantState = initialState;
            _currantState.Enter();
        }

        public void ChangeState(IState newState)
        {
            _currantState.Exit();
            _currantState = newState;
            _currantState.Enter();
        }

    }
}

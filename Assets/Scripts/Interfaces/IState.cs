namespace Kronos.State
{
    public interface IState
    {
        void Enter();
        void Stay();
        void Exit();
    }
}

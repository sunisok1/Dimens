namespace Core.System
{
    public class StateMachine
    {
        private IState currentState;

        public void ChangeState(IState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }

    public interface IState
    {
        void Enter();
        void Exit();
    }
}
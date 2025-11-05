using System.Windows.Forms;

namespace Elevator_A1.States
{
    public class ElevatorContext
    {
        private IElevatorState _currentState;
        private readonly Form1 _form;

        public ElevatorContext(Form1 form)
        {
            _form = form;
            _currentState = new IdleState();
        }

        public IElevatorState CurrentState => _currentState;
        public Form1 Form => _form;

        public void SetState(IElevatorState newState)
        {
            _currentState?.OnExit(this);
            _currentState = newState;
            _currentState.OnEnter(this);
        }

        public void HandleMoveUp() => _currentState.HandleMoveUp(this);
        public void HandleMoveDown() => _currentState.HandleMoveDown(this);
        public void HandleOpenDoors() => _currentState.HandleOpenDoors(this);
        public void HandleCloseDoors() => _currentState.HandleCloseDoors(this);
        public void HandleTimerTick(string timerType) => _currentState.HandleTimerTick(this, timerType);
    }
}
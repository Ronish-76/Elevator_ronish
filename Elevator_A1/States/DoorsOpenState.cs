namespace Elevator_A1.States
{
    public class DoorsOpenState : IElevatorState
    {
        private readonly bool _autoClose;

        public DoorsOpenState(bool autoClose = false)
        {
            _autoClose = autoClose;
        }

        public string StateName => "Doors Open";

        public void HandleMoveUp(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new MovingUpState()));
        }

        public void HandleMoveDown(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new MovingDownState()));
        }

        public void HandleOpenDoors(ElevatorContext context) { }

        public void HandleCloseDoors(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new IdleState()));
        }

        public void HandleTimerTick(ElevatorContext context, string timerType)
        {
            if (timerType == "auto_close")
            {
                context.SetState(new DoorClosingState(new IdleState()));
            }
        }

        public void OnEnter(ElevatorContext context)
        {
            var form = context.Form;
            form.SetStateText("Doors Open");
            form.SetControlsEnabledPublic(true);

            if (_autoClose)
            {
                form.StartAutoCloseTimer();
            }
        }

        public void OnExit(ElevatorContext context)
        {
            context.Form.CancelAutoClose();
        }
    }
}
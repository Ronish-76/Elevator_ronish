namespace Elevator_A1.States
{
    public class IdleState : IElevatorState
    {
        public string StateName => "Idle";

        public void HandleMoveUp(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new MovingUpState()));
        }

        public void HandleMoveDown(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new MovingDownState()));
        }

        public void HandleOpenDoors(ElevatorContext context)
        {
            context.SetState(new DoorOpeningState());
        }

        public void HandleCloseDoors(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new IdleState()));
        }

        public void HandleTimerTick(ElevatorContext context, string timerType) { }

        public void OnEnter(ElevatorContext context)
        {
            context.Form.SetStateText("Idle");
            context.Form.SetControlsEnabledPublic(true);
        }

        public void OnExit(ElevatorContext context) { }
    }
}
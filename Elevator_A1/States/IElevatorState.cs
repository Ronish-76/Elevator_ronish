namespace Elevator_A1.States
{
    public interface IElevatorState
    {
        string StateName { get; }
        void HandleMoveUp(ElevatorContext context);
        void HandleMoveDown(ElevatorContext context);
        void HandleOpenDoors(ElevatorContext context);
        void HandleCloseDoors(ElevatorContext context);
        void HandleTimerTick(ElevatorContext context, string timerType);
        void OnEnter(ElevatorContext context);
        void OnExit(ElevatorContext context);
    }
}
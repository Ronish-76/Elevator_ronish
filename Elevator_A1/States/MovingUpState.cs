namespace Elevator_A1.States
{
    public class MovingUpState : IElevatorState
    {
        public string StateName => "Moving Up";

        public void HandleMoveUp(ElevatorContext context) { }
        public void HandleMoveDown(ElevatorContext context) { }
        public void HandleOpenDoors(ElevatorContext context) { }
        public void HandleCloseDoors(ElevatorContext context) { }

        public void HandleTimerTick(ElevatorContext context, string timerType)
        {
            if (timerType == "up")
            {
                var form = context.Form;
                if (form.PictureElevator.Top > form.ElevatorTopFirst)
                {
                    form.PictureElevator.Top -= 1;
                }
                else
                {
                    form.TimerUp.Stop();
                    form.PictureElevator.Top = form.ElevatorTopFirst;
                    form.AddActionLogPublic("Arrived: First Floor");
                    context.SetState(new DoorOpeningState(true));
                }
                form.UpdateDisplayPublic();
            }
        }

        public void OnEnter(ElevatorContext context)
        {
            context.Form.SetStateText("Moving Up");
            context.Form.SetControlsEnabledPublic(false);
            context.Form.TimerUp.Start();
        }

        public void OnExit(ElevatorContext context) { }
    }
}
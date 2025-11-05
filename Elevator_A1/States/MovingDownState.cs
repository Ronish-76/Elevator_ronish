namespace Elevator_A1.States
{
    public class MovingDownState : IElevatorState
    {
        public string StateName => "Moving Down";

        public void HandleMoveUp(ElevatorContext context) { }
        public void HandleMoveDown(ElevatorContext context) { }
        public void HandleOpenDoors(ElevatorContext context) { }
        public void HandleCloseDoors(ElevatorContext context) { }

        public void HandleTimerTick(ElevatorContext context, string timerType)
        {
            if (timerType == "down")
            {
                var form = context.Form;
                if (form.PictureElevator.Top < form.ElevatorTopGround)
                {
                    form.PictureElevator.Top += 1;
                }
                else
                {
                    form.TimerDown.Stop();
                    form.PictureElevator.Top = form.ElevatorTopGround;
                    form.AddActionLogPublic("Arrived: Ground Floor");
                    context.SetState(new DoorOpeningState(true));
                }
                form.UpdateDisplayPublic();
            }
        }

        public void OnEnter(ElevatorContext context)
        {
            context.Form.SetStateText("Moving Down");
            context.Form.SetControlsEnabledPublic(false);
            context.Form.TimerDown.Start();
        }

        public void OnExit(ElevatorContext context) { }
    }
}
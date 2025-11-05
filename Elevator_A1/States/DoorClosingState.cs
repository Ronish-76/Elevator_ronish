namespace Elevator_A1.States
{
    public class DoorClosingState : IElevatorState
    {
        private readonly IElevatorState _nextState;

        public DoorClosingState(IElevatorState nextState)
        {
            _nextState = nextState;
        }

        public string StateName => "Door Closing";

        public void HandleMoveUp(ElevatorContext context) { }
        public void HandleMoveDown(ElevatorContext context) { }
        public void HandleOpenDoors(ElevatorContext context)
        {
            context.SetState(new DoorOpeningState());
        }
        public void HandleCloseDoors(ElevatorContext context) { }

        public void HandleTimerTick(ElevatorContext context, string timerType)
        {
            var form = context.Form;
            bool finished = false;

            if (timerType == "door_close_up")
            {
                finished = HandleDoorCloseAnimation(form.DoorLeftUp, form.DoorRightUp, 
                    form.leftUpClosed, form.rightUpClosed, form);
                if (finished) form.TimerDoorCloseUp.Stop();
            }
            else if (timerType == "door_close_down")
            {
                finished = HandleDoorCloseAnimation(form.DoorLeftDown, form.DoorRightDown, 
                    form.leftDownClosed, form.rightDownClosed, form);
                if (finished) form.TimerDoorCloseDown.Stop();
            }

            if (finished)
            {
                form.AddActionLogPublic("Doors Closed");
                context.SetState(_nextState);
            }
            form.UpdateDisplayPublic();
        }

        private bool HandleDoorCloseAnimation(System.Windows.Forms.PictureBox leftDoor, 
            System.Windows.Forms.PictureBox rightDoor, int leftClosed, int rightClosed, Form1 form)
        {
            int nextLeft = System.Math.Min(leftDoor.Left + 1, leftClosed);
            int nextRight = System.Math.Max(rightDoor.Left - 1, rightClosed);

            if (nextLeft + leftDoor.Width + Form1.MinDoorGap >= nextRight)
            {
                leftDoor.Left = leftClosed;
                rightDoor.Left = rightClosed;
                return true;
            }

            bool moved = false;
            if (leftDoor.Left < leftClosed)
            {
                leftDoor.Left = nextLeft;
                moved = true;
            }
            if (rightDoor.Left > rightClosed)
            {
                rightDoor.Left = nextRight;
                moved = true;
            }

            return !moved;
        }

        public void OnEnter(ElevatorContext context)
        {
            var form = context.Form;
            form.SetStateText("Door Closing");
            form.SetControlsEnabledPublic(false);
            form.CancelAutoClose();

            form.TimerDoorOpenUp.Stop();
            form.TimerDoorOpenDown.Stop();

            if (form.CurrentFloor == Form1.Floor.First)
            {
                form.TimerDoorCloseUp.Start();
            }
            else
            {
                form.TimerDoorCloseDown.Start();
            }
        }

        public void OnExit(ElevatorContext context) { }
    }
}
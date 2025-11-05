namespace Elevator_A1.States
{
    public class DoorOpeningState : IElevatorState
    {
        private readonly bool _autoClose;

        public DoorOpeningState(bool autoClose = false)
        {
            _autoClose = autoClose;
        }

        public string StateName => "Door Opening";

        public void HandleMoveUp(ElevatorContext context) { }
        public void HandleMoveDown(ElevatorContext context) { }
        public void HandleOpenDoors(ElevatorContext context) { }
        public void HandleCloseDoors(ElevatorContext context)
        {
            context.SetState(new DoorClosingState(new IdleState()));
        }

        public void HandleTimerTick(ElevatorContext context, string timerType)
        {
            var form = context.Form;
            bool moved = false;

            if (timerType == "door_open_up")
            {
                if (form.DoorLeftUp.Left > form.leftUpOpenTarget)
                {
                    form.DoorLeftUp.Left = System.Math.Max(form.DoorLeftUp.Left - 1, form.leftUpOpenTarget);
                    moved = true;
                }
                if (form.DoorRightUp.Left < form.rightUpOpenTarget)
                {
                    form.DoorRightUp.Left = System.Math.Min(form.DoorRightUp.Left + 1, form.rightUpOpenTarget);
                    moved = true;
                }
                if (!moved)
                {
                    form.TimerDoorOpenUp.Stop();
                    form.AddActionLogPublic("Doors Opened");
                    context.SetState(new DoorsOpenState(_autoClose));
                }
            }
            else if (timerType == "door_open_down")
            {
                if (form.DoorLeftDown.Left > form.leftDownOpenTarget)
                {
                    form.DoorLeftDown.Left = System.Math.Max(form.DoorLeftDown.Left - 1, form.leftDownOpenTarget);
                    moved = true;
                }
                if (form.DoorRightDown.Left < form.rightDownOpenTarget)
                {
                    form.DoorRightDown.Left = System.Math.Min(form.DoorRightDown.Left + 1, form.rightDownOpenTarget);
                    moved = true;
                }
                if (!moved)
                {
                    form.TimerDoorOpenDown.Stop();
                    form.AddActionLogPublic("Doors Opened");
                    context.SetState(new DoorsOpenState(_autoClose));
                }
            }
            form.UpdateDisplayPublic();
        }

        public void OnEnter(ElevatorContext context)
        {
            var form = context.Form;
            form.SetStateText("Door Opening");
            form.SetControlsEnabledPublic(false);
            form.CancelAutoClose();

            if (form.CurrentFloor == Form1.Floor.First)
            {
                form.TimerDoorOpenUp.Start();
            }
            else
            {
                form.TimerDoorOpenDown.Start();
            }
        }

        public void OnExit(ElevatorContext context) { }
    }
}
using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        private void Timer_door_open_up_Tick(object? sender, EventArgs e)
        {
            _elevatorContext.HandleTimerTick("door_open_up");
        }

        private void Timer_door_open_down_Tick(object? sender, EventArgs e)
        {
            _elevatorContext.HandleTimerTick("door_open_down");
        }

        private void Timer_door_close_up_Tick(object? sender, EventArgs e)
        {
            _elevatorContext.HandleTimerTick("door_close_up");
        }

        private void Timer_door_close_down_Tick(object? sender, EventArgs e)
        {
            _elevatorContext.HandleTimerTick("door_close_down");
        }
    }
}
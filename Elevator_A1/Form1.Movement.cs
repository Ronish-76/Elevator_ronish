using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        private void Timer_up_Tick(object? sender, EventArgs e)
        {
            _elevatorContext.HandleTimerTick("up");
        }

        private void Timer_down_Tick(object? sender, EventArgs e)
        {
            _elevatorContext.HandleTimerTick("down");
        }
    }
}
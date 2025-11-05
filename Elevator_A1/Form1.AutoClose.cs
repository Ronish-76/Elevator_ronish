using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        // Auto-close timer tick: start closing doors for the last opened floor
        private void AutoCloseTimer_Tick(object? sender, EventArgs e)
        {
            _autoCloseTimer.Stop();
            _elevatorContext.HandleTimerTick("auto_close");
        }
    }
}
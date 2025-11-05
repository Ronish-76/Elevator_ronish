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

            if (!_autoCloseRequested || _lastOpenedFloor == null)
            {
                _autoCloseRequested = false;
                _lastOpenedFloor = null;
                return;
            }

            // Start closing the doors for the floor that was opened automatically
            if (_lastOpenedFloor == Floor.First)
            {
                SetControlsEnabled(false);
                timer_door_close_up.Start();
                SetState("Auto-closing");
            }
            else
            {
                SetControlsEnabled(false);
                timer_door_close_down.Start();
                SetState("Auto-closing");
            }

            _autoCloseRequested = false;
            _lastOpenedFloor = null;
        }
    }
}
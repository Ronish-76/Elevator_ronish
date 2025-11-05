using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        // Enable/disable UI buttons while actions run.
        // Keep btnExit enabled so user can still close app while action runs.
        private void SetControlsEnabled(bool enabled)
        {
            // Buttons to disable/enable during actions
            btnGfloor.Enabled = enabled;
            btn1Floor.Enabled = enabled;
            btnUp.Enabled = enabled;
            btnDown.Enabled = enabled;
            btnOpen.Enabled = enabled;
            btnClose.Enabled = enabled;
            btnDeleteLogs.Enabled = enabled;

            // Leave btnExit enabled always to allow closing the app
            btnExit.Enabled = true;
        }

        // Cancel any scheduled auto-close
        private void CancelAutoClose()
        {
            _autoCloseRequested = false;
            _lastOpenedFloor = null;
            if (_autoCloseTimer.Enabled) _autoCloseTimer.Stop();
        }
    }
}
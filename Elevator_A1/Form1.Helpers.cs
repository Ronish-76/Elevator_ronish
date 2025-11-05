using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {


        // Cancel any scheduled auto-close
        public void CancelAutoClose()
        {
            _autoCloseRequested = false;
            _lastOpenedFloor = null;
            if (_autoCloseTimer.Enabled) _autoCloseTimer.Stop();
        }
    }
}
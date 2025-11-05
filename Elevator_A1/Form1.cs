using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        private enum Floor { Ground, First }

        // Pixel bounds (defaults) — will be overridden at Form1_Load using door positions
        private int _elevatorTopFirst =82;
        private int _elevatorTopGround =431;

        // Tunable door parameters
        private const int DoorOpenOffset =60; // how many pixels each door moves outward when opening (tune this)
        private const int MinDoorGap =2; // minimum gap (in px) between doors to avoid overlap

        // Auto-close interval (ms)
        private const int AutoCloseInterval =5000; //5 seconds

        // Closed positions captured at runtime
        private int leftUpClosed, rightUpClosed, leftDownClosed, rightDownClosed;
        // Computed open targets
        private int leftUpOpenTarget, rightUpOpenTarget, leftDownOpenTarget, rightDownOpenTarget;

        private string _stateText = "Idle";

        // Pending move: used to wait for doors to finish closing before starting motion
        private enum PendingAction { None, MoveUp, MoveDown }
        private PendingAction _pendingAction = PendingAction.None;

        // Auto-close timer and tracking
        private System.Windows.Forms.Timer _autoCloseTimer;
        private bool _autoCloseRequested = false;
        private Floor? _lastOpenedFloor = null;

        // Action log fields
        private int _nextLogId =1;

        public Form1()
        {
            InitializeComponent();

            // Wire up timers to handlers — handlers implemented in partial files
            timer_up.Tick += Timer_up_Tick;
            timer_down.Tick += Timer_down_Tick;
            timer_door_open_up.Tick += Timer_door_open_up_Tick;
            timer_door_open_down.Tick += Timer_door_open_down_Tick;
            timer_door_close_up.Tick += Timer_door_close_up_Tick;
            timer_door_close_down.Tick += Timer_door_close_down_Tick;

            // Create auto-close timer (not in Designer) and wire it
            _autoCloseTimer = new System.Windows.Forms.Timer();
            _autoCloseTimer.Interval = AutoCloseInterval;
            _autoCloseTimer.Tick += AutoCloseTimer_Tick;

            // initial display update (UpdateDisplay implemented in Form1.Display.cs)
            UpdateDisplay();
        }

        // NOTE: Implementation for behavior (event handlers, timers, display, logging, etc.)
        // has been moved into partial files named:
        // - Form1.Display.cs
        // - Form1.Helpers.cs
        // - Form1.Init.cs
        // - Form1.Controls.cs
        // - Form1.Movement.cs
        // - Form1.Doors.cs
        // - Form1.AutoClose.cs
        // Keep this file limited to shared fields and the constructor.
    }
}

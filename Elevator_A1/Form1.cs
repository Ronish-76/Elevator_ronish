using System;
using System.Windows.Forms;
using Elevator_A1.States;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        public enum Floor { Ground, First }

        // Pixel bounds (defaults) � will be overridden at Form1_Load using door positions
        private int _elevatorTopFirst =82;
        private int _elevatorTopGround =431;

        // Tunable door parameters
        private const int DoorOpenOffset =60; // how many pixels each door moves outward when opening (tune this)
        public const int MinDoorGap =2; // minimum gap (in px) between doors to avoid overlap

        // Auto-close interval (ms)
        private const int AutoCloseInterval =5000; //5 seconds

        // Closed positions captured at runtime
        public int leftUpClosed, rightUpClosed, leftDownClosed, rightDownClosed;
        // Computed open targets
        public int leftUpOpenTarget, rightUpOpenTarget, leftDownOpenTarget, rightDownOpenTarget;

        private string _stateText = "Idle";

        // State pattern context
        private ElevatorContext _elevatorContext;

        // Auto-close timer and tracking
        private System.Windows.Forms.Timer _autoCloseTimer;
        private bool _autoCloseRequested = false;
        private Floor? _lastOpenedFloor = null;

        // Action log fields
        private int _nextLogId =1;

        // Public properties for state classes
        public int ElevatorTopFirst => _elevatorTopFirst;
        public int ElevatorTopGround => _elevatorTopGround;
        public Floor CurrentFloor => (pictureElevator.Top >= (_elevatorTopGround + _elevatorTopFirst) / 2) ? Floor.Ground : Floor.First;
        
        // Public access to controls and timers
        public System.Windows.Forms.PictureBox PictureElevator => pictureElevator;
        public System.Windows.Forms.PictureBox DoorLeftUp => doorLeftup;
        public System.Windows.Forms.PictureBox DoorRightUp => doorRightup;
        public System.Windows.Forms.PictureBox DoorLeftDown => doorLeftdown;
        public System.Windows.Forms.PictureBox DoorRightDown => doorRightdown;
        public System.Windows.Forms.Timer TimerUp => timer_up;
        public System.Windows.Forms.Timer TimerDown => timer_down;
        public System.Windows.Forms.Timer TimerDoorOpenUp => timer_door_open_up;
        public System.Windows.Forms.Timer TimerDoorOpenDown => timer_door_open_down;
        public System.Windows.Forms.Timer TimerDoorCloseUp => timer_door_close_up;
        public System.Windows.Forms.Timer TimerDoorCloseDown => timer_door_close_down;
        
        // Public methods for state classes
        public void SetControlsEnabledPublic(bool enabled) => SetControlsEnabled(enabled);
        public void UpdateDisplayPublic() => UpdateDisplay();
        public void AddActionLogPublic(string message) => AddActionLog(message);

        public Form1()
        {
            InitializeComponent();

            // Initialize state pattern
            _elevatorContext = new ElevatorContext(this);

            // Wire up timers to handlers � handlers implemented in partial files
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

        // Public methods for state classes
        public void SetStateText(string state)
        {
            _stateText = state;
            UpdateDisplay();
        }

        public void StartAutoCloseTimer()
        {
            _autoCloseRequested = true;
            _lastOpenedFloor = CurrentFloor;
            if (_autoCloseTimer.Enabled) _autoCloseTimer.Stop();
            _autoCloseTimer.Start();
        }
        
        // Expose SetControlsEnabled publicly
        public void SetControlsEnabled(bool enabled)
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

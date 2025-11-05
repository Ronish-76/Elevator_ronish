using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        private void Timer_door_open_up_Tick(object? sender, EventArgs e)
        {
            bool moved = false;

            if (doorLeftup.Left > leftUpOpenTarget)
            {
                doorLeftup.Left = Math.Max(doorLeftup.Left - 1, leftUpOpenTarget);
                moved = true;
            }

            if (doorRightup.Left < rightUpOpenTarget)
            {
                doorRightup.Left = Math.Min(doorRightup.Left + 1, rightUpOpenTarget);
                moved = true;
            }

            if (!moved)
            {
                timer_door_open_up.Stop();
                SetState("Doors Open");

                // enable controls now that open is complete
                SetControlsEnabled(true);

                // Log action
                try { AddActionLog("Doors Opened"); } catch { }

                // If auto-close was requested for this open action, start the auto-close timer
                if (_autoCloseRequested && _lastOpenedFloor == Floor.First)
                {
                    if (_autoCloseTimer.Enabled) _autoCloseTimer.Stop();
                    _autoCloseTimer.Start();
                }
            }

            UpdateDisplay();
        }

        private void Timer_door_open_down_Tick(object? sender, EventArgs e)
        {
            bool moved = false;

            if (doorLeftdown.Left > leftDownOpenTarget)
            {
                doorLeftdown.Left = Math.Max(doorLeftdown.Left - 1, leftDownOpenTarget);
                moved = true;
            }

            if (doorRightdown.Left < rightDownOpenTarget)
            {
                doorRightdown.Left = Math.Min(doorRightdown.Left + 1, rightDownOpenTarget);
                moved = true;
            }

            if (!moved)
            {
                timer_door_open_down.Stop();
                SetState("Doors Open");

                // enable controls now that open is complete
                SetControlsEnabled(true);

                // Log action
                try { AddActionLog("Doors Opened"); } catch { }

                // If auto-close was requested for this open action, start the auto-close timer
                if (_autoCloseRequested && _lastOpenedFloor == Floor.Ground)
                {
                    if (_autoCloseTimer.Enabled) _autoCloseTimer.Stop();
                    _autoCloseTimer.Start();
                }
            }

            UpdateDisplay();
        }

        private void Timer_door_close_up_Tick(object? sender, EventArgs e)
        {
            int nextLeft = Math.Min(doorLeftup.Left + 1, leftUpClosed);
            int nextRight = Math.Max(doorRightup.Left - 1, rightUpClosed);

            if (nextLeft + doorLeftup.Width + MinDoorGap >= nextRight)
            {
                doorLeftup.Left = leftUpClosed;
                doorRightup.Left = rightUpClosed;
                timer_door_close_up.Stop();
                SetState("Doors Closed");

                // Log action
                try { AddActionLog("Doors Closed"); } catch { }

                if (_pendingAction != PendingAction.None)
                {
                    if (_pendingAction == PendingAction.MoveUp)
                    {
                        timer_up.Start();
                        SetControlsEnabled(false);
                        SetState("Moving Up");
                    }
                    else if (_pendingAction == PendingAction.MoveDown)
                    {
                        timer_down.Start();
                        SetControlsEnabled(false);
                        SetState("Moving Down");
                    }
                    _pendingAction = PendingAction.None;
                }
                else
                {
                    SetControlsEnabled(true);
                }
            }
            else
            {
                bool moved = false;
                if (doorLeftup.Left < leftUpClosed)
                {
                    doorLeftup.Left = nextLeft;
                    moved = true;
                }

                if (doorRightup.Left > rightUpClosed)
                {
                    doorRightup.Left = nextRight;
                    moved = true;
                }

                if (!moved)
                {
                    timer_door_close_up.Stop();
                    SetState("Doors Closed");

                    // Log action
                    try { AddActionLog("Doors Closed"); } catch { }

                    if (_pendingAction != PendingAction.None)
                    {
                        if (_pendingAction == PendingAction.MoveUp)
                        {
                            timer_up.Start();
                            SetControlsEnabled(false);
                            SetState("Moving Up");
                        }
                        else if (_pendingAction == PendingAction.MoveDown)
                        {
                            timer_down.Start();
                            SetControlsEnabled(false);
                            SetState("Moving Down");
                        }
                        _pendingAction = PendingAction.None;
                    }
                    else
                    {
                        SetControlsEnabled(true);
                    }
                }
            }

            UpdateDisplay();
        }

        private void Timer_door_close_down_Tick(object? sender, EventArgs e)
        {
            int nextLeft = Math.Min(doorLeftdown.Left + 1, leftDownClosed);
            int nextRight = Math.Max(doorRightdown.Left - 1, rightDownClosed);

            if (nextLeft + doorLeftdown.Width + MinDoorGap >= nextRight)
            {
                doorLeftdown.Left = leftDownClosed;
                doorRightdown.Left = rightDownClosed;
                timer_door_close_down.Stop();
                SetState("Doors Closed");

                // Log action
                try { AddActionLog("Doors Closed"); } catch { }

                if (_pendingAction != PendingAction.None)
                {
                    if (_pendingAction == PendingAction.MoveUp)
                    {
                        timer_up.Start();
                        SetControlsEnabled(false);
                        SetState("Moving Up");
                    }
                    else if (_pendingAction == PendingAction.MoveDown)
                    {
                        timer_down.Start();
                        SetControlsEnabled(false);
                        SetState("Moving Down");
                    }
                    _pendingAction = PendingAction.None;
                }
                else
                {
                    SetControlsEnabled(true);
                }
            }
            else
            {
                bool moved = false;
                if (doorLeftdown.Left < leftDownClosed)
                {
                    doorLeftdown.Left = nextLeft;
                    moved = true;
                }

                if (doorRightdown.Left > rightDownClosed)
                {
                    doorRightdown.Left = nextRight;
                    moved = true;
                }

                if (!moved)
                {
                    timer_door_close_down.Stop();
                    SetState("Doors Closed");

                    // Log action
                    try { AddActionLog("Doors Closed"); } catch { }

                    if (_pendingAction != PendingAction.None)
                    {
                        if (_pendingAction == PendingAction.MoveUp)
                        {
                            timer_up.Start();
                            SetControlsEnabled(false);
                            SetState("Moving Up");
                        }
                        else if (_pendingAction == PendingAction.MoveDown)
                        {
                            timer_down.Start();
                            SetControlsEnabled(false);
                            SetState("Moving Down");
                        }
                        _pendingAction = PendingAction.None;
                    }
                    else
                    {
                        SetControlsEnabled(true);
                    }
                }
            }

            UpdateDisplay();
        }
    }
}
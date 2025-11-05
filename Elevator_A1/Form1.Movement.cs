using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        // Helper: close doors at current floor when movement starts.
        // If pending != PendingAction.None the requested movement will begin automatically
        // after doors finish closing.
        private void StartClosingDoorsAtCurrentFloor(PendingAction pending = PendingAction.None)
        {
            // Cancel any opening action and auto-close request
            timer_door_open_up.Stop();
            timer_door_open_down.Stop();
            CancelAutoClose();

            // Register pending action (will be consumed when close finishes)
            _pendingAction = pending;

            // disable other UI controls while closing/moving
            SetControlsEnabled(false);

            if (CurrentFloor == Floor.First)
            {
                // close first-floor doors
                timer_door_close_up.Start();
            }
            else
            {
                // close ground-floor doors
                timer_door_close_down.Start();
            }
            SetState("Door Closing");
        }

        // Helper: open doors for target floor after arrival
        // startAutoClose: if true, schedule automatic close AutoCloseInterval ms after doors finish opening
        private void StartOpeningDoorsAtFloor(Floor floor, bool startAutoClose = false)
        {
            // Stop any closing action for that floor
            if (floor == Floor.First)
            {
                timer_door_close_up.Stop();
                timer_door_open_up.Start();
                SetState("Door Opening");
            }
            else
            {
                timer_door_close_down.Stop();
                timer_door_open_down.Start();
                SetState("Door Opening");
            }

            // Prepare auto-close request only if caller asked for it
            _autoCloseRequested = startAutoClose;
            _lastOpenedFloor = floor;

            // disable controls until doors finish opening (arrival sequence)
            SetControlsEnabled(false);
            // Do not start the auto-close timer here — start it only after doors fully open
        }

        private void Timer_up_Tick(object? sender, EventArgs e)
        {
            // Move elevator up: Top decreases until _elevatorTopFirst
            if (pictureElevator.Top > _elevatorTopFirst)
            {
                pictureElevator.Top -= 1;
                SetState("Moving Up");
            }
            else
            {
                timer_up.Stop();
                SetState("Idle");
                pictureElevator.Top = _elevatorTopFirst;

                // Log arrival
                try { AddActionLog("Arrived: First Floor"); } catch { }

                StartOpeningDoorsAtFloor(Floor.First, startAutoClose: true);
            }
            UpdateDisplay();
        }

        private void Timer_down_Tick(object? sender, EventArgs e)
        {
            // Move elevator down: Top increases until _elevatorTopGround
            if (pictureElevator.Top < _elevatorTopGround)
            {
                pictureElevator.Top += 1;
                SetState("Moving Down");
            }
            else
            {
                timer_down.Stop();
                SetState("Idle");
                pictureElevator.Top = _elevatorTopGround;

                // Log arrival
                try { AddActionLog("Arrived: Ground Floor"); } catch { }

                StartOpeningDoorsAtFloor(Floor.Ground, startAutoClose: true);
            }
            UpdateDisplay();
        }
    }
}
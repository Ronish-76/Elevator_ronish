using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            // Capture closed positions for doors (these come from Designer initial layout)
            leftUpClosed = doorLeftup.Left;
            rightUpClosed = doorRightup.Left;
            leftDownClosed = doorLeftdown.Left;
            rightDownClosed = doorRightdown.Left;

            // Compute open targets relative to closed positions (outward movement)
            leftUpOpenTarget = Math.Max(0, leftUpClosed - DoorOpenOffset);
            rightUpOpenTarget = rightUpClosed + DoorOpenOffset;
            leftDownOpenTarget = Math.Max(0, leftDownClosed - DoorOpenOffset);
            rightDownOpenTarget = rightDownClosed + DoorOpenOffset;

            // Derive elevator top positions from door positions so the car appears behind doors.
            _elevatorTopFirst = doorLeftup.Top;
            _elevatorTopGround = doorLeftdown.Top;

            // Place elevator at ground start behind doors
            pictureElevator.Top = _elevatorTopGround;

            // Align elevator horizontally to the center between the left and right doors (use down doors as baseline)
            var leftDoorCenter = doorLeftdown.Left + doorLeftdown.Width / 2;
            var rightDoorCenter = doorRightdown.Left + doorRightdown.Width / 2;
            var center = (leftDoorCenter + rightDoorCenter) / 2;
            pictureElevator.Left = Math.Max(0, center - pictureElevator.Width / 2);

            // Prepare action log grid and load persisted logs from database
            EnsureActionLogGrid();
            LoadLogsFromDatabase();

            SetStateText("Idle");
            // Ensure controls are enabled initially
            SetControlsEnabled(true);
        }
    }
}
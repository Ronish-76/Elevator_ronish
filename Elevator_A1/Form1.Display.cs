using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {


        private string GetDisplayText()
        {
            string floor = CurrentFloor == Floor.First ? "1st Floor" : "Ground Floor";

            // Map internal state strings to concise action phrases
            string action;
            if (_stateText.StartsWith("Moving Up", StringComparison.OrdinalIgnoreCase)) action = "Moving Up";
            else if (_stateText.StartsWith("Moving Down", StringComparison.OrdinalIgnoreCase)) action = "Moving Down";
            else if (_stateText.Contains("Doors Open", StringComparison.OrdinalIgnoreCase) || _stateText.Contains("Doors Open")) action = "Doors Open";
            else if (_stateText.Contains("Door Opening", StringComparison.OrdinalIgnoreCase) || _stateText.Contains("Opening")) action = "Opening";
            else if (_stateText.Contains("Door Closing", StringComparison.OrdinalIgnoreCase) || _stateText.Contains("Closing")) action = "Closing";
            else if (_stateText.Contains("Auto-closing", StringComparison.OrdinalIgnoreCase)) action = "Auto-closing";
            else if (_stateText.Contains("Idle", StringComparison.OrdinalIgnoreCase)) action = "Idle";
            else action = _stateText;

            return $"{floor} - {action}";
        }

        private void UpdateDisplay()
        {
            // Update label on form and form title
            try
            {
                if (lblFloorDisplay != null && !lblFloorDisplay.IsDisposed)
                {
                    lblFloorDisplay.Text = GetDisplayText();
                }
            }
            catch
            {
                // ignore update errors in designer/runtime scenarios
            }

            // keep form title informative as well
            this.Text = $"Elevator - {GetDisplayText()}";
        }


    }
}
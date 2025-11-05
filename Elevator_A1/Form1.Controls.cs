using System;
using System.Windows.Forms;

namespace Elevator_A1
{
    public partial class Form1 : Form
    {
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn1Floor_Click(object sender, EventArgs e)
        {
            // Log call to First Floor
            try { AddActionLog("Called: First Floor"); } catch { }

            // Close doors first, then move up when closed
            StartClosingDoorsAtCurrentFloor(PendingAction.MoveUp);
        }

        private void btnGfloor_Click(object sender, EventArgs e)
        {
            // Log call to Ground Floor
            try { AddActionLog("Called: Ground Floor"); } catch { }

            // Close doors first, then move down when closed
            StartClosingDoorsAtCurrentFloor(PendingAction.MoveDown);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // Log manual up request
            try { AddActionLog("Called Up"); } catch { }

            // Manual Up request: close doors then start moving up when closed
            StartClosingDoorsAtCurrentFloor(PendingAction.MoveUp);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // Log manual down request
            try { AddActionLog("Called Down"); } catch { }

            // Manual Down request: close doors then start moving down when closed
            StartClosingDoorsAtCurrentFloor(PendingAction.MoveDown);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Explicit user open: stop any scheduled auto-close (user action cancels)
            CancelAutoClose();

            // Open doors on current floor (do not schedule auto-close here)
            if (CurrentFloor == Floor.First)
            {
                // disable controls while opening
                SetControlsEnabled(false);
                timer_door_open_up.Start();
                SetState("Door Opening (First)");
            }
            else
            {
                SetControlsEnabled(false);
                timer_door_open_down.Start();
                SetState("Door Opening (Ground)");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // User explicit close: cancel auto-close scheduling and start closing now
            CancelAutoClose();

            timer_door_open_up.Stop();
            timer_door_open_down.Stop();

            // disable controls while closing
            SetControlsEnabled(false);

            if (CurrentFloor == Floor.First)
            {
                timer_door_close_up.Start();
                SetState("Door Closing (First)");
            }
            else
            {
                timer_door_close_down.Start();
                SetState("Door Closing");
            }
        }

        private void BtnDeleteLogs_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Delete all logs from database and UI? This cannot be undone.", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                try
                {
                    // Delete from database
                    using var conn = new MySqlConnector.MySqlConnection(_mySqlConn);
                    conn.Open();
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM elevator_logs;";
                    var affected = cmd.ExecuteNonQuery();

                    // Reset AUTO_INCREMENT if present (best-effort)
                    try
                    {
                        cmd.CommandText = "ALTER TABLE elevator_logs AUTO_INCREMENT =1;";
                        cmd.ExecuteNonQuery();
                    }
                    catch { /* ignore if not supported */ }

                    // Clear UI grid and reset next id
                    dataGridView1.Rows.Clear();
                    _nextLogId =1;

                    MessageBox.Show($"Deleted {affected} rows from database and cleared UI.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { /* no-op */ }
        private void pictureBox3_Click(object sender, EventArgs e) { /* no-op */ }
        private void label2_Click(object sender, EventArgs e) { /* no-op */ }
    }
}
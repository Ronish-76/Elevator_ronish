using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector; 

namespace Elevator_A1
{
 public partial class Form1 : Form
 {
 // Database connection settings (set your password/user as needed)
 private string _dbUser = "root";
 private string _dbPassword = "ronish"; 
 private string _dbName = "elevator_db";
 private string _dbHost = "localhost";
 private int _dbPort =3306;

 // Managed MySQL connection string (used by MySqlConnector)
 private string _mySqlConn =>
 $"Server={_dbHost};Port={_dbPort};Database={_dbName};User ID={_dbUser};Password={_dbPassword};SslMode=None;";

 // Ensure DataGridView columns exist and are configured
 private void EnsureActionLogGrid()
 {
 if (dataGridView1.Columns.Count ==0)
 {
 dataGridView1.Columns.Add("Id", "Id");
 dataGridView1.Columns.Add("DATE", "DATE");
 dataGridView1.Columns.Add("TIME", "TIME");
 dataGridView1.Columns.Add("ACTIONS", "ACTIONS");
 dataGridView1.Columns.Add("FLOOR", "FLOOR");

 // set read-only and sizing
 foreach (DataGridViewColumn c in dataGridView1.Columns)
 {
 c.ReadOnly = true;
 c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
 }

 dataGridView1.AllowUserToAddRows = false;
 dataGridView1.RowHeadersVisible = false;
 }
 }

 // Add a row to the action log (in-memory) and persist to DB
 private void AddActionLog(string action)
 {
 try
 {
 EnsureActionLogGrid();
 var now = DateTime.Now;
 string date = now.ToString("yyyy-MM-dd");
 //12-hour time with AM/PM
 string time = now.ToString("hh:mm:ss tt");
 string floor = CurrentFloor == Floor.First ? "First Floor" : "Ground Floor";

 // Persist to database first (so UI reflects real saved state)
 var saved = SaveLogToDatabase(now, action, floor);

 if (saved)
 {
 // Insert at top so latest entries are visible first
 dataGridView1.Rows.Insert(0, _nextLogId++, date, time, action, floor);
 }
 else
 {
 // show unsaved entry so you can see failures and diagnose
 dataGridView1.Rows.Insert(0, "?", date, time, action + " [UNSAVED]", floor);
 }
 }
 catch (Exception ex)
 {
 // avoid throwing from UI update
 System.Diagnostics.Debug.WriteLine("AddActionLog error: " + ex);
 }
 }

 // Save a log entry into MySQL using MySqlConnector. Returns true on success.
 private bool SaveLogToDatabase(DateTime timestamp, string action, string floor)
 {
 try
 {
 using var conn = new MySqlConnector.MySqlConnection(_mySqlConn);
 conn.Open();
 using var cmd = conn.CreateCommand();
 cmd.CommandText = @"INSERT INTO elevator_logs (LogDate, LogTime, ActionText, FloorLabel)
 VALUES (@date, @time, @action, @floor);";
 // Use AddWithValue for simplicity; this also makes debugging easier.
 cmd.Parameters.AddWithValue("@date", timestamp.Date);
 // keep storing TIME value in DB (use TimeOfDay)
 cmd.Parameters.AddWithValue("@time", timestamp.TimeOfDay);
 cmd.Parameters.AddWithValue("@action", action);
 cmd.Parameters.AddWithValue("@floor", floor);

 var affected = cmd.ExecuteNonQuery();
 System.Diagnostics.Debug.WriteLine($"SaveLogToDatabase affected rows: {affected}");
 return affected >0;
 }
 catch (Exception ex)
 {
 // Write to Debug output and show a visible message box so you can see DB errors while debugging
 System.Diagnostics.Debug.WriteLine("SaveLogToDatabase error: " + ex);
 try { MessageBox.Show("SaveLogToDatabase error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
 return false;
 }
 }

 // Load logs from database and display into DataGridView
 private void LoadLogsFromDatabase()
 {
 try
 {
 EnsureActionLogGrid();
 using var conn = new MySqlConnector.MySqlConnection(_mySqlConn);
 conn.Open();
 using var cmd = conn.CreateCommand();
 cmd.CommandText = "SELECT Id, LogDate, LogTime, ActionText, FloorLabel FROM elevator_logs ORDER BY Id DESC;";
 using var reader = cmd.ExecuteReader();
 var dt = new DataTable();
 dt.Load(reader);

 // Clear any existing rows (we manage rows manually, not via DataSource)
 dataGridView1.Invoke(() => {
 dataGridView1.Rows.Clear();
 _nextLogId =1; // default if table empty

 int maxId =0;
 foreach (DataRow r in dt.Rows)
 {
 var idStr = r["Id"]?.ToString() ?? "";
 if (int.TryParse(idStr, out var idVal) && idVal > maxId) maxId = idVal;
 var date = Convert.ToDateTime(r["LogDate"]).ToString("yyyy-MM-dd");
 // Convert TIME (stored as TimeSpan) to12-hour string with AM/PM
 string time;
 if (TimeSpan.TryParse(r["LogTime"]?.ToString(), out var t))
 {
 time = (DateTime.Today + t).ToString("hh:mm:ss tt");
 }
 else
 {
 time = r["LogTime"]?.ToString() ?? "";
 }
 var act = r["ActionText"]?.ToString() ?? "";
 var floor = r["FloorLabel"]?.ToString() ?? "";
 dataGridView1.Rows.Add(idStr, date, time, act, floor);
 }

 // next id should be maxId +1 so new rows get a unique identifier for UI
 if (maxId >0) _nextLogId = maxId +1;
 });
 }
 catch (Exception ex)
 {
 System.Diagnostics.Debug.WriteLine("LoadLogsFromDatabase error: " + ex);
 try { MessageBox.Show("LoadLogsFromDatabase error:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
 }
 }
 }
}

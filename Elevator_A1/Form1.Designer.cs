namespace Elevator_A1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox2 = new PictureBox();
            btnGfloor = new Button();
            btn1Floor = new Button();
            btnUp = new Button();
            btnDown = new Button();
            btnExit = new Button();
            btnDeleteLogs = new Button();
            btnOpen = new Button();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureElevator = new PictureBox();
            doorRightup = new PictureBox();
            doorLeftup = new PictureBox();
            FirstFloor = new Label();
            label1 = new Label();
            doorRightdown = new PictureBox();
            doorLeftdown = new PictureBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            timer_up = new System.Windows.Forms.Timer(components);
            timer_door_open_up = new System.Windows.Forms.Timer(components);
            timer_door_open_down = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            timer_down = new System.Windows.Forms.Timer(components);
            timer_door_close_down = new System.Windows.Forms.Timer(components);
            timer_door_close_up = new System.Windows.Forms.Timer(components);
            lblFloorDisplay = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureElevator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorRightup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorLeftup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorRightdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorLeftdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Screenshot_2025_11_05_1446051;
            pictureBox2.Location = new Point(443, 389);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(165, 225);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnGfloor
            // 
            btnGfloor.Image = Properties.Resources.g_floor;
            btnGfloor.Location = new Point(542, 435);
            btnGfloor.Name = "btnGfloor";
            btnGfloor.Size = new Size(53, 55);
            btnGfloor.TabIndex = 5;
            btnGfloor.UseVisualStyleBackColor = true;
            btnGfloor.Click += btnGfloor_Click;
            // 
            // btn1Floor
            // 
            btn1Floor.Image = Properties.Resources.Screenshot_2025_11_05_145329;
            btn1Floor.Location = new Point(461, 437);
            btn1Floor.Name = "btn1Floor";
            btn1Floor.Size = new Size(53, 53);
            btn1Floor.TabIndex = 6;
            btn1Floor.UseVisualStyleBackColor = true;
            btn1Floor.Click += btn1Floor_Click;
            // 
            // btnUp
            // 
            btnUp.Image = Properties.Resources.Screenshot_2025_11_05_150534;
            btnUp.Location = new Point(278, 180);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(52, 53);
            btnUp.TabIndex = 7;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Image = Properties.Resources.Screenshot_2025_11_05_151356;
            btnDown.Location = new Point(278, 548);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(53, 50);
            btnDown.TabIndex = 8;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(867, 650);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(109, 46);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnDeleteLogs
            // 
            btnDeleteLogs.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteLogs.Location = new Point(681, 650);
            btnDeleteLogs.Name = "btnDeleteLogs";
            btnDeleteLogs.Size = new Size(150, 48);
            btnDeleteLogs.TabIndex = 10;
            btnDeleteLogs.Text = "Delete Logs";
            btnDeleteLogs.UseVisualStyleBackColor = true;
            btnDeleteLogs.Click += BtnDeleteLogs_Click;
            // 
            // btnOpen
            // 
            btnOpen.Image = Properties.Resources.Screenshot_2025_11_05_152911;
            btnOpen.Location = new Point(461, 535);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(51, 48);
            btnOpen.TabIndex = 11;
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Screenshot_2025_11_05_153242;
            btnClose.Location = new Point(544, 535);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(51, 47);
            btnClose.TabIndex = 12;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_2025_11_05_1610431;
            pictureBox1.Location = new Point(42, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(331, 385);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Screenshot_2025_11_05_1610432;
            pictureBox3.Location = new Point(42, 378);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(331, 390);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureElevator
            // 
            pictureElevator.Image = Properties.Resources.Screenshot_2025_11_05_161805;
            pictureElevator.Location = new Point(142, 467);
            pictureElevator.Name = "pictureElevator";
            pictureElevator.Size = new Size(120, 210);
            pictureElevator.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureElevator.TabIndex = 15;
            pictureElevator.TabStop = false;
            // 
            // doorRightup
            // 
            doorRightup.Image = Properties.Resources.Screenshot_2025_11_05_162832;
            doorRightup.Location = new Point(202, 92);
            doorRightup.Name = "doorRightup";
            doorRightup.Size = new Size(60, 210);
            doorRightup.SizeMode = PictureBoxSizeMode.StretchImage;
            doorRightup.TabIndex = 16;
            doorRightup.TabStop = false;
            // 
            // doorLeftup
            // 
            doorLeftup.Image = Properties.Resources.Screenshot_2025_11_05_162910;
            doorLeftup.Location = new Point(142, 92);
            doorLeftup.Name = "doorLeftup";
            doorLeftup.Size = new Size(60, 210);
            doorLeftup.SizeMode = PictureBoxSizeMode.StretchImage;
            doorLeftup.TabIndex = 17;
            doorLeftup.TabStop = false;
            // 
            // FirstFloor
            // 
            FirstFloor.AutoSize = true;
            FirstFloor.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FirstFloor.Location = new Point(152, 37);
            FirstFloor.Name = "FirstFloor";
            FirstFloor.Size = new Size(123, 31);
            FirstFloor.TabIndex = 20;
            FirstFloor.Text = "First Floor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(133, 412);
            label1.Name = "label1";
            label1.Size = new Size(157, 31);
            label1.TabIndex = 21;
            label1.Text = "Ground Floor";
            // 
            // doorRightdown
            // 
            doorRightdown.Image = Properties.Resources.Screenshot_2025_11_05_162832;
            doorRightdown.Location = new Point(202, 467);
            doorRightdown.Name = "doorRightdown";
            doorRightdown.Size = new Size(60, 210);
            doorRightdown.SizeMode = PictureBoxSizeMode.StretchImage;
            doorRightdown.TabIndex = 22;
            doorRightdown.TabStop = false;
            // 
            // doorLeftdown
            // 
            doorLeftdown.Image = Properties.Resources.Screenshot_2025_11_05_162910;
            doorLeftdown.Location = new Point(142, 467);
            doorLeftdown.Name = "doorLeftdown";
            doorLeftdown.Size = new Size(60, 210);
            doorLeftdown.SizeMode = PictureBoxSizeMode.StretchImage;
            doorLeftdown.TabIndex = 23;
            doorLeftdown.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(649, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(860, 570);
            dataGridView1.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(649, 23);
            label2.Name = "label2";
            label2.Size = new Size(223, 31);
            label2.TabIndex = 25;
            label2.Text = "Elevator Action Log";
            label2.Click += label2_Click;
            // 
            // timer_up
            // 
            timer_up.Interval = 15;
            // 
            // timer_door_open_up
            // 
            timer_door_open_up.Interval = 5;
            // 
            // timer_door_open_down
            // 
            timer_door_open_down.Interval = 5;
            // 
            // timer_down
            // 
            timer_down.Interval = 15;
            // 
            // timer_door_close_down
            // 
            timer_door_close_down.Interval = 5;
            // 
            // timer_door_close_up
            // 
            timer_door_close_up.Interval = 5;
            // 
            // lblFloorDisplay
            // 
            lblFloorDisplay.AutoSize = true;
            lblFloorDisplay.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloorDisplay.Location = new Point(410, 330);
            lblFloorDisplay.Name = "lblFloorDisplay";
            lblFloorDisplay.Size = new Size(61, 27);
            lblFloorDisplay.TabIndex = 26;
            lblFloorDisplay.Text = "State";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1571, 747);
            Controls.Add(lblFloorDisplay);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(doorLeftdown);
            Controls.Add(doorRightdown);
            Controls.Add(label1);
            Controls.Add(FirstFloor);
            Controls.Add(doorLeftup);
            Controls.Add(doorRightup);
            Controls.Add(pictureElevator);
            Controls.Add(btnUp);
            Controls.Add(pictureBox1);
            Controls.Add(btnDown);
            Controls.Add(pictureBox3);
            Controls.Add(btnClose);
            Controls.Add(btnOpen);
            Controls.Add(btnDeleteLogs);
            Controls.Add(btnExit);
            Controls.Add(btn1Floor);
            Controls.Add(btnGfloor);
            Controls.Add(pictureBox2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureElevator).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorRightup).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorLeftup).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorRightdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorLeftdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox2;
        private Button btnGfloor;
        private Button btn1Floor;
        private Button btnUp;
        private Button btnDown;
        private Button btnExit;
        private Button btnDeleteLogs;
        private Button btnOpen;
        private Button btnClose;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureElevator;
        private PictureBox doorRightup;
        private PictureBox doorLeftup;
        private Label FirstFloor;
        private Label label1;
        private PictureBox doorRightdown;
        private PictureBox doorLeftdown;
        private DataGridView dataGridView1;
        private Label label2;
        private System.Windows.Forms.Timer timer_up;
        private System.Windows.Forms.Timer timer_door_open_up;
        private System.Windows.Forms.Timer timer_door_open_down;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer_down;
        private System.Windows.Forms.Timer timer_door_close_down;
        private System.Windows.Forms.Timer timer_door_close_up;
        private Label lblFloorDisplay;
    }
}

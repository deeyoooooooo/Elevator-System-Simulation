namespace WinFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnLift = new Button();
            btnUp = new Button();
            btnDown = new Button();
            btnExit = new Button();
            LiftTimer = new System.Windows.Forms.Timer(components);
            LeftDoor = new Button();
            RightDoor = new Button();
            btnOpen = new Button();
            btnClose = new Button();
            DoorTimer = new System.Windows.Forms.Timer(components);
            dataGridViewLogs = new DataGridView();
            btnClearLog = new Button();
            panelElevatorShaft = new Panel();
            lblFloor2 = new Label();
            lblFloor1 = new Label();
            panelControlPanel = new Panel();
            lblControlPanel = new Label();
            panelLogs = new Panel();
            lblLogs = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogs).BeginInit();
            panelElevatorShaft.SuspendLayout();
            panelControlPanel.SuspendLayout();
            panelLogs.SuspendLayout();
            SuspendLayout();
            // 
            // btnLift
            // 
            btnLift.BackColor = Color.FromArgb(230, 233, 239);
            btnLift.BackgroundImage = (Image)resources.GetObject("btnLift.BackgroundImage");
            btnLift.FlatAppearance.BorderSize = 0;
            btnLift.FlatStyle = FlatStyle.Flat;
            btnLift.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLift.Location = new Point(50, 250);
            btnLift.Name = "btnLift";
            btnLift.Size = new Size(176, 140);
            btnLift.TabIndex = 0;
            btnLift.UseVisualStyleBackColor = false;
            // 
            // btnUp
            // 
            btnUp.BackColor = Color.FromArgb(56, 132, 255);
            btnUp.BackgroundImage = (Image)resources.GetObject("btnUp.BackgroundImage");
            btnUp.FlatAppearance.BorderSize = 0;
            btnUp.FlatStyle = FlatStyle.Flat;
            btnUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUp.ForeColor = Color.White;
            btnUp.Location = new Point(20, 60);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(60, 60);
            btnUp.TabIndex = 1;
            btnUp.Text = "Up";
            btnUp.UseVisualStyleBackColor = false;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.BackColor = Color.FromArgb(56, 132, 255);
            btnDown.BackgroundImage = (Image)resources.GetObject("btnDown.BackgroundImage");
            btnDown.FlatAppearance.BorderSize = 0;
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDown.ForeColor = Color.White;
            btnDown.Location = new Point(100, 60);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(60, 60);
            btnDown.TabIndex = 2;
            btnDown.Text = "Down";
            btnDown.UseVisualStyleBackColor = false;
            btnDown.Click += btnDown_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(220, 53, 69);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(20, 140);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(140, 36);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // LiftTimer
            // 
            LiftTimer.Interval = 50;
            LiftTimer.Tick += LiftTimer_Tick;
            // 
            // LeftDoor
            // 
            LeftDoor.BackColor = Color.WhiteSmoke;
            LeftDoor.BackgroundImage = (Image)resources.GetObject("LeftDoor.BackgroundImage");
            LeftDoor.FlatAppearance.BorderSize = 0;
            LeftDoor.FlatStyle = FlatStyle.Flat;
            LeftDoor.Location = new Point(50, 256);
            LeftDoor.Name = "LeftDoor";
            LeftDoor.Size = new Size(85, 134);
            LeftDoor.TabIndex = 4;
            LeftDoor.UseVisualStyleBackColor = true;
            // 
            // RightDoor
            // 
            RightDoor.BackColor = Color.WhiteSmoke;
            RightDoor.BackgroundImage = (Image)resources.GetObject("RightDoor.BackgroundImage");
            RightDoor.FlatAppearance.BorderSize = 0;
            RightDoor.FlatStyle = FlatStyle.Flat;
            RightDoor.Location = new Point(141, 256);
            RightDoor.Name = "RightDoor";
            RightDoor.Size = new Size(85, 134);
            RightDoor.TabIndex = 5;
            RightDoor.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            btnOpen.BackgroundImage = (Image)resources.GetObject("btnOpen.BackgroundImage");
            btnOpen.BackgroundImageLayout = ImageLayout.Stretch;
            btnOpen.Location = new Point(20, 190);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(60, 40);
            btnOpen.TabIndex = 6;
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(100, 190);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(60, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // DoorTimer
            // 
            DoorTimer.Interval = 30;
            DoorTimer.Tick += DoorTimer_Tick;
            // 
            // dataGridViewLogs
            // 
            dataGridViewLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLogs.BackgroundColor = Color.White;
            dataGridViewLogs.BorderStyle = BorderStyle.None;
            dataGridViewLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLogs.Location = new Point(15, 40);
            dataGridViewLogs.Name = "dataGridViewLogs";
            dataGridViewLogs.ReadOnly = true;
            dataGridViewLogs.RowHeadersVisible = false;
            dataGridViewLogs.Size = new Size(320, 219);
            dataGridViewLogs.TabIndex = 8;
            // 
            // btnClearLog
            // 
            btnClearLog.BackColor = Color.FromArgb(108, 117, 125);
            btnClearLog.FlatAppearance.BorderSize = 0;
            btnClearLog.FlatStyle = FlatStyle.Flat;
            btnClearLog.ForeColor = Color.White;
            btnClearLog.Location = new Point(15, 300);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(96, 28);
            btnClearLog.TabIndex = 9;
            btnClearLog.Text = "Clear Logs";
            btnClearLog.UseVisualStyleBackColor = false;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // panelElevatorShaft
            // 
            panelElevatorShaft.BackColor = Color.FromArgb(240, 240, 240);
            panelElevatorShaft.BorderStyle = BorderStyle.FixedSingle;
            panelElevatorShaft.Controls.Add(lblFloor2);
            panelElevatorShaft.Controls.Add(lblFloor1);
            panelElevatorShaft.Controls.Add(LeftDoor);
            panelElevatorShaft.Controls.Add(RightDoor);
            panelElevatorShaft.Controls.Add(btnLift);
            panelElevatorShaft.Location = new Point(30, 30);
            panelElevatorShaft.Name = "panelElevatorShaft";
            panelElevatorShaft.Size = new Size(280, 420);
            panelElevatorShaft.TabIndex = 10;
            // 
            // lblFloor2
            // 
            lblFloor2.AutoSize = true;
            lblFloor2.BackColor = Color.Transparent;
            lblFloor2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloor2.Location = new Point(10, 20);
            lblFloor2.Name = "lblFloor2";
            lblFloor2.Size = new Size(62, 21);
            lblFloor2.TabIndex = 7;
            lblFloor2.Text = "Floor 2";
            // 
            // lblFloor1
            // 
            lblFloor1.AutoSize = true;
            lblFloor1.BackColor = Color.Transparent;
            lblFloor1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloor1.Location = new Point(10, 380);
            lblFloor1.Name = "lblFloor1";
            lblFloor1.Size = new Size(62, 21);
            lblFloor1.TabIndex = 6;
            lblFloor1.Text = "Floor 1";
            // 
            // panelControlPanel
            // 
            panelControlPanel.BackColor = Color.FromArgb(250, 250, 250);
            panelControlPanel.BorderStyle = BorderStyle.FixedSingle;
            panelControlPanel.Controls.Add(lblControlPanel);
            panelControlPanel.Controls.Add(btnUp);
            panelControlPanel.Controls.Add(btnDown);
            panelControlPanel.Controls.Add(btnOpen);
            panelControlPanel.Controls.Add(btnClose);
            panelControlPanel.Controls.Add(btnExit);
            panelControlPanel.Location = new Point(330, 30);
            panelControlPanel.Name = "panelControlPanel";
            panelControlPanel.Size = new Size(197, 245);
            panelControlPanel.TabIndex = 11;
            // 
            // lblControlPanel
            // 
            lblControlPanel.AutoSize = true;
            lblControlPanel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblControlPanel.Location = new Point(30, 15);
            lblControlPanel.Name = "lblControlPanel";
            lblControlPanel.Size = new Size(114, 21);
            lblControlPanel.TabIndex = 8;
            lblControlPanel.Text = "Control Panel";
            // 
            // panelLogs
            // 
            panelLogs.BackColor = Color.FromArgb(250, 250, 250);
            panelLogs.BorderStyle = BorderStyle.FixedSingle;
            panelLogs.Controls.Add(lblLogs);
            panelLogs.Controls.Add(dataGridViewLogs);
            panelLogs.Controls.Add(btnClearLog);
            panelLogs.Location = new Point(330, 281);
            panelLogs.Name = "panelLogs";
            panelLogs.Size = new Size(350, 319);
            panelLogs.TabIndex = 12;
            // 
            // lblLogs
            // 
            lblLogs.AutoSize = true;
            lblLogs.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogs.Location = new Point(15, 10);
            lblLogs.Name = "lblLogs";
            lblLogs.Size = new Size(108, 21);
            lblLogs.TabIndex = 10;
            lblLogs.Text = "Activity Logs";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(700, 620);
            Controls.Add(panelLogs);
            Controls.Add(panelControlPanel);
            Controls.Add(panelElevatorShaft);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elevator Control System";
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogs).EndInit();
            panelElevatorShaft.ResumeLayout(false);
            panelElevatorShaft.PerformLayout();
            panelControlPanel.ResumeLayout(false);
            panelControlPanel.PerformLayout();
            panelLogs.ResumeLayout(false);
            panelLogs.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLift;
        private Button btnUp;
        private Button btnDown;
        private Button btnExit;
        private System.Windows.Forms.Timer LiftTimer;
        private Button LeftDoor;
        private Button RightDoor;
        private Button btnOpen;
        private Button btnClose;
        private System.Windows.Forms.Timer DoorTimer;
        private DataGridView dataGridViewLogs;
        private Button btnClearLog;
        private Panel panelElevatorShaft;
        private Label lblFloor1;
        private Label lblFloor2;
        private Panel panelControlPanel;
        private Label lblControlPanel;
        private Panel panelLogs;
        private Label lblLogs;
    }
}
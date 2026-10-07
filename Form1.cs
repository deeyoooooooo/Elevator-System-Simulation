using System.Data;
using DatabaseHelper; // Encapsulated DB logic (middleware between UI and DB)
using System.Drawing.Imaging;
using System.IO;

namespace WinFormsApp1
{
    // Form1 class demonstrates OOP concepts: encapsulation, abstraction, event-driven programming
    // It handles UI, animation, and interacts with database through DBHelper
    public partial class Form1 : Form
    {
        // -----------------------------
        // Elevator state variables
        // -----------------------------
        private int floor1Position; // Y coordinate of Floor 1
        private int floor2Position; // Y coordinate of Floor 2
        private int currentFloor = 1; // Track current floor (1 or 2)

        // Lift movement flags
        bool isMovingUp = false;
        bool isMovingDown = false;
        int liftspeed = 5; // pixels per timer tick for smooth animation

        // Door state flags
        bool isOpening = false;
        bool isClosing = false;
        bool pendingMovement = false; // Track if lift should start moving after doors close
        int doorspeed = 10; // pixels per timer tick for door movement
        int doorMaxOpenWidth; // maximum door separation

        // Database helper instance (OOP: encapsulation & abstraction)
        private readonly DBHelper _db = new DBHelper();

        // -----------------------------
        // Constructor: initialize UI and elevator positions
        // -----------------------------
        public Form1()
        {
            InitializeComponent();

            // Calculate floor positions based on panel and lift height
            floor1Position = panelElevatorShaft.Height - btnLift.Height - 40;
            floor2Position = 40;

            // Set initial lift position at Floor 1
            btnLift.Top = floor1Position;
            LeftDoor.Top = btnLift.Top + 6;
            RightDoor.Top = btnLift.Top + 6;

            // Set doors initially closed
            LeftDoor.Left = btnLift.Left;
            RightDoor.Left = btnLift.Left + btnLift.Width - RightDoor.Width;

            // Maximum door opening distance (half of lift width)
            doorMaxOpenWidth = btnLift.Width / 2;

            // Event bindings (event-driven programming)
            this.Load += Form1_Load;
            this.DoubleBuffered = true; // reduce flickering during animations
        }

        // -----------------------------
        // Form load event: initialize DB, load logs, and apply UI theme
        // -----------------------------
        private void Form1_Load(object? sender, EventArgs e)
        {
            // Test DB connection (DBMS: connection)
            _db.TestConnection();

            // Log application start (DBMS: Create operation)
            _db.InsertLog("Application started - Elevator on Floor 1");

            // Load recent logs into grid (DBMS: Read operation)
            LoadRecentLogs();

            // Apply UI images and themes (design pattern: Separation of Concerns)
            ApplyThemeImages();
        }

        // -----------------------------
        // Load recent logs from database and bind to DataGridView
        // -----------------------------
        private void LoadRecentLogs()
        {
            try
            {
                var table = _db.GetRecentLogs(50); // Data flow: DB -> DataTable -> UI
                dataGridViewLogs.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logs: " + ex.Message); // validation: handle DB failure gracefully
            }
        }

        // -----------------------------
        // Apply images to controls dynamically (UI theming)
        // Design pattern: Component-based / Separation of Concerns
        // -----------------------------
        private void ApplyThemeImages()
        {
            string repos = Path.Combine(Application.StartupPath, "repos");

            TrySetBackgroundImage(panelElevatorShaft, Path.Combine(repos, "concrete.JPG"));

            // Lift interior
            TrySetBackgroundImage(btnLift, Path.Combine(repos, "Inside of the lift.png"));
            btnLift.BackgroundImageLayout = ImageLayout.Stretch;

            // Left and right doors
            TrySetBackgroundImage(LeftDoor, Path.Combine(repos, "lift door left.png"));
            LeftDoor.BackgroundImageLayout = ImageLayout.Stretch;

            TrySetBackgroundImage(RightDoor, Path.Combine(repos, "lift door right.png"));
            RightDoor.BackgroundImageLayout = ImageLayout.Stretch;

            // Up/down buttons
            TrySetBackgroundImage(btnUp, Path.Combine(repos, "direction-north.png"));
            btnUp.BackgroundImageLayout = ImageLayout.Zoom;
            btnUp.Text = string.Empty;

            TrySetBackgroundImage(btnDown, Path.Combine(repos, "direction-south.png"));
            btnDown.BackgroundImageLayout = ImageLayout.Zoom;
            btnDown.Text = string.Empty;

            // Door control buttons
            TrySetBackgroundImage(btnOpen, Path.Combine(repos, "opendoorbutton.png"));
            btnOpen.BackgroundImageLayout = ImageLayout.Zoom;
            btnOpen.Text = string.Empty;

            TrySetBackgroundImage(btnClose, Path.Combine(repos, "closedoorsbutton.png"));
            btnClose.BackgroundImageLayout = ImageLayout.Zoom;
            btnClose.Text = string.Empty;
        }

        // -----------------------------
        // Safely set background image for controls
        // Validation: checks file exists and handles exceptions
        // -----------------------------
        private static void TrySetBackgroundImage(Control control, string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    using (var img = Image.FromFile(imagePath))
                    {
                        control.BackgroundImage = new Bitmap(img);
                    }
                }
            }
            catch { /* ignore errors if image missing */ }
        }

        // -----------------------------
        // Exit button handler
        // -----------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // -----------------------------
        // Up button: starts lift movement up (Floor 1 -> Floor 2)
        // Business logic: checks current floor and door state
        // Middleware/API: communicates with DBHelper for logging
        // -----------------------------
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (currentFloor == 1 && !isMovingUp && !isMovingDown)
            {
                // Check doors before movement (validation)
                if (!AreDoorsClosed())
                {
                    isMovingUp = true;
                    isMovingDown = false;
                    CloseDoorsBeforeMovement();
                    return; // movement will start after doors close
                }

                isMovingUp = true;
                isMovingDown = false;
                LiftTimer.Start();
                _db.InsertLog("Lift moving up to Floor 2"); // DBMS: Create
                LoadRecentLogs();
            }
            else if (currentFloor == 2)
            {
                _db.InsertLog("Already at Floor 2");
                LoadRecentLogs();
            }
        }

        // -----------------------------
        // Down button: starts lift movement down (Floor 2 -> Floor 1)
        // Same design pattern / business logic as btnUp_Click
        // -----------------------------
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (currentFloor == 2 && !isMovingUp && !isMovingDown)
            {
                if (!AreDoorsClosed())
                {
                    isMovingDown = true;
                    isMovingUp = false;
                    CloseDoorsBeforeMovement();
                    return;
                }

                isMovingDown = true;
                isMovingUp = false;
                LiftTimer.Start();
                _db.InsertLog("Lift moving down to Floor 1");
                LoadRecentLogs();
            }
            else if (currentFloor == 1)
            {
                _db.InsertLog("Already at Floor 1");
                LoadRecentLogs();
            }
        }

        // -----------------------------
        // Timer event: moves lift up/down smoothly
        // Business logic: updates lift & door positions
        // Data flow: user action -> timer tick -> UI update -> DB logging
        // -----------------------------
        private void LiftTimer_Tick(object sender, EventArgs e)
        {
            if (isMovingUp)
            {
                if (btnLift.Top > floor2Position)
                {
                    btnLift.Top -= liftspeed;
                    LeftDoor.Top -= liftspeed;
                    RightDoor.Top -= liftspeed;
                }
                else
                {
                    LiftTimer.Stop();
                    isMovingUp = false;
                    currentFloor = 2;
                    _db.InsertLog("Lift reached Floor 2");
                    LoadRecentLogs();
                }
            }

            if (isMovingDown)
            {
                if (btnLift.Top < floor1Position)
                {
                    btnLift.Top += liftspeed;
                    LeftDoor.Top += liftspeed;
                    RightDoor.Top += liftspeed;
                }
                else
                {
                    LiftTimer.Stop();
                    isMovingDown = false;
                    currentFloor = 1;
                    _db.InsertLog("Lift reached Floor 1");
                    LoadRecentLogs();
                }
            }
        }

        // -----------------------------
        // Door open button
        // Business logic: only allow opening if lift is stationary
        // -----------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!isMovingUp && !isMovingDown)
            {
                isOpening = true;
                isClosing = false;
                DoorTimer.Start();
                _db.InsertLog("Door opening started");
                LoadRecentLogs();
            }
        }

        // -----------------------------
        // Door close button
        // -----------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            isClosing = true;
            isOpening = false;
            DoorTimer.Start();
            _db.InsertLog("Door closing started");
            LoadRecentLogs();
        }

        // -----------------------------
        // DoorTimer: animates door movement
        // Business logic: handle pending lift movement after door closes
        // -----------------------------
        private void DoorTimer_Tick(object sender, EventArgs e)
        {
            if (isOpening)
            {
                if (LeftDoor.Left > btnLift.Left - doorMaxOpenWidth)
                {
                    LeftDoor.Left -= doorspeed;
                    RightDoor.Left += doorspeed;
                }
                else
                {
                    DoorTimer.Stop();
                    isOpening = false;
                    _db.InsertLog("Door opened");
                    LoadRecentLogs();
                }
            }

            if (isClosing)
            {
                if (LeftDoor.Left < btnLift.Left)
                {
                    LeftDoor.Left += doorspeed;
                    RightDoor.Left -= doorspeed;
                }
                else
                {
                    DoorTimer.Stop();
                    isClosing = false;
                    _db.InsertLog("Door closed");
                    LoadRecentLogs();

                    // Start pending lift movement if any
                    if (pendingMovement)
                    {
                        pendingMovement = false;
                        if (isMovingUp)
                        {
                            LiftTimer.Start();
                            _db.InsertLog("Lift moving up to Floor 2");
                            LoadRecentLogs();
                        }
                        else if (isMovingDown)
                        {
                            LiftTimer.Start();
                            _db.InsertLog("Lift moving down to Floor 1");
                            LoadRecentLogs();
                        }
                    }
                }
            }
        }

        // -----------------------------
        // Helper method: checks if doors are fully closed
        // Validation: prevents lift moving with open doors
        // -----------------------------
        private bool AreDoorsClosed()
        {
            return LeftDoor.Left >= btnLift.Left && RightDoor.Left <= (btnLift.Left + btnLift.Width - RightDoor.Width);
        }

        // -----------------------------
        // Helper: initiate door closing before lift movement
        // Business logic: prevents unsafe lift motion
        // -----------------------------
        private void CloseDoorsBeforeMovement()
        {
            isOpening = false;
            isClosing = true;
            pendingMovement = true; // flag to move lift after doors close
            DoorTimer.Start();
            _db.InsertLog("Closing doors before movement");
            LoadRecentLogs();
        }

        // -----------------------------
        // Clear log button: deletes all DB entries
        // DBMS: Delete operation
        // Validation: handle errors gracefully
        // -----------------------------
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                _db.ClearLogs();
                LoadRecentLogs();
                _db.InsertLog("Logs cleared");
                LoadRecentLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing logs: " + ex.Message);
            }
        }
    }
}

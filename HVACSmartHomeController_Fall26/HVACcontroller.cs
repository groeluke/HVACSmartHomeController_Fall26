/*Luke Groesbeck
*Fall 2026
*RCET 3371
*HVAC Smart Home Controller
*Advanced Programming Techniques & GUI Development
*https://github.com/groeluke/HVACSmartHomeController_Fall26.git
*/
using System.IO.Ports;
using System.Security.Cryptography;
namespace HVACSmartHomeController_Fall26
{
    public partial class HVACcontroller : Form
    {
        QyAtBoard board = new QyAtBoard();
        bool boardConnected = false;
        bool commFaultLogged = false;
        DateTime nextConnectTry = DateTime.Now;
        Label[] inputLabels = new Label[5];

        public HVACcontroller()
        {
            InitializeComponent();
            SetDefaults();
        }

        void SetDefaults()
        {
            // load the last session's port and setpoints
            if (!HvacSettings.Load())
            {
                MessageBox.Show("Could not read the settings file. Using the default settings.");
            }

            inputLabels = new Label[] { Input1Label, Input2Label, Input3Label, Input4Label, Input5Label };

            // list the COM ports in the menu (before hooking the event so it does not fire yet)
            PortToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadPortList();

            // menu events (the button and timer events are already wired in the designer)
            ExitMenuItem.Click += ExitMenuItem_Click;
            SaveSettingsMenuItem.Click += SaveSettingsMenuItem_Click;
            RescanPortsMenuItem.Click += RescanPortsMenuItem_Click;
            PortToolStripComboBox.SelectedIndexChanged += PortToolStripComboBox_SelectedIndexChanged;

            TimeLabel.Text = DateTime.Now.ToString("hh:mm tt");
            ShowSetpoints();
            ShowDisconnected();
            ShowFaultState(false);
            ShowCommStatus("Searching for QY@ board...", false);
        }

        // Fills the menu's combo box with the COM ports Windows lists right now.
        void LoadPortList()
        {
            PortToolStripComboBox.Items.Clear();
            foreach (string name in SerialPort.GetPortNames())
            {
                PortToolStripComboBox.Items.Add(name);
            }

            // select the port we are using (or the one saved last time)
            string wanted = boardConnected ? board.PortName : HvacSettings.PortName;
            if (PortToolStripComboBox.Items.Contains(wanted))
            {
                PortToolStripComboBox.SelectedItem = wanted;
            }
        }
        void ShowSetpoints()
        {
            HighSetpointLabel.Text = "Cool to" HvacSettings.HighSetpoint.ToString("F1");
            LowSetpointLabel.Text = "Heat to" HvacSettings.LowSetpoint.ToString("F1");
        }

        void ShowCommStatus(string text, bool ok)
        {
            CommStatusLabel.Text = text;
            SetIndicator(CommStatusLabel, ok);
        }

        // Shows "no data" on everything that comes from the board
        void ShowDisconnected()
        {
            CurrentTempLabel.Text = "***°F";
            UnitTempLabel.Text = "***°F";
            ModeLabel.Text = "Mode: ***°F";
            FanModeLabel.Text = "Fan mode: ***°F";
            FanStatusLabel.Text = "Fan: OFF";
            foreach (Label label in inputLabels)
            {
                SetIndicator(label, false);
            }
            SetIndicator(Output1Label, false);
            SetIndicator(Output2Label, false);
            SetIndicator(Output3Label, false);
            SetIndicator(Output4Label, false);
            SetIndicator(Output5Label, false);
            SetIndicator(InterlockLabel, false);
            SetIndicator(PressureLabel, false);
            SetIndicator(FanStatusLabel, false);
        }

        // Puts one reading from the board onto the form.
        void ShowReading(BoardReading reading)
        {
            // temperatures
            double homeTemp = Hvac.AdcToFahrenheit(reading.Analog1);
            double unitTemp = Hvac.AdcToFahrenheit(reading.Analog2);
            CurrentTempLabel.Text = homeTemp.ToString("F1") + " °F";
            UnitTempLabel.Text = unitTemp.ToString("F1") + " °F";

            // digital inputs: orange = HIGH
            byte inputs = reading.DigitalInputs;
            for (int i = 0; i < inputLabels.Length; i++)
            {
                SetIndicator(inputLabels[i], QyAtBoard.IsHigh(inputs, i + 1));
            }
            SetIndicator(InterlockLabel, QyAtBoard.IsHigh(inputs, IoMap.InterlockInput));
            SetIndicator(PressureLabel, QyAtBoard.IsHigh(inputs, IoMap.PressureInput));

            // mirror the physical switches
            if (QyAtBoard.IsHigh(inputs, IoMap.HeatInput))
            {
                ModeLabel.Text = "Mode: HEAT";
            }
            else if (QyAtBoard.IsHigh(inputs, IoMap.CoolInput))
            {
                ModeLabel.Text = "Mode: COOL";
            }
            else
            {
                ModeLabel.Text = "Mode: OFF";
            }
            FanModeLabel.Text = QyAtBoard.IsHigh(inputs, IoMap.FanInput) ? "Fan mode: ON" : "Fan mode: AUTO";
        }

        // Adds a fault to the log file, the list box, and the fault indicator.
        void ReportFault(string description)
        {
            ErrorLog.Write(description);
            FaultListBox.Items.Add(DateTime.Now.ToString("HH:mm:ss") + "  " + description);
            FaultListBox.TopIndex = FaultListBox.Items.Count - 1;
            ShowFaultState(true);
        }
        // Searches every COM port for the QY board (the saved port is tried first).
        void ConnectToBoard()
        {
            ShowCommStatus("Searching for QY@ board...", false);
            CommStatusLabel.Refresh();     // show the text now, the search can take a moment

            if (board.Connect(HvacSettings.PortName))
            {
                boardConnected = true;
                commFaultLogged = false;
                HvacSettings.PortName = board.PortName;
                LoadPortList();
                ShowCommStatus("QY@ connected on " + board.PortName, true);
                ShowFaultState(false);
            }
            else
            {
                ConnectionFailed("QY@ board not found - Attempting reconnect");
            }
        }

        // Reads the inputs once. Any problem means the connection was lost.
        void ReadBoard()
        {
            try
            {
                if (!board.IsConnected)
                {
                    throw new IOException("The QY@ board was unplugged.");
                }
                ShowReading(board.ReadInputs());
            }
            catch (Exception)
            {
                ConnectionFailed("Communication lost with QY@ board - Attempting reconnect");
            }
        }

        // Closes the port, shows the error, and schedules another search in 10 seconds.
        void ConnectionFailed(string description)
        {
            boardConnected = false;
            board.Disconnect();
            nextConnectTry = DateTime.Now.AddSeconds(10);
            ShowDisconnected();
            ShowCommStatus("COMM ERROR - retrying every 10 s", false);

            if (!commFaultLogged)          // only log the first failure, not every retry
            {
                ReportFault(description);
                commFaultLogged = true;
            }
        }

        // Setpoints
        void ChangeHighSetpoint(double change)
        {
            HvacSettings.HighSetpoint = Hvac.ClampSetpoint(HvacSettings.HighSetpoint + change);
            ShowSetpoints();
        }

        void ChangeLowSetpoint(double change)
        {
            HvacSettings.LowSetpoint = Hvac.ClampSetpoint(HvacSettings.LowSetpoint + change);
            ShowSetpoints();
        }


        //Event handles below**************************************************
        private void HighUpButton_Click(object sender, EventArgs e)
        {
            ChangeHighSetpoint(-HVAC.SetpointStep);
        }

        private void HighDownButton_Click(object sender, EventArgs e)
        {

        }

        private void LowUpButton_Click(object sender, EventArgs e)
        {

        }

        private void LowDownButton_Click(object sender, EventArgs e)
        {

        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {

        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettingsMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RescanPortsMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PortToolStripComboBox_Click(object sender, EventArgs e)
        {

        }
    }
}

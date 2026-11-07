/*Luke Groesbeck
*Fall 2026
*RCET 3371
*HVAC Smart Home Controller
*Advanced Programming Techniques & GUI Development
*https://github.com/groeluke/HVACSmartHomeController_Fall26.git
*/

using System.IO.Ports;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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
            ISUTheme();
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

            // wire the menu events
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

        void ISUTheme()
        {
            BackColor = IsuColors.GrowlGreyLight;
            ForeColor = IsuColors.BengalBlack;

            TopMenuStrip.BackColor = IsuColors.Roarange;
            TopMenuStrip.ForeColor = IsuColors.BengalBlack;

            Button[] buttons = { HighUpButton, HighDownButton, LowUpButton, LowDownButton };
            foreach (Button button in buttons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = IsuColors.Roarange;
                button.ForeColor = IsuColors.BengalBlack;
            }

            FaultListBox.BackColor = IsuColors.GrowlGreyMed;
            FaultListBox.ForeColor = IsuColors.BengalBlack;
            FaultListBox.BorderStyle = BorderStyle.None;
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
            HighSetpointLabel.Text = "Cool to " + HvacSettings.HighSetpoint.ToString("F1") + " °F";
            LowSetpointLabel.Text = "Heat to " + HvacSettings.LowSetpoint.ToString("F1") + " °F";
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

        // Turns a label orange when the signal is HIGH, grey when LOW
        void SetIndicator(Label label, bool on)
        {
            if (label == null) return;
            label.BackColor = on ? IsuColors.Roarange : IsuColors.GrowlGreyMed;
            label.ForeColor = IsuColors.BengalBlack;
        }

        // Shows or hides the fault indicator
        void ShowFaultState(bool hasFault)
        {
            FaultLabel.Text = hasFault ? "FAULT" : "OK";
            SetIndicator(FaultLabel, hasFault);
        }

        //Event handles below**************************************************
        private void HighUpButton_Click(object sender, EventArgs e)
        {
            ChangeHighSetpoint(+Hvac.SetpointStep);
        }

        private void HighDownButton_Click(object sender, EventArgs e)
        {
            ChangeHighSetpoint(-Hvac.SetpointStep);
        }


        private void LowUpButton_Click(object sender, EventArgs e)
        {
            ChangeLowSetpoint(+Hvac.SetpointStep);
        }

        private void LowDownButton_Click(object sender, EventArgs e)
        {
            ChangeLowSetpoint(-Hvac.SetpointStep);
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // update the clock every tick
            TimeLabel.Text = DateTime.Now.ToString("hh:mm tt");

            if (boardConnected)
            {
                ReadBoard();                 // read sensors + update labels
                                             // later we will add the control logic here
            }
            else if (DateTime.Now >= nextConnectTry)
            {
                ConnectToBoard();            // try to find the board again
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (HvacSettings.Save())
                MessageBox.Show("Settings saved.");
            else
                MessageBox.Show("Could not save settings.");
        }

        private void RescanPortsMenuItem_Click(object sender, EventArgs e)
        {
            LoadPortList();
        }

        private void PortToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PortToolStripComboBox.SelectedItem == null) return;

            string chosen = PortToolStripComboBox.SelectedItem.ToString();
            if (chosen == board.PortName) return;   // already using this port

            board.Disconnect();
            boardConnected = false;
            HvacSettings.PortName = chosen;
            nextConnectTry = DateTime.Now;          // try the new port right away
        }

        // Helper classes 

        public static class IsuColors
        {
            public static Color GrowlGreyLight = Color.FromArgb(230, 231, 232);
            public static Color GrowlGreyMed = Color.FromArgb(167, 167, 167);
            public static Color GrowlGrey = Color.FromArgb(130, 130, 130);
            public static Color Roarange = Color.FromArgb(244, 121, 32);
            public static Color RoarangeL = Color.FromArgb(246, 146, 64);
            public static Color BengalBlack = Color.FromArgb(0, 0, 0);
        }

        public static class HvacSettings
        {
            public static string PortName = "COM6";
            public static double HighSetpoint = 75.0;
            public static double LowSetpoint = 68.0;

            const string FileName = "HVAC Settings.txt";

            public static bool Load()
            {
                try
                {
                    if (!File.Exists(FileName)) return false;
                    foreach (string line in File.ReadAllLines(FileName))
                    {
                        if (line.StartsWith("Port=")) PortName = line.Substring(5).Trim();
                        if (line.StartsWith("High=")) HighSetpoint = double.Parse(line.Substring(5));
                        if (line.StartsWith("Low=")) LowSetpoint = double.Parse(line.Substring(4));
                    }
                    return true;
                }
                catch { return false; }
            }

            public static bool Save()
            {
                try
                {
                    File.WriteAllLines(FileName, new[]
                    {
                    "Port=" + PortName,
                    "High=" + HighSetpoint.ToString("F1"),
                    "Low="  + LowSetpoint.ToString("F1")
                });
                    return true;
                }
                catch { return false; }
            }
        }

        public static class ErrorLog
        {
            public static void Write(string description)
            {
                try
                {
                    string fileName = "HVACSystem-" + DateTime.Now.ToString("yyMMdd") + ".log";
                    string line = DateTime.Now.ToString("yyMMdd-HHmmss") + ": " + description;
                    File.AppendAllText(fileName, line + Environment.NewLine);
                }
                catch { }
            }
        }

        public static class Hvac
        {
            public const double SetpointStep = 0.5;

            public static double AdcToFahrenheit(int adc)
            {
                return 40.0 + (adc * 60.0 / 1023.0);
            }

            public static double ClampSetpoint(double value)
            {
                if (value < 50) return 50;
                if (value > 90) return 90;
                return value;
            }
        }

        public static class IoMap
        {
            public const int InterlockInput = 1;
            public const int HeatInput = 2;
            public const int FanInput = 3;
            public const int PressureInput = 4;
            public const int CoolInput = 5;
        }

        public class BoardReading
        {
            public int Analog1;
            public int Analog2;
            public byte DigitalInputs;
        }

        public class QyAtBoard
        {
            SerialPort port = new SerialPort();
            public string PortName => port.PortName;
            public bool IsConnected => port.IsOpen;

            public bool Connect(string preferredPort)
            {
                string[] ports = SerialPort.GetPortNames();
                if (!string.IsNullOrEmpty(preferredPort) && TryOpen(preferredPort))
                    return true;

                foreach (string name in ports)
                {
                    if (name == preferredPort) continue;
                    if (TryOpen(name)) return true;
                }
                return false;
            }

            bool TryOpen(string name)
            {
                try
                {
                    if (port.IsOpen) port.Close();
                    port.PortName = name;
                    port.BaudRate = 9600;
                    port.Open();
                    return true;
                }
                catch { return false; }
            }

            public void Disconnect()
            {
                try { if (port.IsOpen) port.Close(); } catch { }
            }

            public BoardReading ReadInputs()
            {
                // dummy data so the form runs – replace later with real serial commands
                return new BoardReading
                {
                    Analog1 = 512,
                    Analog2 = 520,
                    DigitalInputs = 0x00
                };
            }

            public static bool IsHigh(byte inputs, int bitNumber)
            {
                return (inputs & (1 << (bitNumber - 1))) != 0;
            }
        }
    }
}

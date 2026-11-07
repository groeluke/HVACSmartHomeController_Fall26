/*Luke Groesbeck
*Fall 2026
*RCET 3371
*HVAC Smart Home Controller
*Advanced Programming Techniques & GUI Development
*https://github.com/groeluke/HVACSmartHomeController_Fall26.git
*/
using System.IO.Ports;
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

        //Event handles below**************************************************
        private void HighUpButton_Click(object sender, EventArgs e)
        {

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
    }
}

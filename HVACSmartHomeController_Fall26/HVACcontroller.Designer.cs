namespace HVACSmartHomeController_Fall26
{
    partial class HVACcontroller
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
            LogoPictureBox = new PictureBox();
            TimeLabel = new Label();
            CurrentTempLabel = new Label();
            HighSetpointLabel = new Label();
            LowSetpointLabel = new Label();
            HighUpButton = new Button();
            HighDownButton = new Button();
            LowUpButton = new Button();
            LowDownButton = new Button();
            ModeLabel = new Label();
            FanModeLabel = new Label();
            FanStatusLabel = new Label();
            FaultLabel = new Label();
            CommStatusLabel = new Label();
            IoGroupBox = new GroupBox();
            PressureLabel = new Label();
            InterlockLabel = new Label();
            UnitTempLabel = new Label();
            Output5Label = new Label();
            Output4Label = new Label();
            Output3Label = new Label();
            Output2Label = new Label();
            Output1Label = new Label();
            Input5Label = new Label();
            Input4Label = new Label();
            Input3Label = new Label();
            Input2Label = new Label();
            Input1Label = new Label();
            MainTimer = new System.Windows.Forms.Timer(components);
            MainToolTip = new ToolTip(components);
            FaultListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            IoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogoPictureBox.Location = new Point(12, 148);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(210, 150);
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Location = new Point(12, 413);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(50, 25);
            TimeLabel.TabIndex = 1;
            TimeLabel.Text = "Time";
            // 
            // CurrentTempLabel
            // 
            CurrentTempLabel.AutoSize = true;
            CurrentTempLabel.Location = new Point(12, 388);
            CurrentTempLabel.Name = "CurrentTempLabel";
            CurrentTempLabel.Size = new Size(118, 25);
            CurrentTempLabel.TabIndex = 2;
            CurrentTempLabel.Text = "Current Temp";
            // 
            // HighSetpointLabel
            // 
            HighSetpointLabel.AutoSize = true;
            HighSetpointLabel.Location = new Point(12, 363);
            HighSetpointLabel.Name = "HighSetpointLabel";
            HighSetpointLabel.Size = new Size(122, 25);
            HighSetpointLabel.TabIndex = 3;
            HighSetpointLabel.Text = "High Setpoint";
            // 
            // LowSetpointLabel
            // 
            LowSetpointLabel.AutoSize = true;
            LowSetpointLabel.Location = new Point(12, 338);
            LowSetpointLabel.Name = "LowSetpointLabel";
            LowSetpointLabel.Size = new Size(116, 25);
            LowSetpointLabel.TabIndex = 4;
            LowSetpointLabel.Text = "Low Setpoint";
            // 
            // HighUpButton
            // 
            HighUpButton.Location = new Point(663, 332);
            HighUpButton.Name = "HighUpButton";
            HighUpButton.Size = new Size(125, 50);
            HighUpButton.TabIndex = 5;
            HighUpButton.Text = "+ High";
            HighUpButton.UseVisualStyleBackColor = true;
            HighUpButton.Click += HighUpButton_Click;
            // 
            // HighDownButton
            // 
            HighDownButton.Location = new Point(663, 388);
            HighDownButton.Name = "HighDownButton";
            HighDownButton.Size = new Size(125, 50);
            HighDownButton.TabIndex = 6;
            HighDownButton.Text = "- High";
            HighDownButton.UseVisualStyleBackColor = true;
            // 
            // LowUpButton
            // 
            LowUpButton.Location = new Point(532, 332);
            LowUpButton.Name = "LowUpButton";
            LowUpButton.Size = new Size(125, 50);
            LowUpButton.TabIndex = 7;
            LowUpButton.Text = "+ Low";
            LowUpButton.UseVisualStyleBackColor = true;
            // 
            // LowDownButton
            // 
            LowDownButton.Location = new Point(532, 388);
            LowDownButton.Name = "LowDownButton";
            LowDownButton.Size = new Size(125, 50);
            LowDownButton.TabIndex = 8;
            LowDownButton.Text = "- Low";
            LowDownButton.UseVisualStyleBackColor = true;
            // 
            // ModeLabel
            // 
            ModeLabel.AutoSize = true;
            ModeLabel.Location = new Point(12, 9);
            ModeLabel.Name = "ModeLabel";
            ModeLabel.Size = new Size(105, 25);
            ModeLabel.TabIndex = 9;
            ModeLabel.Text = "Mode Label";
            // 
            // FanModeLabel
            // 
            FanModeLabel.AutoSize = true;
            FanModeLabel.Location = new Point(12, 34);
            FanModeLabel.Name = "FanModeLabel";
            FanModeLabel.Size = new Size(137, 25);
            FanModeLabel.TabIndex = 10;
            FanModeLabel.Text = "Fan Mode Label";
            // 
            // FanStatusLabel
            // 
            FanStatusLabel.AutoSize = true;
            FanStatusLabel.Location = new Point(12, 59);
            FanStatusLabel.Name = "FanStatusLabel";
            FanStatusLabel.Size = new Size(138, 25);
            FanStatusLabel.TabIndex = 11;
            FanStatusLabel.Text = "Fan Status Label";
            // 
            // FaultLabel
            // 
            FaultLabel.AutoSize = true;
            FaultLabel.Location = new Point(12, 84);
            FaultLabel.Name = "FaultLabel";
            FaultLabel.Size = new Size(95, 25);
            FaultLabel.TabIndex = 12;
            FaultLabel.Text = "Fault Label";
            // 
            // CommStatusLabel
            // 
            CommStatusLabel.AutoSize = true;
            CommStatusLabel.Location = new Point(12, 109);
            CommStatusLabel.Name = "CommStatusLabel";
            CommStatusLabel.Size = new Size(165, 25);
            CommStatusLabel.TabIndex = 13;
            CommStatusLabel.Text = "Comm Status Label";
            // 
            // IoGroupBox
            // 
            IoGroupBox.Controls.Add(PressureLabel);
            IoGroupBox.Controls.Add(InterlockLabel);
            IoGroupBox.Controls.Add(UnitTempLabel);
            IoGroupBox.Controls.Add(Output5Label);
            IoGroupBox.Controls.Add(Output4Label);
            IoGroupBox.Controls.Add(Output3Label);
            IoGroupBox.Controls.Add(Output2Label);
            IoGroupBox.Controls.Add(Output1Label);
            IoGroupBox.Controls.Add(Input5Label);
            IoGroupBox.Controls.Add(Input4Label);
            IoGroupBox.Controls.Add(Input3Label);
            IoGroupBox.Controls.Add(Input2Label);
            IoGroupBox.Controls.Add(Input1Label);
            IoGroupBox.Location = new Point(537, 2);
            IoGroupBox.Name = "IoGroupBox";
            IoGroupBox.Size = new Size(262, 296);
            IoGroupBox.TabIndex = 14;
            IoGroupBox.TabStop = false;
            IoGroupBox.Text = "Q board I/O";
            // 
            // PressureLabel
            // 
            PressureLabel.AutoSize = true;
            PressureLabel.Location = new Point(126, 82);
            PressureLabel.Name = "PressureLabel";
            PressureLabel.Size = new Size(78, 25);
            PressureLabel.TabIndex = 24;
            PressureLabel.Text = "Pressure";
            // 
            // InterlockLabel
            // 
            InterlockLabel.AutoSize = true;
            InterlockLabel.Location = new Point(126, 57);
            InterlockLabel.Name = "InterlockLabel";
            InterlockLabel.Size = new Size(80, 25);
            InterlockLabel.TabIndex = 23;
            InterlockLabel.Text = "Interlock";
            // 
            // UnitTempLabel
            // 
            UnitTempLabel.AutoSize = true;
            UnitTempLabel.Location = new Point(126, 32);
            UnitTempLabel.Name = "UnitTempLabel";
            UnitTempLabel.Size = new Size(92, 25);
            UnitTempLabel.TabIndex = 22;
            UnitTempLabel.Text = "Unit Temp";
            // 
            // Output5Label
            // 
            Output5Label.AutoSize = true;
            Output5Label.Location = new Point(6, 255);
            Output5Label.Name = "Output5Label";
            Output5Label.Size = new Size(84, 25);
            Output5Label.TabIndex = 21;
            Output5Label.Text = "Output 5";
            // 
            // Output4Label
            // 
            Output4Label.AutoSize = true;
            Output4Label.Location = new Point(6, 230);
            Output4Label.Name = "Output4Label";
            Output4Label.Size = new Size(84, 25);
            Output4Label.TabIndex = 20;
            Output4Label.Text = "Output 4";
            // 
            // Output3Label
            // 
            Output3Label.AutoSize = true;
            Output3Label.Location = new Point(6, 205);
            Output3Label.Name = "Output3Label";
            Output3Label.Size = new Size(84, 25);
            Output3Label.TabIndex = 19;
            Output3Label.Text = "Output 3";
            // 
            // Output2Label
            // 
            Output2Label.AutoSize = true;
            Output2Label.Location = new Point(6, 180);
            Output2Label.Name = "Output2Label";
            Output2Label.Size = new Size(84, 25);
            Output2Label.TabIndex = 18;
            Output2Label.Text = "Output 2";
            // 
            // Output1Label
            // 
            Output1Label.AutoSize = true;
            Output1Label.Location = new Point(6, 155);
            Output1Label.Name = "Output1Label";
            Output1Label.Size = new Size(84, 25);
            Output1Label.TabIndex = 17;
            Output1Label.Text = "Output 1";
            // 
            // Input5Label
            // 
            Input5Label.AutoSize = true;
            Input5Label.Location = new Point(6, 130);
            Input5Label.Name = "Input5Label";
            Input5Label.Size = new Size(69, 25);
            Input5Label.TabIndex = 16;
            Input5Label.Text = "Input 5";
            // 
            // Input4Label
            // 
            Input4Label.AutoSize = true;
            Input4Label.Location = new Point(6, 105);
            Input4Label.Name = "Input4Label";
            Input4Label.Size = new Size(69, 25);
            Input4Label.TabIndex = 15;
            Input4Label.Text = "Input 4";
            // 
            // Input3Label
            // 
            Input3Label.AutoSize = true;
            Input3Label.Location = new Point(6, 80);
            Input3Label.Name = "Input3Label";
            Input3Label.Size = new Size(69, 25);
            Input3Label.TabIndex = 2;
            Input3Label.Text = "Input 3";
            // 
            // Input2Label
            // 
            Input2Label.AutoSize = true;
            Input2Label.Location = new Point(6, 55);
            Input2Label.Name = "Input2Label";
            Input2Label.Size = new Size(69, 25);
            Input2Label.TabIndex = 1;
            Input2Label.Text = "Input 2";
            // 
            // Input1Label
            // 
            Input1Label.AutoSize = true;
            Input1Label.Location = new Point(6, 30);
            Input1Label.Name = "Input1Label";
            Input1Label.Size = new Size(69, 25);
            Input1Label.TabIndex = 0;
            Input1Label.Text = "Input 1";
            // 
            // MainTimer
            // 
            MainTimer.Interval = 250;
            // 
            // FaultListBox
            // 
            FaultListBox.FormattingEnabled = true;
            FaultListBox.Location = new Point(402, 334);
            FaultListBox.Name = "FaultListBox";
            FaultListBox.Size = new Size(124, 104);
            FaultListBox.TabIndex = 15;
            // 
            // HVACcontroller
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FaultListBox);
            Controls.Add(IoGroupBox);
            Controls.Add(CommStatusLabel);
            Controls.Add(FaultLabel);
            Controls.Add(FanStatusLabel);
            Controls.Add(FanModeLabel);
            Controls.Add(ModeLabel);
            Controls.Add(LowDownButton);
            Controls.Add(LowUpButton);
            Controls.Add(HighDownButton);
            Controls.Add(HighUpButton);
            Controls.Add(LowSetpointLabel);
            Controls.Add(HighSetpointLabel);
            Controls.Add(CurrentTempLabel);
            Controls.Add(TimeLabel);
            Controls.Add(LogoPictureBox);
            Name = "HVACcontroller";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            IoGroupBox.ResumeLayout(false);
            IoGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox LogoPictureBox;
        private Label TimeLabel;
        private Label CurrentTempLabel;
        private Label HighSetpointLabel;
        private Label LowSetpointLabel;
        private Button HighUpButton;
        private Button HighDownButton;
        private Button LowUpButton;
        private Button LowDownButton;
        private Label ModeLabel;
        private Label FanModeLabel;
        private Label FanStatusLabel;
        private Label FaultLabel;
        private Label CommStatusLabel;
        private GroupBox IoGroupBox;
        private Label Input1Label;
        private Label Input2Label;
        private Label Output3Label;
        private Label Output2Label;
        private Label Output1Label;
        private Label Input5Label;
        private Label Input4Label;
        private Label Input3Label;
        private Label PressureLabel;
        private Label InterlockLabel;
        private Label UnitTempLabel;
        private Label Output5Label;
        private Label Output4Label;
        private System.Windows.Forms.Timer MainTimer;
        private ToolTip MainToolTip;
        private ListBox FaultListBox;
    }
}

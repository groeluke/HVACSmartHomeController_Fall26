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
            Input1Label = new Label();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            IoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogoPictureBox.Location = new Point(2, 2);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(797, 446);
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
            IoGroupBox.Controls.Add(Input1Label);
            IoGroupBox.Location = new Point(488, 12);
            IoGroupBox.Name = "IoGroupBox";
            IoGroupBox.Size = new Size(262, 193);
            IoGroupBox.TabIndex = 14;
            IoGroupBox.TabStop = false;
            IoGroupBox.Text = "Q board I/O";
            // 
            // Input1Label
            // 
            Input1Label.AutoSize = true;
            Input1Label.Location = new Point(6, 38);
            Input1Label.Name = "Input1Label";
            Input1Label.Size = new Size(69, 25);
            Input1Label.TabIndex = 0;
            Input1Label.Text = "Input 1";
            // 
            // HVACcontroller
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}

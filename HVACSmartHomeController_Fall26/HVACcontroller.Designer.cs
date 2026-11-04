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
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
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
            TimeLabel.Size = new Size(59, 25);
            TimeLabel.TabIndex = 1;
            TimeLabel.Text = "label1";
            // 
            // CurrentTempLabel
            // 
            CurrentTempLabel.AutoSize = true;
            CurrentTempLabel.Location = new Point(12, 388);
            CurrentTempLabel.Name = "CurrentTempLabel";
            CurrentTempLabel.Size = new Size(59, 25);
            CurrentTempLabel.TabIndex = 2;
            CurrentTempLabel.Text = "label1";
            // 
            // HighSetpointLabel
            // 
            HighSetpointLabel.AutoSize = true;
            HighSetpointLabel.Location = new Point(12, 363);
            HighSetpointLabel.Name = "HighSetpointLabel";
            HighSetpointLabel.Size = new Size(59, 25);
            HighSetpointLabel.TabIndex = 3;
            HighSetpointLabel.Text = "label1";
            // 
            // LowSetpointLabel
            // 
            LowSetpointLabel.AutoSize = true;
            LowSetpointLabel.Location = new Point(12, 338);
            LowSetpointLabel.Name = "LowSetpointLabel";
            LowSetpointLabel.Size = new Size(59, 25);
            LowSetpointLabel.TabIndex = 4;
            LowSetpointLabel.Text = "label1";
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
            // HVACcontroller
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}

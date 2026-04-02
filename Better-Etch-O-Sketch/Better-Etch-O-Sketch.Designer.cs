namespace Better_Etch_O_Sketch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Analog1StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Analog2StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.AnalogTimer = new System.Windows.Forms.Timer(this.components);
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.DisplayPictureBox = new System.Windows.Forms.PictureBox();
            this.MouseRadioButton = new System.Windows.Forms.RadioButton();
            this.ExternalRadioButton = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.DrawGroupBox = new System.Windows.Forms.GroupBox();
            this.ConnectGroupBox = new System.Windows.Forms.GroupBox();
            this.ColorButton = new System.Windows.Forms.Button();
            this.WaveFormButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPictureBox)).BeginInit();
            this.DrawGroupBox.SuspendLayout();
            this.ConnectGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 116);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 51);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PortComboBox
            // 
            this.PortComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(6, 21);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(106, 33);
            this.PortComboBox.TabIndex = 1;
            this.PortComboBox.SelectedIndexChanged += new System.EventHandler(this.PortComboBox_SelectedIndexChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 60);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 50);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "&Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortStatusLabel,
            this.Analog1StatusLabel,
            this.Analog2StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(948, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PortStatusLabel
            // 
            this.PortStatusLabel.Name = "PortStatusLabel";
            this.PortStatusLabel.Size = new System.Drawing.Size(45, 20);
            this.PortStatusLabel.Text = "None";
            // 
            // Analog1StatusLabel
            // 
            this.Analog1StatusLabel.Name = "Analog1StatusLabel";
            this.Analog1StatusLabel.Size = new System.Drawing.Size(17, 20);
            this.Analog1StatusLabel.Text = "0";
            // 
            // Analog2StatusLabel
            // 
            this.Analog2StatusLabel.Name = "Analog2StatusLabel";
            this.Analog2StatusLabel.Size = new System.Drawing.Size(17, 20);
            this.Analog2StatusLabel.Text = "0";
            // 
            // StatusTimer
            // 
            this.StatusTimer.Enabled = true;
            this.StatusTimer.Interval = 250;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // AnalogTimer
            // 
            this.AnalogTimer.Enabled = true;
            this.AnalogTimer.Interval = 200;
            this.AnalogTimer.Tick += new System.EventHandler(this.AnalogTimer_Tick);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 2000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // DisplayPictureBox
            // 
            this.DisplayPictureBox.Location = new System.Drawing.Point(12, 32);
            this.DisplayPictureBox.Name = "DisplayPictureBox";
            this.DisplayPictureBox.Size = new System.Drawing.Size(803, 472);
            this.DisplayPictureBox.TabIndex = 4;
            this.DisplayPictureBox.TabStop = false;
            // 
            // MouseRadioButton
            // 
            this.MouseRadioButton.AutoSize = true;
            this.MouseRadioButton.Location = new System.Drawing.Point(6, 21);
            this.MouseRadioButton.Name = "MouseRadioButton";
            this.MouseRadioButton.Size = new System.Drawing.Size(69, 20);
            this.MouseRadioButton.TabIndex = 5;
            this.MouseRadioButton.TabStop = true;
            this.MouseRadioButton.Text = "Mouse";
            this.MouseRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExternalRadioButton
            // 
            this.ExternalRadioButton.AutoSize = true;
            this.ExternalRadioButton.Location = new System.Drawing.Point(6, 47);
            this.ExternalRadioButton.Name = "ExternalRadioButton";
            this.ExternalRadioButton.Size = new System.Drawing.Size(76, 20);
            this.ExternalRadioButton.TabIndex = 5;
            this.ExternalRadioButton.TabStop = true;
            this.ExternalRadioButton.Text = "External";
            this.ExternalRadioButton.UseVisualStyleBackColor = true;
            // 
            // DrawGroupBox
            // 
            this.DrawGroupBox.Controls.Add(this.ClearButton);
            this.DrawGroupBox.Controls.Add(this.WaveFormButton);
            this.DrawGroupBox.Controls.Add(this.ColorButton);
            this.DrawGroupBox.Controls.Add(this.MouseRadioButton);
            this.DrawGroupBox.Controls.Add(this.ExternalRadioButton);
            this.DrawGroupBox.Location = new System.Drawing.Point(820, 11);
            this.DrawGroupBox.Name = "DrawGroupBox";
            this.DrawGroupBox.Size = new System.Drawing.Size(116, 283);
            this.DrawGroupBox.TabIndex = 6;
            this.DrawGroupBox.TabStop = false;
            // 
            // ConnectGroupBox
            // 
            this.ConnectGroupBox.Controls.Add(this.PortComboBox);
            this.ConnectGroupBox.Controls.Add(this.ConnectButton);
            this.ConnectGroupBox.Controls.Add(this.ExitButton);
            this.ConnectGroupBox.Location = new System.Drawing.Point(820, 333);
            this.ConnectGroupBox.Name = "ConnectGroupBox";
            this.ConnectGroupBox.Size = new System.Drawing.Size(124, 188);
            this.ConnectGroupBox.TabIndex = 7;
            this.ConnectGroupBox.TabStop = false;
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(13, 88);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(98, 55);
            this.ColorButton.TabIndex = 6;
            this.ColorButton.Text = "C&olor";
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // WaveFormButton
            // 
            this.WaveFormButton.Location = new System.Drawing.Point(12, 149);
            this.WaveFormButton.Name = "WaveFormButton";
            this.WaveFormButton.Size = new System.Drawing.Size(98, 55);
            this.WaveFormButton.TabIndex = 6;
            this.WaveFormButton.Text = "&Waveforms";
            this.WaveFormButton.UseVisualStyleBackColor = true;
            this.WaveFormButton.Click += new System.EventHandler(this.WaveFormButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(12, 210);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(98, 55);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "C&lear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 533);
            this.Controls.Add(this.ConnectGroupBox);
            this.Controls.Add(this.DrawGroupBox);
            this.Controls.Add(this.DisplayPictureBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Better Etch-O-Sketch";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPictureBox)).EndInit();
            this.DrawGroupBox.ResumeLayout(false);
            this.DrawGroupBox.PerformLayout();
            this.ConnectGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PortStatusLabel;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.ToolStripStatusLabel Analog1StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel Analog2StatusLabel;
        private System.Windows.Forms.Timer AnalogTimer;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.PictureBox DisplayPictureBox;
        private System.Windows.Forms.RadioButton MouseRadioButton;
        private System.Windows.Forms.RadioButton ExternalRadioButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox DrawGroupBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button WaveFormButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.GroupBox ConnectGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}


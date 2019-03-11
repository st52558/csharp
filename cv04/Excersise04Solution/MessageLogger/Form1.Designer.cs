namespace MessageLogger
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.LeftPanelCheckBox = new System.Windows.Forms.CheckBox();
            this.RightPanelCheckBox = new System.Windows.Forms.CheckBox();
            this.FileCheckBox = new System.Windows.Forms.CheckBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.LogEnabledPanel = new System.Windows.Forms.Panel();
            this.LeftPanelTextBox = new System.Windows.Forms.TextBox();
            this.RightPanelTextBox = new System.Windows.Forms.TextBox();
            this.RightPanelGroupBox = new System.Windows.Forms.GroupBox();
            this.LeftPanelGroupBox = new System.Windows.Forms.GroupBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.LogEnabledPanel.SuspendLayout();
            this.RightPanelGroupBox.SuspendLayout();
            this.LeftPanelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // LeftPanelCheckBox
            // 
            this.LeftPanelCheckBox.AutoSize = true;
            this.LeftPanelCheckBox.Location = new System.Drawing.Point(17, 13);
            this.LeftPanelCheckBox.Name = "LeftPanelCheckBox";
            this.LeftPanelCheckBox.Size = new System.Drawing.Size(74, 17);
            this.LeftPanelCheckBox.TabIndex = 1;
            this.LeftPanelCheckBox.Text = "Left Panel";
            this.LeftPanelCheckBox.UseVisualStyleBackColor = true;
            this.LeftPanelCheckBox.CheckedChanged += new System.EventHandler(this.OutputEnabledCheckBox_CheckedChanged);
            // 
            // RightPanelCheckBox
            // 
            this.RightPanelCheckBox.AutoSize = true;
            this.RightPanelCheckBox.Location = new System.Drawing.Point(103, 13);
            this.RightPanelCheckBox.Name = "RightPanelCheckBox";
            this.RightPanelCheckBox.Size = new System.Drawing.Size(81, 17);
            this.RightPanelCheckBox.TabIndex = 2;
            this.RightPanelCheckBox.Text = "Right Panel";
            this.RightPanelCheckBox.UseVisualStyleBackColor = true;
            // 
            // FileCheckBox
            // 
            this.FileCheckBox.AutoSize = true;
            this.FileCheckBox.Location = new System.Drawing.Point(189, 13);
            this.FileCheckBox.Name = "FileCheckBox";
            this.FileCheckBox.Size = new System.Drawing.Size(42, 17);
            this.FileCheckBox.TabIndex = 3;
            this.FileCheckBox.Text = "File";
            this.FileCheckBox.UseVisualStyleBackColor = true;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(21, 71);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(276, 40);
            this.InputTextBox.TabIndex = 4;
            // 
            // LogEnabledPanel
            // 
            this.LogEnabledPanel.Controls.Add(this.FileCheckBox);
            this.LogEnabledPanel.Controls.Add(this.RightPanelCheckBox);
            this.LogEnabledPanel.Controls.Add(this.LeftPanelCheckBox);
            this.LogEnabledPanel.Location = new System.Drawing.Point(21, 12);
            this.LogEnabledPanel.Name = "LogEnabledPanel";
            this.LogEnabledPanel.Size = new System.Drawing.Size(276, 39);
            this.LogEnabledPanel.TabIndex = 7;
            // 
            // LeftPanelTextBox
            // 
            this.LeftPanelTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanelTextBox.Enabled = false;
            this.LeftPanelTextBox.Location = new System.Drawing.Point(3, 16);
            this.LeftPanelTextBox.Multiline = true;
            this.LeftPanelTextBox.Name = "LeftPanelTextBox";
            this.LeftPanelTextBox.Size = new System.Drawing.Size(135, 81);
            this.LeftPanelTextBox.TabIndex = 0;
            // 
            // RightPanelTextBox
            // 
            this.RightPanelTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanelTextBox.Enabled = false;
            this.RightPanelTextBox.Location = new System.Drawing.Point(3, 16);
            this.RightPanelTextBox.Multiline = true;
            this.RightPanelTextBox.Name = "RightPanelTextBox";
            this.RightPanelTextBox.Size = new System.Drawing.Size(123, 81);
            this.RightPanelTextBox.TabIndex = 0;
            this.RightPanelTextBox.Tag = "";
            this.RightPanelTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // RightPanelGroupBox
            // 
            this.RightPanelGroupBox.Controls.Add(this.RightPanelTextBox);
            this.RightPanelGroupBox.Location = new System.Drawing.Point(168, 128);
            this.RightPanelGroupBox.Name = "RightPanelGroupBox";
            this.RightPanelGroupBox.Size = new System.Drawing.Size(129, 100);
            this.RightPanelGroupBox.TabIndex = 8;
            this.RightPanelGroupBox.TabStop = false;
            this.RightPanelGroupBox.Text = "Right Panel";
            // 
            // LeftPanelGroupBox
            // 
            this.LeftPanelGroupBox.Controls.Add(this.LeftPanelTextBox);
            this.LeftPanelGroupBox.Location = new System.Drawing.Point(21, 128);
            this.LeftPanelGroupBox.Name = "LeftPanelGroupBox";
            this.LeftPanelGroupBox.Size = new System.Drawing.Size(141, 100);
            this.LeftPanelGroupBox.TabIndex = 9;
            this.LeftPanelGroupBox.TabStop = false;
            this.LeftPanelGroupBox.Text = "Left Panel";
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(21, 55);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(31, 13);
            this.InputLabel.TabIndex = 10;
            this.InputLabel.Text = "Input";
            this.InputLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.LeftPanelGroupBox);
            this.Controls.Add(this.RightPanelGroupBox);
            this.Controls.Add(this.LogEnabledPanel);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Message Logger Application";
            this.LogEnabledPanel.ResumeLayout(false);
            this.LogEnabledPanel.PerformLayout();
            this.RightPanelGroupBox.ResumeLayout(false);
            this.RightPanelGroupBox.PerformLayout();
            this.LeftPanelGroupBox.ResumeLayout(false);
            this.LeftPanelGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox LeftPanelCheckBox;
        private System.Windows.Forms.CheckBox RightPanelCheckBox;
        private System.Windows.Forms.CheckBox FileCheckBox;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox RightPanelTextBox;
        private System.Windows.Forms.TextBox LeftPanelTextBox;
        private System.Windows.Forms.Panel LogEnabledPanel;
        private System.Windows.Forms.GroupBox RightPanelGroupBox;
        private System.Windows.Forms.GroupBox LeftPanelGroupBox;
        private System.Windows.Forms.Label InputLabel;
    }
}


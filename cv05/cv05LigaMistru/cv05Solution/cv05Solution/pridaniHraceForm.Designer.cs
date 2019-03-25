namespace pridaniHraceForm
{
    partial class pridaniHraceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tymComboBox = new System.Windows.Forms.ComboBox();
            this.jmenoTextBox = new System.Windows.Forms.TextBox();
            this.golyTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jméno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tým";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Góly";
            // 
            // tymComboBox
            // 
            this.tymComboBox.FormattingEnabled = true;
            this.tymComboBox.Location = new System.Drawing.Point(75, 51);
            this.tymComboBox.Name = "tymComboBox";
            this.tymComboBox.Size = new System.Drawing.Size(121, 21);
            this.tymComboBox.TabIndex = 3;
            // 
            // jmenoTextBox
            // 
            this.jmenoTextBox.Location = new System.Drawing.Point(75, 13);
            this.jmenoTextBox.Name = "jmenoTextBox";
            this.jmenoTextBox.Size = new System.Drawing.Size(100, 20);
            this.jmenoTextBox.TabIndex = 4;
            // 
            // golyTextBox
            // 
            this.golyTextBox.Location = new System.Drawing.Point(75, 85);
            this.golyTextBox.Name = "golyTextBox";
            this.golyTextBox.Size = new System.Drawing.Size(100, 20);
            this.golyTextBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(36, 122);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // zrusitButton
            // 
            this.zrusitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.zrusitButton.Location = new System.Drawing.Point(134, 122);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(75, 23);
            this.zrusitButton.TabIndex = 7;
            this.zrusitButton.Text = "Zrušit";
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.zrusitButton_Click);
            // 
            // pridaniHraceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 281);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.golyTextBox);
            this.Controls.Add(this.jmenoTextBox);
            this.Controls.Add(this.tymComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "pridaniHraceForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox tymComboBox;
        public System.Windows.Forms.TextBox jmenoTextBox;
        public System.Windows.Forms.TextBox golyTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button zrusitButton;
    }
}


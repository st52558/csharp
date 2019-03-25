namespace cv05Solution
{
    partial class nejlepsiKluby
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
            this.golyBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.klubyBox = new System.Windows.Forms.ListView();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Góly";
            // 
            // golyBox
            // 
            this.golyBox.Enabled = false;
            this.golyBox.Location = new System.Drawing.Point(13, 30);
            this.golyBox.Name = "golyBox";
            this.golyBox.Size = new System.Drawing.Size(100, 20);
            this.golyBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kluby";
            // 
            // klubyBox
            // 
            this.klubyBox.Location = new System.Drawing.Point(13, 74);
            this.klubyBox.Name = "klubyBox";
            this.klubyBox.Size = new System.Drawing.Size(121, 97);
            this.klubyBox.TabIndex = 3;
            this.klubyBox.UseCompatibleStateImageBehavior = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(13, 178);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nejlepsiKluby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 288);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.klubyBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.golyBox);
            this.Controls.Add(this.label1);
            this.Name = "nejlepsiKluby";
            this.Text = "nejlepsiKluby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox golyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView klubyBox;
        private System.Windows.Forms.Button okButton;
    }
}
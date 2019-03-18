namespace cv05Solution
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Goly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pridejButton = new System.Windows.Forms.Button();
            this.vymazButton = new System.Windows.Forms.Button();
            this.upravitButton = new System.Windows.Forms.Button();
            this.nejlepsiButton = new System.Windows.Forms.Button();
            this.registrovatButton = new System.Windows.Forms.Button();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.konecButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jmeno,
            this.Klub,
            this.Goly});
            this.dataGridView1.Location = new System.Drawing.Point(31, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(344, 203);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Jmeno
            // 
            this.Jmeno.HeaderText = "Jmeno";
            this.Jmeno.Name = "Jmeno";
            this.Jmeno.ReadOnly = true;
            // 
            // Klub
            // 
            this.Klub.HeaderText = "Klub";
            this.Klub.Name = "Klub";
            this.Klub.ReadOnly = true;
            // 
            // Goly
            // 
            this.Goly.HeaderText = "Góly";
            this.Goly.Name = "Goly";
            this.Goly.ReadOnly = true;
            // 
            // pridejButton
            // 
            this.pridejButton.Location = new System.Drawing.Point(393, 22);
            this.pridejButton.Name = "pridejButton";
            this.pridejButton.Size = new System.Drawing.Size(75, 23);
            this.pridejButton.TabIndex = 1;
            this.pridejButton.Text = "Přidej";
            this.pridejButton.UseVisualStyleBackColor = true;
            this.pridejButton.Click += new System.EventHandler(this.pridejClick);
            // 
            // vymazButton
            // 
            this.vymazButton.Location = new System.Drawing.Point(393, 52);
            this.vymazButton.Name = "vymazButton";
            this.vymazButton.Size = new System.Drawing.Size(75, 23);
            this.vymazButton.TabIndex = 2;
            this.vymazButton.Text = "Vymaž";
            this.vymazButton.UseVisualStyleBackColor = true;
            this.vymazButton.Click += new System.EventHandler(this.vymazClick);
            // 
            // upravitButton
            // 
            this.upravitButton.Location = new System.Drawing.Point(393, 82);
            this.upravitButton.Name = "upravitButton";
            this.upravitButton.Size = new System.Drawing.Size(75, 23);
            this.upravitButton.TabIndex = 3;
            this.upravitButton.Text = "Upravit";
            this.upravitButton.UseVisualStyleBackColor = true;
            this.upravitButton.Click += new System.EventHandler(this.upravitClick);
            // 
            // nejlepsiButton
            // 
            this.nejlepsiButton.Location = new System.Drawing.Point(393, 112);
            this.nejlepsiButton.Name = "nejlepsiButton";
            this.nejlepsiButton.Size = new System.Drawing.Size(75, 23);
            this.nejlepsiButton.TabIndex = 4;
            this.nejlepsiButton.Text = "Nejlepší";
            this.nejlepsiButton.UseVisualStyleBackColor = true;
            this.nejlepsiButton.Click += new System.EventHandler(this.nejlepsiClick);
            // 
            // registrovatButton
            // 
            this.registrovatButton.Location = new System.Drawing.Point(393, 142);
            this.registrovatButton.Name = "registrovatButton";
            this.registrovatButton.Size = new System.Drawing.Size(75, 23);
            this.registrovatButton.TabIndex = 5;
            this.registrovatButton.Text = "Registrovat";
            this.registrovatButton.UseVisualStyleBackColor = true;
            this.registrovatButton.Click += new System.EventHandler(this.registrovatClick);
            // 
            // zrusitButton
            // 
            this.zrusitButton.Location = new System.Drawing.Point(393, 172);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(75, 23);
            this.zrusitButton.TabIndex = 6;
            this.zrusitButton.Text = "Zrušit";
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.zrusitClick);
            // 
            // konecButton
            // 
            this.konecButton.Location = new System.Drawing.Point(393, 202);
            this.konecButton.Name = "konecButton";
            this.konecButton.Size = new System.Drawing.Size(75, 23);
            this.konecButton.TabIndex = 7;
            this.konecButton.Text = "Konec";
            this.konecButton.UseVisualStyleBackColor = true;
            this.konecButton.Click += new System.EventHandler(this.konecClick);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(31, 232);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(437, 82);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 326);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.konecButton);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.registrovatButton);
            this.Controls.Add(this.nejlepsiButton);
            this.Controls.Add(this.upravitButton);
            this.Controls.Add(this.vymazButton);
            this.Controls.Add(this.pridejButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klub;
        private System.Windows.Forms.DataGridViewTextBoxColumn Goly;
        private System.Windows.Forms.Button pridejButton;
        private System.Windows.Forms.Button vymazButton;
        private System.Windows.Forms.Button upravitButton;
        private System.Windows.Forms.Button nejlepsiButton;
        private System.Windows.Forms.Button registrovatButton;
        private System.Windows.Forms.Button zrusitButton;
        private System.Windows.Forms.Button konecButton;
        private System.Windows.Forms.ListView listView1;
    }
}


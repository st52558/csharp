using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageLogger
{
    public partial class Form1 : Form
    {
        EventHandler SendTextToLeftOutputEventHander;
        EventHandler SendTextToRightOutputEventHander;
        public Form1()
        {
            SendTextToRightOutputEventHander = new EventHandler(SendTextToRightOutput);
            SendTextToLeftOutputEventHander = new EventHandler(SendTextToLeftOutput);
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            if (LeftPanelCheckBox.Checked)
            {
                this.LeftPanelTextBox.Text += InputTextBox.Text + "\r\n";
            }
            if (RightPanelCheckBox.Checked)
            {
                this.RightPanelTextBox.Text += InputTextBox.Text + "\r\n";
            }
        }

        private void SendTextToLeftOutput(object sender, EventArgs e)
        {
            LeftPanelTextBox.Text += InputTextBox.Text + "\r\n";
        }

        private void SendTextToRightOutput(object sender, EventArgs e)
        {
            RightPanelTextBox.Text += InputTextBox.Text + "\r\n";
        }

        private void OutputEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EventHandler checkedChangedEventHandler = null;
            if (sender == LeftPanelCheckBox)
            {
                checkedChangedEventHandler = SendTextToLeftOutputEventHander;
            }
            else if (sender == RightPanelCheckBox)
            {
                checkedChangedEventHandler = SendTextToRightOutputEventHander;
            }

            if ((sender as CheckBox).Checked)
            {
                button1.Click += checkedChangedEventHandler;
            }
            else
            {
                button1.Click -= checkedChangedEventHandler;
            }

        }
    }
}

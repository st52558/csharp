using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv04Hra
{
    public partial class Form1 : Form
    {
        Random random;
        Stats stats;
        public Form1()
        {
            random = new Random();
            stats = new Stats();
            InitializeComponent();
            this.Name = Properties.Resources.Title;
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameListBox.Items.Add((Keys)random.Next(65,90));
            if (gameListBox.Items.Count > 6)
            {
                timer1.Stop();
                gameListBox.Items.Clear();
                gameListBox.Items.Add("Game over!");
            }
        }

        private void gameListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameListBox.Items.Contains(e.KeyCode)){
                gameListBox.Items.Remove(e.KeyCode);
                gameListBox.Refresh();
                stats.Update(true);
            } else
            {
                stats.Update(false);
            }
            if (timer1.Interval > 400)
            {
                timer1.Interval -= 60;
            } else if (timer1.Interval > 250)
            {
                timer1.Interval -= 15;
            } else if (timer1.Interval > 150)
            {
                timer1.Interval -= 8;
            }

            if (timer1.Interval > 800)
            {
                progressBar.Value = 800;
            } else if (timer1.Interval < 0)
            {
                progressBar.Value = 0;
            } else
            {
                progressBar.Value = 800 - timer1.Interval;
            }
            correctLabel.Text = "Correct: " + stats.Correct;
            missedLabel.Text = "Missed: " + stats.Missed;
            accurancyLabel.Text = "Accurancy: " + stats.Accurancy;
        }
    }
}

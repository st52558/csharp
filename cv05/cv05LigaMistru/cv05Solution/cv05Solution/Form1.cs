using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv05Solution
{
    public partial class Form1 : Form
    {
        Hraci hra;
        public Form1()
        {
            InitializeComponent();
            hra = new Hraci();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pridejClick(object sender, EventArgs e)
        {
            hra.Pridej(new Hrac("jmeno", FotbalovyKlub.Arsenal, 2));
        }

        private void vymazClick(object sender, EventArgs e)
        {

        }

        private void upravitClick(object sender, EventArgs e)
        {

        }

        private void nejlepsiClick(object sender, EventArgs e)
        {

        }

        private void registrovatClick(object sender, EventArgs e)
        {

        }

        private void zrusitClick(object sender, EventArgs e)
        {

        }

        private void konecClick(object sender, EventArgs e)
        {

        }

        private void AktualizaceTabulky()
        {
            for (int i = 0; i < hra.Pocet; i++)
            {
                hra[i].Jmeno;
            }
        }
    }
}

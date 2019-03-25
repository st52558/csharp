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
    public partial class nejlepsiKluby : Form
    {
        public nejlepsiKluby(Hraci pole)
        {
            InitializeComponent();
            int[] goly = new int[6];
            for (int i = 0; i < pole.Pocet; i++)
            {
                
                goly[(int)pole[i].Klub] += pole[i].GolPocet;
            }

            int maxGolu = 0;
            for (int i = 0; i < goly.Length; i++)
            {
                if (goly[i] == maxGolu)
                {
                    klubyBox.Items.Add(FotbalovyKlubInfo.DejNazev(i));
                } else if (goly[i] > maxGolu)
                {
                    klubyBox.Items.Clear();
                    klubyBox.Items.Add(FotbalovyKlubInfo.DejNazev(i));
                    maxGolu = goly[i];
                }
            }
            golyBox.Text = maxGolu.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
        bool handler = false;
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
            pridaniHraceForm.pridaniHraceForm pridaniDialog = new pridaniHraceForm.pridaniHraceForm();

            if (pridaniDialog.ShowDialog(this) == DialogResult.OK)
            {
                hra.Pridej(new Hrac(pridaniDialog.jmenoTextBox.Text, (FotbalovyKlub)pridaniDialog.tymComboBox.SelectedValue, int.Parse(pridaniDialog.golyTextBox.Text)));
                
            }
            pridaniDialog.Dispose();
            AktualizaceTabulky();
        }

        private void vymazClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                hra.Vymaz(row.Index);
            }
            AktualizaceTabulky();
        }
        
        private void upravitClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                
           
            pridaniHraceForm.pridaniHraceForm pridaniDialog = new pridaniHraceForm.pridaniHraceForm(hra[row.Index].Jmeno, hra[row.Index].Klub, hra[row.Index].GolPocet);

            if (pridaniDialog.ShowDialog(this) == DialogResult.OK)
            {
                    hra.Vymaz(row.Index);
                    hra.Pridej(new Hrac(pridaniDialog.jmenoTextBox.Text, (FotbalovyKlub)pridaniDialog.tymComboBox.SelectedValue, int.Parse(pridaniDialog.golyTextBox.Text)));

            }
            pridaniDialog.Dispose();
            }
            AktualizaceTabulky();
        }

        private void nejlepsiClick(object sender, EventArgs e)
        {
            nejlepsiKluby klubyDialog = new nejlepsiKluby(hra);
            klubyDialog.Show();
        }

        private void registrovatClick(object sender, EventArgs e)
        {
            handler = true;
            listView1.Items.Add("Handler byl zapnut!");
        }

        private void zrusitClick(object sender, EventArgs e)
        {
            handler = false;
            listView1.Items.Add("Handler byl vypnut!");
        }

        private void konecClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AktualizaceTabulky()
        {
            gridView.Rows.Clear();
            for (int i = 0; i < hra.Pocet; i++)
            {
                gridView.Rows.Add(hra[i].Jmeno, hra[i].Klub, hra[i].GolPocet);
            }
            
        }
    }
}

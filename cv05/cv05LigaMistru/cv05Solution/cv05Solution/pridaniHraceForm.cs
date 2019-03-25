using cv05Solution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pridaniHraceForm
{
    public partial class pridaniHraceForm : Form
    {
        public pridaniHraceForm()
        {
            
            InitializeComponent();
            tymComboBox.DataSource = Enum.GetValues(typeof(FotbalovyKlub)).Cast<FotbalovyKlub>();
        }

        public pridaniHraceForm(string jmeno, FotbalovyKlub klub, int goly)
        {

            InitializeComponent();
            tymComboBox.DataSource = Enum.GetValues(typeof(FotbalovyKlub)).Cast<FotbalovyKlub>();
            for (int i = 0; i < tymComboBox.Items.Count; i++)
            {
                if (tymComboBox.Items[i].Equals(klub))
                {
                    tymComboBox.SelectedIndex = i;
                    break;
                }
                
            }
            jmenoTextBox.Text = jmeno;
            golyTextBox.Text = goly.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

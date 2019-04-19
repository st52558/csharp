using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void DrawEllipseRectangle()
        {
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();

            Pen p = new Pen(Color.Black, 3);
            Rectangle r = new Rectangle(200, 200, 200, 200);
            formGraphics.DrawRectangle(p, r);
            //formGraphics.FillRectangle(myBrush, new Rectangle(200, 200, 200, 300));
            myBrush.Dispose();
            formGraphics.Dispose();
            
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
        }
    }
}

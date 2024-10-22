using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, button1.Width - 2, button1.Height - 2);
            button1.Region = new Region(p);

            GraphicsPath q = new GraphicsPath();
            q.AddEllipse(1, 1, button2.Width - 2, button2.Height - 2);
            button2.Region = new Region(p);
            */
        }
        // Tai yra įvykio tvarkyklė mygtukui. Ją redaguosime, kad atidarytų Form2.
        private void button1_Click(object sender, EventArgs e)
        {
            // Sukuriame naują Form2 egzempliorių
            Form2 form2 = new Form2();

            // Rodome Form2 langą
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            // Rodome Form4 langą
            form4.Show();
            this.Hide();
        }
    }
}

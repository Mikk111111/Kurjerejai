using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        // Šis metodas išlieka, jei jis naudojamas vėliau.
        private void label1_Click(object sender, EventArgs e)
        {

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

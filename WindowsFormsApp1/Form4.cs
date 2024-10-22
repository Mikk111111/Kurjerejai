using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            button2.Enabled = false;  // Initially disable button2
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Check if the text length is exactly 8
            if (textBox2.Text.Length == 8)
            {
                button2.Enabled = true;  // Enable button2
            }
            else
            {
                button2.Enabled = false; // Disable button2
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is not a number or backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Play the error sound
                SystemSounds.Hand.Play();
                e.Handled = true;  // Ignore the input
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new instance of Form5
            Form5 form5 = new Form5();

            // Show Form5
            form5.Show();
            this.Hide();
        }
    }
}
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            // Set the TextBox text alignment to center
            textBox1.TextAlign = HorizontalAlignment.Center;

            // Generate a random 8-digit code and add it to the ListView
            AddRandomCodeToListView();
        }

        // Method to generate a random 8-digit code and add it to the ListView
        private void AddRandomCodeToListView()
        {
            // Create a Random object
            Random random = new Random();

            // Generate a random 8-digit number
            int randomCode = random.Next(10000000, 99999999); // Random number between 10000000 and 99999999

            // Display the random code in textBox1
            textBox1.Text = randomCode.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sukuriame naują Form5 egzempliorių
            Form5 form5 = new Form5();

            // Rodome Form5 langą
            form5.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
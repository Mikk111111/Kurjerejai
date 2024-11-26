using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient; // Add MySQL package for database operations

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear any previous error messages
            label5.Text = "";
            label5.ForeColor = Color.Black;  // Reset font color to black

            // Validate Name (only letters)
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string email = textBox3.Text;
            string phoneNumber = textBox4.Text;

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(name))
            {
                label5.Text = "Name is required!";
                label5.ForeColor = Color.Black;  // Set the error message color to black
                label5.Font = new Font(label5.Font.FontFamily, 48);  // Set font size to 48pt
                return;
            }

            else if (string.IsNullOrWhiteSpace(surname))
            {
                label5.Text = "Surname is required!";
                label5.ForeColor = Color.Black;  // Set the error message color to black
                label5.Font = new Font(label5.Font.FontFamily, 48);  // Set font size to 48pt
                return;
            }

            else if(string.IsNullOrWhiteSpace(email))
            {
                label5.Text = "Email is required!";
                label5.ForeColor = Color.Black;  // Set the error message color to black
                label5.Font = new Font(label5.Font.FontFamily, 48);  // Set font size to 48pt
                return;
            }

            else if(string.IsNullOrWhiteSpace(phoneNumber))
            {
                label5.Text = "Phone number is required!";
                label5.ForeColor = Color.Black;  // Set the error message color to black
                label5.Font = new Font(label5.Font.FontFamily, 48);  // Set font size to 48pt
                return;
            }

            // Check if Name and Surname only contain letters
            else if(!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                label5.Text = "Name must only contain letters!";
                label5.ForeColor = Color.Red;  // Set the error message color to red
                label5.Font = new Font(label5.Font.FontFamily, 48);  // Set font size to 48pt
                return;
            }

            else if(!Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                label5.Text = "Surname must only contain letters!";
                label5.ForeColor = Color.Red;
                label5.Font = new Font(label5.Font.FontFamily, 48);
                return;
            }

            // Check if Email contains '@' symbol
            else if(!email.Contains("@"))
            {
                label5.Text = "Email must contain '@' symbol!";
                label5.ForeColor = Color.Red;
                label5.Font = new Font(label5.Font.FontFamily, 48);
                return;
            }

            // Check if PhoneNumber starts with '+' symbol
            else if(!phoneNumber.StartsWith("+"))
            {
                label5.Text = "Phone number must start with a '+' symbol!";
                label5.ForeColor = Color.Red;
                label5.Font = new Font(label5.Font.FontFamily, 48);
                return;
            }
            else
            {
                Class1.UserName = name;
                Class1.UserSurname = surname;
                Class1.UserEmail = email;
                Class1.UserPhoneNumber = phoneNumber;

                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
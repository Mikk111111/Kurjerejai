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
using MySql.Data.MySqlClient;
using System.Xml.Linq;

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
            // Get the entered code from textBox2
            string enteredCode = textBox2.Text;

            // Connection string to the database
            string ConnectionString = "Server=sql7.freesqldatabase.com;Database=sql7747669;Uid=sql7747669;Pwd=suHFe6f92Y;Port=3306;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Query to check if the entered code exists in the database
                    string query = "SELECT COUNT(*) FROM Users WHERE GeneratedCode = @GeneratedCode";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameter to the query
                        command.Parameters.AddWithValue("@GeneratedCode", enteredCode);

                        // Execute the query and get the result
                        int codeExists = Convert.ToInt32(command.ExecuteScalar());

                        if (codeExists > 0)
                        {
                            // Create a new instance of Form5
                            Form5 form5 = new Form5();

                            // Show Form5
                            form5.Show();
                            this.Hide();
                        }
                        else
                        {
                            label2.Text = "Invalid code. Please try again.";
                            label2.ForeColor = Color.Red;  // Set the error message color to black
                            label2.Font = new Font(label2.Font.FontFamily, 24);  // Set font size to 48pt  
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Handle MySQL-specific errors
                MessageBox.Show($"MySQL Error: {mysqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general errors
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

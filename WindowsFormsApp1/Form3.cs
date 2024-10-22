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
    public partial class Form3 : Form
    {
        // Dictionary to map street names to resource images
        private Dictionary<string, Bitmap> streetImageMap;

        public Form3()
        {
            InitializeComponent();

            // Initialize street names and images
            string[] streets = {
                "Gedimino pr.",
                "Pilies g.",
                "Vokiečių g.",
                "Švitrigailos g.",
                "Ozo g.",
                "Konstitucijos pr.",
                "A. Jakšto g.",
                "Mindaugo g.",
                "Laisvės pr.",
                "J. Basanavičiaus g."
            };
            // Add the street names to the ListBox
            listBox2.Items.AddRange(streets);

            // Initialize the dictionary that maps street names to images from resources
            InitializeStreetImageMap();
        }

        // Method to populate the dictionary with street names and corresponding images from resources
        private void InitializeStreetImageMap()
        {
            // Map street names to images stored in Resources
            streetImageMap = new Dictionary<string, Bitmap>
            {
                { "Gedimino pr.", Properties.Resources.gedimino },
                { "Pilies g.", Properties.Resources.pilies },
                { "Vokiečių g.", Properties.Resources.vokieciu },
                { "Švitrigailos g.", Properties.Resources.svitrigailos },
                { "Ozo g.", Properties.Resources.ozo },
                { "Konstitucijos pr.", Properties.Resources.konstitucijos },
                { "A. Jakšto g.", Properties.Resources.jaksto },
                { "Mindaugo g.", Properties.Resources.mindaugo },
                { "Laisvės pr.", Properties.Resources.laisves },
                { "J. Basanavičiaus g.", Properties.Resources.basanaviciaus }
            };
        }

        // Event handler for when the selected index in listBox1 changes
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected street name
            string selectedStreet = listBox2.SelectedItem.ToString();

            // Check if the selected street has a corresponding image in resources
            if (streetImageMap.ContainsKey(selectedStreet))
            {
                // Load the image from resources and display it in the PictureBox
                pictureBox2.Image = streetImageMap[selectedStreet];

                // Enable the button now that something is selected
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show($"No image available for {selectedStreet}");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sukuriame naują Form6 egzempliorių
            Form6 form6 = new Form6();

            // Rodome Form5 langą
            form6.Show();
            this.Hide();
        }
    }
}
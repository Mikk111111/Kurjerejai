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
    public partial class Form5 : Form
    {
        private Timer closeTimer;

        public Form5()
        {
            InitializeComponent();

            // Initialize and configure the Timer
            closeTimer = new Timer();
            closeTimer.Interval = 10000; // 10 seconds = 10000 milliseconds
            closeTimer.Tick += CloseTimer_Tick; // Event handler for the Timer Tick event
            closeTimer.Start(); // Start the timer
        }

        // Event handler for the Timer Tick event
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop(); // Stop the timer

            // Close the form and exit the application
            Application.Exit();
        }
    }
}

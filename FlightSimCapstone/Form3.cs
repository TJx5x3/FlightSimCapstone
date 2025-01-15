using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;

namespace FlightSimCapstone
{
    public partial class Form3 : Form
    {
        SimConnect simconnect = null;
        const int WM_USER_SIMCONNECT = 0x0402;

        // Start process with parameters:
        // https://stackoverflow.com/questions/5766574/start-a-process-with-parameters
        private void launchFlightSim()
        {
            try
            {
                string fsDevModePath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator\FlightSimulator.exe";

                // Launch exe
                Process.Start(fsDevModePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start FS DevMode");
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

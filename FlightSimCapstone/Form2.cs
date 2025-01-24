// Secret Dev Menu
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace FlightSimCapstone
{
    public partial class Form2 : Form
    {
        // Null instance of utility form
        // https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
        
        private UtilityForm utilityForm = null;
        private Timer valueTimer = null; // Timer to update retrieved SimConnect values


        public Form2()
        {
            InitializeComponent();

            valueTimer = new Timer();
            valueTimer.Interval = 1000; // every 1 second
            valueTimer.Tick += ValueTimer_Tick;
            valueTimer.Start();
        }

        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.timer?view=windowsdesktop-9.0
        public Form2(Form callingUtilityForm)
        {
            utilityForm = callingUtilityForm as UtilityForm;
            InitializeComponent();

            valueTimer = new Timer();
            valueTimer.Interval = 1000; // every 1 second
            valueTimer.Tick += ValueTimer_Tick;
            valueTimer.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /**
         * Test Connection to SimConnect
         */
        private void button1_Click(object sender, EventArgs e)
        {
            bool connectStatus = SimConnectUtility.connect_simconnect();

            if (connectStatus)
                this.utilityForm.appendAppConsole("SimConnect established!", Color.LightGreen);
            else
                this.utilityForm.appendAppConsole("Could not connect to SimConnect", Color.Yellow);
        }


        // Test retrieval of Altemeter data
        private void button2_Click(object sender, EventArgs e)
        {
            SimConnectUtility.printAltemeter();
        }

        public void updateAltimeterValue(string value)
        {
            AltimeterValue.Text = value;
        }


        private void ValueTimer_Tick(object sender, EventArgs e)
        {
            AltimeterValue.Text = $"{SimConnectUtility.AltimeterValue}"; // Formatted string
            Console.WriteLine($"{SimConnectUtility.AltimeterValue}");

            SimConnectUtility.refreshAltimeterValue();

            Console.WriteLine("tick\n");
        }

        protected void CloseHandler(object sender, FormClosingEventArgs e)
        {
            
            valueTimer.Stop();
            valueTimer.Dispose();
            base.OnFormClosing(e);
        }
    }
}

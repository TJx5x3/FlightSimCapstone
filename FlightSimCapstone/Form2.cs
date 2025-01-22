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

namespace FlightSimCapstone
{
    public partial class Form2 : Form
    {
        // Null instance of utility form
        // https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
        
        private UtilityForm utilityForm = null;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form callingUtilityForm)
        {
            utilityForm = callingUtilityForm as UtilityForm;
            InitializeComponent();
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
    }
}

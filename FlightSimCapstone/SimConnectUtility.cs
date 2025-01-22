using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


// https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/Programming_SimConnect_Clients_using_Managed_Code.htm
// https://forums.flightsimulator.com/t/c-simconnect-error/324090
namespace FlightSimCapstone
{
    public static class SimConnectUtility
    {
        // Initialize SimConnect
        static SimConnect simconnect = null;
        const int WM_USER_SIMCONNECT = 0x0402;
        public static IntPtr windowHandle;


        // Test Connection to SimConnect
        // Currently attempts connection, then disconnects
        public static bool connect_simconnect()
        {
            try
            {
                // Open SimConnect client
                simconnect = new SimConnect("Managed Data Request", windowHandle, WM_USER_SIMCONNECT, null, 0);
                MessageBox.Show("SimcConnect Connected!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (COMException ex)
            {
                MessageBox.Show("SimcConnect not connected!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/Programming_SimConnect_Clients_using_Managed_Code.htm
            if (simconnect != null)
            {
                simconnect.Dispose();
                simconnect = null;
            }

            return true;
        }
    }
}

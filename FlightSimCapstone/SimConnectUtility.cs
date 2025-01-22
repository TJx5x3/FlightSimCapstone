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
        static IntPtr windowHandle;

        // https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Events_And_Data/SimConnect_RequestDataOnSimObject.htm
        private enum Requests
        {
            Altimeter
        }

        private enum Definitions
        {
            AltimeterData
        }

        struct AltimeterData
        {
            public double AltimeterReading; // Altimeter reading in feet
        }
            
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct AltitudeStruct
        {
            public double altitude;
        }

        public static void Simconnect_OnRecvSimobjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            // If no simconnection
            if (simconnect == null)
                return;

            if ((Requests)data.dwRequestID == Requests.Altimeter)
            {
                AltimeterData altimeter = (AltimeterData)data.dwData[0];
                Console.WriteLine($"Altimeter Reading: {altimeter.AltimeterReading} feet");
            }
        }

        public static void printAltemeter()
        {
            if(connect_simconnect())
            { 
                simconnect.AddToDataDefinition(Definitions.AltimeterData, "Indicated Altitude", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.RegisterDataDefineStruct<AltimeterData>(Definitions.AltimeterData);

                // Request Altimeter value
                simconnect.RequestDataOnSimObject(Requests.Altimeter, Definitions.AltimeterData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

                // Handle SimConnect events
                simconnect.OnRecvSimobjectData += Simconnect_OnRecvSimobjectData;

                simconnect.ReceiveMessage();
            }
        }

        // Test Connection to SimConnect
        // Currently attempts connection, then disconnects
        public static bool connect_simconnect()
        {
            // Attempt to create instance of SimConnect if no instance found
            if (simconnect == null)
            {
                try
                {
                    // Open SimConnect client
                    simconnect = new SimConnect("Managed Data Request", windowHandle, WM_USER_SIMCONNECT, null, 0);
                    MessageBox.Show("SimcConnect Connected!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Map Simconnect events upon successful SimConnect Connection
                    simconnect.OnRecvSimobjectData += Simconnect_OnRecvSimobjectData;
                    return true;
                }
                catch (COMException ex)
                {
                    MessageBox.Show("SimcConnect not connected!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else // If Simconnect instance already found (App is already connected to simconnect)
            {
                return true;
            }
        }

        /**
         * Disconnect from SimConnect
         */ 
        public static bool disconnect_simconnect()
        {
            // https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/Programming_SimConnect_Clients_using_Managed_Code.htm
            if (simconnect != null)
            {
                simconnect.Dispose();
                simconnect = null;
            }
            MessageBox.Show("Terminated SimConnect Session", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }
    }
}

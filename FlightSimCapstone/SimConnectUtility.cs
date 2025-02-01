/* USE PASCAL CASE (not cammel case) For method names
 * 
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
 *  Attribute Properties syntax - like getter and setter for class attribute(these are cool)
 *  https://www.w3schools.com/cs/cs_properties.php
 *  
 */

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

        // Tweak this, get proper get/set logic
        public static bool connectionStatus 
        { 
            get { return (simconnect != null); } 
        }

        // Retrieved simconnect data attributes
        private static double _altimeterValue = 0.0;
        private static double _headingIndicatorValue = 0.0;

        // Retrieved simconnect data attributes.
        public static double AltimeterValue 
        {
            get { return _altimeterValue; }
            private set { _altimeterValue = value; } 
        }

        public static double HeadingIndicatorValue
        {
            get { return _headingIndicatorValue; }
            private set { _headingIndicatorValue = value; }
        }


        // https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Events_And_Data/SimConnect_RequestDataOnSimObject.htm
        private enum Requests
        {
            Altimeter,
            HeadingIndicator
        }

        private enum Definitions
        {
            AltimeterData,
            HeadingIndicatorData
        }
    

        /// <summary>
        /// This method requests data from SimConnect 
        /// </summary>
        /// 
        /// https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Structures_And_Enumerations/SIMCONNECT_RECV_SIMOBJECT_DATA.htm
        /// 
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public static void Simconnect_OnRecvSimobjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            // If no simconnection
            if (simconnect == null)
                return;

            // Request Altimeter data. 
            if ((Requests)data.dwRequestID == Requests.Altimeter)
            {
                AltimeterData altimeter = (AltimeterData)data.dwData[0];
                AltimeterValue = altimeter.AltimeterReading; 
                Console.WriteLine($"Altimeter Reading: {altimeter.AltimeterReading} feet");
            }

            // Request Heading Indicator Data
            if ((Requests)data.dwRequestID == Requests.HeadingIndicator)
            {
                HeadingIndicatorData headingindicator = (HeadingIndicatorData)data.dwData[0];
                HeadingIndicatorValue = headingindicator.HeadingIndicatorReading;
                Console.WriteLine($"Heading Indicator Reading: {headingindicator.HeadingIndicatorReading} deg");
            }
        }

        /// <summary>
        /// Print Altimeter data to console
        /// </summary>
        public static void initializeSimReadings()
        {
            // NOTE: Pass Simulation variable as string 
            // in 2nd param in AddToDataDefinition 
            // https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_System_Variables.htm
            if (connect_simconnect())
            { 
                // Define Altimeter data
                simconnect.AddToDataDefinition(Definitions.AltimeterData, "Indicated Altitude", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.RegisterDataDefineStruct<AltimeterData>(Definitions.AltimeterData);

                // Define Heading Indicator data
                simconnect.AddToDataDefinition(Definitions.HeadingIndicatorData, "Plane Heading Degrees Gyro", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.RegisterDataDefineStruct<HeadingIndicatorData>(Definitions.HeadingIndicatorData);

                // Request Altimeter value
                simconnect.RequestDataOnSimObject(Requests.Altimeter, Definitions.AltimeterData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

                // Request Heading Indicator value
                simconnect.RequestDataOnSimObject(Requests.HeadingIndicator, Definitions.HeadingIndicatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

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
         * Disconnect from SimConnect client
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

        // Request SimConnect Data
        // TODO: This is not specific to altimeter.
        public static void refreshSimconnect()
        {
            if(simconnect != null)
            {
                simconnect.ReceiveMessage();
            }
        }


    }
}

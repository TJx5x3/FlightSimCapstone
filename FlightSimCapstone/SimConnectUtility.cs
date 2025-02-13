/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/3/25
 *  Class           :   SimConnectUtility.cs
 *  Description     :   This module handles data communication with the Microsoft
 *                      Flight Simulator API (SimConnect). Datatypes, enums, and 
 *                      
 *                      
 *                      
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 *  
 *  Proper attribute initialization in C#
 *  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
 *
 *  Attribute Properties syntax:
 *  https://www.w3schools.com/cs/cs_properties.php
 *  
 *  Establishing and terminating connection to SimConnect Client
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/Programming_SimConnect_Clients_using_Managed_Code.htm
 *  
 *  Troubleshooting missing DLL Dependencies
 *  https://forums.flightsimulator.com/t/c-simconnect-error/324090
 *  
 *  Requesting data from SimConnect API
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Events_And_Data/SimConnect_RequestDataOnSimObject.htm
 *  
 *  Handling SimConnect data transmission upon successful SimConnect Connection:
 *  https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/API_Reference/Structures_And_Enumerations/SIMCONNECT_RECV_SIMOBJECT_DATA.htm
 **********************************************************************************/

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


namespace FlightSimCapstone
{
    /// <summary>
    /// This class provides various methods to handle the creation, termination, and data handling
    /// of the SimConnect client.
    /// </summary>
    /// <remarks>
    /// This class declares the datatypes of all values retrieved from SimConnect,
    /// and maps 
    /// </remarks>
    public static class SimConnectUtility
    {
        // Initialize SimConnect
        static SimConnect simconnect = null;
        const int WM_USER_SIMCONNECT = 0x0402;
        
        // Simconnect Window Handler (Necessary for establishing SimConnect Connection)
        static IntPtr windowHandle;
        private static bool connectionStatus = false;

        // Tweak this, get proper get/set logic
        // Getter/setter
        public static bool ConnectionStatus 
        { 
            get { return (simconnect != null); }
            set { connectionStatus = false; }
        }

        // Retrieved simconnect data attributes
        private static double altimeterValue = 0.0;
        private static double headingIndicatorValue = 0.0f;

        // getter/setter property for altimeterValue
        public static double AltimeterValue 
        {
            get { return altimeterValue; }
            private set { altimeterValue = value; } 
        }

        // Getter/setter property for headingIndicatorValue
        public static double HeadingIndicatorValue
        {
            get { return headingIndicatorValue; }
            private set { headingIndicatorValue = value; }
        }

        // Enumerations for SimConnect requests
        private enum Requests
        {
            Altimeter,
            HeadingIndicator
        }
        
        // Enumerations for Definitions 
        private enum Definitions
        {
            AltimeterData,
            HeadingIndicatorData
        }


        /// <summary>
        /// This method specifies what data the SimConnect Client should expect to recieve
        /// from Microsoft Flight Simulator
        /// </summary>
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
        /// This method initializes the process of reading Microsoft Flight Simulator data.
        /// </summary>
        /// <remarks>
        /// Declarations are defined to Simconnect environment variables.
        /// Retrieved data mapped to declared structs (See SimConnectData.cs)
        /// </remarks>
        public static void InitializeSimReadings()
        {
            // NOTE: Pass Simulation variable as string 
            // in 2nd param in AddToDataDefinition 
            // https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Aircraft_SimVars/Aircraft_System_Variables.htm
            if (!ConnectSimconnectClient())
                return;
            
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

            // Register Simconnect OnRecvSimobjectData event
            simconnect.OnRecvSimobjectData += Simconnect_OnRecvSimobjectData;

            // Recieve SimConnect data.
            simconnect.ReceiveMessage();
        }

        // Test Connection to SimConnect
        // Currently attempts connection, then disconnects
        /// <summary>
        /// Attempt to create an instance of SimConnect client.
        /// </summary>
        /// <returns>
        /// bool - True/False if SimConnect Client could be established
        /// </returns>
        public static bool ConnectSimconnectClient()
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

                    connectionStatus = true;
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

        /// <summary>
        /// Disconnect SimConnect Client from MSFS
        /// </summary>
        public static bool DisconnectSimconnectClient()
        {
            // Dispose if instance of simconnect != null
            if (simconnect != null)
            {
                simconnect.Dispose();
                simconnect = null;
            }
            connectionStatus = false;
            MessageBox.Show("Terminated SimConnect Session", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        /// <summary>
        /// Refresh values retrieved from SimConnect
        /// </summary>
        /// <remarks>
        /// This method should called on each timer itteration of Form objects
        /// </remarks>
        public static void RefreshSimconnect()
        {
            if(simconnect != null)
            {
                simconnect.ReceiveMessage();
            }
        }
    }
}

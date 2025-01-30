/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   1/28/25
 *  Class           :   BaseDependencyUtility.cs
 *  Description     :   This module holds several methods used to check software
 *                      and hardware dependencies. These methods are called when
 *                      an instance of UtilityForm is instantiated.
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 *
 *  To check if file or directory exists:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.exists?view=net-9.0
 * 
 **********************************************************************************/

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;


namespace FlightSimCapstone
{
    /// <summary>
    /// This module holds several methods used to check software and hardware
    /// dependencies. These methods are called when an instance of UtilityForm
    /// is instantiated.
    /// </summary>
    public static class BaseDependencyUtility
    {
        // Locate the Microsoft FLight Sim directory
        // NOTE: This will only work if MSFS 2020 is installed using Steam
        private const string steamFlightSimPath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator";
        private const string msfsSdkPath= @"C:\MSFS SDK";
        private const string simConnectDllPath = @"C:\MSFS SDK\SimConnect SDK\lib\SimConnect.dll";
        private const string simConnectNETDllPath = @"C:\MSFS SDK\SimConnect SDK\lib\managed\Microsoft.FlightSimulator.SimConnect.dll";
        private const string flightSimExePath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator\FlightSimulator.exe";

        // Path to SimConnect.dll
        // Default to steamFlightSimPath
        private const string simConnectPath = steamFlightSimPath;

        /// <summary>
        /// Return bool if Flight Sim Directory can be located
        /// </summary>
        /// <returns></returns>
        public static bool locateFlightSim()
        {
            return Directory.Exists(steamFlightSimPath);
        }

        /// <summary>
        /// Return bool if Flight Sim SDK can be located
        /// </summary>
        /// <returns></returns>
        public static bool locateFlightSimSDK()
        {
            return Directory.Exists(msfsSdkPath);
        }

        /// <summary>
        /// Return bool if Flight Sim DLL can be located
        /// </summary>
        /// <returns></returns>
        public static bool locateSimConnectDll()
        {
            return File.Exists(simConnectDllPath);
        }

        /// <summary>
        /// Return bool if Flight Sim .NET DLL can be located
        /// </summary>
        /// <returns></returns>
        public static bool locateSimConnectNETDll()
        {
            return File.Exists(simConnectNETDllPath);
        }

        /// <summary>
        /// Return the file path to FlightSim.exe
        /// </summary>
        /// <returns></returns>
        public static string getFlightSimExePath()
        {
            return flightSimExePath;
        }

        /// <summary>
        /// Return File Path to SimConnect.DLL
        /// </summary>
        /// <returns></returns>
        public static string getSimConnectDLLPath()
        {
            return simConnectPath;
        }


        /*
        ////////////////////
        // FROM Prototype application created in Fall 2024 semester
        ////////////////////
        private bool CheckArduinoMega(string vid, string pid)
        {
            try
            {
                // Query all USB devices
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE 'USB%'");

                // Search all detected USB devices for match
                foreach (var device in searcher.Get())
                {
                    string deviceId = device["DeviceID"]?.ToString();
                    string name = device["Name"]?.ToString();

                    // Check if VID and PID match retrieved DeviceID and Name
                    if (deviceId != null && deviceId.Contains($"VID_{vid}") && deviceId.Contains($"PID_{pid}"))
                    {
                        return true; // Arduino Mega found
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"Error detecting Arduino Mega: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // Arduino Mega not found

        
        }
        */
    }
}

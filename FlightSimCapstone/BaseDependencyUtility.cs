/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/1/25
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
 *  To check for USB Hardware devices:
 *  ManagementObjectSearcher - Needs System.Management.dll    ----- NOTE: This may break install wizard if not added as dependency
 *  https://learn.microsoft.com/en-us/dotnet/api/system.management.managementobjectsearcher?view=net-9.0-pp
 * 
 *  ManagementObject.Get() documentation:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.management.managementobjectsearcher.get?view=net-9.0-pp
 * 
 *  Identify Arduino Mega 2560 Vendor and Product ID:
 *  https://forum.arduino.cc/t/whats-the-vid-and-pid/305399
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
using System.Security.Cryptography;


namespace FlightSimCapstone
{
    /// <summary>
    /// This module holds several methods used to check software and hardware
    /// dependencies. These methods are called when an instances of forms are created,
    /// or when Button events are fired. 
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

        // Arduino Vendor ID and Product ID
        // These values are used to detect the connected Arduino device
        // See: https://forum.arduino.cc/t/whats-the-vid-and-pid/305399
        private const string arduinoPID = "PID_0042";
        private const string arduinoVID = "VID_2341";

        public static UtilityForm UtilityForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Return bool if Flight Sim Directory can be located
        /// </summary>
        /// <returns>bool</returns>
        public static bool LocateFlightSim()
        {
            return Directory.Exists(steamFlightSimPath);
        }

        /// <summary>
        /// Return bool if Flight Sim SDK can be located
        /// </summary>
        /// <returns>bool</returns>
        public static bool LocateFlightSimSDK()
        {
            return Directory.Exists(msfsSdkPath);
        }

        /// <summary>
        /// Return bool if Flight Sim DLL can be located
        /// </summary>
        /// <returns>bool</returns>
        public static bool LocateSimConnectDll()
        {
            return File.Exists(simConnectDllPath);
        }

        /// <summary>
        /// Return bool if Flight Sim .NET DLL can be located
        /// </summary>
        /// <returns>bool</returns>
        public static bool LocateSimConnectNETDll()
        {
            return File.Exists(simConnectNETDllPath);
        }

        /// <summary>
        /// Return the file path to FlightSim.exe
        /// </summary>
        /// <returns>string</returns>
        public static string GetFlightSimExePath()
        {
            return flightSimExePath;
        }

        /// <summary>
        /// Return File Path to SimConnect.DLL
        /// </summary>
        /// <returns>string</returns>
        public static string GetSimConnectDLLPath()
        {
            return simConnectPath;
        }

        /// <summary>
        /// Check if Arduino device is connected to system
        /// </summary>
        /// <returns>bool</returns>
        public static bool CheckArduinoConnection()
        {
            // Retrieve Plug and play (PnP) USB Devices. Search for Arduino 
            ManagementObjectSearcher usbSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE 'USB%'");
            foreach (ManagementObject device in usbSearcher.Get())
            {
                // Get USB Device ID as string
                string deviceId = device["DeviceID"]?.ToString();
                Console.WriteLine(deviceId);   
                
                // If Device containing specified Arduino PID and VID, Arduino is connected to system.
                if (deviceId.Contains(arduinoPID) &&  deviceId.Contains(arduinoVID))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/11/25
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
 *  Identify Arduino Mega 2560 Vendor and Product ID:
 *  https://forum.arduino.cc/t/whats-the-vid-and-pid/305399
 *  
 *  Win32_PnPEntity columns:
 *  https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/win32-pnpentity
 *  
 *  Locating Device ID:
 *  https://www.anoopcnair.com/find-usb-drive-hardware-id-on-windows-11-device/
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
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace FlightSimCapstone
{
    /// <summary>
    /// Holds several methods used to check software and hardware
    /// dependencies. These methods are called when an instances of forms are created,
    /// or when Button events are fired. 
    /// </summary>
    public static class BaseDependencyUtility
    {

        // Locate the Microsoft FLight Sim directory
        // NOTE: This will only work if MSFS 2020 is installed using Steam

        /// <summary>
        /// Default Steam installation path for Microsoft Flight Simulator 2020
        /// </summary>
        private const string steamFlightSimPath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator";
        
        /// <summary>
        /// Default path for MSFS SDK installation
        /// </summary>
        private const string msfsSdkPath= @"C:\MSFS SDK";
        
        /// <summary>
        /// Default location for Simconnect.dll
        /// </summary>
        private const string simConnectDllPath = @"C:\MSFS SDK\SimConnect SDK\lib\SimConnect.dll";

        /// <summary>
        /// Default location for Microsoft.FlightSimulator.SimConnect.dll
        /// </summary>
        private const string simConnectNETDllPath = @"C:\MSFS SDK\SimConnect SDK\lib\managed\Microsoft.FlightSimulator.SimConnect.dll";

        /// <summary>
        /// Default location for Microsoft Flight Simulator executable
        /// </summary>
        private const string flightSimExePath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator\FlightSimulator.exe";

        // Path to SimConnect.dll
        // Default to steamFlightSimPath
        private const string simConnectPath = steamFlightSimPath;

        /// <summary>
        /// Arduino Vendor ID and Product ID
        /// </summary>
        /// <remarks>
        /// These values are used to detect the connected Arduino device
        /// </remarks>
        /// <see href="!:https://forum.arduino.cc/t/whats-the-vid-and-pid/305399">
        /// what's the vid and pid?
        /// ]
        private const string arduinoPID = "PID_0042";
        private const string arduinoVID = "VID_2341";


        /// <summary>
        /// Yoke Vendor ID and Product ID
        /// </summary>
        private const string yokePID = "PID_00FF";
        private const string yokeVID = "VID_068E";

        /// <summary>
        /// Rudder pedals Vendor ID and Product ID
        /// </summary>
        private const string rudderPID = "PID_B679";
        private const string rudderVID = "VID_044F";

        /// <summary>
        /// Number of display sources connected to the system.
        /// </summary>
        private static int numscreens;

        //public static UtilityForm UtilityForm
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        /// <summary>
        /// Return bool if Flight Sim Directory can be located
        /// </summary>
        /// <returns>Bool. True if MSFS is found, False if not found</returns>
        public static bool LocateFlightSim()
        {
            return Directory.Exists(steamFlightSimPath);
        }

        /// <summary>
        /// Return bool if Flight Sim SDK can be located
        /// </summary>
        /// <returns>Bool. True if SDK is found, false if not found.</returns>
        public static bool LocateFlightSimSDK()
        {
            return Directory.Exists(msfsSdkPath);
        }

        /// <summary>
        /// Return bool if Flight Sim DLL can be located
        /// </summary>
        /// <returns>Bool, True if SimConecct.dll is found, false if not found.</returns>
        public static bool LocateSimConnectDll()
        {
            return File.Exists(simConnectDllPath);
        }

        /// <summary>
        /// Return bool if Flight Sim .NET DLL can be located
        /// </summary>
        /// <returns>Bool. True if .NET dll is found, false if not found.</returns>
        public static bool LocateSimConnectNETDll()
        {
            return File.Exists(simConnectNETDllPath);
        }

        /// <summary>
        /// Return the file path to FlightSim.exe
        /// </summary>
        /// <returns>String of the file path to Microsoft Flight Simulator executable</returns>
        public static string GetFlightSimExePath()
        {
            return flightSimExePath;
        }

        /// <summary>
        /// Return File Path to SimConnect.DLL
        /// </summary>
        /// <returns>String of the file path to SimConnect.dll</returns>
        public static string GetSimConnectDLLPath()
        {
            return simConnectPath;
        }

        /// <summary>
        /// Check if Arduino device is connected to system
        /// </summary>
        /// <returns>Bool. True if arduino is detected, false if no arduino detected.</returns>
        public static bool CheckArduinoConnection()
        {
            if (ArduinoCommunicationUtility.comPort != "none" & ArduinoCommunicationUtility.comPort != null)
                return true;

            return false;
        }

        /// <summary>
        /// Check if USB Yoke is connected to system
        /// </summary>
        /// <returns>Bool. True if yoke is detected, false if not. </returns>
        public static bool CheckYokeConnection()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity"))
            {
                foreach (ManagementObject device in searcher.Get())
                {
                    // Get the PNPDeviceID property of the device
                    string pnpDeviceId = device["PNPDeviceID"]?.ToString() ?? string.Empty;

                    // Check if both the VID and PID appear in the PNPDeviceID string.
                    if (pnpDeviceId.IndexOf(yokeVID, StringComparison.OrdinalIgnoreCase) >= 0 &&
                        pnpDeviceId.IndexOf(yokePID, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        /// <summary>
        /// Check if Rudder pedals are connected to system
        /// </summary>
        /// <returns>Return true if rudder pedals are detected. False if not.</returns>
        public static bool CheckRudderPedalConnection()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity"))
            {
                foreach (ManagementObject device in searcher.Get())
                {
                    // Get the PNPDeviceID property of the device
                    string pnpDeviceId = device["PNPDeviceID"]?.ToString() ?? string.Empty;

                    // Check if both the VID and PID appear in the PNPDeviceID string.
                    if (pnpDeviceId.IndexOf(rudderVID, StringComparison.OrdinalIgnoreCase) >= 0 &&
                        pnpDeviceId.IndexOf(rudderPID, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Get the number of display sources connected to the system.
        /// </summary>
        /// <returns>int</returns>
        public static int GetNumDisplaySources()
        {
            return Screen.AllScreens.Length;
        }
    }
}

using System;
using System.Collections.Generic;
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

        // Return bool if Flight Sim Directory can be located
        public static bool locateFlightSim()
        {
            return Directory.Exists(steamFlightSimPath);
        }

        // Return bool if Flight Sim SDK can be located
        public static bool locateFlightSimSDK()
        {
            return Directory.Exists(msfsSdkPath);
        }

        // Return bool if Flight Sim DLL can be located
        public static bool locateSimConnectDll()
        {
            return File.Exists(simConnectDllPath);
        }

        // Return bool if Flight Sim .NET DLL can be located
        public static bool locateSimConnectNETDll()
        {
            return File.Exists(simConnectNETDllPath);
        }

        // Return the file path to FlightSim.exe
        public static string getFlightSimExePath()
        {
            return flightSimExePath;
        }

        // Return File Path to SimConnect.DLL
        public static string getSimConnectDLLPath()
        {
            return simConnectPath;
        }


        /*
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

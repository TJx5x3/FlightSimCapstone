
/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/18/25
 *  Class           :   ArduinoConnectionUtility.cs
 *  Description     :   This module hold logic needed to detect, and handle Arduino
 *                      serial data. 
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 *
 *  How to read serial data from Arduino Mega 2560
 *  https://forum.arduino.cc/t/reading-serial-data-from-an-arduino-in-c/79324/3
 *  
 *  Removing newline characters from a string:
 *  https://stackoverflow.com/questions/4140723/how-to-remove-new-line-characters-from-a-string
 *
 *  ManagementObject.Get() documentation:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.management.managementobjectsearcher.get?view=net-9.0-pp
 *  https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/win32-pnpentity
 *  https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/getdeviceproperties-win32-pnpentity
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;
using System.Threading;


// This class will probably be removed
namespace FlightSimCapstone
{
    /// <summary>
    /// This class contains methods used to detect, read, and handle Arduino serial data
    /// .
    /// </summary>
    public static class ArduinoCommunicationUtility
    {
        /// <summary>
        /// The COM port number for the Arduino device.
        /// This is automatically set when Initialize() is called.
        /// </summary>
        public static String comPort; // COM port number

        /// <summary>
        /// Timer to periotically retrieve updated values from the Arduino device.
        /// </summary>
        private static Timer connectionTimer = null;

        /// <summary>
        /// The serial port used to communicate with the detected Arduino device.
        /// </summary>
        public static SerialPort serialPort;

        /// <summary>
        /// The data read from the Arduino device.
        /// </summary>
        public static String serialData;


        /// <summary>
        /// A flag to check if the COM port is currently open.
        /// </summary>
        public static bool isComOpen;

        /// <summary>
        /// Arduino Communication Utility Constructor. Initializes the Arduino communication utility by calling Initialize()
        /// </summary>
        static ArduinoCommunicationUtility()
        {
            Initialize();  
        }

        //public static UtilityForm UtilityForm
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public static GraphicalInterface_Right GraphicalInterface_Right
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        /// <summary>
        /// Initialize Arduino Communication Utility
        /// </summary>
        public static void Initialize()
        {
            // Close com port if already open
            if (isComOpen)
                serialPort.Close();

            // Locate COM port for Arduino device
            comPort = locateCOMPort();
            Console.WriteLine("COM PORT: " + comPort);

            // If COM port is found, open serial port
            if (comPort != null && comPort != "none")
            {
                Console.WriteLine("Opening Port on " + comPort);

                isComOpen = true; // Set open COM flag to true

                // Open serial port with 9600 baud rate, no parity, 8 data bits, and 1 stop bit (Default values)
                serialPort = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
                serialPort.Open();

                // Event handler for serial data recieved
                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortReadEvent);

            }
            else // Otherwise , set COM flag to false
            {
                serialData = "No Arduino device found";
                isComOpen = false;
            }
        }

        /// <summary>
        /// Returns the most current line of serial data from the Arduino device.
        /// </summary>
        /// <returns>A string formatted as an int array for each analog or digital Arduino port.</returns>
        public static string GetSerialData()
        {
            return serialData;
        }

        /// <summary>
        /// Serial Data read event.
        /// Logic each time serial data is recieved.
        /// Contains logic that should be conducted each time serial data is read.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SerialPortReadEvent(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // If serial port is open, read serial data
                if (serialPort.IsOpen)
                    serialData = serialPort.ReadLine();

            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading serial data: " + ex.Message);
            }
        }

        /// <summary>
        /// Search detected COM ports for Arduino device. 
        /// Return found COM port number if Arduino device is found.
        /// </summary>
        /// <returns>The COM port number if an arduino is found. Otherwise returns "none"</returns>
        private static string locateCOMPort()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
            {
                foreach (ManagementObject device in searcher.Get())
                {
                    // Search for Device name
                    string deviceName = device["Name"]?.ToString() ?? string.Empty;

                    // Check device "Name" index for Arduino devices
                    if (deviceName.IndexOf("Arduino", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // Extract the COM port using regex
                        Match match = Regex.Match(deviceName, @"(COM\d+)");
                        if (match.Success)
                        {
                            return match.Value;
                        }
                    }
                }
            }
            return "none";
        }

        /// <summary>
        /// Close serial port if open
        /// </summary>
        public static void CloseSerialPort()
        {
            // If COM port is open, close it
            if (isComOpen)
                serialPort.Close();

            // Set COM flag to false
            isComOpen = false;
        }

        /// <summary>
        /// Cast read Arduino serial data to an array of integers
        /// </summary>
        /// <returns>int array of arduino port values</returns>
        public static int[] castSerialInput()
        {
            int[] cast = Array.ConvertAll(serialData.Split(','), int.Parse);
            return cast;
        }        
    }
}


/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/11/25
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


// This class will probably be removed
namespace FlightSimCapstone
{
    /// <summary>
    /// This class handles serial and PnP
    /// </summary>
    public static class ArduinoCommunicationUtility
    {
        public static String comPort; // COM port number
        public static bool openPort = false; // Flag to check if serial port is open

        //static SerialPort serialPort = new SerialPort("COM7", 11520, Parity.None, 8, StopBits.One);
        //static SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

        public static SerialPort serialPort;
        public static String serialData; // Data read from Arduino device

        /// <summary>
        /// Arduino Communication Utility Constructor. Creates event when data is recieved from the COM serial port
        /// </summary>
        static ArduinoCommunicationUtility()
        {
            comPort = locateCOMPort();
            Console.WriteLine("COM PORT: " + comPort);

            // If COM port is found, open serial port
            if (comPort != null && comPort != "none")
            {
                Console.WriteLine("Opening Port on " + comPort);
                serialPort = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
                serialPort.Open();
                openPort = true;

                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortReadEvent);

            }
            else serialData = "No Arduino device found";
        }

        /// <summary>
        /// Get last line read from serial port
        /// </summary>
        /// <returns></returns>
        public static string GetSerialData()
        {
            return serialData;
        }

        /// <summary>
        /// Serial Data read event.
        /// Logic each time serial data is recieved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SerialPortReadEvent(object sender, SerialDataReceivedEventArgs e)
        {
            serialData = serialPort.ReadLine();
        }

        /// <summary>
        /// Search detected COM ports for Arduino device. \n
        /// Return found COM port number if Arduino device is found.
        /// </summary>
        /// <returns></returns>
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

        public static int[] castSerialInput()
        {
            int[] cast = Array.ConvertAll(serialData.Split(','), int.Parse);
            return cast;
        }
    }
}

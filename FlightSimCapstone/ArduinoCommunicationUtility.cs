
/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/1/25
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
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


// This class will probably be removed
namespace FlightSimCapstone
{
    /// <summary>
    /// This class handles serial and PnP
    /// </summary>
    public static class ArduinoCommunicationUtility
    {
        // NOTE: Serial port is COM5 on this machine.
        // This may not be the same on other devices when packaged into 
        // installer.
        // TODO: Identify COM Ports, search for arduino.
        //      * This may require a different approach to how arduino is detected over USB
        static SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

        static String serialData; // Data read from Arduino device

        /// <summary>
        /// Arduino Communication Utility Constructor. Creates event when data is recieved from the COM serial port
        /// </summary>
        static ArduinoCommunicationUtility()
        {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortReadEvent);
            serialPort.Open();
        }

        /// <summary>
        /// Read serial data from arduino device.
        /// </summary>
        /// <returns>String - Last line read from Serial data</returns>
        public static string ReadArduinoSerialData()
        {
            string data = serialPort.ReadLine().Trim();

            serialPort.Close();
            return data;
        }

        /// <summary>
        /// Get last line read from serial port
        /// </summary>
        /// <returns></returns>
        public static string getSerialData()
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
            serialData = serialPort.ReadExisting();
        }
    }
}

// https://forum.arduino.cc/t/reading-serial-data-from-an-arduino-in-c/79324/3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


// This class will probably be removed
namespace FlightSimCapstone
{
    public static class ArduinoCommunicationUtility
    {
        // NOTE: Serial port is COM5 on this machine.
        // This may not be the same on other devices when packaged into 
        // installer.
        // TODO: Identify COM Ports, search for arduino.
        //      * This may require a different approach to how arduino is detected over USB
        static SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

        static String serialData;

        static ArduinoCommunicationUtility()
        {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortReadEvent);
            serialPort.Open();

        }

        public static string ReadArduinoSerialData()
        {
            //serialPort.Open();

            string data = serialPort.ReadLine().Trim();

            serialPort.Close();
            return data;
        }


        public static string getSerialData()
        {
            return serialData;
        }

        // https://stackoverflow.com/questions/4140723/how-to-remove-new-line-characters-from-a-string
        private static void SerialPortReadEvent(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.WriteLine(serialPort.ReadExisting());

            serialData = serialPort.ReadExisting();
        }
    }
}

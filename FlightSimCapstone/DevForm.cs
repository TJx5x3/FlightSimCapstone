
/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/1/25
 *  Class           :   DevForm.cs
 *  Description     :   This module defines the Developer Form. This is a secret
 *                      form that can be launched by pressing F6 from the Utility
 *                      Form.
 *                      
 *                      This form is to display Diagnostics and/or test features
 *                      before they are integrated into the application visible
 *                      to the end user.
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 *  
 *  Communicating between multiple Windows Forms:
 *  https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
 *  
 *  Creating a Timer to Periodically check SimConnect Values
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.timer?view=windowsdesktop-9.0
 *  
 *  Form Close handler / Event when Dev Form is closing:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.formclosing?view=windowsdesktop-9.0#system-windows-forms-form-formclosing
 *  
 *  Testing if COM Port is open:
 *  https://stackoverflow.com/questions/26487061/unauthorizedaccessexception-when-trying-to-open-a-com-port-in-c-sharp
 *  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FlightSimCapstone
{
    /// <summary>
    /// Form Object for the Developer Form. Can be accessed by
    /// pressing F6 in the Utility Form.
    /// </summary>
    /// <remarks>
    /// This form is used to display diagnostics and/or test features before
    /// they are integrated into the application visible to the end user.
    /// </remarks>
    public partial class DevForm : Form
    {
        // Null instance of utility form
        private UtilityForm utilityForm = null;

        // Timer to update retrieved SimConnect values in text fields
        private Timer valueTimer = null;

        // Serial port on COM5 to read arduino Serial Print
        private SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
        

        public DevForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overloaded constructor. Accepts instance of Utility form.
        /// 
        /// Creates a timer that ticks every 1 second.
        /// This is used to retrieve Instrumentation panel data from SimConnect.
        /// </summary>
        /// <param name="callingUtilityForm"></param>
        public DevForm(Form callingUtilityForm)
        {
            utilityForm = callingUtilityForm as UtilityForm; // Register UtilityForm Instance as previously called form
            this.FormClosing += CloseHandler;


            // Close COM5 if already open
            if(!serialPort.IsOpen)
                serialPort.Open();
            
            // Map event when serial data is recieved and open Serial port on COM5
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataRecieved);


            //serialPort.Open();

            InitializeComponent();

            // Instantiate timer. Tick every second.
            valueTimer = new Timer();
            valueTimer.Interval = 1000; // every 1 second
            valueTimer.Tick += ValueTimer_Tick;
            valueTimer.Start();
        }

        // Unused, to be removed
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Test connection to SimConnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (SimConnectUtility.connect_simconnect())
                this.utilityForm.appendAppConsole("SimConnect established!", Color.LightGreen);
            else
                this.utilityForm.appendAppConsole("Could not connect to SimConnect", Color.Yellow);
        }

        /// <summary>
        /// Test retrieval of Altemeter data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SimConnectUtility.initializeSimReadings();
        }

        ///// <summary>
        ///// Update altemeter value shown in the dev form
        ///// </summary>
        ///// <param name="value"></param>
        //public void updateAltimeterValue(string value)
        //{
        //    AltimeterLabel.Text = value;
        //}

        //public void updateHeadingIndicatorValue(string value)
        //{
        //    HeadingIndicatorLabel.Text = value;
        //}


        /// <summary>
        /// valueTimer Event
        /// <br/>
        /// This event handles logic to conduct on each valueTimer clock tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueTimer_Tick(object sender, EventArgs e)
        {
            // If a connection to SimConnect is established, Update the AltimeterValue text label
            // with the retrieved value.
            if (SimConnectUtility.connectionStatus)
            {
                AltimeterLabel.Text = $"Altimeter Value: {SimConnectUtility.AltimeterValue}"; // Formatted string
                Console.WriteLine($"{SimConnectUtility.AltimeterValue}");

                HeadingIndicatorLabel.Text = $"Heading Indicator: {SimConnectUtility.HeadingIndicatorValue}";
                Console.WriteLine($"{SimConnectUtility.HeadingIndicatorValue}");

                SimConnectUtility.refreshSimconnect();
            }
            
        }

        // Tasks to do when Developer Form is closed
        // 
        /// <summary>
        /// Form Close event
        /// <br/>
        /// When dev form is closed, stop and discard the valueTimer.
        /// <br/>
        /// NOTE: Consider terminating connection to SimConnect if deemed applicable later.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseHandler(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing dev form instance\n");
            utilityForm.appendAppConsole("Closing dev form instance\n", Color.White);
            valueTimer.Stop();
            valueTimer.Dispose();

            serialPort.Close(); // Close serial port
        }

        /// <summary>
        /// Close COM5 port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseCOMPort(object sender, EventArgs e)
        {
            serialPort.Close();
        }

        private void SerialPortDataRecieved(object sender, EventArgs e)
        {

            //NOTE: Cross thread operation error
            // https://stackoverflow.com/questions/22356/cleanest-way-to-invoke-cross-thread-events
            // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.methodinvoker?view=windowsdesktop-9.0
            try
            {
                string serialData = serialPort.ReadLine();

                this.Invoke(new MethodInvoker(delegate
                {
                    potentiometerValueLabel.Text = $"Potentiometer Readings: {serialData}";
                }));
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Read Error: {ex.Message}");
            }
        }
    }
}

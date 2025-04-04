
/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/11/25
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
 *  To fix cross-thread communication error when displaying Arduino Potentiometer data
 *  in the developer form:
 *  https://stackoverflow.com/questions/22356/cleanest-way-to-invoke-cross-thread-events
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.methodinvoker?view=windowsdesktop-9.0
 **********************************************************************************/

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
using System.Text.Json;

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


        int throttleValue = 0; // Throttle value from Arduino potentiometer




        // Serial port on COM5 to read arduino Serial Print
        // Arduino connected on COM5 on this machine. Baud rate = 9600 (Configured in Arduino IDE)
        // private SerialPort serialPort = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);

        /// <summary>
        /// Default constructor
        /// This should never be used. Does not allow for cross-form communication.
        /// </summary>
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

            InitializeComponent();

            // Register UtilityForm Instance as previously called form
            utilityForm = callingUtilityForm as UtilityForm; 

            this.FormClosing += CloseHandler; // Register FormClosing event


            //Initialize Selected Combo box items;
            throttleComboBox.SelectedIndex = UtilityForm.ThrottleMapping;
            mixtureComboBox.SelectedIndex = UtilityForm.MixtureMapping;
            parkingBrakeComboBox.SelectedIndex = UtilityForm.BrakeMapping; // Load brake mapping as well, if needed

            // Map event when serial data is recieved and open Serial port on COM
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataRecieved);



            ArduinoCommunicationUtility.Initialize(); // Initialize Arduino Communication Utility

            // Instantiate timer. Tick every second.
            valueTimer = new Timer();
            valueTimer.Interval = 200; // every .2 second
            valueTimer.Tick += ValueTimer_Tick;
            valueTimer.Start();
        }

        /// <summary>
        /// Test connection to SimConnect. Append Utility Form Console on connection status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestSimConnectButton_Click(object sender, EventArgs e)
        {
            if (SimConnectUtility.ConnectSimconnectClient())
                this.utilityForm.AppendAppConsole("SimConnect established!\n", Color.LightGreen);
            else
                this.utilityForm.AppendAppConsole("Could not connect to SimConnect\n", Color.Yellow);
        }

        /// <summary>
        /// Test retrieval of Altemeter and Heading Indicator data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeSimConnectButton_Click(object sender, EventArgs e)
        {
            SimConnectUtility.InitializeSimReadings();
        }

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
            if (SimConnectUtility.ConnectionStatus)
            {
                // Update Altimeter label
                AltimeterLabel.Text = $"Altimeter Value: {SimConnectUtility.AltimeterValue}"; // Formatted string

                // Update Heading Indicator label
                HeadingIndicatorLabel.Text = $"Heading Indicator: {SimConnectUtility.HeadingIndicatorValue}";

                // Update Turn Coordinator label
                TurnCoordinatorLabel.Text = $"Turn Coordinator: {SimConnectUtility.TurnCoordinatorValue}";
                
                // Update Turn Indicator Label
                TurnIndicatorLabel.Text = $"Turn Indicator: {SimConnectUtility.TurnIndicatorValue}"; 

                // Update Airspeed Indicator label
                AirspeedIndicatorLabel.Text = $"Airspeed Indicator: {SimConnectUtility.AirspeedIndicatorValue}";

                // Update Vertical Airspeed Indicator Label
                VerticalAirspeedIndicatorLabel.Text = $"Vertical Airspeed Indicator: {SimConnectUtility.VerticalAirspeedIndicatorValue}";

                // Update Suction Gauge Label
                SuctionGaugeLabel.Text = $"Suction Gauge (inHg): {SimConnectUtility.SuctuionGaugeValue}";

                // Update total fuel capacity Label
                TotalFuelLabel.Text = $"Total Fuel (gal): {SimConnectUtility.TotalFuelValue}";

                // Update current fuel capacity label
                CurrentFuelLabel.Text = $"Current Fuel (gal): {SimConnectUtility.CurrentFuelValue}";

                // Update Ammeter Value
                AmmeterLabel.Text = $"Ammeter (amp): {SimConnectUtility.AmmeterValue}";

                // Update Pitch Value
                PitchLabel.Text = $"Pitch (degrees): {SimConnectUtility.PitchValue}";

                // Update Roll Value
                RollLabel.Text = $"Roll (degrees): {SimConnectUtility.RollValue}";

                // Update Hour Value
                HourLabel.Text = $"Hour: {SimConnectUtility.HourValue}";

                // Update Minute Value
                MinuteLabel.Text = $"Minute: {SimConnectUtility.MinuteValue}";

                // Update Seconds Value
                SecondsLabel.Text = $"Seconds: {SimConnectUtility.SecondValue}";

                // Write potentiometer value to SimConnect client
                if (ArduinoCommunicationUtility.isComOpen == true)
                {
                    //// Update throttle value in SimConnect from Arduino potentiometer value
                    //SimConnectUtility.UpdateThrottleFromPotentiometer(ArduinoCommunicationUtility.castSerialInput()[0]);
                    //Console.WriteLine("Throttle Input: " + ArduinoCommunicationUtility.castSerialInput()[0]);

                    //SimConnectUtility.UpdateMixtureFromPotentiometer(ArduinoCommunicationUtility.castSerialInput()[1]);
                    //Console.WriteLine("Mixture Input: " + ArduinoCommunicationUtility.castSerialInput()[1]);
                }

                // Refresh SimConnect
                SimConnectUtility.RefreshSimconnect();
            }

            // Update Potentiometer Label with read Arduino serial data
            potentiometerValueLabel.Text = $"Arduino Readings:\n{ArduinoCommunicationUtility.serialData}";
        }

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
            utilityForm.AppendAppConsole("Closing dev form instance\n", Color.White);

            
            valueTimer.Stop();
            valueTimer.Dispose();

            ArduinoCommunicationUtility.CloseSerialPort();
            SimConnectUtility.DisconnectSimconnectClient();

            GC.Collect();
        }

        /// <summary>
        /// Close COM5 port when CloseSerialPortButton is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseSerialPortButton_Click(object sender, EventArgs e)
        {
            //serialPort.Close();
        }

        /// <summary>
        /// Event called each time serial data is read from Arduino on COM5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortDataRecieved(object sender, EventArgs e)
        {
            // This is a separate way of directly appending serial data to potentiometerValueLabel.
            // This is to prevent "Cross thread operation error"
            // See: https://stackoverflow.com/questions/22356/cleanest-way-to-invoke-cross-thread-events
            try
            {
                string serialData = ArduinoCommunicationUtility.serialPort.ReadLine();

                this.Invoke(new MethodInvoker(delegate
                {
                    potentiometerValueLabel.Text = $"Arduino Readings:\n {serialData}";
                }));              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Read Error: {ex.Message}");
            }
        }

        private void SetArduinoMappings()
        {
            

            UtilityForm.ThrottleMapping = throttleComboBox.SelectedIndex;
            UtilityForm.MixtureMapping = mixtureComboBox.SelectedIndex;
            UtilityForm.BrakeMapping = parkingBrakeComboBox.SelectedIndex; // Save brake mapping as well, if needed

        }

        /// <summary>
        /// When clicked, set control mappings to selected ports in combo boxes
        /// </summary>
        private void SetButton_OnClick(object sender, EventArgs e)
        {
            SetArduinoMappings();
        }

        private void SaveButton_OnClick(object sender, EventArgs e)
        {
            SetArduinoMappings();
            UtilityForm.SaveControlMappings();
            MessageBox.Show("Mappings Saved!");
        }
    }
}

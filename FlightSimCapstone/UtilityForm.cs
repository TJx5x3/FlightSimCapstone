
/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/1/25
 *  Class           :   UtilityForm.cs
 *  Description     :   This module defines the Utility Form. This is the first
 *                      form displayed when the application is launched. 
 **********************************************************************************
 *  I used source code from the following websites to complete this assignment:
 *  
 *  Detecting Keypresses in Form Windows:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-8.0
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.keypreview?view=windowsdesktop-9.0&redirectedfrom=MSDN
 *
 *  Header block comment format reference:
 *  https://www.baeldung.com/wp-content/uploads/2019/07/eclipsecopy3-1024x484.png
 *  
 *  Form Closing event:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.closing?view=windowsdesktop-9.0
 *  https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel?view=net-9.0
 *
 *  Using C# to run CMD commands (Currently Unused)
 *  https://stackoverflow.com/questions/1469764/run-command-prompt-commands
 *  
 *  To launch Microsoft Flight Simulator when Start Button is clicked 
 *  (Process.Start() method)
 *  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.start?view=net-9.0
 *  
 *  To skip intro when Microsoft Flight Simulator is launched / launch process with parameters 
 *  (Removed from current build, -FastLaunch was confugured in Steam)
 *  https://stackoverflow.com/questions/5766574/start-a-process-with-parameters
 *  https://forums.flightsimulator.com/t/skip-the-intro-spots-when-loading-the-game/222479/4
 *  
 *  Communicating between multiple Windows Forms:
 *  https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
 *  
 *  
 *  NOTE: Remember, in form designer -> lightning bolt - > propper wat to create event handler
 **********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FlightSimCapstone
{
    /// <summary>
    /// Form object for Utility Window
    /// </summary>
    /// <remarks>
    /// This form provides a console showing application information,
    /// and buttons for opening the graphical interface configuration,
    /// and to launch Microsoft Flight Simulator.
    /// </remarks>
    public partial class UtilityForm : Form
    {
        /// <summary>
        /// Utility Form Constructor
        /// </summary>
        /// <remarks>
        /// Maps Utility Form events,
        /// checks for software and hardware dependencies.
        /// </remarks>
        public UtilityForm()
        {

            InitializeComponent();

            // Map events
            this.KeyPreview = true;
            this.KeyDown += UtilityForm_KeyDown;
            this.Closing += CloseHandler; // map FormClosed event to CloseHandler()

            // Append starting message to console
            AppConsole.AppendText("Application launched.\n");
            checkSoftwareDependencies();
        }


        /// <summary>
        /// This function appends text to the rich textbox element displayed in the Utility Window.
        /// Appended text color can be specified.
        /// </summary>
        /// <param name="text">
        /// Text to append to utility form console
        /// </param>
        /// <param name="color">
        /// Color of appended text
        /// </param>
        public void AppendAppConsole(String text, Color color)
        {
            AppConsole.SelectionColor = color;
            AppConsole.AppendText(text);
        }

        /// <summary>
        /// This method checks hardware and software dependencies when application launched
        /// Check for Flight Sim installation. 
        /// (ONLY CHECKS STEAM INSTALL)
        /// </summary>
        /// <remarks>
        /// Locate SimConnect.dll, Microsoft.FlightSimulator.SimConnect.dll
        /// </remarks>
        private void checkSoftwareDependencies()
        {
            AppConsole.AppendText("Checking software dependencies...\n");
            AppConsole.AppendText("Locating Microsoft Flight Sim 2020...\n");

            // Check for MSFS Program path. Append application console message with result
            if (BaseDependencyUtility.LocateFlightSim()) 
                AppendAppConsole("Flight Sim 2020 Located :D\n", Color.LightGreen); // success
            else
                AppendAppConsole("Flight Sim not found :(\n", Color.OrangeRed); // fail

            // Check for SimConnect.dll
            AppConsole.AppendText("Locating SimConnect DLL dependencies\n");
            AppConsole.AppendText("SimConnect.dll: \n");
            if (BaseDependencyUtility.LocateSimConnectDll())
                AppendAppConsole("OK\n", Color.LightGreen);
            else
                AppendAppConsole("Not Found\n", Color.OrangeRed);

            // Check for Microsoft.FlightSimulator.SimConnect.dll
            AppConsole.AppendText("Locating Microsoft.FlightSimulator.SimConnect.dll:\n");
            if (BaseDependencyUtility.LocateSimConnectNETDll())
                AppendAppConsole("OK\n", Color.LightGreen);
            else
                AppendAppConsole("Not Found\n", Color.OrangeRed);

            // If any DLL cannot be located, append yellow warning message to app console
            if(!BaseDependencyUtility.LocateSimConnectNETDll() || !BaseDependencyUtility.LocateSimConnectDll())
                AppendAppConsole("Warning: One or more SimConnect libraries could not be located. To resolve this, please install the MSFS SDK\n", Color.Yellow);

            // Check System Management for Arduino connection
            AppConsole.AppendText("Checking Arduino Connection...\n");
            if (BaseDependencyUtility.CheckArduinoConnection())
            {
                this.arduinoStatusLabel.Text = "OK";
                this.arduinoStatusLabel.ForeColor = Color.Green;
                AppendAppConsole("Arduino Located!\n", Color.LightGreen);
            }
            else
            {
                this.arduinoStatusLabel.Text = "Failed";
                this.arduinoStatusLabel.ForeColor = Color.Red;
                AppendAppConsole("Arduino could not be located\n", Color.OrangeRed);
            }

        }

        /// <summary>
        /// Start button click event
        /// Launches Microsoft Flight Simulator.
        /// Will also launch Graphical Interface on specified display(s) in future revision.
        /// 
        /// NOTE: Consider making FlightSimPath a UtilityForm or Program.cs class attribute
        /// 
        /// TODO: Launch Graphical Interface on second and/or third display
        /// </summary>
        private void StartButton_Click(object sender, EventArgs e)
        {
            AppendAppConsole("Launching MSFS 2020...\n", Color.White);
            Process.Start(BaseDependencyUtility.GetFlightSimExePath());
        }

        /// <summary>
        /// Keyboard press event
        /// </summary>
        /// <remarks>
        /// Keyboard input is handled when Utility Form is selected.
        /// Creates new instance of DevForm when F6 is pressed.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtilityForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                AppendAppConsole("Opening Secret Developer Settings...\n", Color.MediumPurple);

                e.SuppressKeyPress = true;
                DevForm secretMenu = new DevForm(this);
                secretMenu.Show();
            }
        }
    
        /// <summary>
        /// Utility Form Close Event
        /// </summary>
        /// <remarks>
        /// Logic conducted when Utility Form is closed.
        /// 
        /// <br/>
        /// NOTE: This will be required when the Graphical Interface is created.
        ///       Currently a prototype. The UtilityForm will not close if 'int close'
        ///       is set to 1.
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseHandler(object sender, CancelEventArgs e)
        {
            SimConnectUtility.DisconnectSimconnectClient();
           
            /*
            * NOTE: This needs to be formatted better once you figure out where it will be used
            * If close is set to anything other than 0, the utility form will not close. 
            */
            int close = 0;

            // Check if form should be closed
            if (close != 0)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Configure Graphical Interface button clicked event.
        /// Open new instance of left and right graphical 
        /// interface forms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            // If SimConnect Client can be created, initialize Sim Readings and Open Graphical Interface form
            if (SimConnectUtility.ConnectSimconnectClient())
            {
                AppendAppConsole("Opening Graphical Interface\n", Color.White);
                SimConnectUtility.InitializeSimReadings();

                // Define Graphical Interface Forms (Left and right)
                GraphicalInterface_Left graphicalInterfaceLeft = new GraphicalInterface_Left();
                GraphicalInterface_Right graphicalInterfaceRight = new GraphicalInterface_Right();

                //Link graphical interface forms together to ensure they close each other.
                graphicalInterfaceLeft.setLinkedForm(graphicalInterfaceRight); // Link Left Graphical Interface to Right 
                graphicalInterfaceRight.setLinkedForm(graphicalInterfaceLeft);  // Link Right Graphical Interface to Left 

                // Show Graphical Interface Forms
                graphicalInterfaceLeft.Show();
                graphicalInterfaceRight.Show();
            }

            else
            {
                MessageBox.Show("Please Start Microsoft Flight Simulator before opening graphical interface.", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SimConnectUtility.InitializeSimReadings();
                
                // Define Graphical Interface Forms (Left and right)
                GraphicalInterface_Left graphicalInterfaceLeft = new GraphicalInterface_Left();
                GraphicalInterface_Right graphicalInterfaceRight = new GraphicalInterface_Right();

                //Link graphical interface forms together to ensure they close each other.
                graphicalInterfaceLeft.setLinkedForm(graphicalInterfaceRight); // Link Left Graphical Interface to Right 
                graphicalInterfaceRight.setLinkedForm(graphicalInterfaceLeft);  // Link Right Graphical Interface to Left 

                // Show Graphical Interface Forms
                graphicalInterfaceLeft.Show();
                graphicalInterfaceRight.Show();

                AppendAppConsole("Please Start Microsoft Flight Simulator before opening graphical interface.\n", Color.Yellow);
            }
        }
    }
}


/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   1/24/25
 *  Class           :   UtilityForm.cs
 *  Description     :   This module defines the Utility Form. This is the first
 *                      form displayed when the application is launched. 
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 * 
 *  Detecting Keypresses in Form Windows:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-8.0
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.keypreview?view=windowsdesktop-9.0&redirectedfrom=MSDN#System_Windows_Forms_Form_KeyPreview
 *
 *  Header block comment format reference:
 *  https://www.baeldung.com/wp-content/uploads/2019/07/eclipsecopy3-1024x484.png
 *  
 *  Form Closing event:
 *  https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.closing?view=windowsdesktop-9.0
 *  https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel?view=net-9.0
 *
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
    /// 
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
        public void appendAppConsole(String text, Color color)
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
            if (BaseDependencyUtility.locateFlightSim()) 
                appendAppConsole("Flight Sim 2020 Located :D\n", Color.LightGreen); // success
            else
                appendAppConsole("Flight Sim not found :(\n", Color.OrangeRed); // fail

            // Check for SimConnect.dll
            AppConsole.AppendText("Locating SimConnect DLL dependencies\n");
            AppConsole.AppendText("SimConnect.dll: \n");
            if (BaseDependencyUtility.locateSimConnectDll())
                appendAppConsole("OK\n", Color.LightGreen);
            else
                appendAppConsole("Not Found\n", Color.OrangeRed);

            // Check for Microsoft.FlightSimulator.SimConnect.dll
            AppConsole.AppendText("Locating Microsoft.FlightSimulator.SimConnect.dll:\n");
            if (BaseDependencyUtility.locateSimConnectNETDll())
                appendAppConsole("OK\n", Color.LightGreen);
            else
                appendAppConsole("Not Found\n", Color.OrangeRed);

            // If any DLL cannot be located, append yellow warning message to app console
            if(!BaseDependencyUtility.locateSimConnectNETDll() || !BaseDependencyUtility.locateSimConnectDll())
                appendAppConsole("Warning: One or more SimConnect libraries could not be located. To resolve this, please install the MSFS SDK\n", Color.Yellow);
        }

        /**
         * Start button:
         * Opens graphical interface & Launch Flight Simulator
         * 
         * TODO: Launch graphical interface once implemented 
         * Promblem: MSFS displays warning message when launched this way. Potentially try running with a batch command?
         * THIS RESOURCE HAS NOT (yet) BEEN USED
         * https://stackoverflow.com/questions/1469764/run-command-prompt-commands
         */

        /// <summary>
        /// Start button click event
        /// </summary>
        /// <remarks>
        /// Launches Microsoft Flight SImulator.
        /// Will launch Graphical Interface in future revision.
        /// </remarks>
        private void StartButton_Click(object sender, EventArgs e)
        {
            appendAppConsole("Launching MSFS 2020...\n", Color.White);
            Process.Start(BaseDependencyUtility.getFlightSimExePath());
        }

        /// <summary>
        /// Keyboard press event
        /// </summary>
        /// <remarks>
        /// Keyboard input is handled when Utility Form is selected.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtilityForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                appendAppConsole("Opening Secret Developer Settings...\n", Color.MediumPurple);


                e.SuppressKeyPress = true;
                Form2 secretMenu = new Form2(this);
                secretMenu.Show();
            }
        }
    

        /**
         * NOTE: This needs to be formatted better once you figure out where it will be used
         * If close is set to anything other than 0, the utility form will not close. 
         */
        int close = 0;


        /// <summary>
        /// Utility Form Close Event
        /// </summary>
        /// <remarks>
        /// Logic conducted when Utility Form is closed
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseHandler(object sender, CancelEventArgs e)
        {
            SimConnectUtility.disconnect_simconnect();

            if (close != 0)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}

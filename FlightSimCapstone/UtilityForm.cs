
/*
 * 
 * Key events resources:
 * https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-8.0
 * https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.keypreview?view=windowsdesktop-9.0&redirectedfrom=MSDN#System_Windows_Forms_Form_KeyPreview
 *
 *
 */

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


/**
 * TODO:
 * Create new static class for SimConnect, and Enums
 */


namespace FlightSimCapstone
{
    public partial class UtilityForm : Form
    {

        /***
         * Utility Form Constructor.
         * Map events
         */
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


        /**
        * This function appends text to the application console displayed in the Utility Window.
        * Appended text color can be specified. 
        */
        public void appendAppConsole(String text, Color color)
        {
            AppConsole.SelectionColor = color;
            AppConsole.AppendText(text);
        }

        /**
         * This method checks hardware and software dependencies when application launched
         * Check for Flight Sim installation (ONLY CHECKS STEAM INSTALL)
         */
        private void checkSoftwareDependencies()
        {
            AppConsole.AppendText("Checking software dependencies...\n");
            AppConsole.AppendText("Locating Microsoft Flight Sim 2020...\n");

            // Check for MSFS Program path. Append application console message
            if (BaseDependencyUtility.locateFlightSim())
                appendAppConsole("Flight Sim 2020 Located :D\n", Color.LightGreen);
            else
                appendAppConsole("Flight Sim not found :(\n", Color.OrangeRed);

            // Check for Sim Connect DLLs
            // Check for SimConnect.dll
            AppConsole.AppendText("Locating SimConnect DLL dependencies\n");
            AppConsole.AppendText("SimConnect.dll: ");
            if (BaseDependencyUtility.locateSimConnectDll())
                appendAppConsole("OK\n", Color.LightGreen);
            else
                appendAppConsole("Not Found\n", Color.OrangeRed);

            // Check for Microsoft.FlightSimulator.SimConnect.dll
            AppConsole.AppendText("Microsoft.FlightSimulator.SimConnect.dll: ");
            if (BaseDependencyUtility.locateSimConnectNETDll())
                appendAppConsole("OK\n", Color.LightGreen);
            else
                appendAppConsole("Not Found\n", Color.OrangeRed);

            // If any DLL cannot be located, append yellow warning message to app console
            if(!BaseDependencyUtility.locateSimConnectNETDll() || !BaseDependencyUtility.locateSimConnectDll())
                appendAppConsole("Warning: One or more SimConnect libraries could not be located. To resolve this, please install the MSFS SDK", Color.Yellow);
        }


        /**
         * Start button:
         * Launches MSFS,
         * Opens graphical interface & Launch Flight Simulator
         * 
         * Promblem: MSFS displays warning message when launched this way. Potentially try running with a batch command?
         * https://stackoverflow.com/questions/1469764/run-command-prompt-commands
         */
        private void startButton_Click(object sender, EventArgs e)
        {
            appendAppConsole("Launching MSFS 2020...\n",Color.White);
            Process.Start(BaseDependencyUtility.getFlightSimExePath());
        }



        /*
         * Launch Flight Sim
         */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*
         * Handle keypresses in Utility Window
         * NOTE: Find way to prevent loop if key held down
         */
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
         * Event when Utility form is closed
         * https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel?view=net-9.0
         * 
         * NOTE: This needs to be formatted better once you figure out where it will be used
         * If close is set to anything other than 0, the utility form will not close. 
         */
        int close = 0;
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

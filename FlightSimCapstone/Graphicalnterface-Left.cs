/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/8/25
 *  Class           :   GraphicalInterface-Left.cs
 *  Description     :   This module will contain various overlayed bitmap images to create graphical modules.
 *                      Each module will update according to real-time values retrieved from the SimConnect Client.
 **********************************************************************************
 *  I used source code from the following websites to complete
 *  this assignment:
 * 
 * Image Rotation
 * https://foxlearn.com/csharp/image-rotation-8368.html
 * 
 * Avoid Automatic Scaling when applying Image Transformations
 * https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-improve-performance-by-avoiding-automatic-scaling?view=netframeworkdesktop-4.8
 * 
 * Overlap Transparent Image
 * https://stackoverflow.com/questions/38566828/overlap-one-image-as-transparent-on-another-in-c-sharp
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;

namespace FlightSimCapstone
{
    /// <summary>
    /// This module holds graphical elements to be displayed in the 
    /// Left Side of the Instrumentation Panel
    /// </summary>
    public partial class GraphicalInterface_Left : Form
    {
        // Timer to update retrieved SimConnect values
        private Timer formTimer = null;

        // Attributes for Bitmaps that will be rotated
        private Bitmap originalHeadingIndicatorGauge;
        private Bitmap originalTurnCoordinatorAirplane;
        private Bitmap originalSuctionGaugeDial;

        // Link Right form to current form
        private GraphicalInterface_Right linkedForm;

        // Check if OnClosing event first fired in other form
        public bool isRightClosing { get; set; }


        // Degree attribute for testing/debug
        private float degree = 0f;

        /// <summary>
        /// Class constructor
        /// 
        /// Initialize picturebox attributes. 
        /// Overlay transparent images, set size, parent image, location, and color
        /// 
        /// <br/>
        /// Instantiate Timer
        /// </summary>
        public GraphicalInterface_Left()
        {
            InitializeComponent();

            // Heading Indicator
            originalHeadingIndicatorGauge = new Bitmap(Properties.Resources.HeadingIndicator1); // Circular gauge that shows degree values
            HeadingIndicatorBack.Image = originalHeadingIndicatorGauge;

            HeadingIndicatorOverlay.Parent = HeadingIndicatorBack; // Transparent Airplane overlay
            HeadingIndicatorOverlay.Location =  new Point(0,0);
            HeadingIndicatorOverlay.BackColor = Color.Transparent;

            // Turn Coordinator
            originalTurnCoordinatorAirplane = new Bitmap(Properties.Resources.TurnCoordinatorAirplane);
            TurnCoordinatorAirplane.Image = originalTurnCoordinatorAirplane;

            TurnCoordinatorAirplane.Parent = TurnCoordinatorBack;
            TurnCoordinatorAirplane.Location = new Point(0, 0);
            TurnCoordinatorAirplane.BackColor = Color.Transparent;

            // Suction Gauge
            originalSuctionGaugeDial = new Bitmap(Properties.Resources.SuctionGauge_Dial);
            SuctionGaugeDial.Image = originalSuctionGaugeDial;

            SuctionGaugeDial.Parent = SuctionGauge;
            SuctionGaugeDial.Location = new Point(0, 0);
            SuctionGaugeDial.BackColor = Color.Transparent;


            // initialize form closing event
            this.FormClosing += GraphicalInterface_OnClosing;

            // initialize form timer
            formTimer = new Timer();
            formTimer.Interval = 1000;
            formTimer.Tick += FormTimer_Tick;
            formTimer.Start();

        }


        /// <summary>
        /// This image rotates a Bitmap image around the center point.
        /// Image is re-sized accordingly to avoid visible image resize durring transformation. 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        /// <see cref="https://foxlearn.com/csharp/image-rotation-8368.html"/>
        public static Bitmap SetImageRotation(Bitmap image, float degree)
        {
            Bitmap rotatedBitmap = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(rotatedBitmap);

            // Scale image down /2 and rotate
            g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
            g.RotateTransform(degree);

            // Scale rotated image back to full size before drawing (To avoid visible resizing)
            g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
            g.DrawImage(image, new Point(0,0));
            return rotatedBitmap;
        }



        public void setLinkedForm(GraphicalInterface_Right rightForm)
        {
            linkedForm = rightForm;
        }

        /// <summary>
        /// valueTimer Event
        /// <br/>
        /// This event handles logic to conduct on each valueTimer clock tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTimer_Tick(object sender, EventArgs e)
        {
            // If a connection to SimConnect is established, update graphical modules
            if (SimConnectUtility.ConnectionStatus)
            {
                // Refresh SimConnect Client
                SimConnectUtility.RefreshSimconnect();

                // Rotate background image based on rotational value of the Heading Indicator retrieved from SimConnect. 
                Bitmap rotatedImage = SetImageRotation(originalHeadingIndicatorGauge, -(float)SimConnectUtility.HeadingIndicatorValue);
                HeadingIndicatorBack.Image = rotatedImage;

                // TODO: Swap names of TurnIndicator and TurnCoordinator in simconnect request declaration
                Bitmap rotatedTurnCoordinatorAirplane = SetImageRotation(originalTurnCoordinatorAirplane, (float)SimConnectUtility.TurnIndicatorValue * 5.0f); // Multiply 5 to get proper degree rotation value
                TurnCoordinatorAirplane.Image = rotatedTurnCoordinatorAirplane;

                // TODO: Implement Suction Gauge  
            }

            Console.WriteLine("Tick");
        }

        /// <summary>
        /// OnClosing Event.
        /// Disable and Discard Form timer when closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicalInterface_OnClosing(object sender, FormClosingEventArgs e)
        {
            formTimer.Stop();
            formTimer.Dispose();

            // Tell other form that this form is closing
            linkedForm.isLeftClosing = true;

            // If the other form didn't tell us it closed first, close it first
            if (!isRightClosing)
            {
                isRightClosing = true;
                linkedForm.Close();
            }

            //Close SimConnect client
            SimConnectUtility.DisconnectSimconnectClient();
        }
    }
}

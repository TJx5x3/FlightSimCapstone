/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/11/25
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
 * Optimizing memory usage of image transformation functions
 * https://codereview.stackexchange.com/questions/273064/memory-leak-i-cant-identify-using-bitmap-and-graphics-classes
 * 
 * Ensuring object disposal
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using
 * 
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Configuration;
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
        private UtilityForm utilityForm = null;

        // Timer to update retrieved SimConnect values
        private Timer formTimer = null;

        // Original Bitmap images that are transformed
        private Bitmap originalAirspeedIndicatorDial;
        private Bitmap originalHeadingIndicatorGauge;
        private Bitmap originalTurnCoordinatorAirplane;
        private Bitmap originalSuctionGaugeDial;
        private Bitmap originalAltitudeIndicatorBase;
        private Bitmap originalAltitudeIndicatorMiddle;
        private Bitmap originalAltitudeIndicatorRoll;

        // updated and transformed images
        private Bitmap rotatedAirspeedIndicatorDial;
        private Bitmap rotatedHeadingIndicator;
        private Bitmap rotatedTurnCoordinatorAirplane;
        private Bitmap rotatedSuctionGaugeDial;
        private Bitmap rotatedAltitudeIndicatorBase;
        private Bitmap rotatedAltitudeIndicatorCenter;
        private Bitmap rotatedAltitudeIndicatorRoll;
        private Bitmap translatedAltitudeIndicatorCenter;


        // Link Right form to current form
        private GraphicalInterface_Right linkedForm;


        private ArrayList ImageResources = new ArrayList();

        // Check if OnClosing event first fired in other form
        public bool isRightClosing { get; set; }


        // Degree attribute for testing/debug
        private float degree = 0f;

        /// <summary>
        /// Class constructor
        /// 
        /// Initialize picturebox attributes. 
        /// Overlay transparent images, set size, parent image(s), location, and color.
        /// 
        /// <br/>
        /// Instantiate Timer 
        /// </summary>
        public GraphicalInterface_Left(UtilityForm callingUtilityForm)
        {
            InitializeComponent();
            ArduinoCommunicationUtility.Initialize();

            // initialize calling utility form
            utilityForm = callingUtilityForm;

            // Airspeed Indicator
            originalAirspeedIndicatorDial = new Bitmap(Properties.Resources.AirspeedIndicator_Dial); // Rotating dial that shows airspeed values
            AirspeedIndicatorDial.Image = originalAirspeedIndicatorDial;

            AirspeedIndicatorDial.Parent = AirspeedIndicatorBack; // Transparent needle overlay
            AirspeedIndicatorDial.Location = new Point(0, 0);
            AirspeedIndicatorDial.BackColor = Color.Transparent;

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

            // Atitude Indicator
            originalAltitudeIndicatorBase = new Bitmap(Properties.Resources.AltitudeIndicator_Base);
            AltitudeIndicatorBase.Image = originalAltitudeIndicatorBase;

            originalAltitudeIndicatorRoll = new Bitmap(Properties.Resources.AltitudeIndicator_Roll);
            AltitudeIndicatorRoll.Image = originalAltitudeIndicatorRoll;

            originalAltitudeIndicatorMiddle = new Bitmap(Properties.Resources.AltitudeIndicator_Middle);
            AltitudeIndicatorMiddle.Image = originalAltitudeIndicatorMiddle;

            AltitudeIndicatorMiddle.Parent = AltitudeIndicatorBase;
            AltitudeIndicatorMiddle.Location = new Point(0, 0);
            AltitudeIndicatorMiddle.BackColor = Color.Transparent;

            AltitudeIndicatorRoll.Parent = AltitudeIndicatorMiddle;
            AltitudeIndicatorRoll.Location = new Point(0, 0);

            AltitudeIndicatorStatic.Parent = AltitudeIndicatorRoll;
            AltitudeIndicatorStatic.Location = new Point(0, 0);
            AltitudeIndicatorStatic.BackColor = Color.Transparent;



            // initialize form closing event
            this.FormClosing += GraphicalInterface_OnClosing;

            // initialize form timer
            formTimer = new Timer();
            formTimer.Interval = 200;
            formTimer.Tick += FormTimer_Tick;
            formTimer.Start();


            // Initialize Image Resources array list

            ImageResources.Add(originalAirspeedIndicatorDial);
            ImageResources.Add(originalHeadingIndicatorGauge);
            ImageResources.Add(originalTurnCoordinatorAirplane);
            ImageResources.Add(originalSuctionGaugeDial);
            ImageResources.Add(originalAltitudeIndicatorBase);
            ImageResources.Add(originalAltitudeIndicatorMiddle);
            ImageResources.Add(originalAltitudeIndicatorRoll);

            ImageResources.Add(rotatedAirspeedIndicatorDial);
            ImageResources.Add(rotatedHeadingIndicator);
            ImageResources.Add(rotatedTurnCoordinatorAirplane);
            ImageResources.Add(rotatedSuctionGaugeDial);
            ImageResources.Add(rotatedAltitudeIndicatorBase);
            ImageResources.Add(rotatedAltitudeIndicatorCenter);
            ImageResources.Add(rotatedAltitudeIndicatorRoll);

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

            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                // Translate image to center, then rotate
                g.TranslateTransform(image.Width / 2f, image.Height / 2f);
                g.RotateTransform(degree);

                // Translate back to original position (to avoid resizing issue)
                g.TranslateTransform(-image.Width / 2f, -image.Height / 2f);
                g.DrawImage(image, new Point(0, 0));
            }

            return rotatedBitmap;

        }

        /// <summary>
        /// Translate bitmap image across Y axis
        /// </summary>
        public static Bitmap TranslateImageY(Bitmap image, float y)
        {
            Bitmap translatedImage = new Bitmap(image.Width, image.Height);
            
            using (Graphics g = Graphics.FromImage(translatedImage))
            { 
                g.TranslateTransform(0, y);
                g.DrawImage(image, new Point(0, 0));
            }

            return translatedImage;
        }


        /// <summary>
        /// Setter method for linked form
        /// </summary>
        /// <param name="rightForm"></param>
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
                if (!SimConnectUtility.RefreshSimconnect())
                {
                    linkedForm.Close();
                    this.Close();
                };

                // Rotate Airspeed Indicator dial

                // If imagebox or previously transformed images not null, clear from memory
                if (AirspeedIndicatorDial.Image != null && rotatedAirspeedIndicatorDial != null)
                {
                    rotatedAirspeedIndicatorDial.Dispose();
                }

                // Update and set Airspeed Indicator dial
                rotatedAirspeedIndicatorDial = SetImageRotation(originalAirspeedIndicatorDial, (float)(SimConnectUtility.AirspeedIndicatorValue * (10000.0f / 13909.0f))); // Multiply 9/7 to get proper degree rotation value
                AirspeedIndicatorDial.Image = rotatedAirspeedIndicatorDial;

                
                if (HeadingIndicatorBack.Image != null && rotatedHeadingIndicator != null)
                {
                    rotatedHeadingIndicator.Dispose();
                }

                // Rotate background image based on rotational value of the Heading Indicator retrieved from SimConnect. 
                rotatedHeadingIndicator = SetImageRotation(originalHeadingIndicatorGauge, -(float)SimConnectUtility.HeadingIndicatorValue);
                HeadingIndicatorBack.Image = rotatedHeadingIndicator;


                // Turn Coordinator
                if (TurnCoordinatorAirplane.Image != null && rotatedTurnCoordinatorAirplane != null)
                {
                    rotatedTurnCoordinatorAirplane.Dispose();
                }

                // TODO: Swap names of TurnIndicator and TurnCoordinator in simconnect request declaration
                rotatedTurnCoordinatorAirplane = SetImageRotation(originalTurnCoordinatorAirplane, (float)SimConnectUtility.TurnIndicatorValue * 5.0f); // Multiply 5 to get proper degree rotation value
                TurnCoordinatorAirplane.Image = rotatedTurnCoordinatorAirplane;



                // TODO: Implement Suction Gauge  

                // Altitude Indicator //

                // Rotate Atitude Indicator Roll dial
                if (AltitudeIndicatorRoll.Image != null && rotatedAltitudeIndicatorRoll != null)
                {
                    rotatedAltitudeIndicatorRoll.Dispose();
                }
                rotatedAltitudeIndicatorRoll = SetImageRotation(originalAltitudeIndicatorRoll, (float)SimConnectUtility.RollValue);
                AltitudeIndicatorRoll.Image = rotatedAltitudeIndicatorRoll;

                // Rotate Atitude Indicator Center dial
                if (AltitudeIndicatorMiddle.Image != null && translatedAltitudeIndicatorCenter != null && rotatedAltitudeIndicatorCenter != null)
                {
                    Console.WriteLine("Old Images disposed");
                    translatedAltitudeIndicatorCenter.Dispose();
                    rotatedAltitudeIndicatorCenter.Dispose();
                }

                translatedAltitudeIndicatorCenter = TranslateImageY(originalAltitudeIndicatorMiddle, -(float)SimConnectUtility.PitchValue * 10.0f);
                rotatedAltitudeIndicatorCenter = SetImageRotation(translatedAltitudeIndicatorCenter, (float)SimConnectUtility.RollValue);
                AltitudeIndicatorMiddle.Image = rotatedAltitudeIndicatorCenter;


                if (AltitudeIndicatorBase.Image != null && rotatedAltitudeIndicatorBase != null)
                {
                    rotatedAltitudeIndicatorBase.Dispose();
                }

                // Rotate Atitude Indicator Base dial
                rotatedAltitudeIndicatorBase = SetImageRotation(originalAltitudeIndicatorBase, (float)SimConnectUtility.RollValue);
                AltitudeIndicatorBase.Image = rotatedAltitudeIndicatorBase;

                // Write potentiometer value to SimConnect client
                if (ArduinoCommunicationUtility.isComOpen == true)
                {
                    //// Update throttle value in SimConnect from Arduino potentiometer value
                    SimConnectUtility.UpdateThrottleFromPotentiometer(ArduinoCommunicationUtility.castSerialInput()[UtilityForm.ThrottleMapping]);
                    Console.WriteLine("Throttle Input: " + ArduinoCommunicationUtility.castSerialInput()[UtilityForm.ThrottleMapping]);

                    SimConnectUtility.UpdateMixtureFromPotentiometer(ArduinoCommunicationUtility.castSerialInput()[UtilityForm.MixtureMapping]);
                    Console.WriteLine("Mixture Input: " + ArduinoCommunicationUtility.castSerialInput()[UtilityForm.MixtureMapping]);
                }

            }

            Console.WriteLine("Tick");


            // Force Garbage Collection to reduce memory usage
            GC.Collect();
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
                //Close SimConnect client
                SimConnectUtility.DisconnectSimconnectClient();

                isRightClosing = true;
                linkedForm.Close();
            }

            // Disable open graphical interface check
            utilityForm.IsGraphicalInterfaceOpen = false;

            // Garbage collection
            GC.WaitForPendingFinalizers();
        }
    }
}

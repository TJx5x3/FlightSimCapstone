/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/11/25
 *  Class           :   GraphicalInterface-Right.cs
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
 * Understanding what an Altimeter does
 * https://www.wikihow.com/Read-an-Altimeter
 * 
 * Ensuring object disposal
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace FlightSimCapstone
{
    /// <summary>
    /// This module holds graphical elements to be displayed in the 
    /// Right Side of the Instrumentation Panel
    /// </summary>
    public partial class GraphicalInterface_Right : Form
    {
        // Timer to update retrieved SimConnect values 
        private Timer formTimer = null;

        // Attributes for Bitmaps that will be rotated
        private Bitmap originalVerticalAirspeedIndicatorDial;

        private Bitmap originalAltimeter100Dial;
        private Bitmap originalAltimeter1kDial;
        private Bitmap originalAltimeter10kDial;

        private Bitmap originalClockSeconds;
        private Bitmap originalClockMinutes;
        private Bitmap originalClockHours;

        // Rotated Images 
        private Bitmap rotatedVerticalAirspeedIndicatorDial;
        private Bitmap rotatedAltimeter100Dial;
        private Bitmap rotatedAltimeter1kDial;
        private Bitmap rotatedAltimeter10kDial;

        private Bitmap rotatedClockSeconds;
        private Bitmap rotatedClockMinutes;
        private Bitmap rotatedClockHours;

        // Link Left form to current form
        private GraphicalInterface_Left linkedForm;

        private float currentVerticalAirspeedValue;
        
        // Check if OnClosing event first fired in left form
        public bool isLeftClosing { get; set; }

        /// <summary>
        /// Class constructor
        /// 
        /// Initialize picturebox attributes.
        /// Oberlay transparent images, set size, parent image(s) and color
        /// 
        /// <br/>
        /// Instantiate Timer.
        /// </summary>
        public GraphicalInterface_Right()
        {
            InitializeComponent();

            // Vertical Airspeed Indicator
            originalVerticalAirspeedIndicatorDial = new Bitmap(Properties.Resources.VerticalAirspeedIndicatorDial);
            VerticalAirspeedIndicatorDial.Image = originalVerticalAirspeedIndicatorDial;

            VerticalAirspeedIndicatorDial.Parent = VerticalAirspeedIndicator;
            VerticalAirspeedIndicatorDial.Location = new Point(0, 0);
            VerticalAirspeedIndicatorDial.BackColor = Color.Transparent;

            // Altimeter
            // 100 dial
            originalAltimeter100Dial = new Bitmap(Properties.Resources.AltimeterDial100);
            Altimeter100Dial.Image = originalAltimeter100Dial;

            Altimeter100Dial.Parent = AltimeterBack;
            Altimeter100Dial.Location = new Point(0, 0);
            Altimeter100Dial.BackColor = Color.Transparent;

            // 1k dial
            originalAltimeter1kDial = new Bitmap(Properties.Resources.AltimeterDial1k);
            Altimeter1kDial.Image = originalAltimeter1kDial;

            Altimeter1kDial.Parent = Altimeter100Dial;
            Altimeter1kDial.Location = new Point(0, 0);
            Altimeter1kDial.BackColor = Color.Transparent;

            // 10k dial
            originalAltimeter10kDial = new Bitmap(Properties.Resources.AltimeterDial10k);
            Altimeter10kDial.Image = originalAltimeter10kDial;

            Altimeter10kDial.Parent = Altimeter1kDial;
            Altimeter10kDial.Location = new Point(0, 0);
            Altimeter10kDial.BackColor = Color.Transparent;

            // Clock

            // Hours
            originalClockHours = new Bitmap(Properties.Resources.Clock_Hours);
            ClockHours.Image = originalClockHours;

            ClockHours.Parent = ClockBase;
            ClockHours.Location = new Point(0, 0);
            ClockHours.BackColor = Color.Transparent;

            // Seconds
            originalClockSeconds = new Bitmap(Properties.Resources.Clock_Seconds);
            ClockSeconds.Image = originalClockSeconds;

            ClockSeconds.Parent = ClockHours;
            ClockSeconds.Location = new Point(0, 0);
            ClockSeconds.BackColor = Color.Transparent;

            // Minutes
            originalClockMinutes = new Bitmap(Properties.Resources.Clock_Minutes);
            ClockMinutes.Image = originalClockMinutes;

            ClockMinutes.Parent = ClockSeconds;
            ClockMinutes.Location = new Point(0, 0);
            ClockMinutes.BackColor = Color.Transparent;



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
        /// see https://foxlearn.com/csharp/image-rotation-8368.html
        /// </summary>
        /// <param name="image"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        /// 
        public static Bitmap SetImageRotation(Bitmap image, float degree)
        {
            Bitmap rotatedBitmap = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                // Translate image to center then rotate
                g.TranslateTransform(image.Width / 2f, image.Height / 2f);
                g.RotateTransform(degree);

                // Translate back to original position (to avoid resizing issue)
                g.TranslateTransform(-image.Width / 2f, -image.Height / 2f);
                g.DrawImage(image, new Point(0, 0));
            }
            return rotatedBitmap;
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

                }
                // Vertical Airspeed Indicator //
                currentVerticalAirspeedValue = (float)SimConnectUtility.VerticalAirspeedIndicatorValue;

                // // TODO: Stop vertical airspeed indicator if speed > 200 feet/sec
                if (SimConnectUtility.VerticalAirspeedIndicatorValue > 34.00f)
                    currentVerticalAirspeedValue = 34.0f;
                if (SimConnectUtility.VerticalAirspeedIndicatorValue < -34.00f)
                    currentVerticalAirspeedValue = -34.0f;

                rotatedVerticalAirspeedIndicatorDial = SetImageRotation(originalVerticalAirspeedIndicatorDial, currentVerticalAirspeedValue * 5.0f);
                VerticalAirspeedIndicatorDial.Image = rotatedVerticalAirspeedIndicatorDial;

                // Altimeter //
                float altitudeMod100000 = (float)(SimConnectUtility.AltimeterValue % 100000.0f);
                float altitudeMod10000 = (float)(SimConnectUtility.AltimeterValue % 10000.0f);
                float altitudeMod1000 = (float)(SimConnectUtility.AltimeterValue % 1000.0f);

                float thousands = (float)(SimConnectUtility.AltimeterValue / 1000.0f);
                float dial10kangle = (altitudeMod100000 / 100000.0f) * 360.0f;
                float dial1kangle = ((thousands % 10.0f) / 10.0f) * 360.0f;// - 180.0f;
                float dial100angle = (altitudeMod1000 / 1000.0f) * 360.0f;// - 180.0f;
                
                // Cleanup Altimeter 100 Dial
                if (Altimeter100Dial.Image != null && rotatedAltimeter100Dial != null)
                {
                    rotatedAltimeter100Dial.Dispose();
                }

                rotatedAltimeter100Dial = SetImageRotation(originalAltimeter100Dial, dial100angle);
                Altimeter100Dial.Image = rotatedAltimeter100Dial;

                // Cleanup Altimeter 1k Dial
                if (Altimeter1kDial.Image != null && rotatedAltimeter1kDial != null)
                {
                    rotatedAltimeter1kDial.Dispose();
                }

                rotatedAltimeter1kDial = SetImageRotation(originalAltimeter1kDial, dial1kangle);
                Altimeter1kDial.Image = rotatedAltimeter1kDial;

                // Cleanup Altimeter 10k dial
                if (Altimeter10kDial.Image != null && rotatedAltimeter10kDial != null)
                {
                    rotatedAltimeter10kDial.Dispose();
                }

                rotatedAltimeter10kDial = SetImageRotation(originalAltimeter10kDial, dial10kangle);
                Altimeter10kDial.Image = rotatedAltimeter10kDial;


                // Clock //
                if (ClockSeconds.Image != null && rotatedClockSeconds != null)
                {
                    rotatedClockSeconds.Dispose();
                }
                rotatedClockSeconds = SetImageRotation(originalClockSeconds, (float)(SimConnectUtility.SecondValue) * 6.0f);
                ClockSeconds.Image = rotatedClockSeconds;

                if (ClockMinutes.Image != null && rotatedClockMinutes != null)
                {
                    rotatedClockMinutes.Dispose();
                }
                rotatedClockMinutes = SetImageRotation(originalClockMinutes, (float)(SimConnectUtility.MinuteValue) * 6.0f);
                ClockMinutes.Image = rotatedClockMinutes;

                if (ClockHours.Image != null && rotatedClockHours != null)
                {
                    rotatedClockHours.Dispose();
                }
                rotatedClockHours = SetImageRotation(originalClockHours, (float)(SimConnectUtility.HourValue) * 30.0f);
                ClockHours.Image = rotatedClockHours;
            }

            Console.WriteLine("Tick");
        }
        
        /// <summary>
        /// Setter method for linked form
        /// </summary>
        /// <param name="leftForm"></param>
        public void setLinkedForm(GraphicalInterface_Left leftForm)
        {
            linkedForm = leftForm;
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
            linkedForm.isRightClosing = true;

            // If the other form didn't tell us it closed first, close it first
            if (!isLeftClosing)
            {
                //Close SimConnect client
                SimConnectUtility.DisconnectSimconnectClient();

                isLeftClosing = true; 
                linkedForm.Close();
            }
        }
    }
}

/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   2/23/25
 *  Class           :   GraphicalInterface.cs
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
    /// This module holds graphical elements to be displayed in the Instrumentation Panel.
    /// TODO: Create Second Form to display fullscreen on second display. 
    ///       This will require BaseDependencyUtility to detect secondary displays. 
    /// </summary>
    public partial class Graphicalnterface : Form
    {
        // Timer to update retrieved SimConnect values in text fields
        private Timer formTimer = null;

        private Bitmap originalImage;
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
        public Graphicalnterface()
        {
            InitializeComponent();
            originalImage = new Bitmap(Properties.Resources.HeadingIndicator1); // Circular gauge that shows degree values
            pictureBox1.Image = originalImage;

            pictureBox2.Parent = pictureBox1; // Transparent Airplane overlay
            pictureBox2.Location =  new Point(0,0);
            pictureBox2.BackColor = Color.Transparent;


            // initialize form closing event
            this.FormClosing += GraphicalInterface_OnClosing;

            // initialize form timer
            formTimer = new Timer();
            formTimer.Interval = 100;
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

        /// <summary>
        /// Testing button 
        /// Used to test updating data in graphical modules.
        /// (This button is to be removed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotateButton_Click(object sender, EventArgs e)
        {
            // 
            if (SimConnectUtility.ConnectionStatus != false)
            {
                // Retrieve Heading Indicator value from SimConnect Client, Refresh Simconnect. 
                float test = (float)SimConnectUtility.HeadingIndicatorValue;
                SimConnectUtility.RefreshSimconnect();

                // Set picturebox to rotational value retrieved from SimConnect.
                Bitmap rotatedImage = SetImageRotation(originalImage, test);
                pictureBox1.Image = rotatedImage;

            }
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
            // If a connection to SimConnect is established, Update the AltimeterValue text label
            // with the retrieved value.
            if (SimConnectUtility.ConnectionStatus)
            {
                // Refresh SimConnect Client
                SimConnectUtility.RefreshSimconnect();

                // Rotate background image based on rotational value of the Heading Indicator retrieved from SimConnect. 
                Bitmap rotatedImage = SetImageRotation(originalImage, -(float)SimConnectUtility.HeadingIndicatorValue);
                pictureBox1.Image = rotatedImage;
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
        }
    }
}

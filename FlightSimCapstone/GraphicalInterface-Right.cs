using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSimCapstone
{
    public partial class GraphicalInterface_Right : Form
    {
        private Timer formTimer = null;

        private Bitmap originalVerticalAirspeedIndicatorDial;

        // Link Left form to current form
        private GraphicalInterface_Left linkedForm;
        
        // Check if OnClosing event first fired in left form
        public bool isLeftClosing { get; set; }

        public GraphicalInterface_Right()
        {
            InitializeComponent();
            originalVerticalAirspeedIndicatorDial = new Bitmap(Properties.Resources.VerticalAirspeedIndicatorDial);
            VerticalAirspeedIndicatorDial.Image = originalVerticalAirspeedIndicatorDial;

            VerticalAirspeedIndicatorDial.Parent = VerticalAirspeedIndicator;
            VerticalAirspeedIndicatorDial.Location = new Point(0, 0);
            VerticalAirspeedIndicatorDial.BackColor = Color.Transparent;

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
            g.DrawImage(image, new Point(0, 0));
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
                SimConnectUtility.RefreshSimconnect();

                // Rotate background image based on rotational value of the Heading Indicator retrieved from SimConnect.
                // // TODO: Stop vertical airspeed indicator if speed > 200 feet/sec
                Bitmap rotatedImage = SetImageRotation(originalVerticalAirspeedIndicatorDial, (float)(SimConnectUtility.VerticalAirspeedIndicatorValue) * 5.0f);
                VerticalAirspeedIndicatorDial.Image = rotatedImage;

            }

            Console.WriteLine("Tick");
        }
        
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
                isLeftClosing = true; 
                linkedForm.Close();
            }
        }
    }
}

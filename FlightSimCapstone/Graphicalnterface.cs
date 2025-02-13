/*
 * https://foxlearn.com/csharp/image-rotation-8368.html
 * https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-improve-performance-by-avoiding-automatic-scaling?view=netframeworkdesktop-4.8
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
using static System.Net.Mime.MediaTypeNames;

namespace FlightSimCapstone
{
    public partial class Graphicalnterface : Form
    {
        // Timer to update retrieved SimConnect values in text fields
        private Timer formTimer = null;

        private Bitmap originalImage;
        private float degree = 0f;

        // Start process with parameters:
        // https://stackoverflow.com/questions/5766574/start-a-process-with-parameters
        private void launchFlightSim()
        {
            try
            {
                string fsDevModePath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator\FlightSimulator.exe";

                // Launch exe
                Process.Start(fsDevModePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start FS DevMode");
            }
        }

        public Graphicalnterface()
        {
            InitializeComponent();
            originalImage = new Bitmap(Properties.Resources.HeadingIndicator1);
            pictureBox1.Image = originalImage;

            pictureBox2.Parent = pictureBox1;
            pictureBox2.Location =  new Point(0,0);
            pictureBox2.BackColor = Color.Transparent;


            // initialize form closing event
            this.FormClosing += GraphicalInterface_OnClosing;

            // initialize form timer
            formTimer = new Timer();
            formTimer.Interval = 1000;
            formTimer.Tick += FormTimer_Tick;
            formTimer.Start();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        /// <see cref="https://foxlearn.com/csharp/image-rotation-8368.html"/>
        public static Bitmap SetImageRotation(Bitmap image, float degree)
        {
            Bitmap rotatedBitmap = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(rotatedBitmap);

            g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
            g.RotateTransform(degree);
            g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
            g.DrawImage(image, new Point(0,0));
            return rotatedBitmap;
        }
        private void RotateButton_Click(object sender, EventArgs e)
        {
            degree += 5f;

            if (degree >= 360)
                degree -= 360;

            //Bitmap rotatedImage = SetImageRotation(originalImage, degree);

            //pictureBox1.Image = rotatedImage;


            if (SimConnectUtility.ConnectionStatus != false)
            {
                Console.WriteLine("can connect");

                float test = (float)SimConnectUtility.HeadingIndicatorValue;
                Console.WriteLine(test);
                SimConnectUtility.RefreshSimconnect();

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
                SimConnectUtility.RefreshSimconnect();

                Bitmap rotatedImage = SetImageRotation(originalImage, -(float)SimConnectUtility.HeadingIndicatorValue);
                pictureBox1.Image = rotatedImage;
            }
        }


        private void GraphicalInterface_OnClosing(object sender, FormClosingEventArgs e)
        {
            formTimer.Stop();
            formTimer.Dispose();
        }
    }
}

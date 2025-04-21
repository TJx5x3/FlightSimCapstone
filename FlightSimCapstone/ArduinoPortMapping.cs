/**********************************************************************************
 *  Author          :   Jason Broom
 *  Course Number   :   STG-452
 *  Last Revision   :   3/11/25
 *  Class           :   GraphicalInterface-Left.cs
 *  Description     :   This module will contain various overlayed bitmap images to create graphical modules.
 *                      Each module will update according to real-time values retrieved from the SimConnect Client.
 **********************************************************************************
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace FlightSimCapstone
{
    /// <summary>
    /// 
    /// This class is serialized to JSON data to save 
    /// Arduino port mapping states defined in the dev form (DevForm.cs).
    /// 
    /// </summary>
    public class ArduinoPortMapping
    {
        private int throttle;
        private int mixture;
        private int brake;
        private int trimWheel;
        private int flapSwitch;

        /// <summary>
        /// Get or set the port number for throttle control
        /// </summary>
        public int Throttle
        {
            get { return throttle; }
            set { throttle = value; }
        }

        /// <summary>
        /// Get or set the port number for mixture control
        /// </summary>
        public int Mixture
        {
            get { return mixture; }
            set { mixture = value; }
        }

        /// <summary>
        /// Get or set the port number for brake control
        /// </summary>
        public int Brake
        {
            get { return brake; }
            set { brake = value; }
        }

        /// <summary>
        /// Get or set the port number for the Trim Wheel control
        /// </summary>
        public int TrimWheel
        {
            get { return trimWheel; }
            set { trimWheel = value; }
        }

        /// <summary>
        /// Get or set the port number for the Flap Switch control
        /// </summary>
        public int FlapSwitch
        {
            get { return flapSwitch; }
            set { flapSwitch = value; }
        }
    }
}

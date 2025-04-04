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
    /// This class is used to create objects where attributes correspond to user controls.
    /// 
    /// This class is serialized to JSON to save saved states defined in the dev form.
    /// 
    /// </summary>
    public class ArduinoPortMapping
    {
        private int throttle;
        private int mixture;
        private int brake;

        public int Throttle
        {
            get { return throttle; }
            set { throttle = value; }
        }

        public int Mixture
        {
            get { return mixture; }
            set { mixture = value; }
        }

        public int Brake
        {
            get { return brake; }
            set { brake = value; }
        }
    }
}

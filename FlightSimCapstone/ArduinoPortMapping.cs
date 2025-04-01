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
    public class ArduinoPortMapping
    {
        private int throttle;
        private int mixture;

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


    }
}

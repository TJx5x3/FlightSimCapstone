using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace FlightSimCapstone
{
    public static class SimConnectUtility
    {
        // Initialize SimConnect
        static SimConnect simconnect = null;
        const int WM_USER_SIMCONNECT = 0x0402;

    }
}

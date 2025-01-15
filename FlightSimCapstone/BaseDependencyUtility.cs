using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace FlightSimCapstone
{
    public static class BaseDependencyUtility
    {
        // Locate the Microsoft FLight Sim directory
        // NOTE: This will only work if MSFS 2020 is installed using Steam
        const string steamFlightSimPath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator";
        const string msfsSdkPath= @"C:\MSFS SDK";
        const string simConnectDllPath = @"C:\MSFS SDK\SimConnect SDK\lib\SimConnect.dll";
        const string simConnectNETDllPath = @"C:\MSFS SDK\SimConnect SDK\lib\managed\Microsoft.FlightSimulator.SimConnect.dll";

        const string flightSimExePath = @"C:\Program Files (x86)\Steam\steamapps\common\MicrosoftFlightSimulator\FlightSimulator.exe";

        // Path to SimConnect.dll
        const String simConnectPath = @"C:\";

        // Return bool if Flight Sim Directory can be located
        public static bool locateFlightSim()
        {
            return Directory.Exists(steamFlightSimPath);
        }

        // Return bool if Flight Sim SDK can be located
        public static bool locateFlightSimSDK()
        {
            return Directory.Exists(msfsSdkPath);
        }

        // Return bool if Flight Sim DLL can be located
        public static bool locateSimConnectDll()
        {
            return File.Exists(simConnectDllPath);
        }

        // Return bool if Flight Sim .NET DLL can be located
        public static bool locateSimConnectNETDll()
        {
            return File.Exists(simConnectNETDllPath);
        }

        // Return the file path to FlightSim.exe
        public static string getFlightSimExePath()
        {
            return flightSimExePath;
        }
    }
}

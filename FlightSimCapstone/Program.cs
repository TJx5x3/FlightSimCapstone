using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSimCapstone
{
    internal static class Program
    {
        public static UtilityForm UtilityForm
        {
            get => default;
            set
            {
            }
        }

        // Dependency inject SimConnect DLLs at runtime
        // https://stackoverflow.com/questions/8836093/how-can-i-specify-a-dllimport-path-at-runtime


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine(BaseDependencyUtility.LocateSimConnectDll());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UtilityForm());
        }
    }
}

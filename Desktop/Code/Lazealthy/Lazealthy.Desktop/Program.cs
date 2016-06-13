using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lazealthy.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag = false;
            string processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            System.Diagnostics.Process[] processesLazealthy = System.Diagnostics.Process.GetProcessesByName(processName);
            bool processCountValidFlag = (processesLazealthy != null && processesLazealthy.Length <= 1);
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, processName, out flag);
            if (!flag || !processCountValidFlag)
            {
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }
    }
}

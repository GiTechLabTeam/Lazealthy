using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lazealthy.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var service = new MainService();
                service.StartService(args);
                Console.WriteLine("Lazealthy service is running. Press any key to quit.");
                Console.ReadKey();
                service.StopService();
            }
            else
            {
                var ServicesToRun = new ServiceBase[] { new MainService() };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}

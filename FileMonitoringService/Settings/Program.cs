using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitoringService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive) //اذا كان في الكونسول
            {
                FileMonitoringService fileMonitoring = new FileMonitoringService();
                Console.WriteLine("______________________ Start Service _________________");
                fileMonitoring.StartService(null);
                Console.ReadKey();
                fileMonitoring.StopService();
                Console.WriteLine("_______________________ End ____________________");
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new FileMonitoringService()
                };
                ServiceBase.Run(ServicesToRun);
            }

        }
    }
}

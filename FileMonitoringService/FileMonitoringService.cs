using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileMonitoringService
{
    public partial class FileMonitoringService : ServiceBase
    {
        public FileMonitoringService()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            string watchFolder = ConfigurationManager.AppSettings["WatchFolder"];
            string destinationFolder = ConfigurationManager.AppSettings["DestinationFolder"];

            ClsMonitoringFile.CreateFile(watchFolder);       //انشاء الملف اذا غير موجود
            ClsMonitoringFile.CreateFile(destinationFolder);

            // جيب كل الملفات داخل المجلد
            string[] files = Directory.GetFiles(watchFolder);

            foreach (string file in files)
            {
                try
                {
                    // اسم الملف فقط
                    string fileName = Path.GetFileName(file);

                    // اسم جديد مع التاريخ
                    string newName = DateTime.Now.ToString("yyyy_MM_dd-HH_mm") + " " + fileName;

                    // المسار الجديد
                    string newPath = Path.Combine(destinationFolder, newName);

                    // نقل الملف
                    File.Move(file, newPath);

                    ClsMonitoringFile.Log("Moved: " + file);
                }
                catch (Exception ex)
                {
                    ClsMonitoringFile.Log("Error moving file: " + ex.Message);
                }
            }
        }

        protected override void OnStop()
        {


        }






        public void StartService(string[] args) 
        {
            OnStart(args);
        }

        public void StopService()
        {
            OnStop(); 
        }

        /// <summary>
        /// الطباعة بعد التحقق من انك في وضح الكونسول
        /// </summary>
     public static  void Print(dynamic Value , string Message ="")
        {
            if(Environment.UserInteractive)
            {
                Console.WriteLine($@"  {Value} {Message} ");
                Console.WriteLine("______________________________________________________");
            }
        }
    }
}

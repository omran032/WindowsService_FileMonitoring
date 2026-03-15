using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileMonitoringService
{
    internal class ClsMonitoringFile
    {

        /// <summary>
        /// تسجيل عمليات على ملف اللوغ
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message , string PathFile = "")
        {
            string path = ConfigurationManager.AppSettings["LogPath"];

            // إذا الملف غير موجود، أنشئه
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                FileMonitoringService.Print("Create ( ServiceLog.txt )");
            }

            // أضف السطر الجديد
            File.AppendAllText(path, $"{DateTime.Now} - {message}\n");
            FileMonitoringService.Print("Log :  ", $"{message}  {DateTime.Now} _ P{PathFile} \n");
        }

        /// <summary>
        /// انشاء مجلد معين اذا غير موجود
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFile(string path)
        {
            // إذا المجلد غير موجود → أنشئه
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Log("folder created: " , path);
            }
        }


    


    }
}

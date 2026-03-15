using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FileMonitoringService
{
    [RunInstaller(true)]
    public partial class Project_Installer : System.Configuration.Install.Installer
    {
        public Project_Installer()
        {
            InitializeComponent();
            LoadInstaller();
        }

        private ServiceInstaller SI;
        private ServiceProcessInstaller SPI;

        void LoadInstaller ()
        {
            SPI = new ServiceProcessInstaller()
            {
                Account = ServiceAccount.LocalSystem,

            };

            SI = new ServiceInstaller()
            {
                ServiceName = "FileMonitoringService",
                DisplayName = "MyFileMonitoringService",
                Description = @"خدمة ويندوز تقوم بمراقبة مجلد، وإعادة تسمية الملفات الجديدة، ونقلها إلى مجلد آخر، وحذف النسخة الأصلية، مع تسجيل جميع العمليات. قابلة للتكوين عبر App.config وتتضمن Installer للنشر.",
                StartType = ServiceStartMode.Automatic
            };

            Installers.Add(SI);
            Installers.Add(SPI);
        }

    }
}

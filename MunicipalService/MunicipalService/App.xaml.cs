using System.Configuration;
using System.Data;
using System.Windows;
using MunicipalService;

namespace MunicipalService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        // A public static CustomQueue to store Report objects, accessible from any window.
        public static CustomQueue<Report> ReportsQueue = new CustomQueue<Report>();
        public static int CurrentReportId = 1; // A simple counter to generate unique IDs

        public static EventsManager EventsManager { get; set; } = new EventsManager();

        public static ServiceRequestManager ServiceRequestManager { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize managers
            EventsManager = new EventsManager();
            ServiceRequestManager = new ServiceRequestManager();
        }

    }
}

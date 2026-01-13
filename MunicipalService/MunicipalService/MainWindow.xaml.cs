using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MunicipalService
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ReportIssuesButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Report Issues window
            ReportIssuesWindow reportWindow = new ReportIssuesWindow();

            // Show the Report Issues window
            reportWindow.Show();

            //Hides the main window 
            this.Hide();
        }

        private void LocalEventsButton_Click(object sender, RoutedEventArgs e)
        {
            LocalEventsWindow eventsWindow = new LocalEventsWindow();
            
            eventsWindow.Show();
            
            this.Hide();
        }

        private void ServiceRequestStatusButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusWindow statusWindow = new ServiceRequestStatusWindow();
            statusWindow.Show();
            this.Hide();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenPollButton_Click(object sender, RoutedEventArgs e)
        {
            var pollWindow = new PollWindow();
            pollWindow.Owner = this;
            pollWindow.Closed += PollWindow_Closed;
            pollWindow.ShowDialog();
        }

        private void PollWindow_Closed(object sender, EventArgs e)
        {
            // Refresh results when poll window closes
            DisplayPollResults();
        }

        private void DisplayPollResults()
        {
            var currentPoll = PollManager.Instance.CurrentPoll;

            if (currentPoll != null && currentPoll.GetTotalVotes() > 0)
            {
                PollQuestionText.Text = currentPoll.Question;
                TotalVotesText.Text = $"Total votes: {currentPoll.GetTotalVotes()}";

                // Calculate max votes for progress bars
                int maxVotes = currentPoll.Options.Max(option => option.VoteCount);
                PollResultsItems.Tag = maxVotes > 0 ? maxVotes : 1; 

                PollResultsItems.ItemsSource = currentPoll.Options;

                // Show results, hide notification
                PollResults.Visibility = Visibility.Visible;
                PollNotification.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Show notification, hide results
                PollResults.Visibility = Visibility.Collapsed;
                PollNotification.Visibility = Visibility.Visible;
            }
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayPollResults();
        }
    }
}
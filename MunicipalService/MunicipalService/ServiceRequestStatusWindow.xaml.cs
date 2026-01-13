using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MunicipalService
{
    public partial class ServiceRequestStatusWindow : Window
    {
        private ServiceRequestManager _requestManager;
        private bool _filtersReady = false;

        public ServiceRequestStatusWindow()
        {
            InitializeComponent();
            _requestManager = App.ServiceRequestManager;
            LoadFilters();
            LoadAllRequests();
            UpdateStatistics(_requestManager.AllRequests);
            _filtersReady = true; 
        }

        private void LoadFilters()
        {
            // Populate area filter dropdown
            AreaFilterComboBox.Items.Clear();
            AreaFilterComboBox.Items.Add(new ComboBoxItem { Content = "All Areas" });
            foreach (var area in _requestManager.GetAllAreas().OrderBy(a => a))
            {
                AreaFilterComboBox.Items.Add(new ComboBoxItem { Content = area });
            }
            AreaFilterComboBox.SelectedIndex = 0;
        }

        private void LoadAllRequests()
        {
            // Load all requests sorted by date (newest first)
            var allRequests = _requestManager.AllRequests
                .OrderByDescending(r => r.SubmissionDate)
                .ToList();

            RequestsItemsControl.ItemsSource = allRequests;
            UpdateResultsCount(allRequests.Count);
        }

        private void UpdateResultsCount(int count)
        {
            // Update results counter and show/hide "no results" message
            ResultsCount.Text = $"{count} request{(count != 1 ? "s" : "")} found";
            NoResultsText.Visibility = count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UpdateStatistics(System.Collections.Generic.IEnumerable<ServiceRequest> requests)
        {
            // Calculate and display request statistics
            var totalCount = requests.Count();
            var pendingCount = requests.Count(r => r.Status == "Pending");
            var inProgressCount = requests.Count(r => r.Status == "In Progress");
            var completedCount = requests.Count(r => r.Status == "Completed");
            var userRequestsCount = requests.Count(r => r.RequestId >= 2000);

            StatsText.Text =
                $"Total: {totalCount}\n" +
                $"Pending: {pendingCount}\n" +
                $"In Progress: {inProgressCount}\n" +
                $"Completed: {completedCount}\n" +
                $"Your Requests: {userRequestsCount}";
        }

        private void ViewFilter_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (!_filtersReady) return;
            ApplyFilters();
        }

        private void StatusFilter_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (!_filtersReady) return;
            ApplyFilters();
        }

        private void AreaFilter_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (!_filtersReady) return;
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (!_filtersReady) return;

            // Get current filter selections
            var viewFilter = (ViewFilterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            var statusFilter = (StatusFilterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            var areaFilter = (AreaFilterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            var filteredRequests = _requestManager.AllRequests.AsEnumerable();

            // Apply view filter (My Requests vs All Requests)
            if (viewFilter == "My Requests Only")
            {
                filteredRequests = filteredRequests.Where(r => r.RequestId >= 2000);
            }

            // Apply status filter
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All Status")
            {
                filteredRequests = filteredRequests.Where(r => r.Status == statusFilter);
            }

            // Apply area filter
            if (!string.IsNullOrEmpty(areaFilter) && areaFilter != "All Areas")
            {
                filteredRequests = filteredRequests.Where(r => r.Area == areaFilter);
            }

            // Display filtered results
            var results = filteredRequests.OrderByDescending(r => r.SubmissionDate).ToList();
            RequestsItemsControl.ItemsSource = results;
            UpdateResultsCount(results.Count);
            UpdateStatistics(results);
        }

        private void HighPriorityButton_Click(object sender, RoutedEventArgs e)
        {
            // Show only high priority requests
            var highPriorityRequests = _requestManager.GetHighPriorityRequests()
                .OrderByDescending(r => r.SubmissionDate)
                .ToList();

            RequestsItemsControl.ItemsSource = highPriorityRequests;
            UpdateResultsCount(highPriorityRequests.Count);
            UpdateStatistics(highPriorityRequests);
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset all filters to default values
            _filtersReady = false;
            ViewFilterComboBox.SelectedIndex = 0;
            StatusFilterComboBox.SelectedIndex = 0;
            AreaFilterComboBox.SelectedIndex = 0;
            _filtersReady = true;
            ApplyFilters();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Return to main window
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
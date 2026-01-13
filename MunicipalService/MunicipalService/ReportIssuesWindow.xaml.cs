using System;
using System.Windows;
using System.Windows.Controls;
using MunicipalService;
using Microsoft.Win32;

namespace MunicipalService
{
    public partial class ReportIssuesWindow : Window
    {
        public ReportIssuesWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a file dialog to browse for images
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                // Display the selected file path in the textbox
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(LocationTextBox.Text) ||
                CategoryComboBox.SelectedItem == null ||
                AreaComboBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                               MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate that location is not just whitespace or empty lines
            string location = LocationTextBox.Text.Trim();
            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please provide a valid location/address.", "Validation Error",
                               MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 1. Create a new Report object
            string selectedCategory = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string description = DescriptionTextBox.Text.Trim();
            string selectedArea = (AreaComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            var newReport = new Report(
                location: location,
                category: selectedCategory,
                description: description,
                filePath: FilePathTextBox.Text,
                id: App.CurrentReportId
            );

            // 2. Create service request from report BEFORE incrementing ID
            var serviceRequest = new ServiceRequest(
                id: App.CurrentReportId + 2000, // User requests start from 2000
                category: selectedCategory,
                location: location,
                description: description,
                status: "Pending", // User requests always pending
                 area: selectedArea,
                priority: DeterminePriorityFromCategory(selectedCategory) // Determine priority
            );

            // 3. Add it to the central Queue
            App.ReportsQueue.Enqueue(newReport);

            // 4. Add to service request manager
            App.ServiceRequestManager.AddUserRequest(serviceRequest);

            // 5. Increment the ID for the next report
            App.CurrentReportId++;

            // Success message
            MessageBox.Show($"Thank you! Your report #{newReport.ReportId} has been submitted. You are number {App.ReportsQueue.Count} in line.",
                           "Report Submitted", MessageBoxButton.OK, MessageBoxImage.Information);

            // Reset the form after submission
            LocationTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;
            DescriptionTextBox.Clear();
            FilePathTextBox.Clear();

            // Show ratings pop up
            ShowRatingPopup();
        }

       

        private int DeterminePriorityFromCategory(string category)
        {
            // Priority logic based on category
            return category?.ToLower() switch
            {
                "utilities" or "public safety" => 3, // High priority
                "road repair" or "sanitation" => 2,  // Medium priority
                _ => 1 // Low priority for others
            };
        }

        private void ShowRatingPopup()
        {
            var lastRatingTime = Properties.Settings.Default.LastRatingTime;
            if ((DateTime.Now - lastRatingTime).TotalDays < 1) // Only show once per day
                return;

            var ratingPopup = new RatingPopup();
            ratingPopup.Owner = this;
            var result = ratingPopup.ShowDialog();

            if (result == true)
            {
                Console.WriteLine($"User rated: {Properties.Settings.Default.LastRating}");
            }
        }
    }
}
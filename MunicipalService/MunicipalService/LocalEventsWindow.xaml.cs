using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MunicipalService
{
    public partial class LocalEventsWindow : Window
    {
        //references the events management system
        private EventsManager eventsManager;

        public LocalEventsWindow()
        {
            InitializeComponent();
            eventsManager = App.EventsManager;
            LoadEvents();
            LoadCategories();
            LoadRecentlyViewed();
        }

        //loads and displays upcoming events
        private void LoadEvents()
        {
            //gets the next 20 upcoming events
            var events = eventsManager.GetUpcomingEvents(20);
            EventsItemsControl.ItemsSource = events;
            UpdateResultsHeader(events.Count);
        }

        //populates the category filter
        private void LoadCategories()
        {
            CategoryComboBox.Items.Clear();
            CategoryComboBox.Items.Add(new ComboBoxItem { Content = "All Categories" });

            foreach (var category in eventsManager.Categories.OrderBy(c => c))
            {
                CategoryComboBox.Items.Add(new ComboBoxItem { Content = category });
            }

            CategoryComboBox.SelectedIndex = 0;
        }

        //loads the user's recently viewed history
        private void LoadRecentlyViewed()
        {
            // Convert stack to list for display (reverse to show most recent first)
            RecentlyViewedList.ItemsSource = eventsManager.RecentlyViewedEvents.Reverse().ToList();
        }

        
        private void UpdateResultsHeader(int resultCount)
        {
            if (resultCount == 0)
            {
                ResultsHeader.Text = "No Events Found";
                ResultsCount.Text = "";
                NoResultsText.Visibility = Visibility.Visible;
            }
            else
            {
                ResultsHeader.Text = $"Upcoming Events";
                ResultsCount.Text = $"{resultCount} event{(resultCount > 1 ? "s" : "")} found";
                NoResultsText.Visibility = Visibility.Collapsed;
            }
        }

        //searches/filters based on user input
        private void SearchEvents()
        {
            string searchTerm = SearchTextBox.Text;
            string selectedCategory = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            DateTime? selectedDate = DateFilterPicker.SelectedDate;

            // Use "All Categories" as null
            if (selectedCategory == "All Categories")
                selectedCategory = null;

            var results = eventsManager.SearchEvents(searchTerm, selectedCategory, selectedDate);
            EventsItemsControl.ItemsSource = results;
            UpdateResultsHeader(results.Count);
        }

        // Event Handlers
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchEvents();
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchEvents();
        }

        private void DateFilterPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchEvents();
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            CategoryComboBox.SelectedIndex = 0;
            DateFilterPicker.SelectedDate = null;
            SearchEvents();
        }

        private void RecentlyViewedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecentlyViewedList.SelectedItem is Event selectedEvent)
            {
                // Show event details 
                MessageBox.Show(
                    $"{selectedEvent.Title}\n\n" +
                    $"Date: {selectedEvent.Date:yyyy-MM-dd}\n" +
                    $"Location: {selectedEvent.Location}\n" +
                    $"Category: {selectedEvent.Category}\n" +
                    $"Organizer: {selectedEvent.Organizer}\n\n" +
                    $"{selectedEvent.Description}",
                    "Event Details",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        // gets event recommendations based on the current event's category
        private List<Event> GetCategoryRecommendations(Event currentEvent)
        {
            var recommendations = new List<Event>();
            string targetCategory = currentEvent.Category;

            // Look through all events to find ones with same category
            foreach (var dateEvents in eventsManager.EventsByDate)
            {
                foreach (var ev in dateEvents.Value)
                {
                    if (ev.Category == targetCategory &&
                        ev.Title != currentEvent.Title &&
                        ev.Date >= DateTime.Today)
                    {
                        recommendations.Add(ev);
                        if (recommendations.Count >= 3) // Get max 3 recommendations
                            return recommendations;
                    }
                }
            }

            return recommendations;
        }

        // shows recommendations to the user in a message box
        private void ShowSimpleRecommendations(List<Event> recommendations, string category)
        {
            string message = $"Other {category} events you might like:\n\n";

            foreach (var ev in recommendations)
            {
                message += $"• {ev.Title} ({ev.Date:MMM dd})\n";
            }

            

            MessageBox.Show(message, "You Might Also Like",
                           MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Event selectedEvent)
            {
                // Show event details
                MessageBox.Show(
                    $"📅 {selectedEvent.Title}\n\n" +
                    $"📖 Description: {selectedEvent.Description}\n\n" +
                    $"🗓️ Date: {selectedEvent.Date:dddd, MMMM dd, yyyy}\n" +
                    $"⏰ Time: {selectedEvent.Date:hh:mm tt}\n" +
                    $"📍 Location: {selectedEvent.Location}\n" +
                    $"📂 Category: {selectedEvent.Category}\n" +
                    $"👤 Organizer: {selectedEvent.Organizer}",
                    "Event Details",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // Show recommendations in the sidebar
                var similarEvents = GetCategoryRecommendations(selectedEvent);
                ShowSidebarRecommendations(similarEvents, selectedEvent.Category);

                // Add to recently viewed
                eventsManager.AddToRecentlyViewed(selectedEvent);
                LoadRecentlyViewed();
            }
        }

        private void ShowSidebarRecommendations(List<Event> recommendations, string category)
        {
            if (recommendations.Any())
            {
                SidebarRecommendationsItemsControl.ItemsSource = recommendations;
                RecommendationsSection.Visibility = Visibility.Visible;
                NoRecommendationsText.Visibility = Visibility.Collapsed;
            }
            else
            {
                RecommendationsSection.Visibility = Visibility.Collapsed;
                NoRecommendationsText.Visibility = Visibility.Visible;
            }
        }

        private void RecommendationViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Event selectedEvent)
            {
                // Show details for the recommended event
                MessageBox.Show(
                    $"📅 {selectedEvent.Title}\n\n" +
                    $"📖 Description: {selectedEvent.Description}\n\n" +
                    $"🗓️ Date: {selectedEvent.Date:dddd, MMMM dd, yyyy}\n" +
                    $"⏰ Time: {selectedEvent.Date:hh:mm tt}\n" +
                    $"📍 Location: {selectedEvent.Location}\n" +
                    $"📂 Category: {selectedEvent.Category}\n" +
                    $"👤 Organizer: {selectedEvent.Organizer}",
                    "Event Details",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // Add to recently viewed
                eventsManager.AddToRecentlyViewed(selectedEvent);
                LoadRecentlyViewed();
            }
        }
    }
}
using System;
using System.Windows;
using System.Windows.Controls;

namespace MunicipalService
{
    public partial class RatingPopup : Window
    {
        public string SelectedRating { get; private set; }

        public RatingPopup()
        {
            InitializeComponent();

            
            CommentTextBox.TextChanged += CommentTextBox_TextChanged;
            CommentTextBox.GotFocus += CommentTextBox_GotFocus;
            CommentTextBox.LostFocus += CommentTextBox_LostFocus;
        }

        private void CommentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }

        private void CommentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderText.Visibility = Visibility.Collapsed;
        }

        private void CommentTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }

        private void UpdatePlaceholderVisibility()
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(CommentTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void RatingButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            SelectedRating = button.Tag.ToString();

            
            HappyButton.Opacity = button == HappyButton ? 1.0 : 0.6;
            NeutralButton.Opacity = button == NeutralButton ? 1.0 : 0.6;
            SadButton.Opacity = button == SadButton ? 1.0 : 0.6;

            
            var submitButton = this.FindName("SubmitButton") as Button;
            if (submitButton != null)
            {
                submitButton.IsEnabled = true;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedRating))
            {
                MessageBox.Show("Please select a rating first.", "Rating Required",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Saves rating using Application Settings
            Properties.Settings.Default.LastRating = SelectedRating;
            Properties.Settings.Default.LastRatingComment = CommentTextBox.Text;
            Properties.Settings.Default.LastRatingTime = DateTime.Now;
            Properties.Settings.Default.Save();

            MessageBox.Show("Thank you for your feedback!", "Feedback Submitted",
                          MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true;
            this.Close();
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
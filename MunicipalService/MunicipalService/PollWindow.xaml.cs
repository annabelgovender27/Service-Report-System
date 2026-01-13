using System;
using System.Windows;
using System.Windows.Controls;

namespace MunicipalService
{
    public partial class PollWindow : Window
    {
        private int selectedOptionIndex = -1;

        public PollWindow()
        {
            InitializeComponent();
            LoadPollData();
        }

        private void LoadPollData()
        {
            var currentPoll = PollManager.Instance.CurrentPoll;

            if (currentPoll != null)
            {
                QuestionText.Text = currentPoll.Question;

                // Clear existing options
                OptionsPanel.Children.Clear();

                // buttons for each option
                for (int i = 0; i < currentPoll.Options.Count; i++)
                {
                    var option = currentPoll.Options[i];
                    var radioButton = new RadioButton
                    {
                        Content = option.OptionText,
                        Tag = i, 
                        Margin = new Thickness(0, 8, 0, 0),
                        FontSize = 14,
                        Cursor = System.Windows.Input.Cursors.Hand
                    };

                    radioButton.Checked += (s, e) =>
                    {
                        selectedOptionIndex = (int)((RadioButton)s).Tag;
                    };

                    OptionsPanel.Children.Add(radioButton);
                }
            }
        }

        private void SubmitVote_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOptionIndex >= 0)
            {
                PollManager.Instance.AddVoteToCurrentPoll(selectedOptionIndex);

                // Saves that user has voted using Application Settings
                Properties.Settings.Default.HasVotedInCurrentPoll = true;
                Properties.Settings.Default.Save();

                MessageBox.Show("Thank you for your vote!", "Vote Submitted",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an option before voting.",
                              "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalService
{
    public class PollOption
    {
        public string OptionText { get; set; }
        public int VoteCount { get; set; }
    }

    public class PollQuestion
    {
        public string Question { get; set; }
        public List<PollOption> Options { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PollQuestion()
        {
            Options = new List<PollOption>();
        }

        public void AddVote(int optionIndex)
        {
            if (optionIndex >= 0 && optionIndex < Options.Count)
            {
                Options[optionIndex].VoteCount++;
            }
        }

        public int GetTotalVotes()
        {
            return Options.Sum(option => option.VoteCount);
        }

        public string GetWinningOption()
        {
            if (Options.Count == 0) return "No options available";

            var maxVotes = Options.Max(option => option.VoteCount);
            var winningOptions = Options.Where(option => option.VoteCount == maxVotes).ToList();

            if (winningOptions.Count > 1)
                return "Tie between multiple options";

            return winningOptions[0].OptionText;
        }
    }

    public class PollManager
    {
        private static PollManager _instance;
        public static PollManager Instance => _instance ?? (_instance = new PollManager());

        public List<PollQuestion> Polls { get; set; }
        public PollQuestion CurrentPoll { get; set; }

        private PollManager()
        {
            Polls = new List<PollQuestion>();
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // sample poll
            CurrentPoll = new PollQuestion
            {
                Question = "What should be the municipality's top priority?",
                StartDate = DateTime.Now.AddDays(-7),
                EndDate = DateTime.Now.AddDays(7)
            };

            CurrentPoll.Options.Add(new PollOption { OptionText = "Road Maintenance" });
            CurrentPoll.Options.Add(new PollOption { OptionText = "Water Services" });
            CurrentPoll.Options.Add(new PollOption { OptionText = "Waste Management" });
            CurrentPoll.Options.Add(new PollOption { OptionText = "Public Safety" });

            // sample votes for poll results
            CurrentPoll.AddVote(0);
            CurrentPoll.AddVote(0);
            CurrentPoll.AddVote(1);
            CurrentPoll.AddVote(2);
            CurrentPoll.AddVote(0);
            CurrentPoll.AddVote(3);
            CurrentPoll.AddVote(1);

            Polls.Add(CurrentPoll);
        }

        public void AddVoteToCurrentPoll(int optionIndex)
        {
            CurrentPoll.AddVote(optionIndex);
        }
    }
}
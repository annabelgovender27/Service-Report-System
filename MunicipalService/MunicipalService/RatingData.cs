using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalService
{
    public class Rating
    {
        public string Emotion { get; set; } 
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public static class RatingManager
    {
        public static List<Rating> Ratings { get; private set; } = new List<Rating>();

        public static void AddRating(string emotion, string comment = "")
        {
            Ratings.Add(new Rating
            {
                Emotion = emotion,
                Comment = comment,
                Timestamp = DateTime.Now
            });

            
            SaveRatings();
        }

        public static int GetHappyCount() => Ratings.Count(r => r.Emotion == "Happy");
        public static int GetNeutralCount() => Ratings.Count(r => r.Emotion == "Neutral");
        public static int GetSadCount() => Ratings.Count(r => r.Emotion == "Sad");

        private static void SaveRatings()
        {
            
            try
            {
                var lines = Ratings.Select(r => $"{r.Timestamp}|{r.Emotion}|{r.Comment}");
                System.IO.File.WriteAllLines("ratings.txt", lines);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error saving ratings: {ex.Message}");
            }
        }

        public static void LoadRatings()
        {
            
            if (System.IO.File.Exists("ratings.txt"))
            {
                try
                {
                    var lines = System.IO.File.ReadAllLines("ratings.txt");
                    foreach (var line in lines)
                    {
                        var parts = line.Split('|');
                        if (parts.Length >= 2)
                        {
                            Ratings.Add(new Rating
                            {
                                Timestamp = DateTime.Parse(parts[0]),
                                Emotion = parts[1],
                                Comment = parts.Length > 2 ? parts[2] : ""
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error loading ratings: {ex.Message}");
                }
            }
        }
    }
}
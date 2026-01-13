using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalService
{
    public class EventsManager
    {
        // Primary storage - SortedDictionary for automatic date sorting
        public SortedDictionary<DateTime, List<Event>> EventsByDate { get; private set; }

        // Recently viewed events - Stack for Last In First Out (LIFO) behavior
        public Stack<Event> RecentlyViewedEvents { get; private set; }

        // Unique categories - HashSet for fast lookups and uniqueness
        public HashSet<string> Categories { get; private set; }

        //  Dictionary for quick event lookup by title
        public Dictionary<string, Event> EventsByTitle { get; private set; }

        public EventsManager()
        {
            EventsByDate = new SortedDictionary<DateTime, List<Event>>();
            RecentlyViewedEvents = new Stack<Event>();
            Categories = new HashSet<string>();
            EventsByTitle = new Dictionary<string, Event>();

            InitializeSampleEvents();
        }

        private void InitializeSampleEvents()
        {
            
            AddEvent(new Event
            {
                Title = "Community Clean-up Day",
                Description = "Join your neighbors for a community-wide clean-up event. Gloves and bags provided!",
                Category = "Environment",
                Date = DateTime.Now.AddDays(7),
                Location = "Central Park",
                Organizer = "Municipal Council"
            });

            AddEvent(new Event
            {
                Title = "Neighborhood Recycling Drive",
                Description = "Drop off recyclables and learn about proper waste management practices",
                Category = "Environment",
                Date = DateTime.Now.AddDays(14),
                Location = "Recycling Center",
                Organizer = "Environmental Department"
            });

            AddEvent(new Event
            {
                Title = "Tree Planting Initiative",
                Description = "Help us plant 100 new trees in urban areas to improve air quality",
                Category = "Environment",
                Date = DateTime.Now.AddDays(21),
                Location = "Greenbelt Area",
                Organizer = "Parks Department"
            });

            AddEvent(new Event
            {
                Title = "River Clean-up Project",
                Description = "Volunteer to clean up our local river and surrounding areas",
                Category = "Environment",
                Date = DateTime.Now.AddDays(28),
                Location = "Riverside Park",
                Organizer = "Environmental Department"
            });

            
            AddEvent(new Event
            {
                Title = "Budget Planning Meeting",
                Description = "Public meeting to discuss municipal budget for next fiscal year",
                Category = "Government",
                Date = DateTime.Now.AddDays(3),
                Location = "Town Hall",
                Organizer = "Finance Department"
            });

            AddEvent(new Event
            {
                Title = "Council Public Session",
                Description = "Monthly council meeting open to public questions and concerns",
                Category = "Government",
                Date = DateTime.Now.AddDays(10),
                Location = "Council Chambers",
                Organizer = "Municipal Council"
            });

            AddEvent(new Event
            {
                Title = "Tax Information Workshop",
                Description = "Learn about property tax assessments and payment options",
                Category = "Government",
                Date = DateTime.Now.AddDays(17),
                Location = "Community Center",
                Organizer = "Revenue Services"
            });

            
            AddEvent(new Event
            {
                Title = "Summer Festival",
                Description = "Annual summer festival with food, music, games, and activities for all ages",
                Category = "Entertainment",
                Date = DateTime.Now.AddDays(14),
                Location = "Main Street",
                Organizer = "Tourism Board"
            });

            AddEvent(new Event
            {
                Title = "Friday Night Concert Series",
                Description = "Live music performances every Friday evening throughout summer",
                Category = "Entertainment",
                Date = DateTime.Now.AddDays(5),
                Location = "Amphitheater",
                Organizer = "Cultural Affairs"
            });

            AddEvent(new Event
            {
                Title = "Food Truck Fair",
                Description = "Sample cuisine from 20+ local food trucks and vendors",
                Category = "Entertainment",
                Date = DateTime.Now.AddDays(12),
                Location = "Market Square",
                Organizer = "Business Association"
            });

            AddEvent(new Event
            {
                Title = "Outdoor Movie Night",
                Description = "Family-friendly movie screening under the stars - bring blankets and chairs",
                Category = "Entertainment",
                Date = DateTime.Now.AddDays(19),
                Location = "Central Park",
                Organizer = "Recreation Department"
            });

            AddEvent(new Event
            {
                Title = "Art Walk Weekend",
                Description = "Self-guided tour of local art galleries and street installations",
                Category = "Entertainment",
                Date = DateTime.Now.AddDays(25),
                Location = "Arts District",
                Organizer = "Cultural Affairs"
            });

            
            AddEvent(new Event
            {
                Title = "Road Maintenance Info Session",
                Description = "Learn about upcoming road maintenance projects and traffic diversions",
                Category = "Infrastructure",
                Date = DateTime.Now.AddDays(5),
                Location = "Community Center",
                Organizer = "Public Works"
            });

            AddEvent(new Event
            {
                Title = "Public Transport Forum",
                Description = "Discuss improvements to bus routes and schedules",
                Category = "Infrastructure",
                Date = DateTime.Now.AddDays(11),
                Location = "Transit Center",
                Organizer = "Transport Department"
            });

            AddEvent(new Event
            {
                Title = "Bridge Construction Update",
                Description = "Information session about the new bridge construction timeline",
                Category = "Infrastructure",
                Date = DateTime.Now.AddDays(18),
                Location = "Library Auditorium",
                Organizer = "Public Works"
            });

            AddEvent(new Event
            {
                Title = "Water System Maintenance Briefing",
                Description = "Updates on planned water system upgrades and maintenance schedules",
                Category = "Infrastructure",
                Date = DateTime.Now.AddDays(24),
                Location = "Water Treatment Plant",
                Organizer = "Utilities Department"
            });

           
            AddEvent(new Event
            {
                Title = "Community Health Fair",
                Description = "Free health screenings, wellness information, and fitness demonstrations",
                Category = "Health",
                Date = DateTime.Now.AddDays(8),
                Location = "Community Center",
                Organizer = "Health Department"
            });

            AddEvent(new Event
            {
                Title = "Mental Wellness Workshop",
                Description = "Learn stress management techniques and mental health resources",
                Category = "Health",
                Date = DateTime.Now.AddDays(15),
                Location = "Wellness Center",
                Organizer = "Mental Health Services"
            });

            AddEvent(new Event
            {
                Title = "Vaccination Drive",
                Description = "Free flu shots and COVID-19 boosters for residents",
                Category = "Health",
                Date = DateTime.Now.AddDays(22),
                Location = "Health Clinic",
                Organizer = "Public Health"
            });

           
            AddEvent(new Event
            {
                Title = "Adult Education Open House",
                Description = "Explore continuing education courses and vocational training programs",
                Category = "Education",
                Date = DateTime.Now.AddDays(6),
                Location = "Adult Learning Center",
                Organizer = "Education Department"
            });

            AddEvent(new Event
            {
                Title = "Library Tech Workshop",
                Description = "Learn digital skills: internet basics, email, and online resources",
                Category = "Education",
                Date = DateTime.Now.AddDays(13),
                Location = "Main Library",
                Organizer = "Library Services"
            });

            AddEvent(new Event
            {
                Title = "Career Development Seminar",
                Description = "Job search strategies, resume writing, and interview skills",
                Category = "Education",
                Date = DateTime.Now.AddDays(20),
                Location = "Career Center",
                Organizer = "Employment Services"
            });

            
            AddEvent(new Event
            {
                Title = "Neighborhood Watch Meeting",
                Description = "Community safety discussion and crime prevention tips",
                Category = "Safety",
                Date = DateTime.Now.AddDays(9),
                Location = "Police Community Room",
                Organizer = "Police Department"
            });

            AddEvent(new Event
            {
                Title = "Emergency Preparedness Workshop",
                Description = "Learn how to prepare for natural disasters and emergencies",
                Category = "Safety",
                Date = DateTime.Now.AddDays(16),
                Location = "Fire Station #1",
                Organizer = "Emergency Services"
            });
        }

        public void AddEvent(Event eventItem)
        {
            // Add to SortedDictionary by date
            if (!EventsByDate.ContainsKey(eventItem.Date.Date))
            {
                EventsByDate[eventItem.Date.Date] = new List<Event>();
            }
            EventsByDate[eventItem.Date.Date].Add(eventItem);

            // Add to categories set
            Categories.Add(eventItem.Category);

            // Add to title dictionary
            EventsByTitle[eventItem.Title] = eventItem;
        }

        public void AddToRecentlyViewed(Event eventItem)
        {
            RecentlyViewedEvents.Push(eventItem);
            // Keep only last 10 viewed events
            if (RecentlyViewedEvents.Count > 10)
            {
                var tempStack = new Stack<Event>();
                for (int i = 0; i < 10; i++)
                {
                    tempStack.Push(RecentlyViewedEvents.Pop());
                }
                RecentlyViewedEvents = tempStack;
            }
        }

        public List<Event> SearchEvents(string searchTerm, string category = null, DateTime? date = null)
        {
            var results = new List<Event>();

            foreach (var dateEvents in EventsByDate)
            {
                foreach (var eventItem in dateEvents.Value)
                {
                    bool matchesSearch = string.IsNullOrEmpty(searchTerm) ||
                                       eventItem.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                       eventItem.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);

                    bool matchesCategory = string.IsNullOrEmpty(category) ||
                                         eventItem.Category.Equals(category, StringComparison.OrdinalIgnoreCase);

                    bool matchesDate = !date.HasValue || eventItem.Date.Date == date.Value.Date;

                    if (matchesSearch && matchesCategory && matchesDate)
                    {
                        results.Add(eventItem);
                    }
                }
            }

            return results;
        }

        public List<Event> GetUpcomingEvents(int count = 5)
        {
            var upcoming = new List<Event>();
            foreach (var dateEvents in EventsByDate.Where(kv => kv.Key >= DateTime.Today))
            {
                upcoming.AddRange(dateEvents.Value);
                if (upcoming.Count >= count) break;
            }
            return upcoming.Take(count).ToList();
        }
    }
}
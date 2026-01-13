using System;
using System.Windows.Media;

namespace MunicipalService
{

    // Represents a municipal service request with all relevant details
    // serves as a data model for tracking service requests in the system
    public class ServiceRequest
    {
        public int RequestId { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Area { get; set; }
        public int Priority { get; set; }

        // Computed properties for display
        public string PriorityText => Priority switch
        {
            1 => "LOW",
            2 => "MEDIUM",
            3 => "HIGH",
            _ => "UNKNOWN"
        };

        public SolidColorBrush PriorityColor => Priority switch
        {
            1 => new SolidColorBrush(Color.FromRgb(76, 175, 80)),   
            2 => new SolidColorBrush(Color.FromRgb(255, 193, 7)),
            3 => new SolidColorBrush(Color.FromRgb(244, 67, 54)),   
            _ => new SolidColorBrush(Color.FromRgb(158, 158, 158))  
        };


        // Constructor to initialize a new service request
        public ServiceRequest(int id, string category, string location, string description, string status, string area, int priority = 2)
        {
            RequestId = id;
            Category = category;
            Location = location;
            Description = description;
            Status = status;
            Area = area;
            Priority = priority;
            SubmissionDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"#{RequestId}: {Category} at {Location} - {Status}";
        }
    }
}
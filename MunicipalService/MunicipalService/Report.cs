using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalService
{
    public class Report
    {
        //  properties for the report data
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; } 
        public DateTime SubmissionTime { get; set; }
        public int ReportId { get; set; }

        // Constructor to initialize a new report
        public Report(string location, string category, string description, string filePath, int id)
        {
            Location = location;
            Category = category;
            Description = description;
            FilePath = filePath;
            SubmissionTime = DateTime.Now; 
            ReportId = id;
        }

        
        public override string ToString()
        {
            return $"ID: {ReportId} | {Category} issue at {Location} (Submitted: {SubmissionTime})";
        }
    }
}

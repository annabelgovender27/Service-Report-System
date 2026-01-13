using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MunicipalService
{
    //  converts priority levels to colors for UI display
    // Implements IValueConverter interface for WPF data binding
    public class PriorityToColorConverter : IValueConverter
    {
        // Convert method - changes priority number to a colored brush for display
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is int priority)
            {
                
                return priority switch
                {
                    // Priority 1: Low priority - Green color 
                    1 => new SolidColorBrush(Color.FromRgb(76, 175, 80)),

                    // Priority 2: Medium priority - Yellow color 
                    2 => new SolidColorBrush(Color.FromRgb(255, 193, 7)),

                    // Priority 3: High priority - Red color 
                    3 => new SolidColorBrush(Color.FromRgb(244, 67, 54)),

                    // Default case: Unknown priority - Gray color 
                    _ => new SolidColorBrush(Color.FromRgb(158, 158, 158))
                };
            }

            // If value is not an integer, return default gray color
            return new SolidColorBrush(Color.FromRgb(158, 158, 158));
        }

        // ConvertBack method - not implemented since this is one-way conversion
       
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // converts priority levels to human-readable text
    // Also implements IValueConverter interface for WPF data binding
    public class PriorityToTextConverter : IValueConverter
    {
        // Convert method - transforms priority number to descriptive text
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the incoming value is an integer representing priority
            if (value is int priority)
            {
                
                return priority switch
                {
                    // Priority 1: Low priority
                    1 => "LOW",

                    // Priority 2: Medium priority  
                    2 => "MEDIUM",

                    // Priority 3: High priority
                    3 => "HIGH",

                    // Default case: Unknown priority
                    _ => "UNKNOWN"
                };
            }

            // If value is not an integer, return "UNKNOWN"
            return "UNKNOWN";
        }

        // ConvertBack method - not implemented since this is one-way conversion
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
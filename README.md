
# Municipal Services Application

A comprehensive .NET WPF desktop application designed to streamline citizen engagement and service delivery for a South African municipality. This application allows residents to report issues, view local events, and track the status of their service requests across three progressive development phases.

## 🚀 Complete Application Features

### **Core Reporting System**
- **Main Menu** - User-friendly interface for navigating all municipal services
- **Report Issues** - Submit municipal issues with details such as location, category, description, and optional image attachments
- **User Engagement Features** - Dynamic progress indicators and encouraging messaging

### **Events & Community Engagement**
- **Local Events & Announcements**
  - Browse upcoming community events with advanced search and filtering
  - View events by category, date, and organizer
  - Recently viewed events tracking using Stack data structure
  - Event recommendations system based on user preferences
- **Enhanced User Engagement Tools**
  - In-app polling system with real-time results visualization
  - Daily experience rating system after report submission
  - Interactive event discovery with category-based recommendations

### **Advanced Service Management**
- **Service Request Status Tracking**
  - Comprehensive view of all service requests with real-time status updates
  - Advanced filtering by status, area, priority, and user submissions
  - Priority-based request management using Heap data structures
- **Geographic Relationship Mapping**
  - Graph-based visualization of service requests by area
  - Graph traversal to find related requests in geographic zones
- **Efficient Data Management**
  - Binary Search Trees for fast request lookup by ID
  - Graph structures for managing complex geographic relationships
  - Priority queues for urgent request handling

## 🛠️ Prerequisites

**Before you can compile and run this application, ensure you have the following installed:**

- **Visual Studio 2022** - Download from: https://visualstudio.microsoft.com/vs/
- **.NET SDK 8.0** (or later) - Download from: https://dotnet.microsoft.com/download
- **Git** (for version control access) - Download from: https://git-scm.com/downloads

## ⚙️ How to Build and Run

### 1. Clone the Repository
```bash
git clone https://github.com/VCWVL/prog7312-part-2-ST10271600.git
cd municipal-services-app
```

### 2. Open in Visual Studio
- Open Visual Studio 2022
- File → Open → Project/Solution → MunicipalServicesApp.sln

### 3. Restore NuGet Packages
If not restored automatically:
- Right-click the solution in Solution Explorer
- Select "Restore NuGet Packages"

### 4. Build the Solution
- Press `Ctrl + Shift + B` or
- Go to Build → Build Solution

## 🧑‍💻 How to Use the Application

### 📝 Reporting Issues
1. Run the application
2. Click "Report Issues"
3. Fill in required fields: location, category, area, and description
4. Optionally attach an image
5. Submit your report

### 📊 Rating Your Experience
- After submitting a report, a pop-up window will appear
- Rate your experience using simple emoji feedback
- Optionally leave a comment (appears once per day)

### 📊 Participating in Polls
- Navigate to the Community Polls section on the home screen
- Choose your preference and vote
- View poll results and community feedback

### 🗓️ Looking at Local Events
- From the main menu, click "Local Events and Announcements"
- Use search box to find specific events
- Filter by category using the dropdown
- Filter by specific date using the date picker
- Click "View Details" on any event for more information
- View your recently visited events in the left panel

### 📋 Tracking Service Requests
- From the main menu, click "Service Request Status"
- View all service requests with comprehensive filtering options
- Filter by: "All Requests" or "My Requests Only"
- Filter by status: Pending, In Progress, Completed
- Filter by geographic area
- View high-priority requests using the priority filter
- Track submission dates and request progress

## 🧱 Technical Architecture

### **Advanced Data Structures Implemented**


- **`CustomQueue<T>`** - Custom queue using `LinkedList<T>` to manage citizen reports in FIFO order
- **`List<Report>`** - Stores all submitted reports for review and management
- **`SortedDictionary<DateTime, List<Event>>`** - Automatically sorts events by date for efficient chronological display
- **`Stack<Event>`** - LIFO collection for tracking recently viewed events (last 10 events)
- **`HashSet<string>`** - Ensures unique event categories with fast lookup operations
- **`Dictionary<string, Event>`** - Provides O(1) event lookup by title for quick access
- **`List<T>` Collections** - Multiple generic lists for polls, ratings, and event management
- **`BinarySearchTree<ServiceRequest>`** - Efficient O(log n) lookup and organization of service requests by ID
- **`PriorityHeap<ServiceRequest>`** - Max-heap implementation for prioritizing high-urgency service requests
- **Graph Structures** - Geographic relationship mapping between service requests using adjacency lists
- **Graph Traversal Algorithms** - BFS/DFS for finding related requests in geographic areas
- **Area-Based Grouping** - Dictionary-based graph representation for efficient area-based filtering

## 🎯 Key Technical Achievements

### **Data Structure Integration**
- **Binary Search Trees** - Efficient service request lookup and management
- **Graph Theory Application** - Geographic relationship modeling between service areas
- **Heap-Based Prioritization** - Urgent request handling system
- **Advanced Collections** - Comprehensive data organization across all application features

### **Algorithm Implementation**
- **Graph Traversal** - Breadth-First Search for area-based request discovery
- **Tree Operations** - Efficient insertion, search, and retrieval of service requests
- **Priority Queue Operations** - Max-heap implementation for urgent request management
- **Search Algorithms** - Advanced filtering across multiple data dimensions

### **User Experience Features**
- **Real-time Filtering** - Instant results across all data views
- **Intelligent Recommendations** - Category-based event suggestions
- **Progress Tracking** - Comprehensive service request status monitoring
- **Geographic Context** - Area-based request grouping and visualization

## 👤 Developer

- **Name**: Annabel Govender

## 📫 Contact

For questions or support: 
Email: Annabelgovender27@gmail.com

## 📚 References

### **Core WPF & .NET Development**
Microsoft Docs - WPF Fundamentals
URL: https://docs.microsoft.com/en-us/dotnet/desktop/wpf/

WPF Tutorial .NET
URL: https://wpf-tutorial.com/

Stack Overflow - WPF Questions
URL: https://stackoverflow.com/questions/tagged/wpf

C# Corner - WPF Section
URL: https://www.c-sharpcorner.com/article/tag/wpf/

GitHub - WPF Samples
URL: https://github.com/microsoft/WPF-Samples

Code Project - WPF Articles
URL: https://www.codeproject.com/script/Articles/Latest.aspx?tdir=1&lang=WPF

Microsoft Docs - Application Settings
URL: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/advanced/application-settings

TutorialsTeacher - WPF
URL: https://www.tutorialsteacher.com/wpf

WPFTutorials.net
URL: http://www.wpftutorial.net/

Dot Net Perls - WPF Examples
URL: https://www.dotnetperls.com/wpf

### **Data Structures & Algorithms**
Microsoft Docs - Generic Collections in .NET
URL: https://docs.microsoft.com/en-us/dotnet/standard/generics/collections

Microsoft Docs - SortedDictionary<TKey,TValue> Class
URL: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2

Microsoft Docs - Stack Class
URL: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1

Microsoft Docs - HashSet Class
URL: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1

Microsoft Docs - WPF Data Binding
URL: https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/data-binding-overview

Microsoft Docs - WPF Styles and Templates
URL: https://docs.microsoft.com/en-us/dotnet/desktop/wpf/controls/styling-and-templating

Microsoft Docs - Application Settings Architecture
URL: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/advanced/application-settings-architecture

C# Corner - Implementing Custom Collections
URL: https://www.c-sharpcorner.com/article/implementing-custom-collections-in-C-Sharp/

Stack Overflow - WPF Window Navigation Patterns
URL: https://stackoverflow.com/questions/tagged/wpf+navigation

TutorialsTeacher - WPF ItemsControl
URL: https://www.tutorialsteacher.com/wpf/itemscontrol-wpf

WPF Tutorial - Data Templates
URL: https://wpf-tutorial.com/data-binding/data-templates/

Code Project - WPF MVVM Navigation
URL: https://www.codeproject.com/Articles/526786/WPF-Navigation-MVVM

Microsoft Docs - File I/O in .NET
URL: https://docs.microsoft.com/en-us/dotnet/standard/io/

C# Corner - DateTime Operations
URL: https://www.c-sharpcorner.com/article/datetime-in-c-sharp/

Stack Overflow - WPF Popup Dialog Patterns
URL: https://stackoverflow.com/questions/tagged/wpf+dialog

### **Advanced Data Structures & Algorithms**
GeeksforGeeks - Binary Search Tree Data Structure
URL: https://www.geeksforgeeks.org/binary-search-tree-data-structure/

GeeksforGeeks - Graph Data Structure and Algorithms
URL: https://www.geeksforgeeks.org/graph-data-structure-and-algorithms/

GeeksforGeeks - Heap Data Structure
URL: https://www.geeksforgeeks.org/heap-data-structure/

C# Corner - Binary Search Tree Implementation in C#
URL: https://www.c-sharpcorner.com/article/binary-search-tree-in-c-sharp/

Stack Overflow - Graph Traversal in C#
URL: https://stackoverflow.com/questions/tagged/c%23+graph+traversal

Microsoft Docs - Queue Class
URL: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1

Microsoft Docs - List Class
URL: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1


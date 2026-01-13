using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalService
{
    public class ServiceRequestManager
    {
        // Binary Search Tree for efficient ID lookup
        private BinarySearchTree<ServiceRequest> _requestsById;

        // Graph for geographic relationships
        private Dictionary<string, List<int>> _areaGraph;

        // Heap for priority management
        private PriorityHeap<ServiceRequest> _priorityHeap;

        // List of all requests
        public List<ServiceRequest> AllRequests { get; private set; }

        public ServiceRequestManager()
        {
            _requestsById = new BinarySearchTree<ServiceRequest>();
            _areaGraph = new Dictionary<string, List<int>>();
            _priorityHeap = new PriorityHeap<ServiceRequest>();
            AllRequests = new List<ServiceRequest>();

            InitializeDummyData();
        }

        private void InitializeDummyData()
        {
            // Dummy data with different statuses
            AddRequest(new ServiceRequest(1001, "Road Repair", "Main Street & 1st Ave", "Large pothole causing traffic issues", "In Progress", "Durban", 3));
            AddRequest(new ServiceRequest(1002, "Sanitation", "Oak Avenue", "Garbage not collected for 3 days", "Completed", "Pinetown", 2));
            AddRequest(new ServiceRequest(1003, "Utilities", "River Road", "Water leak near fire hydrant", "Pending", "Hillcrest", 3));
            AddRequest(new ServiceRequest(1004, "Public Safety", "City Park", "Broken playground equipment", "In Progress", "Kloof", 2));
            AddRequest(new ServiceRequest(1005, "Street Lights", "Pine Street", "Street light out at intersection", "Completed", "New Germany", 2));
            AddRequest(new ServiceRequest(1006, "Parks", "Community Garden", "Overgrown vegetation blocking pathway", "Pending", "Umhlanga", 1));
            AddRequest(new ServiceRequest(1007, "Drainage", "Coastal Road", "Blocked stormwater drain causing flooding", "In Progress", "Amanzimtoti", 3));
            AddRequest(new ServiceRequest(1008, "Traffic Signals", "Main Intersection", "Malfunctioning traffic lights", "Pending", "Westville", 2));
            AddRequest(new ServiceRequest(1009, "Beach Maintenance", "Main Beach", "Lifesaving equipment needs replacement", "Completed", "Ballito", 2));
            AddRequest(new ServiceRequest(1010, "Public Transport", "Bus Terminal", "Shelter damage at bus stop", "In Progress", "Umbilo", 1));
        }

        public void AddUserRequest(ServiceRequest request)
        {
            // User requests always start as Pending
            request.Status = "Pending";
            AddRequest(request);
        }

        private void AddRequest(ServiceRequest request)
        {
            AllRequests.Add(request);
            _requestsById.Insert(request.RequestId, request);
            _priorityHeap.Insert(request, request.Priority);

            // Add to area graph
            if (!_areaGraph.ContainsKey(request.Area))
                _areaGraph[request.Area] = new List<int>();
            _areaGraph[request.Area].Add(request.RequestId);
        }

        // Graph traversal - get all requests in an area
        public List<ServiceRequest> GetRequestsInArea(string area)
        {
            var requests = new List<ServiceRequest>();
            if (_areaGraph.ContainsKey(area))
            {
                foreach (var requestId in _areaGraph[area])
                {
                    var request = _requestsById.Search(requestId);
                    if (request != null)
                        requests.Add(request);
                }
            }
            return requests;
        }

        // Get high priority requests (Heap usage)
        public List<ServiceRequest> GetHighPriorityRequests()
        {
            return _priorityHeap.GetTopPriorities(5);
        }

        public List<ServiceRequest> GetRequestsByStatus(string status)
        {
            return AllRequests.Where(r => r.Status == status).ToList();
        }

        public List<string> GetAllAreas()
        {
            return _areaGraph.Keys.ToList();
        }
    }
}
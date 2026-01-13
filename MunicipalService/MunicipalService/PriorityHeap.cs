using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalService
{
    // PriorityHeap class - a max-heap implementation for prioritizing items
    // T is the type of items to be stored in the heap
    public class PriorityHeap<T>
    {
        // Internal storage: list of tuples containing the item and its priority
        // The heap is represented as a list where each element has (Item, Priority)
        private List<(T Item, int Priority)> heap = new List<(T, int)>();

        //  adds a new item with specified priority to the heap
        public void Insert(T item, int priority)
        {
            // Step 1: Add the new element at the end of the list
            heap.Add((item, priority));

            // Step 2: Restore heap property by moving the new element up as needed
            HeapifyUp(heap.Count - 1);
        }

        // GetTopPriorities method - retrieves the top 'count' highest priority items
     
        public List<T> GetTopPriorities(int count)
        {
            // Order the heap by priority in descending order (highest first)
            // Take the specified number of top items
            // Extract just the items (without priorities) and return as list
            return heap.OrderByDescending(x => x.Priority)
                      .Take(count)
                      .Select(x => x.Item)
                      .ToList();
        }

        // maintains heap property by moving an element up the tree
        // Used after insertion to ensure the max-heap property is preserved
        private void HeapifyUp(int index)
        {
            // Continue until we reach the root (index 0)
            while (index > 0)
            {
                // Calculate parent index
                int parent = (index - 1) / 2;

                // Max-heap property: parent should be >= child
                // If parent has higher or equal priority, heap property is satisfied
                if (heap[parent].Priority >= heap[index].Priority)
                    break;

                // If child has higher priority than parent, swap them
                // This moves the higher priority item up the tree
                var temp = heap[parent];
                heap[parent] = heap[index];
                heap[index] = temp;

                // Move up to the parent position and continue checking
                index = parent;
            }
        }
    }
}
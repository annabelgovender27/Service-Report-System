using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace MunicipalService
{
    public class CustomQueue<T>
    {
        // A LinkedList is used as the underlying data structure for efficient enqueueing and dequeueing.
        private readonly LinkedList<T> _items = new LinkedList<T>();

        // Enqueue: Add an item to the end of the queue.
        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        // Dequeue: Remove and return the item from the front of the queue.
        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items.First.Value;
            _items.RemoveFirst();
            return value;
        }

        // Peek: Return the item from the front without removing it.
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items.First.Value;
        }

        // Property to get the number of elements in the queue.
        public int Count => _items.Count;

        // Method to check if the queue is empty.
        public bool IsEmpty => _items.Count == 0;
    }
}
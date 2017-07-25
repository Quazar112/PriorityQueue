using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueClassLibrary
{
    public interface IPriorityQueue<T>
    {
        /// <summary>
        /// Adds an item to the queue at the appropriate position with the given priority
        /// </summary>
        void Enqueue(T item, float priority);

        /// <summary>
        /// Removes and returns the first item in the queue
        /// </summary>
        T Dequeue();

        /// <summary>
        /// Finds the first item in the queue
        /// </summary>
        T First { get; }

        /// <summary>
        /// Clears the queue
        /// </summary>
        void Clear();

        /// <summary>
        /// The number of items in the queue
        /// </summary>
        int Count { get; }

        /// <summary>
        /// The maximum number of items that can currently be stored (
        /// </summary>
        int Capacity { get; }

        bool IsEmpty { get; }

        //TODO to list, array? 
    }
}

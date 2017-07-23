using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueClassLibrary
{
    interface IHeap<T> : IEnumerable<T>
    {
        /// <summary>
        /// Finds the first item in the heap
        /// </summary>
        /// <returns>The first item in the heap</returns>
        T First();

        /// <summary>
        /// Removes and returns the first element in the heap
        /// </summary>
        T RemoveFirst();

        /// <summary>
        /// Clears all items from the heap
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds and item to the heap
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <exception cref="ArgumentNullException">Does not allow addinf of null values</exception>
        void Add(T item);

        /// <summary>
        /// Adds multiple elements to the heap
        /// </summary>
        /// <param name="items">The items to be added</param>
        void AddAll(IEnumerable<T> items);

        /// <summary>
        /// Adds multiple elements to the heap
        /// </summary>
        /// <param name="items">The items to be added</param>
        void AddAll(params T[] items);

        /// <summary>
        /// The number of elements in the heap
        /// </summary>
        int Count { get; }

        /// <summary>
        /// The maximum capacity of the heap
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Whether or not the heap is empty
        /// </summary>
        bool IsEmpty { get; }
    }
}

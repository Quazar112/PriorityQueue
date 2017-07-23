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





    }
}

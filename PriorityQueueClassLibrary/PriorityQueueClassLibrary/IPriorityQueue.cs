using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueClassLibrary
{
    public interface IPriorityQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Enqueues 
        /// </summary>
        /// <param name="item"></param>
        void Enqueue(T item);
        T Dequeue();
        T First();
        void Clear();

        int Count { get; }

        //TODO to list, array? are these in IEnumerable?
    }
}

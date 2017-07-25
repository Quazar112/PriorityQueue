using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueClassLibrary
{
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private MinHeap<PriorityNode<T>> _queue;

        public int Count => _queue.Count;
        public int Capacity => _queue.Capacity;
        public T First => Count > 0 ? _queue.First.Item : default(T); 
        public bool IsEmpty => _queue.IsEmpty;

        public PriorityQueue()
        {
            _queue = new MinHeap<PriorityNode<T>>(PriorityNode<T>.Compare);
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public T Dequeue()
        {
            if (Count <= 0) return default(T); 
            return _queue.RemoveFirst().Item;
        }

        public void Enqueue(T item, float priority)
        {
            _queue.Add(new PriorityNode<T>(item, priority));
        }
    }
}

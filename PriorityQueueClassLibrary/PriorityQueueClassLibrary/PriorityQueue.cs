using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueClassLibrary
{
    class PriorityQueue<T> : IPriorityQueue<T>
    {
        private MinHeap<PriorityNode<T>> _queue;

        public int Count => _queue.Count;
        public int Capacity => _queue.Capacity;
        public T First => _queue.First.Item;

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
            return _queue.RemoveFirst().Item;
        }

        public void Enqueue(T item, int priority)
        {
            _queue.Add(new PriorityNode<T>(item, priority));
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

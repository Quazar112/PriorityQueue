using System;

namespace PriorityQueueClassLibrary
{
    class PriorityNode<T>
    {
        public static Func<PriorityNode<T>, PriorityNode<T>, int> Compare = (a, b) => {
            float t = (a.Priority - b.Priority);
            if (t > 0) return 1;
            else if (t < 0) return -1;
            else return 0;
        };

        public float Priority { get; private set; }
        public T Item { get; private set; }

        public PriorityNode(T item, float priority){
            Priority = priority;
            Item = item;
        }
    }
}

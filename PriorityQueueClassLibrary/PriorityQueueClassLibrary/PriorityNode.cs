using System;

namespace PriorityQueueClassLibrary
{
    class PriorityNode<T>
    {
        public static Func<PriorityNode<T>, PriorityNode<T>, int> Compare = (a, b) => (a.Priority - b.Priority);

        public int Priority { get; private set; }
        public T Item { get; private set; }

        public PriorityNode(T item, int priority){
            Priority = priority;
            Item = item;
        }
    }
}

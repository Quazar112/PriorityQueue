using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueClassLibrary
{
    public class MinHeap<T> : IHeap<T>
    {
        private const int DEFAULT_CAPACITY = 1;
        private const int GROWTH_FACTOR = 2;

        private T[] _heap;
        private int _count;
        private int _capacity;
        private int _shrink_capacity;
        private Func<T, T, int> _comparer;

        public int Count => _count;
        public int Capacity => _capacity;
        public bool IsReadOnly => false;

        public MinHeap(Func<T, T, int> comparer, int initialCapacity = DEFAULT_CAPACITY)
        {
            if(initialCapacity <= 0) throw new ArgumentException("must be positive", "initialCapacity");

            _comparer = comparer ?? throw new ArgumentNullException("comparer");
            _capacity = initialCapacity;
            _shrink_capacity = _capacity / (GROWTH_FACTOR * GROWTH_FACTOR);
            _heap = new T[_capacity];
            _count = 0;
        }

        public MinHeap(Func<T, T, int> comparer, IEnumerable<T> items, int initialCapacity = -1)
        {
            if (initialCapacity < 0) initialCapacity = items.Count(); //negative signals use size of input collection
            else if (initialCapacity < items.Count()) throw new ArgumentException("not enough space for all itms in collection", "initialCapacity");

            _comparer = comparer ?? throw new ArgumentNullException("comparer");
            _capacity = initialCapacity;
            _shrink_capacity = _capacity / (GROWTH_FACTOR * GROWTH_FACTOR);
            _heap = new T[_capacity];
            _count = 0;

            //add items from the input collection
            foreach(T item in items) {
                Add(item);
            }
        }

        public void Clear()
        {
            _count = 0;
            _capacity = DEFAULT_CAPACITY;
            _heap = new T[_capacity];
        }

        public void Add(T item)
        {
            //increase size of array if necessary
            Grow();

            //insert new item at end and then move it up
            _heap[_capacity] = item;
            BubbleUp(_capacity);
            _capacity++;
        }

        public T RemoveFirst()
        {
            if (_count == 0) return default(T); //TODO throw exception? for value types
            T retval = _heap[0];
            _count--;
            _heap[0] = _heap[_count];

            BubbleDown(0);

            //shrink array if needed
            Shrink();

            return retval;
        }

        public T First()
        {
            if (_count == 0) return default(T); //TODO throw exception? for value types
            return _heap[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves an item up in the heap until it is properly ordered
        /// </summary>
        /// <param name="i">the index of the item to move up</param>
        private void BubbleUp(int i)
        {
            int p;
            while(i > 0) {
                p = Parent(i);
                if (_comparer(_heap[i], _heap[p]) < 0) {
                    Swap(i, p);
                    i = p;
                } else return;
            }
        }

        /// <summary>
        /// Moves an item down until the heap is properly ordered again
        /// </summary>
        /// <param name="i">the index of the item to move</param>
        private void BubbleDown(int i = 0)
        {
            int l = LeftChild(i);
            int r = RightChild(i);
            int c = r < _count ? Max(l, r) : l;

            while(c < _count) {
                if (_comparer(_heap[c], _heap[i]) <= 0) {
                    Swap(i, c);
                    i = c;
                } else return;
                l = LeftChild(i);
                r = RightChild(i);
                c = r < _count ? Max(l, r) : l;
            }
        }

        /// <summary>
        /// Determines the index of the parent of the element at index i
        /// </summary>
        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        /// <summary>
        /// Determines the index of the left child of the element at index i
        /// </summary>
        private int LeftChild(int i)
        {
            return 2 * i + 1;
        }

        /// <summary>
        /// Determines the index of the right child of the element at index i
        /// </summary>
        private int RightChild(int i)
        {
            return 2 * i + 2;
        }

        /// <summary>
        /// Swaps the elements at array indices i and j
        /// </summary>
        private void Swap(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        /// <summary>
        /// Shrinks the size of the heap if necessary
        /// </summary>
        private void Shrink()
        {
            if (_count < _shrink_capacity) {
                var temp = _heap;

                _capacity /= GROWTH_FACTOR;
                _shrink_capacity = _capacity / (GROWTH_FACTOR * GROWTH_FACTOR);

                _heap = new T[_capacity];
                for (int i = 0; i < _count; i++) {
                    _heap[i] = temp[i];
                }
            }
        }

        /// <summary>
        /// Grows the size of the heap array if necessary
        /// </summary>
        private void Grow()
        {
            if (_count == _capacity) {
                _capacity *= GROWTH_FACTOR;
                _shrink_capacity = _capacity / (GROWTH_FACTOR * GROWTH_FACTOR);
                T[] temp = _heap;
                _heap = new T[_capacity];
                for (int i = 0; i < temp.Length; i++) {
                    _heap[i] = temp[i];
                }
            }
        }

        /// <summary>
        /// Determines the index of the item at position i or j that is higher (or i if equal)
        /// </summary>
        private int Max(int i, int j)
        {
            if (_comparer(_heap[i], _heap[j]) <= 0) return i;
            else return j;
        }
    }
}

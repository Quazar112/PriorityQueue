using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueueClassLibrary;

namespace PriorityQueueTests
{
    [TestClass]
    public class HeapTests
    {
        private Func<int, int, int> intComparer = (a, b) => { return a - b; };

        [TestMethod]
        public void TestAddRemove()
        {
            MinHeap<int> minHeap = new MinHeap<int>(intComparer);
            Assert.AreEqual(minHeap.Count, 0);
            Assert.AreEqual(minHeap.Capacity, 1);
            Assert.IsTrue(minHeap.IsEmpty);

            minHeap.Add(3);
            Assert.AreEqual(minHeap.Count, 1);
            Assert.AreEqual(minHeap.First(), 3);
            Assert.IsFalse(minHeap.IsEmpty);

            minHeap.Add(2);
            Assert.AreEqual(minHeap.Count, 2);
            Assert.AreEqual(minHeap.First(), 2);
            Assert.AreEqual(minHeap.Capacity, 2);

            minHeap.Add(4);
            Assert.AreEqual(minHeap.Capacity, 4);
            Assert.AreEqual(minHeap.Count, 3);

            minHeap.Add(1);
            minHeap.Add(5);
            Assert.AreEqual(minHeap.Count, 5);
            Assert.IsTrue(minHeap.Capacity >= 5);
            Assert.AreEqual(minHeap.First(), 1);
            Assert.AreEqual(minHeap.RemoveFirst(), 1);
            Assert.AreEqual(minHeap.Count, 4);
            Assert.AreEqual(minHeap.RemoveFirst(), 2);
            Assert.AreEqual(minHeap.Count, 3);
            Assert.AreEqual(minHeap.RemoveFirst(), 3);
            Assert.AreEqual(minHeap.RemoveFirst(), 4);
            Assert.AreEqual(minHeap.Count, 1);
            Assert.IsTrue(minHeap.Capacity < 5);
        }

        [TestMethod]
        public void TestAddAllClear()
        {
            MinHeap<int> mh = new MinHeap<int>(intComparer, new int[]{ 1, 3, 4, 0, -1, 2, 5 });
            Assert.AreEqual(mh.Count, 7);
            Assert.IsFalse(mh.IsEmpty);
            Assert.AreEqual(mh.RemoveFirst(), -1);
            Assert.AreEqual(mh.RemoveFirst(), 0);
            Assert.AreEqual(mh.RemoveFirst(), 1);
            Assert.AreEqual(mh.RemoveFirst(), 2);
            Assert.AreEqual(mh.RemoveFirst(), 3);
            Assert.AreEqual(mh.RemoveFirst(), 4);
            Assert.AreEqual(mh.RemoveFirst(), 5);
            Assert.IsTrue(mh.IsEmpty);

            mh.AddAll(new int[] { 4, 3, 2, 1, 0 });
            Assert.IsFalse(mh.IsEmpty);
            Assert.AreEqual(mh.Count, 5);
            Assert.AreEqual(mh.First(), 0);

            mh.Clear();
            Assert.IsTrue(mh.IsEmpty);
            Assert.AreEqual(mh.Count, 0);
            Assert.AreEqual(mh.Capacity, 1);

            mh.AddAll(1, 2, 5, 10);
            Assert.AreEqual(mh.Count, 4);
            Assert.IsTrue(mh.Capacity >= 4);
            Assert.AreEqual(mh.RemoveFirst(), 1);
            Assert.AreEqual(mh.RemoveFirst(), 2);
            Assert.AreEqual(mh.RemoveFirst(), 5);
            Assert.AreEqual(mh.RemoveFirst(), 10);
            Assert.IsTrue(mh.IsEmpty);
        }

        [TestMethod]
        public void TestBadInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { new MinHeap<int>(null); });
            Assert.ThrowsException<ArgumentException>(() => { new MinHeap<int>(intComparer, -1); });
            Assert.ThrowsException<ArgumentException>(() => { new MinHeap<int>(intComparer, 0); });
            Assert.ThrowsException<ArgumentException>(() => { new MinHeap<int>(intComparer, new int[] { 1, 2, 3, }, 2); });
            Assert.ThrowsException<ArgumentNullException>(() => {
                var mh = new MinHeap<Object>((a, b) => 1);
                mh.Add(null);
            });
        }
    }
}

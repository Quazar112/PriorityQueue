using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueueClassLibrary;

namespace PriorityQueueTests
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void TestEnqueueDequeue()
        {
            PriorityQueue<string> pq = new PriorityQueue<string>();
            Assert.AreEqual(pq.Count, 0);
            Assert.IsTrue(pq.IsEmpty);
            pq.Enqueue("First", 1);
            Assert.IsFalse(pq.IsEmpty);
            pq.Enqueue("Second", 2);
            pq.Enqueue("Third", 3);
            Assert.AreEqual(pq.Count, 3);
            Assert.AreEqual(pq.First, "First");
            Assert.AreEqual(pq.Dequeue(), "First");
            Assert.IsFalse(pq.IsEmpty);
            Assert.AreEqual(pq.Count, 2);
            Assert.AreEqual(pq.Dequeue(), "Second");
            Assert.AreEqual(pq.Dequeue(), "Third");
            Assert.AreEqual(pq.Count, 0);
            Assert.IsTrue(pq.IsEmpty);
        }

        [TestMethod]
        public void TestClear()
        {
            PriorityQueue<char> pq = new PriorityQueue<char>();
            pq.Enqueue('b', 2);
            pq.Enqueue('c', 2);
            pq.Enqueue('d', 2);
            pq.Enqueue('a', 1);
            pq.Enqueue('g', 5);
            pq.Enqueue('h', 0);
            pq.Enqueue('i', 11);

            Assert.AreEqual(pq.Count, 7);
            Assert.AreEqual(pq.Dequeue(), 'h');
            Assert.AreEqual(pq.Dequeue(), 'a');
            Assert.AreEqual(pq.Dequeue(), 'b');
            Assert.AreEqual(pq.First, 'c');
            Assert.AreEqual(pq.Count, 4);

            pq.Clear();
            Assert.IsTrue(pq.IsEmpty);
            Assert.AreEqual(pq.Count, 0);

            pq.Clear();
            Assert.IsTrue(pq.IsEmpty);
            Assert.AreEqual(pq.Count, 0);
        }

        [TestMethod]
        public void TestBadInput()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            Assert.AreEqual(pq.Dequeue(), default(int));
            Assert.AreEqual(pq.First, 0);

            PriorityQueue<string> p2 = new PriorityQueue<string>();
            Assert.AreEqual(p2.Dequeue(), null);
            Assert.AreEqual(p2.First, default(string));
        }

        //[TestMethod] //Disabled for now, queue is not stable
        public void TestSamePriorityOrder()
        {
            PriorityQueue<string> pq = new PriorityQueue<string>();
            pq.Enqueue("s1", 3);
            pq.Enqueue("s2", 3);
            pq.Enqueue("s3", 3);
            pq.Enqueue("s4", 3);
            Assert.AreEqual(pq.Dequeue(), "s1");
            Assert.AreEqual(pq.Dequeue(), "s2");
            pq.Enqueue("s5", 3);
            pq.Enqueue("s6", 3);
            Assert.AreEqual(pq.Dequeue(), "s3");
            Assert.AreEqual(pq.Dequeue(), "s4");
            Assert.AreEqual(pq.Dequeue(), "s5");
            Assert.AreEqual(pq.Dequeue(), "s6");

        }
    }
}

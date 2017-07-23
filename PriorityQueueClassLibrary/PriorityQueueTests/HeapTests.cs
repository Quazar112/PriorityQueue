using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueueClassLibrary;

namespace PriorityQueueTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            MinHeap<int> minHeap = new MinHeap<int>((a, b) => { return a - b;  });
            Assert.AreEqual(minHeap.Count, 0);
       
            

        }
    }
}

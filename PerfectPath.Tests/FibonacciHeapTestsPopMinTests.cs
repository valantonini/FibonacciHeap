using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapTestsPopMinTests
    {
        [Test]
        public void Pop_EmptyHeap_Exception()
        {
            var fh = new FibonacciHeap<int>();
            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
        }
    }
}
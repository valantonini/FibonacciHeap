using NUnit.Framework;
using PerfectPath.PriorityQueue;
using System.Linq;

namespace PerfectPath.Tests
{
    public class FibonacciHeapIteratorTests
    {
        private FibonacciHeap<int> _heap;

        [SetUp]
        public void SetUp()
        {
            _heap = new FibonacciHeap<int>();
        }

        [Test]
        public void Iterate_Siblings_Success()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            _heap.Join(p2, p3);
            _heap.Join(p1, p2);

            var actual = NodeDebugTools<int>.IterateSiblings(p1).ToList();

            Assert.AreEqual(3, actual.Count());
            Assert.AreEqual(1, actual[0].Value);
            Assert.AreEqual(2, actual[1].Value);
            Assert.AreEqual(3, actual[2].Value);
        }
    }
}
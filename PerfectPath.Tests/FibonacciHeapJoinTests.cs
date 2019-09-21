using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapJoinTests
    {
        private FibonacciHeap<int> _heap;

        [SetUp]
        public void SetUp()
        {
            _heap = new FibonacciHeap<int>();
        }

        [Test]
        public void JoinNodes_2Nodes_CorrectNextAndPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            _heap.Join(p1, p2);

            Assert.AreEqual(p2, p1.Prev);
            Assert.AreEqual(p2, p1.Next);

            Assert.AreEqual(p1, p2.Prev);
            Assert.AreEqual(p1, p2.Next);
        }

        [Test]
        public void JoinNodes_3Nodes_CorrectNextAndPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            _heap.Join(p2, p3);
            _heap.Join(p1, p2);

            Assert.AreEqual(p3, p1.Prev);
            Assert.AreEqual(p2, p1.Next);

            Assert.AreEqual(p1, p2.Prev);
            Assert.AreEqual(p3, p2.Next);

            Assert.AreEqual(p2, p3.Prev);
            Assert.AreEqual(p1, p3.Next);
        }
    }
}
using NUnit.Framework;
using FibonacciHeap.PriorityQueue;

namespace FibonacciHeap.Tests.PriorityQueue
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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(p2, p1.Prev);
                Assert.AreEqual(p2, p1.Next);

                Assert.AreEqual(p1, p2.Prev);
                Assert.AreEqual(p1, p2.Next);
            });
        }

        [Test]
        public void JoinNodes_3Nodes_CorrectNextAndPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            _heap.Join(p2, p3);
            _heap.Join(p1, p2);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(p3, p1.Prev);
                Assert.AreEqual(p2, p1.Next);

                Assert.AreEqual(p1, p2.Prev);
                Assert.AreEqual(p3, p2.Next);

                Assert.AreEqual(p2, p3.Prev);
                Assert.AreEqual(p1, p3.Next);
            });
        }

        [Test]
        public void JoinNodes_3NodesAnd3Nodes_CorrectNextAndPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            _heap.Join(p2, p3);
            _heap.Join(p1, p2);

            var n1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var n2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var n3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            _heap.Join(n2, n3);
            _heap.Join(n1, n2);

            _heap.Join(p1, n1);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(n3, p1.Prev);
                Assert.AreEqual(p2, p1.Next);

                Assert.AreEqual(p1, p2.Prev);
                Assert.AreEqual(p3, p2.Next);

                Assert.AreEqual(p2, p3.Prev);
                Assert.AreEqual(n1, p3.Next);

                Assert.AreEqual(p3, n1.Prev);
                Assert.AreEqual(n2, n1.Next);

                Assert.AreEqual(n1, n2.Prev);
                Assert.AreEqual(n3, n2.Next);

                Assert.AreEqual(n2, n3.Prev);
                Assert.AreEqual(p1, n3.Next);
            });
        }
    }
}
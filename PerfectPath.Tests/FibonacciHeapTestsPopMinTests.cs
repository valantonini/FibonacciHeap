using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapTestsPopMinTests
    {
        [Test]
        public void PopMin_EmptyHeap_Exception()
        {
            var fh = new FibonacciHeap<int>();
            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
        }

        [Test]
        public void PopMin_1Node_CorrectNode()
        {
            var fh = new FibonacciHeap<int>();

            fh.Push(7);
            var actual = fh.PopMin();

            Assert.AreEqual(7, actual);
        }

        [Test]
        public void PopMin_2Nodes_CorrectNode()
        {
            var fh = new FibonacciHeap<int>();

            fh.Push(7);
            fh.Push(6);

            var first = fh.PopMin();
            var second = fh.PopMin();

            Assert.AreEqual(6, first);
            Assert.AreEqual(7, second);
        }
    }
}
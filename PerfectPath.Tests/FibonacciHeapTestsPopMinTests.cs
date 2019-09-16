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

            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
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

            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
        }
        // [Test]
        public void PopMin_3Nodes_CorrectNode()
        {
            var fh = new FibonacciHeap<int>();

            fh.Push(6);
            fh.Push(5);
            fh.Push(7);

            var first = fh.PopMin();
            var second = fh.PopMin();
            var third = fh.PopMin();

            Assert.AreEqual(5, first);
            Assert.AreEqual(6, second);
            Assert.AreEqual(7, third);

            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
        }
    }
}
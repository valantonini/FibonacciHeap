using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests.PriorityQueue
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

        [Test]
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

        [Test]
        public void PopMin_5Nodes_CorrectNode()
        {
            var fh = new FibonacciHeap<int>();

            fh.Push(7);
            fh.Push(6);
            fh.Push(5);
            fh.Push(8);
            fh.Push(4);
            fh.Push(2);
            fh.Push(1);
            fh.Push(3);

            var first = fh.PopMin();
            var second = fh.PopMin();
            var third = fh.PopMin();
            var fourth = fh.PopMin();
            var fifth = fh.PopMin();
            var sixth = fh.PopMin();
            var seven = fh.PopMin();
            var eigth = fh.PopMin();

            Assert.AreEqual(1, first);
            Assert.AreEqual(2, second);
            Assert.AreEqual(3, third);
            Assert.AreEqual(4, fourth);
            Assert.AreEqual(5, fifth);
            Assert.AreEqual(6, sixth);
            Assert.AreEqual(7, seven);
            Assert.AreEqual(8, eigth);

            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
        }

        [TestCase(new int[] { 1, -1 })]
        [TestCase(new int[] { 1, 2, -1, -2 })]
        [TestCase(new int[] { 3, 1, 2, -1, 4, -2, -3, 8, 5, 6, -4, -5, 7, -6, -7, -8 })]
        [TestCase(new int[] { 984556, 907815, 743545, 811641, 738779, 48315, 17001, 149360, -17001, -48315, -149360, -738779, -743545, -811641, -907815, -984556 })]
        [TestCase(new int[] { 7, 6, 5, 8, 4, 2, 1, 3, -1, -2, -3, -4, -5, -6, -7, -8 })]
        public void ProcessIntArray(int[] sequence)
        {
            var fh = new FibonacciHeap<int>();

            foreach (var s in sequence)
            {
                if (s < 0)
                {
                    var val = fh.PopMin();
                    Assert.AreEqual(System.Math.Abs(s), val);
                }
                else
                {
                    fh.Push(s);
                }
            }

            Assert.Throws<HeapEmptyException>(() => fh.PopMin());
        }
    }
}
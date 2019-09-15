using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacchiHeapAddChildTests
    {
        [Test]
        public void AddChild_1Node_CorrectParent()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p1, p2.Parent);
        }

        [Test]
        public void AddChild_FirstChild_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p1.Child);
        }

        [Test]
        public void AddChild_1Node_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p2.Prev);
            Assert.AreEqual(p2, p2.Next);
        }

        [Test]
        public void AddChild_2Nodes_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            FibonacciHeap<int>.AddChild(p1, p2);
            FibonacciHeap<int>.AddChild(p1, p3);

            Assert.AreEqual(p2, p3.Prev);
            Assert.AreEqual(p2, p3.Next);

            Assert.AreEqual(p3, p2.Prev);
            Assert.AreEqual(p3, p2.Next);
        }

        [Test]
        public void AddChild_3Nodes_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var c3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.AddChild(p1, c3);

            // Parent
            // c1 > c3 > c2 

            Assert.AreEqual(c2, c1.Prev);
            Assert.AreEqual(c3, c1.Next);

            Assert.AreEqual(c3, c2.Prev);
            Assert.AreEqual(c1, c2.Next);

            Assert.AreEqual(c1, c3.Prev);
            Assert.AreEqual(c2, c3.Next);
        }

        [Test]
        public void AddChild_2Nodes_CorrectParents()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            FibonacciHeap<int>.AddChild(p1, p2);
            FibonacciHeap<int>.AddChild(p1, p3);

            Assert.AreEqual(p1, p2.Parent);
            Assert.AreEqual(p1, p3.Parent);
        }
    }
}
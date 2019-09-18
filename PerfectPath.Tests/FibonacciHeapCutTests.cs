using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapCutTests
    {

        [Test]
        public void Cut_1Node_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);

            FibonacciHeap<int>.Cut(p1);

            Assert.AreEqual(p1, p1.Next);
            Assert.AreEqual(p1, p1.Prev);
        }

        [Test]
        public void Cut_2Nodes_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.Join(p1, p2);
            FibonacciHeap<int>.Cut(p1);

            Assert.AreEqual(p1, p1.Next);
            Assert.AreEqual(p1, p1.Prev);

            Assert.AreEqual(p2, p2.Next);
            Assert.AreEqual(p2, p2.Prev);
        }

        [Test]
        public void Cut_2NodesWithIndirectParent_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c2);

            Assert.AreEqual(c1, c1.Next);
            Assert.AreEqual(c1, c1.Prev);

            Assert.AreEqual(c2, c2.Next);
            Assert.AreEqual(c2, c2.Prev);
        }

        [Test]
        public void Cut_2NodesWithIndirectParent_CorrectParent()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c2);

            Assert.AreEqual(p1, c1.Parent);
        }

        [Test]
        public void Cut_2NodesWithDirectParent_CorrectNextPrev()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c1);

            Assert.AreEqual(c1, c1.Next);
            Assert.AreEqual(c1, c1.Prev);

            Assert.AreEqual(c2, c2.Next);
            Assert.AreEqual(c2, c2.Prev);
        }

        [Test]
        public void Cut_2NodesWithDirectParent_CorrectParent()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c1);

            Assert.AreEqual(p1, c2.Parent);
        }

        [Test]
        public void Cut_2NodesWithDirectParent_CorrectChild()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c1);

            Assert.AreEqual(c2, p1.Child);
        }

        [Test]
        [Ignore("currently nulling parent in cut while debugging consolidate issue")]
        public void Cut_2NodesWithDirectParent_IncorrectParentForDeferredUpdating()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c1);

            // although cut, we will defer parent reassignment until collapse
            Assert.AreEqual(p1, c1.Parent);
        }
    }
}
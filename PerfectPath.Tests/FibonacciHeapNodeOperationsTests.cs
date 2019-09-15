using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapNodeOperationsTests
    {
        [Test]
        public void AddChild_1Node_CorrectParent()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p1, p2.Parent);
        }

        [Test]
        public void AddChild_FirstChild_CorrectNextPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p1.Child);
        }

        [Test]
        public void AddChild_1Node_CorrectNextPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p2.Prev);
            Assert.AreEqual(p2, p2.Next);
        }

        [Test]
        public void AddChild_2Nodes_CorrectNextPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);
            var p3 = CreateNodeConnectedToSelf(3);

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
            var p1 = CreateNodeConnectedToSelf(1);
            var c1 = CreateNodeConnectedToSelf(2);
            var c2 = CreateNodeConnectedToSelf(3);
            var c3 = CreateNodeConnectedToSelf(4);

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
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);
            var p3 = CreateNodeConnectedToSelf(3);

            FibonacciHeap<int>.AddChild(p1, p2);
            FibonacciHeap<int>.AddChild(p1, p3);

            Assert.AreEqual(p1, p2.Parent);
            Assert.AreEqual(p1, p3.Parent);
        }

        [Test]
        public void JoinNodes_2Nodes_CorrectNextAndPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.Join(p1, p2);

            Assert.AreEqual(p2, p1.Prev);
            Assert.AreEqual(p2, p1.Next);

            Assert.AreEqual(p1, p2.Prev);
            Assert.AreEqual(p1, p2.Next);
        }

        [Test]
        public void JoinNodes_3Nodes_CorrectNextAndPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);
            var p3 = CreateNodeConnectedToSelf(3);

            FibonacciHeap<int>.Join(p1, p2);
            FibonacciHeap<int>.Join(p2, p3);

            Assert.AreEqual(p3, p1.Prev);
            Assert.AreEqual(p2, p1.Next);

            Assert.AreEqual(p1, p2.Prev);
            Assert.AreEqual(p3, p2.Next);

            Assert.AreEqual(p2, p3.Prev);
            Assert.AreEqual(p1, p3.Next);
        }

        [Test]
        public void Cut_1Node_CorrectNextPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);

            FibonacciHeap<int>.Cut(p1);

            Assert.AreEqual(p1, p1.Next);
            Assert.AreEqual(p1, p1.Prev);
        }

        [Test]
        public void Cut_2Nodes_CorrectNextPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);

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
            var p1 = CreateNodeConnectedToSelf(1);
            var c1 = CreateNodeConnectedToSelf(1);
            var c2 = CreateNodeConnectedToSelf(2);

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
            var p1 = CreateNodeConnectedToSelf(1);
            var c1 = CreateNodeConnectedToSelf(1);
            var c2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c2);

            Assert.AreEqual(p1, c1.Parent);
        }

        [Test]
        public void Cut_2NodesWithDirectParent_CorrectNextPrev()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var c1 = CreateNodeConnectedToSelf(1);
            var c2 = CreateNodeConnectedToSelf(2);

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
            var p1 = CreateNodeConnectedToSelf(1);
            var c1 = CreateNodeConnectedToSelf(1);
            var c2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c1);

            Assert.AreEqual(p1, c2.Parent);
        }

        [Test]
        public void Cut_2NodesWithDirectParent_CorrectChild()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var c1 = CreateNodeConnectedToSelf(1);
            var c2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p1, c2);
            FibonacciHeap<int>.Cut(c1);

            Assert.AreEqual(c2, p1.Child);
        }

        private Node<int> CreateNodeConnectedToSelf(int value)
        {
            var node = new Node<int>(value);
            node.Prev = node.Next = node;
            return node;
        }
    }
}
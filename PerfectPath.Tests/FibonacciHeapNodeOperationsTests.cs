using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class NodeOperationsTests
    {
        [Test]
        public void AddChild_ShouldSetParent()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p1, p2.Parent);
        }

        [Test]
        public void AddChild_ShouldSetChild()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p1.Child);
        }

        [Test]
        public void AddChild_OnlyChild_LeftAndRightShouldBeSelf()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            FibonacciHeap<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p2.Prev);
            Assert.AreEqual(p2, p2.Next);
        }

        [Test]
        public void AddChild_SecondChild_LeftAndRightShouldBeCorrect()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);
            var p3 = new Node<int>(3);

            FibonacciHeap<int>.AddChild(p1, p2);
            FibonacciHeap<int>.AddChild(p1, p3);

            Assert.AreEqual(p2, p3.Prev);
            Assert.AreEqual(p2, p3.Next);

            Assert.AreEqual(p3, p2.Prev);
            Assert.AreEqual(p3, p2.Next);
        }

        [Test]
        public void AddChild_ThirdChild_LeftAndRightShouldBeCorrect()
        {
            var p1 = new Node<int>(1);
            var c1 = new Node<int>(2);
            var c2 = new Node<int>(3);
            var c3 = new Node<int>(4);

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
        public void AddChild_SecondChild_ParentShouldBeCorrect()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);
            var p3 = new Node<int>(3);

            FibonacciHeap<int>.AddChild(p1, p2);
            FibonacciHeap<int>.AddChild(p1, p3);

            Assert.AreEqual(p1, p2.Parent);
            Assert.AreEqual(p1, p3.Parent);
        }

        [Test]
        public void JoinNodes_NextAndPrevious_ShouldBeEachother()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.JoinNodes(p1, p2);

            Assert.AreEqual(p2, p1.Prev);
            Assert.AreEqual(p2, p1.Next);

            Assert.AreEqual(p1, p2.Prev);
            Assert.AreEqual(p1, p2.Next);            
        }

        [Test]
        public void JoinNodes_NextAndPrevious_ShouldBeCorrectFor3Nodes()
        {
            var p1 = CreateNodeConnectedToSelf(1);
            var p2 = CreateNodeConnectedToSelf(2);
            var p3 = CreateNodeConnectedToSelf(3);

            FibonacciHeap<int>.JoinNodes(p1, p2);
            FibonacciHeap<int>.JoinNodes(p2, p3);

            Assert.AreEqual(p3, p1.Prev);
            Assert.AreEqual(p2, p1.Next);
            
            Assert.AreEqual(p1, p2.Prev);
            Assert.AreEqual(p3, p2.Next);

            Assert.AreEqual(p2, p3.Prev);
            Assert.AreEqual(p1, p3.Next);
        }

        private Node<int> CreateNodeConnectedToSelf(int value)
        {
            var node =  new Node<int>(value);
            node.Prev = node.Next = node;
            return node;
        }
    }
}
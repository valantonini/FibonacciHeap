using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciNodeTest
    {
        [Test]
        public void New_ShouldInstantiate()
        {
            var node = new Node<int>(7);
            Assert.AreEqual(7, node.Value);
        }

        [Test]
        public void AddChild_ShouldSetParent()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            NodeOperations<int>.AddChild(p1, p2);

            Assert.AreEqual(p1, p2.Parent);
        }

        [Test]
        public void AddChild_ShouldSetChild()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            NodeOperations<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p1.Child);
        }

        [Test]
        public void AddChild_OnlyChild_LeftAndRightShouldBeSelf()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            NodeOperations<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p2.Left);
            Assert.AreEqual(p2, p2.Right);
        }

         [Test]
        public void AddChild_SecondChild_LeftAndRightShouldBeCorrect()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);
            var p3 = new Node<int>(3);

            NodeOperations<int>.AddChild(p1, p2);
            NodeOperations<int>.AddChild(p1, p3);

            Assert.AreEqual(p2, p3.Left);
            Assert.AreEqual(p2, p3.Right);

            Assert.AreEqual(p3, p2.Left);
            Assert.AreEqual(p3, p2.Right);
        }

        [Test]
        public void AddChild_SecondChild_ParentShouldBeCorrect()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);
            var p3 = new Node<int>(3);

            NodeOperations<int>.AddChild(p1, p2);
            NodeOperations<int>.AddChild(p1, p3);

            Assert.AreEqual(p1, p2.Parent);
            Assert.AreEqual(p1, p3.Parent);
        }
    }
}
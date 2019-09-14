using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciNodeTest
    {
        [Test]
        public void ShouldInstantiate()
        {
            var node = new Node<int>(7);
            Assert.AreEqual(7, node.Value);
        }

        [Test]
        public void ShouldSetParent()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            NodeOperations<int>.AddChild(p1, p2);

            Assert.AreEqual(p1, p2.Parent);
        }

        [Test]
        public void ShouldSetChild()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            NodeOperations<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p1.Child);
        }

        [Test]
        public void OnlyChildLeftAndRightShouldBeSelf()
        {
            var p1 = new Node<int>(1);
            var p2 = new Node<int>(2);

            NodeOperations<int>.AddChild(p1, p2);

            Assert.AreEqual(p2, p2.Left);
            Assert.AreEqual(p2, p2.Right);
        }
    }
}
using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapConsolidateTests
    {
        [Test]
        public void Consolidate_1Node_CorrectSiblings()
        {
            var node = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);

            FibonacciHeap<int>.Consolidate(node, 1);

            Assert.AreEqual(node, node.Prev);
            Assert.AreEqual(node, node.Next);
        }

        [Test]
        public void Consolidate_2Node_CorrectSiblings()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            FibonacciHeap<int>.Join(node1, node2);
            FibonacciHeap<int>.Consolidate(node1, 2);

            Assert.AreEqual(node1, node1.Prev);
            Assert.AreEqual(node1, node1.Next);

            Assert.AreEqual(node2, node2.Prev);
            Assert.AreEqual(node2, node2.Next);
        }

        [Test]
        public void Consolidate_2Node_CorrectDegree()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            FibonacciHeap<int>.Join(node1, node2);
            FibonacciHeap<int>.Consolidate(node1, 2);

            Assert.AreEqual(1, node1.Degree);
            Assert.AreEqual(0, node2.Degree);
        }

        [Test]
        public void Consolidate_2Node_CorrectParents()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            FibonacciHeap<int>.Join(node1, node2);
            FibonacciHeap<int>.Consolidate(node1, 2);

            Assert.IsNull(node1.Parent);
            Assert.AreEqual(node1, node2.Parent);
        }
    }
}
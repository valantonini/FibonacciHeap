#define DEBUG
using NUnit.Framework;
using PerfectPath.PriorityQueue;
using System.Linq;

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

        [Test]
        public void Consolidate_2Node_CorrectMinReturned()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            FibonacciHeap<int>.Join(node1, node2);
            var newMin = FibonacciHeap<int>.Consolidate(node1, 2);

            Assert.AreEqual(5, newMin.Value);
        }

        [Test]
        public void Consolidate_3Node_CorrectMin()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);

            FibonacciHeap<int>.AddChild(node1, node2);

            var node3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);

            FibonacciHeap<int>.Join(node3, node1);

            var newMin = FibonacciHeap<int>.Consolidate(node3, 2);

            Assert.AreEqual(3, newMin.Value);
        }
        [Test]
        public void Consolidate_LotsOfNodes_CorrectWidth()
        {
            var tree1 = CreateTree(new int[] { 1 });
            var tree2 = CreateTree(new int[] { 2 });
            var tree3 = CreateTree(new int[] { 3, 4 });

            FibonacciHeap<int>.Join(tree1, tree2);
            FibonacciHeap<int>.Join(tree1, tree3);

            var consolidated = FibonacciHeap<int>.Consolidate(tree1, 3);

            var enumeratedSiblings = FibonacciHeap<int>.IterateSiblings(consolidated);

            Assert.AreEqual(1, enumeratedSiblings.Count());
        }

        private Node<int> CreateTree(int[] tree)
        {
            Node<int> node = null;
            foreach (var level in tree)
            {
                var newNode = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(level);
                if (node == null)
                {
                    node = newNode;
                }
                else
                {
                    FibonacciHeap<int>.AddChild(node, newNode);
                }
            }
            return node;

        }
    }
}
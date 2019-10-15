#define DEBUG
using NUnit.Framework;
using PerfectPath.PriorityQueue;
using System.Linq;

namespace PerfectPath.Tests.PriorityQueue
{
    public class FibonacciHeapConsolidateTests
    {
        private FibonacciHeap<int> _heap;

        [SetUp]
        public void SetUp()
        {
            _heap = new FibonacciHeap<int>();
        }

        [Test]
        public void Consolidate_1Node_CorrectSiblings()
        {
            var node = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);

            _heap.Consolidate(node, 1);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(node, node.Prev);
                Assert.AreEqual(node, node.Next);
            });
        }

        [Test]
        public void Consolidate_2Node_CorrectSiblings()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            _heap.Join(node1, node2);
            _heap.Consolidate(node1, 2);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(node1, node1.Prev);
                Assert.AreEqual(node1, node1.Next);

                Assert.AreEqual(node2, node2.Prev);
                Assert.AreEqual(node2, node2.Next);
            });
        }

        [Test]
        public void Consolidate_2Node_CorrectDegree()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            _heap.Join(node1, node2);
            _heap.Consolidate(node1, 2);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, node1.Degree);
                Assert.AreEqual(0, node2.Degree);
            });
        }

        [Test]
        public void Consolidate_2Node_CorrectParents()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            _heap.Join(node1, node2);
            _heap.Consolidate(node1, 2);

            Assert.Multiple(() =>
            {
                Assert.IsNull(node1.Parent);
                Assert.AreEqual(node1, node2.Parent);
            });
        }

        [Test]
        public void Consolidate_2Node_CorrectMinReturned()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            _heap.Join(node1, node2);
            var newMin = _heap.Consolidate(node1, 2);

            Assert.AreEqual(5, newMin.Value);
        }

        [Test]
        public void Consolidate_3Node_CorrectMin()
        {
            var node1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var node2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);

            _heap.AddChild(node1, node2);

            var node3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);

            _heap.Join(node3, node1);

            var newMin = _heap.Consolidate(node3, 2);

            Assert.AreEqual(3, newMin.Value);
        }
        [Test]
        public void Consolidate_LotsOfNodes_CorrectWidth()
        {
            var tree1 = CreateTree(new[] { 1 });
            var tree2 = CreateTree(new[] { 2 });
            var tree3 = CreateTree(new[] { 3, 4 });

            _heap.Join(tree1, tree2);
            _heap.Join(tree1, tree3);

            var consolidated = _heap.Consolidate(tree1, 3);

            var enumeratedSiblings = NodeDebugTools<int>.IterateSiblings(consolidated);

            Assert.AreEqual(1, enumeratedSiblings.Count());
        }

        // this sequence of numbers was thought to be misbehaving...
        [TestCase(new[] { 984556, 907815, 743545, 811641, 738779, 48315, 17001, 149360 })]
        [TestCase(new[] { 7, 6, 5, 8, 4, 2, 1, 3 })]
        public void Consolidate_LargeNumberOfSiblings(int[] sequence)
        {
            var siblings = CreateSiblings(sequence);
            var count = NodeDebugTools<int>.IterateSiblings(siblings).Count();

            Assert.AreEqual(sequence.Length, count);

            var consolidated = _heap.Consolidate(siblings, count);

            var consolidatedCount = NodeDebugTools<int>.IterateSiblings(consolidated).Count();

            Assert.AreEqual(1, consolidatedCount);
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
                    _heap.AddChild(node, newNode);
                }
            }
            return node;

        }

        private Node<int> CreateSiblings(int[] tree)
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
                    _heap.Join(node, newNode);
                }
            }
            return node;
        }
    }
}
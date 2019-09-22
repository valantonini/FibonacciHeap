
using NUnit.Framework;
using PerfectPath.PriorityQueue;
using PerfectPath.PriorityQueue.DegreeUpdatingStrategies;

namespace PerfectPath.Tests.DegreeUpdatingStrategies
{
    public class LazyDegreeUpdaterTests
    {
        private FibonacciHeap<int> _heap;

        [SetUp]
        public void SetUp()
        {
            _heap = new FibonacciHeap<int>();
            _heap.DegreeUpdatingStrategy = new LazyDegreeUpdater<int>();
        }

        [Test]
        public void Degree_NewNode_0Degree()
        {
            var node = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            Assert.AreEqual(0, node.Degree);
        }

        [Test]
        public void Degree_1Degree_1Degree()
        {
            var parent = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var child = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);

            _heap.AddChild(parent, child);

            Assert.AreEqual(1, parent.Degree);
            Assert.AreEqual(0, child.Degree);
        }

        [Test]
        public void Degree_0Degree_plus_2Degree_2Degree()
        {
            var parent = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var child = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var grandChild = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);

            _heap.AddChild(child, grandChild);
            _heap.AddChild(parent, child);

            Assert.AreEqual(2, parent.Degree);
            Assert.AreEqual(1, child.Degree);
            Assert.AreEqual(0, grandChild.Degree);
        }

        [Test]
        public void Degree_1Degree_plus_1Degree_2Degree()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);

            _heap.AddChild(p1, c1);
            _heap.AddChild(p2, c2);
            _heap.AddChild(p1, p2);

            Assert.AreEqual(2, p1.Degree);
            Assert.AreEqual(1, p2.Degree);
            Assert.AreEqual(0, c1.Degree);
            Assert.AreEqual(0, c2.Degree);
        }

        [Test]
        public void Degree_3Degree_plus_1Degree_3Degree()
        {
            var a1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var a2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var a3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var a4 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var b1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var b2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);

            _heap.AddChild(a3, a4);
            _heap.AddChild(a2, a3);
            _heap.AddChild(a1, a2);

            _heap.AddChild(b1, b2);

            Assert.AreEqual(3, a1.Degree);

            _heap.AddChild(a1, b1);

            Assert.AreEqual(3, a1.Degree);
        }
    }
}
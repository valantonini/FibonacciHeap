using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapDegreeTests
    {
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

            FibonacciHeap<int>.AddChild(parent, child);

            Assert.AreEqual(1, parent.Degree);
            Assert.AreEqual(0, child.Degree);
        }

        [Test]
        public void Degree_0Degree_plus_2Degree_2Degree()
        {
            var parent = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var child = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var grandChild = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);

            FibonacciHeap<int>.AddChild(child, grandChild);
            FibonacciHeap<int>.AddChild(parent, child);

            Assert.AreEqual(2, parent.Degree);
            Assert.AreEqual(1, child.Degree);
            Assert.AreEqual(0, grandChild.Degree);
        }

        [Test]
        public void Degree_1Degree_plus_0Degree_2Degree()
        {
            var parent = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var child = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var grandChild = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);

            FibonacciHeap<int>.AddChild(parent, child);
            FibonacciHeap<int>.AddChild(child, grandChild);

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

            FibonacciHeap<int>.AddChild(p1, c1);
            FibonacciHeap<int>.AddChild(p2, c2);
            FibonacciHeap<int>.AddChild(p1, p2);

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

            FibonacciHeap<int>.AddChild(a1, a2);
            FibonacciHeap<int>.AddChild(a2, a3);
            FibonacciHeap<int>.AddChild(a3, a4);

            FibonacciHeap<int>.AddChild(b1, b2);

            Assert.AreEqual(3, a1.Degree);

            FibonacciHeap<int>.AddChild(a1, b1);

            Assert.AreEqual(3, a1.Degree);
        }

        [Test]
        public void Degree_3Degree_plus_1Degree_lower_in_tree_3Degree()
        {
            var a1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var a2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);
            var a3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var a4 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);
            var b1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var b2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(a1, a2);
            FibonacciHeap<int>.AddChild(a2, a3);
            FibonacciHeap<int>.AddChild(a3, a4);

            FibonacciHeap<int>.AddChild(b1, b2);

            Assert.AreEqual(3, a1.Degree);

            FibonacciHeap<int>.AddChild(a2, b1);

            Assert.AreEqual(3, a1.Degree);
        }

        //[Test]
        public void Degree_RemoveLargeSubTree_DegreeRecalculated()
        {
            var a1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            var a2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

            FibonacciHeap<int>.AddChild(a1, a2);

            var b1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var b2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var b3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            var b4 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);


            FibonacciHeap<int>.AddChild(b1, b2);
            FibonacciHeap<int>.AddChild(b2, b3);
            FibonacciHeap<int>.AddChild(b3, b4);

            var c1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            var c2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);

            FibonacciHeap<int>.AddChild(c1, c2);


            FibonacciHeap<int>.AddChild(a1, b1);
            FibonacciHeap<int>.AddChild(a1, c1);

            Assert.AreEqual(4, a1.Degree);

            FibonacciHeap<int>.Cut(b1);

            Assert.AreEqual(2, a1.Degree);
        }
    }
}
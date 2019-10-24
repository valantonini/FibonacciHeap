using NUnit.Framework;
using PerfectPath.PriorityQueue;
using PerfectPath.PriorityQueue.DegreeUpdatingStrategies;

namespace PerfectPath.Tests.PriorityQueue.DegreeUpdatingStrategies
{
    public class AccurateDegreeUpdaterShortCircuitTests
    {
        private FibonacciHeap<int> _fibonacciHeap;
        private Node<int> _n1;
        private Node<int> _n10;
        private Node<int> _n11;
        private Node<int> _n12;
        private Node<int> _n2;
        private Node<int> _n3;
        private Node<int> _n4;
        private Node<int> _n5;
        private Node<int> _n6;
        private Node<int> _n7;
        private Node<int> _n8;
        private Node<int> _n9;

        [SetUp]
        public void SetUp()
        {
            _n1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            _n2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            _n3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            _n4 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);
            _n5 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            _n6 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);
            _n7 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(7);
            _n8 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(8);
            _n9 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(9);
            _n10 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(10);
            _n11 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(11);
            _n12 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(12);

            _fibonacciHeap = new FibonacciHeap<int>
            {
                DegreeUpdatingStrategy = new AccurateDegreeUpdater<int>()
            };

            _fibonacciHeap.Push(_n1);
            _fibonacciHeap.Push(_n2);
            _fibonacciHeap.Push(_n3);
            _fibonacciHeap.Push(_n4);
            _fibonacciHeap.Push(_n5);
            _fibonacciHeap.Push(_n6);
            _fibonacciHeap.Push(_n7);
            _fibonacciHeap.Push(_n8);
            _fibonacciHeap.Push(_n9);
            _fibonacciHeap.Push(_n10);
            _fibonacciHeap.Push(_n11);
            _fibonacciHeap.Push(_n12);

            _fibonacciHeap.PopMin();

            Assert.AreEqual(2, _fibonacciHeap.Peek());

            //    ├─┐ 2
            //    │ ├─╴ 3
            //    │ ├─╴ 4
            //    │ └─┐ 6
            //    │   ├─╴ 7
            //    │   └─┐ 8
            //    │     └─╴ 9
            //    ├─╴ 12
            //    ├─┐ 10
            //    │ └─╴ 11
            //    └─╴ 1
        }

        [Test]
        public void DecreaseKey_UpdateParents_Success()
        {
            Assert.AreEqual(3, _n2.Degree);

            _fibonacciHeap.Cut(_n9);

            Assert.AreEqual(2, _n2.Degree);
        }

        [Test]
        public void DecreaseKey_Investigation_Success()
        {
            var n13 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(13);
            var n14 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(14);
            var n15 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(15);
            var n16 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(16);
            var n17 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(17);
            var n18 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(18);
            var n19 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(19);
            var n0 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(0);

            _fibonacciHeap.Push(n13);
            _fibonacciHeap.Push(n14);
            _fibonacciHeap.Push(n15);
            _fibonacciHeap.Push(n16);
            _fibonacciHeap.Push(n17);
            _fibonacciHeap.Push(n18);
            _fibonacciHeap.Push(n19);
            _fibonacciHeap.Push(n0);

            _fibonacciHeap.PopMin();


            //    ├─┐ 2
            //    │ ├─╴ 3
            //    │ ├─┐ 4
            //    │ │ └─╴ 5
            //    │ ├─┐ 6
            //    │ │ ├─╴ 7
            //    │ │ └─┐ 8
            //    │ │   └─╴ 9
            //    │ └─┐ 10
            //    │   ├─╴ 11
            //    │   ├─┐ 12
            //    │   │ └─╴ 13
            //    │   └─┐ 14
            //    │     ├─╴ 15
            //    │     └─┐ 16
            //    │       └─╴ 17
            //    └─┐ 18
            //    └─╴ 19

            Assert.AreEqual(4, _n2.Degree);

            _fibonacciHeap.DecreaseKey(13, 0);

            Assert.AreEqual(4, _n2.Degree);
        }
    }
}
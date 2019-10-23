using System.Linq;
using NUnit.Framework;
using PerfectPath.PriorityQueue;
using PerfectPath.PriorityQueue.DegreeUpdatingStrategies;

namespace PerfectPath.Tests.PriorityQueue
{
    public class FibonacciHeapDecreaseKeyTests
    {
        private FibonacciHeap<int> _fibonacciHeap;
        private Node<int> _n1;
        private Node<int> _n2;
        private Node<int> _n3;
        private Node<int> _n4;
        private Node<int> _n5;
        private Node<int> _n6;

        [SetUp]
        public void SetUp()
        {
            _n1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            _n2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            _n3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);
            _n4 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(4);
            _n5 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(5);
            _n6 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(6);

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

            _fibonacciHeap.PopMin();

            Assert.AreEqual(2, _fibonacciHeap.Peek());

            //    ├─┐ 2
            //    │ ├─╴ 3
            //    │ └─┐ 4
            //    │   └─╴ 5
            //    └─╴ 6
        }

        [Test]
        public void DecreaseKey_MarkParentIfLower_Success()
        {
            _fibonacciHeap.DecreaseKey(5, 1);

            Assert.IsTrue(_n4.Marked);
        }

        [Test]
        public void DecreaseKey_PromoteParentIfLower_Success()
        {
            // mark 4
            // decrease key 5
            _fibonacciHeap.DecreaseKey(_n5, 1);

            Assert.IsNull(_n5.Parent);
            Assert.AreEqual(_n2, _n5.Next);
            Assert.AreEqual(_n6, _n5.Prev);
        }

        [Test]
        public void DecreaseKey_CorrectParentDegreesOnPromotion_Success()
        {
            _fibonacciHeap.DecreaseKey(_n5, 1);

            Assert.AreEqual(0, _n4.Degree, $"{nameof(_n4)} degree");
            Assert.AreEqual(1, _n2.Degree, $"{nameof(_n2)} degree");
        }

        [Test]
        public void DecreaseKey_CorrectNodeDegreeOnPromotion_Success()
        {
            _fibonacciHeap.DecreaseKey(_n5, 1);

            Assert.AreEqual(0, _n5.Degree);
        }

        [Test]
        public void DecreaseKey_MarkedParentPromotedWhenLosingChild_Success()
        {
            _n4.Marked = true;

            _fibonacciHeap.DecreaseKey(_n5, 1);

            CollectionAssert.Contains(NodeDebugTools<int>.IterateSiblings(_n2).ToList(), _n4);
            CollectionAssert.Contains(NodeDebugTools<int>.IterateSiblings(_n2).ToList(), _n5);
        }

        [Test]
        public void DecreaseKey_MarkedParentPromotedIsNoLongerMarked_Success()
        {
            _n4.Marked = true;

            _fibonacciHeap.DecreaseKey(_n5, 1);

            Assert.IsFalse(_n4.Marked);
        }

        [Test]
        public void DecreaseKey_MarkedParentPromotedMarksItsParent_Success()
        {
            _n4.Marked = true;

            _fibonacciHeap.DecreaseKey(_n5, 1);

            Assert.IsTrue(_n2.Marked);
        }
    }
}
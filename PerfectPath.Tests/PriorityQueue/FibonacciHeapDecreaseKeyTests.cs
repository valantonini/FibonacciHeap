using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests.PriorityQueue
{
    public class FibonacciHeapDecreaseKeyTests
    {
        private FibonacciHeap<int> _fibonacciHeap;

        [SetUp]
        public void SetUp()
        {
            _fibonacciHeap = new FibonacciHeap<int>();
        }

        [Test]
        public void DecreaseKey_MarkParentIfLower_Success()
        {
            var n1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var n2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
        }
    }
}
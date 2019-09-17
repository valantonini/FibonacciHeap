using NUnit.Framework;
using PerfectPath.PriorityQueue;
using System.Linq;

namespace PerfectPath.Tests
{
    public class FibonacciHeapIteratorTests
    {
        [Test]
        public void Iterate_Siblings_Success()
        {
            var p1 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(1);
            var p2 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(2);
            var p3 = FibonacciHeapTestHelpers.CreateNodeConnectedToSelf(3);

            FibonacciHeap<int>.Join(p1, p2);
            FibonacciHeap<int>.Join(p2, p3);

            var actual = FibonacciHeap<int>.IterateSiblings(p1).ToList();

            Assert.AreEqual(3, actual.Count());
            Assert.AreEqual(1, actual[0].Value);
            Assert.AreEqual(2, actual[1].Value);
            Assert.AreEqual(3, actual[2].Value);
        }
    }
}
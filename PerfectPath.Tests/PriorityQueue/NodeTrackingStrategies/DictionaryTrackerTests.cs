using PerfectPath.PriorityQueue;
using PerfectPath.PriorityQueue.NodeTrackingStrategies;
using NUnit.Framework;

namespace PerfectPath.Tests.NodeTrackingStrategies
{
    [TestFixture]
    public class DictionaryTrackerTests
    {
        public FibonacciHeap<int> _fibonacciHeap;
        public ITrackNodes<int> _dictionaryKeyTracker;

        [SetUp]
        public void SetUp()
        {
            _fibonacciHeap = new FibonacciHeap<int>();
            _dictionaryKeyTracker = new DictionaryTracker<int>();
            _fibonacciHeap.NodeTrackingStrategy = _dictionaryKeyTracker;
        }

        [Test]
        public void Dict_Push1Node_ShouldAdd()
        {
            _fibonacciHeap.Push(7);
            var node = _dictionaryKeyTracker.Get(7);

            Assert.AreEqual(7, node.Value);
        }

        [Test]
        public void Dict_Pop1Node_ShouldRemove()
        {
            _fibonacciHeap.Push(7);

            _fibonacciHeap.PopMin();

            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => _dictionaryKeyTracker.Get(7));
        }
    }
}
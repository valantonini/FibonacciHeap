using NUnit.Framework;
using PerfectPath.PriorityQueue;
using PerfectPath.PriorityQueue.NodeTrackingStrategies;

namespace PerfectPath.Tests.PriorityQueue.NodeTrackingStrategies
{
    internal class Vector2 : IVector2
    {
        public int F { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }

    [TestFixture]
    public class Vector2TrackerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fibonacciHeap = new FibonacciHeap<Vector2>();
            _dictionaryKeyTracker = new Vector2Tracker<Vector2>(10, 10);
            _fibonacciHeap.NodeTrackingStrategy = _dictionaryKeyTracker;
        }

        private FibonacciHeap<Vector2> _fibonacciHeap;
        private ITrackNodes<Vector2> _dictionaryKeyTracker;

        [Test]
        public void Dict_Pop1Node_ShouldRemove()
        {
            var v1 = new Vector2 {X = 7, Y = 9, F = 123};
            _fibonacciHeap.Push(v1);

            _fibonacciHeap.PopMin();

            Assert.IsNull(_dictionaryKeyTracker.Get(v1));
        }

        [Test]
        public void Dict_Push1Node_ShouldAdd()
        {
            var v1 = new Vector2 {X = 7, Y = 9, F = 123};
            _fibonacciHeap.Push(v1);

            var node = _dictionaryKeyTracker.Get(v1);

            Assert.AreEqual(123, node.Value.F);
        }
    }
}
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
    }
}
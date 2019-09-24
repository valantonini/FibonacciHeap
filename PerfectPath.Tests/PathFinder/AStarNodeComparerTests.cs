using PerfectPath.PathFinder;
using NUnit.Framework;

namespace PerfectPath.Tests.PathFinder
{
    public class AStarNodeComparerTests
    {
        private AStarNodeFComparer _comparer = new AStarNodeFComparer();

        [Test]
        public void CompareTo_LessThan_Success()
        {
            var node1 = new AStarNode
            {
                F = 1,
            };

            var node2 = new AStarNode
            {
                F = 2,
            };

            Assert.AreEqual(-1, _comparer.Compare(node1, node2));
        }

        [Test]
        public void CompareTo_GreaterThan_Success()
        {
            var node1 = new AStarNode
            {
                F = 3,
            };

            var node2 = new AStarNode
            {
                F = 2,
            };

            Assert.AreEqual(1, _comparer.Compare(node1, node2));
        }

        [Test]
        public void CompareTo_Equal_Success()
        {
            var node1 = new AStarNode
            {
                F = 7,
            };

            var node2 = new AStarNode
            {
                F = 7,
            };

            Assert.AreEqual(0, _comparer.Compare(node1, node2));
        }
    }
}
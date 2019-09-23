using PerfectPath.PathFinder;
using NUnit.Framework;

namespace PerfectPath.Tests.PathFinder
{
    public class PathfinderTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Instantiate_Success()
        {
            var pathfinderGrid = new PathFinderGrid(3, 3);
            var pathfinder = new AStar(pathfinderGrid);
        }
    }
}
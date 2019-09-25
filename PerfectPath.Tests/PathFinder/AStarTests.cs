using PerfectPath.PathFinder;
using NUnit.Framework;

namespace PerfectPath.Tests.PathFinder
{
    public class AStarTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Instantiate_Success()
        {
            var pathfinderGrid = new PathFinderGrid<byte>(3, 3);
            var pathfinder = new AStar(pathfinderGrid);
        }

        public void FindPath_StraightLine_Success()
        {
            var pathfinderGrid = new PathFinderGrid<byte>(3, 3);
            var pathfinder = new AStar(pathfinderGrid);
        }
    }
}
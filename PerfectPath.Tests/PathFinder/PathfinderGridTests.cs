using PerfectPath.PathFinder;
using NUnit.Framework;

namespace PerfectPath.Tests.PathFinder
{
    public class PathfinderGridTests
    {
        [Test]
        public void ShouldInstantiateAMatrix()
        {
            var matrix = new PathFinderGrid<byte>(4, 5);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(4, matrix.Height);
                Assert.AreEqual(5, matrix.Width);
            });
        }

        [Test]
        public void ShouldSet2dCoordinates()
        {
            var matrix = new PathFinderGrid<byte>(3, 3);

            byte index = 0;
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    matrix[(x, y)] = index++;
                }
            }

            byte expected = 0;
            foreach (var position in matrix.ToArray())
            {
                Assert.AreEqual(expected++, position);
            }
        }
    }
}
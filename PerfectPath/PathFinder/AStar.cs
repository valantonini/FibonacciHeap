using System.Collections.Generic;
using PerfectPath.PriorityQueue;

namespace PerfectPath.PathFinder
{
    public class AStar : IPathThrough2dSpace
    {
        private readonly PathFinderGrid _grid;
        private readonly AStarNodeFComparer _comparer = new AStarNodeFComparer();

        public AStar(PathFinderGrid grid)
        {
            _grid = grid;
        }

        public (int x, int y)[] FindPath((int x, int y) start, (int x, int y) end)
        {
            IPriorityQueue<AStarNode> open = new FibonacciHeap<AStarNode>();

            throw new System.NotImplementedException();
        }
    }
}
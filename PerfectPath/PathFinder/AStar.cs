using System.Collections.Generic;
using PerfectPath.PriorityQueue;

namespace PerfectPath.PathFinder
{
    public class AStar : IPathThrough2dSpace
    {
        private readonly sbyte[,] _successors = new sbyte[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
        private readonly PathFinderGrid<byte> _grid;
        private readonly AStarCellFComparer _comparer = new AStarCellFComparer();

        public AStar(PathFinderGrid<byte> grid)
        {
            _grid = grid;
        }

        public (int x, int y)[] FindPath((int x, int y) start, (int x, int y) end)
        {
            IPriorityQueue<AStarCell> open = new FibonacciHeap<AStarCell>(_comparer);

            var startCell = new AStarCell()
            {
                X = start.x,
                Y = start.y,
            };

            open.Push(startCell);

            while (open.Count > 0)
            {
                var q = open.PopMin();

                for (var i = 0; i < _successors.GetLength(0); i++)
                {
                    var successorX = q.X + _successors[i, 0];
                }
            }

            throw new System.NotImplementedException();
        }
    }
}
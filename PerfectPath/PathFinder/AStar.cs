using System;
using System.Collections.Generic;
using PerfectPath.PriorityQueue;

namespace PerfectPath.PathFinder
{
    public class AStar : IPathThrough2dSpace
    {
        private readonly sbyte[,] _successors = new sbyte[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
        private readonly PathFinderGrid<byte> _grid;
        private readonly AStarCellFComparer _comparer = new AStarCellFComparer();
        private const int DistanceBetweenCells = 10;

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

                    // make sure x is in bounds for first and last rows
                    if (successorX < 0 || successorX >= _grid.Height)
                    {
                        continue;
                    }

                    var successorY = q.Y + _successors[i, 1];

                    //  make sure y is in bounds for first and last columns
                    if (successorY < 0 || successorY >= _grid.Width)
                    {
                        continue;
                    }

                    var successorCell = new AStarCell()
                    {
                        X = successorX,
                        Y = successorY,
                        G = q.G + DistanceBetweenCells,
                        H = CalculateDistanceBetween2Points(end, (successorX, successorY))
                    };
                    successorCell.F = successorCell.G + successorCell.H;
                }
            }

            throw new System.NotImplementedException();
        }


        private int CalculateDistanceBetween2Points((int x, int y) position1, (int x, int y) positon2)
        {
            var XaMinuxXbSquared = Math.Pow(positon2.x - position1.x, 2);
            var YaMinusYbSquared = Math.Pow(positon2.y - position1.y, 2);

            return (int)Math.Sqrt(XaMinuxXbSquared + YaMinusYbSquared);
        }
    }
}
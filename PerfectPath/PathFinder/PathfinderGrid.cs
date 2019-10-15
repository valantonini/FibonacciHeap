
using System;
using System.Collections.ObjectModel;

namespace PerfectPath.PathFinder
{
    public class PathFinderGrid<T>
    {
        public int Height { get; }
        public int Width { get; }

        private readonly T[] _matrix;

        public PathFinderGrid(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new T[Height * Width];
        }

        public T this[(int x, int y) point]
        {
            get => _matrix[point.x * Width + point.y];
            set => _matrix[point.x * Width + point.y] = value;
        }

        public ReadOnlyCollection<T> ToArray()
        {
            return Array.AsReadOnly(_matrix);
        }
    }
}
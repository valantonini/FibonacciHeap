
using System;
using System.Collections.ObjectModel;

namespace PerfectPath.PathFinder
{
    public class PathFinderGrid
    {
        public static readonly byte OPEN = 0;
        public static readonly byte CLOSED = 1;

        public int Height { get; private set; }
        public int Width { get; private set; }

        private readonly byte[] _matrix;

        public PathFinderGrid(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new byte[Height * Width];
        }

        public byte this[(int x, int y) point]
        {
            get => _matrix[point.x * Width + point.y];
            set => _matrix[point.x * Width + point.y] = value;
        }

        public ReadOnlyCollection<byte> ToArray()
        {
            return Array.AsReadOnly(_matrix);
        }
    }
}
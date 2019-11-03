namespace PerfectPath.PriorityQueue.NodeTrackingStrategies
{
    public class Vector2Tracker<T> : ITrackNodes<T> where T : IVector2
    {
        private readonly Node<T>[] _lookup;

        public Vector2Tracker(int height, int width)
        {
            _lookup = new Node<T>[height * width];
        }

        public void Add(Node<T> node)
        {
            _lookup[node.Value.X * node.Value.Y + node.Value.Y] = node;
        }

        public Node<T> Get(T value)
        {
            return _lookup[value.X * value.Y + value.Y];
        }

        public Node<T> Remove(T value)
        {
            var node = Get(value);
            _lookup[value.X * value.Y + value.Y] = null;
            return node;
        }
    }
}
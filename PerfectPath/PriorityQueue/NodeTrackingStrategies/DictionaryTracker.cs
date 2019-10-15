using System.Collections.Generic;

namespace PerfectPath.PriorityQueue.NodeTrackingStrategies
{
    public class DictionaryTracker<T> : ITrackNodes<T>
    {
        private readonly Dictionary<T, Node<T>> _lookup = new Dictionary<T, Node<T>>();

        public void Add(Node<T> node)
        {
            _lookup.Add(node.Value, node);
        }

        public Node<T> Get(T value)
        {
            return _lookup[value];
        }

        public Node<T> Remove(T value)
        {
            _lookup.Remove(value, out var node);
            return node;
        }
    }
}
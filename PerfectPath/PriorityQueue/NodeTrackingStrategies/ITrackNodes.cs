namespace PerfectPath.PriorityQueue.NodeTrackingStrategies
{
    public interface ITrackNodes<T>
    {
        void Add(Node<T> node);
        Node<T> Get(T value);
        Node<T> Remove(T value);
    }
}
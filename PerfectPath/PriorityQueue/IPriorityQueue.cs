namespace PerfectPath.PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        int Count { get; }
        void Push(T item);
        T Peek();
        T PopMin();
    }
}
namespace PerfectPath.PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Push(T item);
        T Peek();
    }
}
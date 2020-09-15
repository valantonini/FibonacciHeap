namespace FibonacciHeap.PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Push(T item);
        T Peek();
        T PopMin();

        int Count { get; }
    }
}
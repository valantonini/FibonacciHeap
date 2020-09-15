namespace FibonacciHeap.PriorityQueue
{
    public partial class Node<T>
    {
        public T Value { get; internal set; }

        public int Degree { get; internal set; }

        public Node<T> Parent { get; internal set; }
        public Node<T> Child { get; internal set; }
        public Node<T> Prev { get; internal set; }
        public Node<T> Next { get; internal set; }

        public Node() : this(default(T)) { }
        public Node(T value)
        {
            Value = value;
        }
    }
}
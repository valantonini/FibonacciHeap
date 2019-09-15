
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PerfectPath.Tests")]
namespace PerfectPath.PriorityQueue
{
    public class FibonacciHeap<T> : IPriorityQueue<T>
    {
        private Node<T> _min = null;
        private readonly IComparer<T> _comparer;
        public FibonacciHeap() : this(Comparer<T>.Default) { }

        public FibonacciHeap(IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public T Peek()
        {
            return _min.Value;
        }

        public void Push(T item)
        {
            if (_min == null)
            {
                _min = new Node<T>(item);
                _min.Prev = _min.Next = _min;
            }
            else
            {
                var newNode = new Node<T>(item);
                Join(_min, newNode);
                if (_comparer.Compare(item, _min.Value) < 0)
                {
                    _min = newNode;
                }
            }
        }

        public T PopMin()
        {
            if (_min == null)
            {
                throw new HeapEmptyException("Can't pop from empty heap");
            }
            throw new System.Exception();
        }

        internal static void AddChild(Node<T> parent, Node<T> child)
        {
            child.Parent = parent;

            if (parent.Child == null)
            {
                parent.Child = child;
            }
            else
            {
                Join(parent.Child, child);
            }
        }

        internal static void Join(Node<T> prev, Node<T> next)
        {
            var previousOldNext = prev.Next;
            prev.Next = next;
            next.Prev = prev;
            next.Next = previousOldNext;
            previousOldNext.Prev = next;
        }

        internal static Node<T> Cut(Node<T> node)
        {
            node.Next.Prev = node.Prev;
            node.Prev.Next = node.Next;

            if (node.Parent != null && node.Parent.Child == node)
            {
                if (node.Next == node)
                {
                    node.Parent.Child = null;
                }
                else
                {
                    node.Parent.Child = node.Next;
                }
            }

            // Defer resetting parent until later

            node.Prev = node.Next = node;

            return node;
        }
    }
}
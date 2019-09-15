
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
                JoinNodes(_min, newNode);
                if (_comparer.Compare(item, _min.Value) < 0)
                {
                    _min = newNode;
                }
            }
        }

        internal static void AddChild(Node<T> parent, Node<T> child)
        {
            child.Parent = parent;

            if (parent.Child == null)
            {
                parent.Child = child;
                child.Prev = child.Next = child;
            }
            else
            {
                JoinNodes(parent.Child, child);
            }
        }

        internal static void JoinNodes(Node<T> prev, Node<T> next)
        {
            var previousOldNext = prev.Next;
            prev.Next = next;
            next.Prev = prev;
            next.Next = previousOldNext;
            previousOldNext.Prev = next;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PerfectPath.Tests")]
namespace PerfectPath.PriorityQueue
{
    public class FibonacciHeap<T> : IPriorityQueue<T>
    {
        public static readonly double OneOverLogPhi = 1.0 / Math.Log((1.0 + Math.Sqrt(5.0)) / 2.0);

        private Node<T> _min = null;
        private readonly IComparer<T> _comparer;

        public int Count { get; private set; }

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

            Count++;
        }

        public T PopMin()
        {
            if (_min == null)
            {
                throw new HeapEmptyException("Can't pop from empty heap");
            }

            var min = _min;

            _min = _min.Next == _min ? null : _min.Next;

            Count--;

            return Cut(min).Value;
        }

        internal static void AddChild(Node<T> parent, Node<T> child)
        {
            child.Parent = parent;

            if (parent.Child == null)
            {
                parent.Child = child;

                var p = parent;
                while (p != null)
                {
                    p.Degree = p.Child.Degree + 1;
                    p = p.Parent;
                }
            }
            else
            {
                Join(parent.Child, child);

                var p = parent;
                var c = child;
                while (p != null)
                {
                    if (p.Degree >= c.Degree + 1)
                    {
                        break; // bigger sibling already exists 
                    }
                    else
                    {
                        p.Degree = c.Degree + 1;
                        p = p.Parent;
                        c = p;
                    }
                }
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

            // Defer resetting parent until later, this is dangerous as root nodes have now invalid parents

            node.Prev = node.Next = node;

            return node;
        }

        internal static void Consolidate(Node<T> root, int nodeCount)
        {
            var arraySize = ((int)Math.Floor(Math.Log(nodeCount) * OneOverLogPhi)) + 1;
            var array = new Node<T>[arraySize];
        }
    }
}
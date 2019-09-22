using System;
using PerfectPath.PriorityQueue.DegreeUpdatingStrategies;
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

        public IUpdateDegree<T> DegreeUpdatingStrategy = new LazyDegreeUpdater<T>();

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
            // first node in queue
            if (_min == null)
            {
                _min = new Node<T>(item);
                _min.Prev = _min.Next = _min; // join node to self
            }
            else
            {
                var newNode = new Node<T>(item);
                newNode.Prev = newNode.Next = newNode;

                // join node to current min
                Join(_min, newNode);

                // set min to point to new node if smaller
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

            // want to iterate through root nodes. Get a reference to min's next as we are about
            // to cut it from it's siblings
            var minSibling = _min.Next;
            var min = Cut(_min);

            // children need to be promoted to root before we remove it
            if (min.Child != null)
            {
                if (minSibling == min)
                {
                    // if min was the only root node, it's children are now the root
                    minSibling = min.Child;
                }
                else
                {
                    // join children to soon to be new root
                    Join(minSibling, min.Child);
                }

                // sever child, children will sever ties to parent in consolidate
                min.Child = null;
            }

            _min = min == minSibling // there are no other nodes
                        ? null // heap empty 
                        : Consolidate(minSibling, Count, _comparer); // clean up the heap

#if (DEBUG)
            //System.Console.WriteLine(NodeDebugTools<T>.Stringify(_min));
#endif
            Count--;

            return min.Value;

        }

        internal void AddChild(Node<T> parent, Node<T> child)
        {
            child.Parent = parent;

            // first child of parent
            if (parent.Child == null)
            {
                parent.Child = child;
            }
            else
            {
                Join(parent.Child, child);
            }

            // Update parent's degree
            DegreeUpdatingStrategy.UpdateParentsDegreeFromChildAdd(parent, child);
        }

        /// <summary>
        /// Joins 2 nodes. Those nodes can have siblings / links to adjacent
        internal void Join(Node<T> first, Node<T> second)
        {
            var lastNodeInSecond = second.Prev; // last node in second

            first.Prev.Next = second; // last node in first
            second.Prev = first.Prev; // join first node in second to last node in first
            lastNodeInSecond.Next = first; // join lasnode in second to first node in first
            first.Prev = lastNodeInSecond; //join first node in first to last node in second
        }

        /// <summary>
        /// Sever the adjacent and reassign child to parent's child if this was the connection
        /// to the parent.
        /// <summary>
        internal Node<T> Cut(Node<T> node)
        {
            DegreeUpdatingStrategy.UpdateParentsDegreeFromChildCut(node);

            // remove node from adjacent by:
            node.Next.Prev = node.Prev; // joining node on left of this node to node on right
            node.Prev.Next = node.Next; // joining node on right of this one to node on left

            // update parent's child if the parents child is the node about to be removed
            if (node.Parent?.Child == node)
            {
                if (node.Next == node)
                {
                    node.Parent.Child = null; // no adjacent / siblings to replace with
                }
                else
                {
                    node.Parent.Child = node.Next; // parent's child is node on right
                }
            }

            // connect node to itself
            node.Prev = node.Next = node;

            // sever parent
            node.Parent = null;

            return node;
        }

        internal Node<T> Consolidate(Node<T> root, int nodeCount, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

            var arraySize = ((int)Math.Floor(Math.Log(nodeCount) * OneOverLogPhi)) + 1; // magic to ensure array won't be too small (index will be tree degree)
            var array = new Node<T>[arraySize];

            var next = root.Next;
            var current = Cut(root);
            while (current != null)
            {
                var mergeSource = current;
                var index = current.Degree;
                var mergeTarget = array[index];

                while (mergeTarget != null)
                {
                    if (comparer.Compare(mergeSource.Value, mergeTarget.Value) < 0)
                    {
                        AddChild(mergeSource, mergeTarget);
                    }
                    else
                    {
                        AddChild(mergeTarget, mergeSource);
                        mergeSource = mergeTarget;
                    }

                    array[index] = null;
                    index = mergeSource.Degree;
                    mergeTarget = array[index];
                }

                array[mergeSource.Degree] = mergeSource;

                current = current == next ? null : next;
                next = next.Next;

                if (current != null)
                {
                    Cut(current);
                }

            }

            // join togethor merged trees into 1 linked list again
            Node<T> newRoot = null;
            Node<T> newMin = null;
            foreach (var node in array)
            {
                if (node == null)
                {
                    continue;
                }
                else
                {
                    if (newRoot == null)
                    {
                        newRoot = node;
                        newMin = node;
                    }
                    else
                    {
                        if (comparer.Compare(node.Value, newMin.Value) < 0)
                        {
                            newMin = node;
                        }
                        Join(newRoot, node);
                    }
                }
            }

            return newMin;
        }
    }
}
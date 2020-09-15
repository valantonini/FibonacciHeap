using System.Runtime.CompilerServices;

namespace FibonacciHeap.PriorityQueue.DegreeUpdatingStrategies
{
    public class AccurateDegreeUpdater<T> : IUpdateDegree<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdateParentsDegreeFromChildAdd(Node<T> parent, Node<T> child)
        {
            // go up parents updating their degree unless they are bigger due to siblings having higher degree
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdateParentsDegreeFromChildCut(Node<T> node)
        {
            var parent = node.Parent;
            var child = node;
            while (parent != null)
            {
                // go up the chain updating parent's degrees
                if (parent.Degree == child.Degree + 1)
                {
                    var biggestDegree = 0;

                    // iterate through adjacent nodes to find the biggest to recalc parent degree
                    var start = child;
                    var next = child.Next;
                    do
                    {
                        if (next == node)
                        {
                            continue; // skip current node as it is the biggest and will be removed
                        }
                        else
                        {
                            biggestDegree = next.Degree + 1 > biggestDegree ? next.Degree + 1 : biggestDegree;
                        }

                        next = next.Next;
                    }
                    while (next != start);
                    // update parent's degree
                    parent.Degree = biggestDegree;
                }
                else
                {
                    break;
                }

                child = parent;
                parent = parent.Parent;
            }
        }
    }
}
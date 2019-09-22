using System.Runtime.CompilerServices;

namespace PerfectPath.PriorityQueue.DegreeUpdatingStrategies
{
    public class LazyDegreeUpdater<T> : IUpdateDegree<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdateParentsDegreeFromChildAdd(Node<T> parent, Node<T> child)
        {
            if (parent.Degree < child.Degree + 1)
            {
                parent.Degree = child.Degree + 1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdateParentsDegreeFromChildCut(Node<T> node)
        {
        }
    }
}
using FibonacciHeap.PriorityQueue;

namespace  FibonacciHeap.PriorityQueue.DegreeUpdatingStrategies
{
    public interface IUpdateDegree<T>
    {
        void UpdateParentsDegreeFromChildAdd(Node<T> parent, Node<T> child);
        void UpdateParentsDegreeFromChildCut(Node<T> node);
    }
}
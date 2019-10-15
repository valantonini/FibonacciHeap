namespace  PerfectPath.PriorityQueue.DegreeUpdatingStrategies
{
    public interface IUpdateDegree<T>
    {
        void UpdateParentsDegreeFromChildAdd(Node<T> parent, Node<T> child);
        void UpdateParentsDegreeFromChildCut(Node<T> node);
    }
}
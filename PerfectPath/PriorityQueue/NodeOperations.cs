namespace PerfectPath.PriorityQueue
{
    public class NodeOperations<T>
    {
        public static void AddChild(Node<T> parent, Node<T> child)
        {
            parent.Child = child;

            child.Parent = parent;
            child.Left = child.Right = child;
        }
    }
}
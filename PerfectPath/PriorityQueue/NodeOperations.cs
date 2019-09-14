namespace PerfectPath.PriorityQueue
{
    public class NodeOperations<T>
    {
        public static void AddChild(Node<T> parent, Node<T> child)
        {
            child.Parent = parent;

            if (parent.Child == null)
            {
                parent.Child = child;
                child.Left = child.Right = child;
            }
            else
            {
                child.Left = parent.Child.Right;
                child.Right = parent.Child.Right.Left;

                parent.Child.Right.Left = child;
                parent.Child.Right = child;
            }

        }
    }
}
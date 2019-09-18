using System.Linq;
namespace PerfectPath.PriorityQueue
{
    public partial class Node<T>
    {
#if (DEBUG)
        public bool SingleNode => Next == this && Prev == this;
        public int SiblingCount => NodeDebugTools<T>.IterateSiblings(this).Count();
        public int parentCount => this.Parent == null ? 0 : NodeDebugTools<T>.IterateUpParents(this.Parent, this).Count();

        public override string ToString() => NodeDebugTools<T>.Stringify(this);
#endif
    }
}
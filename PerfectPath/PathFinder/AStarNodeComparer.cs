using System.Collections.Generic;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PerfectPath.Tests")]
namespace PerfectPath.PathFinder
{
    internal class AStarNodeFComparer : IComparer<AStarNode>
    {
        public int Compare(AStarNode x, AStarNode y)
        {
            return x.F.CompareTo(y.F);
        }
    }
}
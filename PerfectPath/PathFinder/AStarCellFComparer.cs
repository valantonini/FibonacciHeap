using System.Collections.Generic;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PerfectPath.Tests")]
namespace PerfectPath.PathFinder
{
    internal class AStarCellFComparer : IComparer<AStarCell>
    {
        public int Compare(AStarCell x, AStarCell y)
        {
            return x.F.CompareTo(y.F);
        }
    }
}
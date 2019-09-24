namespace PerfectPath.PathFinder
{
    public interface IPathThrough2dSpace
    {
        (int x, int y)[] FindPath((int x, int y) start, (int x, int y) end);
    }
}
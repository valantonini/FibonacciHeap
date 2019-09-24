namespace PerfectPath.PathFinder
{
    public class AStar : IPathThrough2dSpace
    {
        private readonly PathFinderGrid _grid;
        public AStar(PathFinderGrid grid)
        {
            _grid = grid;
        }

        public (int x, int y)[] FindPath((int x, int y) start, (int x, int y) end)
        {
            throw new System.NotImplementedException();
        }
    }
}
namespace PerfectPath.PathFinder
{
    public struct AStarCell
    {
        ///<summary>
        /// Row.
        ///</summary>
        public int X { get; set; }

        ///<summary>
        /// Column.
        ///</summary>
        public int Y { get; set; }

        ///<summary>
        /// Distance from start.
        ///</summary>
        public int G { get; set; }

        ///<summary>
        /// Distance from [ X, Y ] to goal.
        ///</summary>
        public int H { get; set; }

        ///<summary>
        /// G + H
        ///</summary>
        public int F { get; set; }

        public int ParentX { get; set; }
        public int ParentY { get; set; }
    }
}
using System;

namespace PerfectPath.PriorityQueue
{
    public class HeapEmptyException : Exception
    {
        public HeapEmptyException(string msg) : base(msg) { }

    }
}
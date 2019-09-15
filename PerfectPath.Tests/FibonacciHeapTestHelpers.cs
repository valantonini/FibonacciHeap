using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public static class FibonacciHeapTestHelpers
    {
        public static Node<int> CreateNodeConnectedToSelf(int value)
        {
            var node = new Node<int>(value);
            node.Prev = node.Next = node;
            return node;
        }
    }
}
using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests.PriorityQueue
{
    public static class FibonacciHeapTestHelpers
    {
        // TODO: create helper method to create nunit testcase
        // var str = $"new int[]{{{string.Join(", ", numbers)},{string.Join(", ", numbers.OrderBy(n => n).Select(n => n * -1))}}}";

        public static Node<int> CreateNodeConnectedToSelf(int value)
        {
            var node = new Node<int>(value);
            node.Prev = node.Next = node;
            return node;
        }

        public static FibonacciHeap<int> ProcessIntArray(int[] sequence)
        {
            var fh = new FibonacciHeap<int>();

            foreach (var s in sequence)
            {
                if (s < 0)
                {
                    var val = fh.PopMin();
                    Assert.AreEqual(System.Math.Abs(s), val);
                }
                else
                {
                    fh.Push(s);
                }
            }

            return fh;
        }
    }
}
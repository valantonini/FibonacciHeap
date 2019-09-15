using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapTests
    {
        [Test]
        public void New_ShouldInstantiate()
        {
            var fh = new FibonacciHeap<int>();
            Assert.NotNull(fh);
        }

        [Test]
        public void Peek_ShouldShowMin()
        {
            var fh = new FibonacciHeap<int>();
            
            fh.Push(3);
            
            Assert.AreEqual(3, fh.Peek());
        }

        [Test]
        public void Peek_ShouldShowMin_WhenSmallerWasPushedAfter()
        {
            var fh = new FibonacciHeap<int>();
            
            fh.Push(2);
            fh.Push(3);
            
            Assert.AreEqual(2, fh.Peek());
        }

        private FibonacciHeap<int> ProcessIntArray(int[] sequence)
        {
            var fh = new FibonacciHeap<int>();

            foreach (var s in sequence)
            {
                if (s < 0)
                {
                    // var val = fh.PopMin();
                    // Assert.AreEqual(System.Math.Abs(s), val);
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
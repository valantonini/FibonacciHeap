using NUnit.Framework;
using FibonacciHeap.PriorityQueue;

namespace FibonacciHeap.Tests.PriorityQueue
{
    public class FibonacciHeapCountTests
    {
        [Test]
        public void Count_EmptyHeap_0Count()
        {
            var fh = new FibonacciHeap<int>();

            Assert.AreEqual(0, fh.Count);
        }

        [Test]
        public void Count_1Node_1Count()
        {
            var fh = new FibonacciHeap<int>();

            fh.Push(7);

            Assert.AreEqual(1, fh.Count);
        }


        [Test]
        public void Count_2Node_2Count()
        {
            var fh = new FibonacciHeap<int>();

            fh.Push(7);
            fh.Push(8);

            Assert.AreEqual(2, fh.Count);
        }

        // Negative will Peek and assert against Math.Abs of the value
        [TestCase(new int[] { 1, -1 })]
        [TestCase(new int[] { 1, 2, -1 })]
        [TestCase(new int[] { 2, 1, -1 })]
        [TestCase(new int[] { 7, 8, 9, -7, 5, 6, -5, 4, -4, 3, 2, 99, -2 })]
        public void Count_MultipleValuesPushedAndPopped_CorrectCount(int[] sequence)
        {
            var fh = new FibonacciHeap<int>();
            var count = 0;
            foreach (var value in sequence)
            {
                if (value < 0)
                {
                    var val = fh.PopMin();
                    Assert.AreEqual(--count, fh.Count);
                }
                else
                {
                    fh.Push(value);
                    count++;
                }
            }
        }
    }
}
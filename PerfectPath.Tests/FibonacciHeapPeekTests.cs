using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapPeekTests
    {
        [Test]
        public void Peek_1Node_CorrectValue()
        {
            var fh = new FibonacciHeap<int>();
            
            fh.Push(3);
            
            Assert.AreEqual(3, fh.Peek());
        }

        [Test]
        public void Peek_2NodesSmallerFirst_CorrectValue()
        {
            var fh = new FibonacciHeap<int>();
            
            fh.Push(2);
            fh.Push(3);
            
            Assert.AreEqual(2, fh.Peek());
        }

        [Test]
        public void Peek_2NodesSmallerLast_CorrectValue()
        {
            var fh = new FibonacciHeap<int>();
            
            fh.Push(3);
            fh.Push(2);
            
            Assert.AreEqual(2, fh.Peek());
        }

        // Negative will Peek and assert against Math.Abs of the value
        [TestCase(new int[] { 1, -1 })]
        [TestCase(new int[] { 1, 2, -1 })]
        [TestCase(new int[] { 2, 1, -1 })]
        [TestCase(new int[] { 7, 8, 9, -7, 5, 6, -5, 4, -4, 3, 2, 99, -2 })]
        public void Peek_MultipleValues_CorrectValue(int[] sequence)
        {
             var fh = new FibonacciHeap<int>();

            foreach (var value in sequence)
            {
                if (value < 0)
                {
                    var val = fh.Peek();
                    Assert.AreEqual(System.Math.Abs(value), val);
                }
                else
                {
                    fh.Push(value);
                }
            }
        }
    }
}
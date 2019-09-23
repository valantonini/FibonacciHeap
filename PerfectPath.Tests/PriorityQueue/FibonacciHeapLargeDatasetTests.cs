using System;
using System.Linq;
using NUnit.Framework;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests.PriorityQueue
{
    public class FibonacciHeapLargeDatasetTests
    {
        [Test]
        public void FibonacciHeap_ShouldOrderLargeDataset()
        {
            var random = new Random(123);

            var numbers = Enumerable
                            .Range(0, 8)
                            .Select(_ => random.Next(1, 1000000))
                            .Distinct()
                            .ToList();

            var heap = new FibonacciHeap<int>();

            foreach (var i in numbers)
            {
                heap.Push(i);
            }

            foreach (var i in numbers.OrderBy(n => n))
            {
                Assert.AreEqual(i, heap.PopMin());
            }
        }
    }
}
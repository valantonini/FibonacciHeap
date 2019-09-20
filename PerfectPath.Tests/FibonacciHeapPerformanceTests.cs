using System;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using PerfectPath.PriorityQueue;

namespace PerfectPath.Tests
{
    public class FibonacciHeapPerformanceTests
    {
        [Test]
        public void FibonacciHeap_ShouldPerform()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine();
            var mod = 2;
            var random = new Random(123);

            var numbers = Enumerable
                            .Range(0, 200000)
                            .Select(_ => random.Next(1, 1000000))
                            .Distinct()
                            .ToList();

            var timer = Stopwatch.StartNew();
            var heap = new FibonacciHeap<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                heap.Push(numbers[i]);
                if (i % mod == 0)
                {
                    heap.PopMin();
                }
            }
            timer.Stop();
            var heapElapsed = timer.ElapsedMilliseconds;
            stringBuilder.AppendLine($"Heap: {numbers.Count} processed in {heapElapsed}ms");

            // timer = Stopwatch.StartNew();
            // var list = new List<int>();
            // for (var i = 0; i < numbers.Count; i++)
            // {
            //     list.Add(numbers[i]);  
            //     if (i % mod == 0) {
            //         list.Remove(list.Min());
            //     }  
            // }
            // timer.Stop();
            // stringBuilder.AppendLine($"List: {numbers.Count} processed in {timer.ElapsedMilliseconds}ms");

            timer = Stopwatch.StartNew();
            var queueB = new BaselinePriorityQueue<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                queueB.Push(numbers[i]);
                if (i % mod == 0)
                {
                    queueB.PopMin();
                }
            }
            timer.Stop();
            var queueElapsed = timer.ElapsedMilliseconds;

            var variance = heapElapsed < queueElapsed
                            ? ((double)heapElapsed / (double)queueElapsed) * (double)100 * -1
                            : ((double)queueElapsed / (double)heapElapsed) * (double)100;

            stringBuilder.AppendLine($"Queue: {numbers.Count} processed in {queueElapsed}ms");

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"variance {heapElapsed - queueElapsed}ms ({variance}%)");
            stringBuilder.AppendLine();

            Console.WriteLine(stringBuilder.ToString());

            // Assert.Less(heapElapsed, queueElapsed);
        }
    }
}
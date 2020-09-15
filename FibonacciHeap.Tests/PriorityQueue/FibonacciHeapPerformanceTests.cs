using System;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using FibonacciHeap.PriorityQueue;

namespace FibonacciHeap.Tests.PriorityQueue
{
    public class FibonacciHeapPerformanceTests
    {
        [Test]
        public void FibonacciHeap_ShouldPerform()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine();
            var mod = 4;
            var random = new Random(123);

            var numbers = Enumerable
                            .Range(0, 200000)
                            .Select(_ => random.Next(1, 1000000))
                            .Distinct()
                            .ToList();


            var baselineTimer = Stopwatch.StartNew();
            var queueB = new BaselinePriorityQueue<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                queueB.Push(numbers[i]);
                if (i % mod == 0)
                {
                    queueB.PopMin();
                }
            }
            baselineTimer.Stop();
            var queueElapsed = baselineTimer.ElapsedMilliseconds;

            var heapTimer = Stopwatch.StartNew();
            var heap = new FibonacciHeap<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                heap.Push(numbers[i]);
                if (i % mod == 0)
                {
                    heap.PopMin();
                }
            }
            heapTimer.Stop();
            var heapElapsed = heapTimer.ElapsedMilliseconds;
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


            var variance = ((double)heapElapsed / (double)queueElapsed) * (double)100;

            stringBuilder.AppendLine($"Queue: {numbers.Count} processed in {queueElapsed}ms");

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"variance {heapElapsed - queueElapsed}ms ({Math.Round(variance, 2)}%)");
            stringBuilder.AppendLine();

            Console.WriteLine(stringBuilder.ToString());

            // Assert.Less(heapElapsed, queueElapsed);
        }
    }
}
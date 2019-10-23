using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using PerfectPath.PriorityQueue;
using PerfectPath.PriorityQueue.DegreeUpdatingStrategies;

namespace PerfectPath.Tests.PriorityQueue
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

            const int iterations = 10;
            var results = new List<long>();
            for (var iteration = 0; iteration <= iterations; iteration++)
            {
                var heapTimer = Stopwatch.StartNew();
                var heap = new FibonacciHeap<int>
                {
                    DegreeUpdatingStrategy = new AccurateDegreeUpdater<int>()
                };

                for (var i = 0; i < numbers.Count; i++)
                {
                    heap.Push(numbers[i]);
                    if (i % mod == 0)
                    {
                        heap.PopMin();
                    }
                }

                heapTimer.Stop();

                if (iteration == 0)
                {
                    // warm up
                    continue;
                }

                results.Add(heapTimer.ElapsedMilliseconds);
            }
            
            var heapElapsedAverage = results.Sum() / iterations;

            stringBuilder.AppendLine($"Heap: {numbers.Count} processed in {heapElapsedAverage}ms averaged over {iterations} runs");

            Console.WriteLine(stringBuilder.ToString());
            Assert.Inconclusive(stringBuilder.ToString());
        }
    }
}
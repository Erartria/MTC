using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task4
{
    class Program
    {
        static int[] Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            var barrier = 0;
            var result = new List<int>();
            List<int> cache = new List<int>();
            //эмуляция потока данных
            foreach (var element in inputStream)
            {
                barrier = Math.Max(barrier, element - sortFactor);
                cache.Add(element);
                while (cache.Count > 0 && (cache.First() <= barrier || cache.First() == maxValue))
                {
                    Console.Out.Write($"OUT {cache.First()} ");
                    result.Add(cache.First());
                    cache.Remove(cache.First());
                }
                cache.InsertionSort();
            }

            foreach (var element in cache)
            {
                Console.Out.Write($"{element} ");
                result.Add(element);
            }

            cache.Clear();
            return result.ToArray();
        }

        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            var softFactor = 20;
            var input = new List<int>() {20, 0, 19, 18, 17, 0, 17,18, 7, 5, 1, 16, 19, 20};
            //var softFactor = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            //var input = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();
            Sort(input, softFactor, 2000);
            timer.Stop();
            var resultTime = timer.Elapsed;
            string elapsedTime =
                $"\n{resultTime.Hours:00}:{resultTime.Minutes:00}:{resultTime.Seconds:00}.{resultTime.Milliseconds:000}";
            Console.Out.WriteLine(elapsedTime);
        }
    }
}
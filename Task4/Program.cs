using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;

namespace Task4
{
    /// <summary>
    /// Реализуйте метод Sort.
    /// Известно, что потребители метода зачастую не будут вычитывать данные до конца.
    /// Оптимально ли Ваше решение с точки зрения скорости выполнения?
    /// С точки зрения потребляемой памяти?
    /// </summary>
    class Program
    {
        private static readonly object ConsoleWriteLock = new object();
        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// Скорость работы: O(N),
        /// Дополнительная память: Teta(N)
        /// N - колличество эллементов в массиве (не превышает миллиарда чисел)
        /// т.к. max-min будет много меньше чем N -> можно принебречь
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число.
        /// Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        static int[] Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            var barrier = 0;
            var result = new List<int>();
            List<int> cache = new List<int>();
            foreach (var element in inputStream)
            {
                barrier = Math.Max(barrier, element - sortFactor);
                while (cache.Count > 0 && cache.First() < barrier)
                {
                    Console.Out.Write($"{cache.First()} ");
                    result.Add(cache.First());
                    cache.Remove(cache.First());
                }
                cache.InsertInCorrectPosition(element);
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
            var softFactor = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var input = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();
            Sort(input, softFactor, 2000);
        }
    }
}
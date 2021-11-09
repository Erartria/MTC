using System;
using System.IO;

namespace Task5
{
    /// <summary>
    /// Слон из мухи.
    /// Программа выводит на экран строку «Муха», а затем продолжает выполнять остальной код.
    /// Реализуйте метод TransformToElephant так, чтобы программа выводила на экран строку «Слон»,
    /// а затем продолжала выполнять остальной код, не выводя перед этим на экран строку «Муха».
    /// </summary>
    class Program
    {
        static void Main(string[] args) {
            TransformToElephant();
            Console.WriteLine("Муха");
            //... custom application code
            Console.WriteLine("Муха");
            Console.WriteLine("Оса");
        }

        static void TransformToElephant()
        {
            //https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/unsafe
            unsafe
            {
                //https://metanit.com/sharp/tutorial/2.33.php
                ReadOnlySpan<char> elephant = new Span<char>(new[]{'С','л','о','н'});
                string fly = "Муха";
                //https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/fixed-statement
                fixed (char* ptr = fly)
                    //https://docs.microsoft.com/ru-ru/dotnet/api/system.span-1.copyto?view=netcore-2.2
                    elephant.CopyTo(new Span<char>(ptr, elephant.Length));
            }
        }
    }
}
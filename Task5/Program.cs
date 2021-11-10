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
            Console.Out.WriteLine("Муха");
            //... custom application code
            Console.Out.WriteLine("Муха");
            Console.Out.WriteLine("Оса");
        }

        static void TransformToElephant()
        {
            Console.Out.WriteLine("Слон");
            Console.SetOut(new MyWriter());
        }
        
        class MyWriter : StringWriter
        {
            TextWriter defaultTextWriter = Console.Out;

            public override void WriteLine(string? value)
            {
                Console.SetOut(defaultTextWriter);
            }
        }
    }
}
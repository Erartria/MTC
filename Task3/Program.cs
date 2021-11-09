using System;

namespace Task3
{
    /// <summary>
    /// Быть или не быть? Вопрос не в этом.
    /// Модифицируйте код так, чтобы во всех местах на экран выводилось «True».
    /// Метод Main изменять нельзя.
    ///
    /// Появились ли в коде новые методы или свойства? Можно ли обойтись без них?
    /// Ответ:
    /// Неявно было создано публичное свойство get.
    /// Обойтись без методов и свойств нельзя.
    /// </summary>
    class Program
    {
        struct IntValue
        {
            public int? Value;

            public bool HasValue => Value.HasValue;
            /*public bool HasValue
            {
                get
                {
                    return Value.HasValue;
                }
            }*/
        }

        static void Main(string[] args)
        {
            IntValue intValue = new IntValue();
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = 1;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = -1;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = 0;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = null;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            Console.ReadKey();
        }
    }

}
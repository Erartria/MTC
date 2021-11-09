using System;
using System.Globalization;

namespace Task2
{
	/// <summary>
	/// Операция «Ы».
	/// Измените класс Number так, чтобы на экран выводился результат сложения для любых значений someValue1 и someValue2.
	///
	/// Что выводится на экран?
	/// Ответ:
	/// Изначально выводилась строка 105.
	/// Происходит неявное преобразование типов. Для new Number(someValue1) неявно вызывается метод toString().
	/// При сложении значений типа string происходит их конкатенация
	/// </summary>
    class Program
    {
    	static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;
    
    	class Number
    	{
    		readonly int _number;
    
    		public Number(int number)
    		{
    			_number = number;
    		}

            public static string operator +(Number x, string strY)
            {
	            try
	            {
		            var y = Int32.Parse(strY);
		            return (x._number + y).ToString(_ifp);
	            }
	            catch
	            {
		            throw new ArgumentException();
	            }
            }
    
    		public override string ToString()
    		{
    			return _number.ToString(_ifp);
    		}
    	}
    
    	static void Main(string[] args)
    	{
    		int someValue1 = 10;
    		int someValue2 = 5;
    
    		string result = new Number(someValue1) + someValue2.ToString(_ifp);
    		Console.WriteLine(result);
    		Console.ReadKey();
    	}
    }

}
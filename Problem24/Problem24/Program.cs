using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem24
{
    class Program
    {
        static void Main(string[] args)
        {
            var digits = Enumerable.Range(0, 10).ToList();
            string result = "";
            var order = 1000000 - 1;
            for (int position = 9; position >= 0; position--)
            {
                var optionCount = Factorial(position);
                var digitIndex = order / optionCount;
                result += digits[digitIndex];
                order %= optionCount;
                digits.RemoveAt(digitIndex);
            }
            Console.WriteLine(result);
        }

        private static int Factorial(int number)
        {
            var fact = 1;
            for (int i = 2; i <= number; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}

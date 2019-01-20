using System;
using System.Collections.Generic;

namespace Problem34
{
    class Program
    {
        private static Dictionary<int, int> _digitFactorials = new Dictionary<int, int>();

        private static long _solution = 0;

        static void Main(string[] args)
        {
            PreCalculateDigitFactorials();
            for (int i = 3; i < 1000000; i++)
            {
                var sum = 0;
                var number = i;
                while (number != 0)
                {
                    var digit = number % 10;
                    sum += _digitFactorials[digit];
                    number /= 10;
                }

                if (sum == i)
                {
                    _solution += i;
                }
            }

            Console.WriteLine(_solution);
        }

        private static void PreCalculateDigitFactorials()
        {
            for (int digit = 0; digit < 10; digit++)
            {
                var product = 1;
                for (int multiplier = 1; multiplier <= digit; multiplier++)
                {
                    product *= multiplier;
                }
                _digitFactorials.Add(digit, product);
            }
        }
    }
}

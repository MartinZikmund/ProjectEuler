using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem23
{
    class Program
    {
        private static HashSet<int> _allNumbers = new HashSet<int>(Enumerable.Range(1,28123));

        static void Main(string[] args)
        {
            var abundantNumbers = new List<int>();
            for (int i = 1; i <= 28123; i++)
            {
                var divisorSum = GetSumOfProperDivisors(i);
                if (divisorSum > i)
                {
                    abundantNumbers.Add(i);
                }
            }

            foreach (var firstNumber in abundantNumbers)
            {
                foreach (var secondNumber in abundantNumbers)
                {
                    _allNumbers.Remove(firstNumber + secondNumber);
                }
            }

            Console.WriteLine(_allNumbers.Sum());
        }

        public static int GetSumOfProperDivisors(int number)
        {
            var sum = 0;
            var sqrt = (int)Math.Sqrt(number);
            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                    var otherDivisor = number / i;
                    if (otherDivisor != i && otherDivisor != number)
                    {
                        sum += otherDivisor;
                    }
                }
            }
            return sum;
        }
    }
}

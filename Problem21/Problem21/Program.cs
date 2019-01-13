using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem21
{
    class Program
    {
        private static Dictionary<int, int> _divisorSums = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            var amicableSum = 0L;
            for (int i = 2; i <= 10000; i++)
            {
                var mirror = GetSumOfProperDivisors(i);
                _divisorSums[i] = mirror;
                if (_divisorSums.TryGetValue(_divisorSums[i], out var mirrorValue))
                {
                    if (mirrorValue == i && mirror != i)
                    {
                        //amicable
                        amicableSum += i;
                        amicableSum += mirror;
                    }
                }
            }

            Console.WriteLine(amicableSum);
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

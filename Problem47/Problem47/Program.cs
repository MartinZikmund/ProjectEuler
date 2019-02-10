using System;
using System.Collections.Generic;

namespace Problem47
{
    class Program
    {
        private static List<int> _foundPrimes = new List<int>();

        static void Main(string[] args)
        {
            var fourStreakLength = 0;
            var current = 1;
            do
            {
                current++;
                var divisorCount = GetPrimeDivisorsCount(current);
                if (divisorCount == 0)
                {
                    _foundPrimes.Add(current);
                    fourStreakLength = 0;
                }
                else
                {
                    if (divisorCount == 4)
                    {
                        fourStreakLength++;
                    }
                    else
                    {
                        fourStreakLength = 0;
                    }
                }
            } while (fourStreakLength != 4);            
            Console.WriteLine(current - 3);
        }

        private static int GetPrimeDivisorsCount(int number)
        {
            var sqrt = Math.Sqrt(number);            
            var divisorCount = 0;            
            for (int i = 0; i < _foundPrimes.Count && _foundPrimes[i] <= sqrt && _foundPrimes[i] <= number; i++)
            {
                var divisions = 0;
                while (number % _foundPrimes[i] == 0)
                {
                    number /= _foundPrimes[i];
                    divisions++;
                }

                if (divisions > 0)
                {
                    divisorCount++;
                }
            }
            if (number != 1 && divisorCount > 0)
            {
                divisorCount++;
            }
            return divisorCount;
        }
    }
}

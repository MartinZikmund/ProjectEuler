using System;
using System.Collections.Generic;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengthCalculator = new DecimalCycleLengthCalculator();
            var maxCycle = 0;
            var bestDivisor = 0;
            for (int i = 2; i < 1000; i++)
            {
                var currentCycle = lengthCalculator.CalculateCycleLength(i);
                maxCycle = Math.Max(currentCycle, maxCycle);
                if (maxCycle == currentCycle)
                {
                    bestDivisor = i;
                }

            }
            Console.WriteLine(bestDivisor);
        }

        
    }

    public class DecimalCycleLengthCalculator
    {
        public int CalculateCycleLength(int denominator)
        {
            var encounteredCombinations = new Dictionary<int, int>();
            var cycleSize = 0;
            int number = 1;
            int position = 0;
            do
            {
                while (number < denominator)
                {
                    number *= 10;
                }

                var remainder = number % denominator;

                if (remainder == 0)
                {
                    break;
                }
                if (encounteredCombinations.ContainsKey(remainder))
                {
                    cycleSize = position - encounteredCombinations[remainder];
                    break;
                }
                encounteredCombinations.Add(remainder, position);
                position++;
                number = remainder;
            } while (true);

            return cycleSize;
        }
    }
}

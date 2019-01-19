using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem33
{
    class Program
    {
        private static HashSet<(int numerator, int denominator)> _solutions = new HashSet<(int numerator, int denominator)>();
        static void Main(string[] args)
        {
            for (int numerator = 10; numerator <= 99; numerator++)
            {
                for (int denominator = numerator + 1; denominator < 99; denominator++)
                {
                    var result = numerator / (1.0 * denominator);

                    var numeratorString = numerator.ToString();
                    var denominatorString = denominator.ToString();

                    bool isSolution = false;                    
                    isSolution = 
                        IsNonTrivialSolution(numerator, denominator, numerator / 10, denominator / 10, numerator % 10, denominator % 10) ||
                        IsNonTrivialSolution(numerator,denominator, numerator / 10, denominator % 10, numerator % 10, denominator / 10) ||
                        IsNonTrivialSolution(numerator, denominator, numerator % 10, denominator / 10, numerator / 10, denominator % 10) ||
                        IsNonTrivialSolution(numerator, denominator, numerator % 10, denominator % 10, numerator / 10, denominator / 10);

                    if (isSolution)
                    {
                        _solutions.Add((numerator, denominator));
                    }
                }
            }

            var totalNumerator = _solutions.Select(s => s.numerator).Aggregate(1, (a, b) => a * b);
            var totalDenominator = _solutions.Select(s => s.denominator).Aggregate(1, (a, b) => a * b);
            var sqrt = Math.Sqrt(totalNumerator);
            for (int i = 2; i <= sqrt; i++)
            {
                while (totalNumerator % i == 0 && totalDenominator % i == 0)
                {
                    totalNumerator /= i;
                    totalDenominator /= i;
                }
            }

            Console.WriteLine(totalDenominator);
        }

        private static bool IsNonTrivialSolution(int numerator, int denominator, int crossOutDigit1, int crossOutDigit2, int remainingDigit1, int remainingDigit2)
        {
            if (remainingDigit1 == 0 || remainingDigit2 == 0) return false;
            if (crossOutDigit1 != crossOutDigit2) return false;
            var originalFraction = numerator / (1.0 * denominator);
            var newFraction = remainingDigit1 / (1.0 * remainingDigit2);
            if (Math.Abs(originalFraction - newFraction) > 0.0001) return false;
            if (crossOutDigit1 % remainingDigit1 == 0 && crossOutDigit2 % remainingDigit2 == 0 &&
                crossOutDigit1 / remainingDigit1 == crossOutDigit2 / remainingDigit2) return false;
            return true;
        }
    }
}

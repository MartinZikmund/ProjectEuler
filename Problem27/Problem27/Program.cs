using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            var bestN = 0;
            var bestProduct = 0;
            for (int a = -999; a <= 999; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    //avoid calculation if can't improve
                    if (!IsPrime(bestN * bestN + a * bestN + b)) continue;
                    int n = 0;
                    while (IsPrime(n * n + a * n + b))
                    {
                        n++;
                    }
                    bestN = Math.Max(n, bestN);
                    if (bestN == n)
                    {
                        bestProduct = a * b;
                    }
                }
            }
            Console.WriteLine(bestProduct);
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            var sqrt = (int)Math.Sqrt(number);
            var isPrime = Enumerable.Range(2, sqrt).All(d => number % d != 0);
            return isPrime;
        }
    }
}

using System;
using System.Numerics;

namespace Problem53
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalCombinatorials = 100 * (100 + 1) / 2 + 100;
            var lowerCombinatorials = 0;
            for (int n = 1; n <= 100; n++)
            {
                int thisCount = 0;
                bool overflow = false;
                for (int r = 0; r <= n; r++)
                {
                    var result = CalculateCombinatorial(n, r);
                    if (result <= 1000000)
                    {
                        thisCount++;
                    }
                    else
                    {
                        overflow = true;
                        break;
                    }
                }

                if (overflow)
                {
                    lowerCombinatorials += thisCount * 2;
                }
                else
                {
                    lowerCombinatorials += thisCount;
                }
            }
            Console.WriteLine(lowerCombinatorials);
            Console.WriteLine(totalCombinatorials - lowerCombinatorials);
        }

        private static BigInteger CalculateCombinatorial(int n, int r)
        {
            return Factorial(n - r + 1, n) / Factorial(r);
        }

        private static BigInteger Factorial(int from, int to)
        {
            BigInteger product = 1;
            for (int current = from; current <= to; current++)
            {
                product *= current;
            }
            return product;
        }

        private static BigInteger Factorial(int n)
        {
            BigInteger product = 1;
            for (int i = 1; i <= n; i++)
            {
                product *= i;
            }
            return product;
        }
    }
}

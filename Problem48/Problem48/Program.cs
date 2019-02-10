using System;
using System.Numerics;

namespace Problem48
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger totalSum = new BigInteger(0);
            for (int i = 1; i <= 1000; i++)
            {
                BigInteger current = new BigInteger(i);
                for (int exp = 2; exp <= i; exp++)
                {
                    current *= i;
                }

                totalSum += current;
            }

            var fullString = totalSum.ToString();
            Console.WriteLine(fullString.Substring(fullString.Length - 10));
        }
    }
}

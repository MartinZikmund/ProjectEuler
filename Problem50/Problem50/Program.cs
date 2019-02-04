using System;
using System.Collections.Generic;

namespace Problem50
{
    class Program
    {
        private static int MaxN = 1000000;
        

        static void Main(string[] args)
        {
            var primes = FindPrimes();
            var primeHashSet = new HashSet<int>(primes);
            var maxLength = 21;
            var bestSolution = 953;

            for (int startPrimeId = 0; startPrimeId < primes.Length - maxLength; startPrimeId++)
            {
                int currentSum = primes[startPrimeId];
                var currentLength = 1;
                for (int endPrimeId = startPrimeId + 1; endPrimeId < primes.Length; endPrimeId++)
                {
                    currentSum += primes[endPrimeId];
                    currentLength += 1;
                    if (primeHashSet.Contains(currentSum) && currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        bestSolution = currentSum;
                    }

                    if (currentSum > MaxN)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(bestSolution);
        }

        private static int[] FindPrimes()
        {
            bool[] isPrime = new bool[MaxN];
            Array.Fill(isPrime, true);
            var sqrt = (int) Math.Sqrt(MaxN);
            for (int i = 2; i <= sqrt; i++)
            {
                if (isPrime[i])
                {
                    //mark all multiples
                    var multiple = i * i;
                    while (multiple < MaxN)
                    {
                        isPrime[multiple] = false;
                        multiple += i;
                    }
                }
            }

            var primes = new List<int>();
            for (int i = 2; i < MaxN; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
        }
    }
}

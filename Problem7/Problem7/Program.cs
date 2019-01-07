using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7
{
    class Program
    {
        private const int TargetPrime = 10001;

        static void Main(string[] args)
        {
            var primes = new List<int>(TargetPrime)
            {
                2
            };
            int currentNumber = 3;
            while (primes.Count < TargetPrime)
            {
                var sqrt = (int)Math.Sqrt(currentNumber) + 1;
                bool isPrime = true;
                for (int i = 0; i < primes.Count && primes[i] <= sqrt; i++)
                {
                    if (currentNumber % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(currentNumber);
                }
                currentNumber += 2; //skipping even numbers
            }
            Console.WriteLine(primes.Last());
        }
    }
}

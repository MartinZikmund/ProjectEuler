using System;

namespace Problem10
{
    class Program
    {
        private const int MaxNum = 2000000;
        static void Main(string[] args)
        {
            var primeSum = 0UL;
            bool[] isPrime = new bool[MaxNum];
            Array.Fill(isPrime, true);
            isPrime[0] = false;
            isPrime[1] = false;
            for (uint i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    primeSum += i;
                    var multiple = i + i;
                    while (multiple < isPrime.Length)
                    {
                        isPrime[multiple] = false;
                        multiple += i;
                    }
                }
            }

            Console.WriteLine(primeSum);
        }
    }
}

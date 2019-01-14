using System;
using System.Numerics;

namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            var termIndex = 2;
            BigInteger previousNumber = 1, currentNumber = 1;
            while (currentNumber.ToString().Length < 1000)
            {
                var nextNumber = currentNumber + previousNumber;
                previousNumber = currentNumber;
                currentNumber = nextNumber;
                termIndex++;
            }

            Console.WriteLine(termIndex);
        }
    }
}

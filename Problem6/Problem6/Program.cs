using System;
using System.Linq;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            var hundred = Enumerable.Range(1, 100);
            var sumSquares = hundred.Sum(n => n * n);
            var sum = hundred.Sum();
            var squareSum = sum * sum;
            Console.WriteLine(squareSum - sumSquares);
        }
    }
}

using System;
using System.Linq;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enumerable.Range(1, 100).Aggregate((BigInteger)1, (bigInt, n) => bigInt * n).ToString()
                .Sum(c => c - '0'));
        }
    }
}

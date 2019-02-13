using System;
using System.Linq;
using System.Numerics;

namespace Problem56
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enumerable.Range(1, 99).SelectMany(a=> Enumerable.Range(1, 99).Select(b => new {a,b}))
                .Select(pair => BigInteger.Pow(new BigInteger(pair.a), pair.b))
                .Select(number => number.ToString().Select(digitChar => digitChar - '0').Sum()).Max());
        }
    }
}

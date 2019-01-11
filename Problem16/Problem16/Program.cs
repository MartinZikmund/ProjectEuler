using System;
using System.Linq;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((((BigInteger)1) << 1000).ToString().Select(c => (c - '0')).Sum());
        }
    }
}

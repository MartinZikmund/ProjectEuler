using System;
using System.Linq;
using System.Net.Sockets;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(100, 999 - 100 + 1);
            Console.WriteLine(
                (from a in range
                 from b in range
                 select a * b)
                    .Where(product => product.ToString().Reverse().SequenceEqual(product.ToString()))
                    .Max());
        }
    }
}

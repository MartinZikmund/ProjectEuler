using System;
using System.Linq;
using System.Net.Sockets;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((from a in Enumerable.Range(100, 999 - 100 + 1)
             from b in Enumerable.Range(100, 999 - 100 + 1)
             select a * b).Where(product => product.ToString().Reverse().SequenceEqual(product.ToString()))
                .Max());
        }
    }
}

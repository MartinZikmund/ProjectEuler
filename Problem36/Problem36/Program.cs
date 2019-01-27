using System;
using System.Linq;

namespace Problem36
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enumerable.Range(0, 1000000).Where(n =>
                Convert.ToString(n, 10).Reverse().SequenceEqual(Convert.ToString(n, 10)) &&
                Convert.ToString(n, 2).Reverse().SequenceEqual(Convert.ToString(n, 2))
            ).Sum());
        }
    }
}

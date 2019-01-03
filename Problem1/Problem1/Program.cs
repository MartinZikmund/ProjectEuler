using System;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enumerable.Range(1, 999).Where(i => i % 3 == 0 || i % 5 == 0).Sum());
        }
    }
}

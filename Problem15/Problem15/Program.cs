using System;
using System.Linq;
using System.Numerics;

namespace Problem15
{
    class Program
    {
        static void Main(string[] args)
        {
            long solution = 1;
            for (int i = 1; i <= 20; i++)
            {
                solution *= (20 + i);
                solution /= i;
            }
            Console.WriteLine(solution);
        }        
    }
}

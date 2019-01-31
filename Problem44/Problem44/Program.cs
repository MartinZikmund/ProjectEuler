using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem44
{
    class Program
    {
        private const int MaxN = 10000;

        private static readonly HashSet<int> PentagonalNumbersHash = new HashSet<int>();

        static void Main(string[] args)
        {
            GeneratePentagonal();
            var orderedPentagonals = PentagonalNumbersHash.OrderBy(n => n).ToArray();
            foreach (var difference in orderedPentagonals)
            {
                foreach (var firstNum in orderedPentagonals)
                {
                    var result = firstNum + difference;
                    if (PentagonalNumbersHash.Contains(result) &&
                        PentagonalNumbersHash.Contains(firstNum + result))
                    {
                        Console.WriteLine(difference);
                        return;
                    }
                }
            }
        }

        private static void GeneratePentagonal()
        {
            for (int n = 1; n <= MaxN; n++)
            {
                var number = n * (3 * n - 1) / 2;
                PentagonalNumbersHash.Add(number);
            }
        }
    }
}

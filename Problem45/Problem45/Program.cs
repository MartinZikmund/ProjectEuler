using System;
using System.Collections.Generic;

namespace Problem45
{
    class Program
    {
        private static HashSet<long> _pentagonalNumbers = new HashSet<long>();
        private static HashSet<long> _hexagonalNumbers = new HashSet<long>();
        private static long _lastGeneratedN = 0;

        static void Main(string[] args)
        {
            long n = 286;
            var currentTriangle = 0L;
            do
            {
                if (_lastGeneratedN < n / 2)
                {
                    GenerateHexagonals(_lastGeneratedN+1, n );
                    GeneratePentagonals(_lastGeneratedN + 1, n );
                    _lastGeneratedN = n;
                }
                currentTriangle = n * (n + 1) / 2;
                n++;
            } while (!_pentagonalNumbers.Contains(currentTriangle) || !_hexagonalNumbers.Contains(currentTriangle));
            Console.WriteLine(currentTriangle);
        }

        private static void GeneratePentagonals(long fromN, long toN)
        {
            for (;  fromN <= toN; fromN++)
            {
                _pentagonalNumbers.Add(fromN * (3 * fromN - 1) / 2);
            }
        }

        private static void GenerateHexagonals(long fromN, long toN)
        {
            for (; fromN <= toN; fromN++)
            {
                _hexagonalNumbers.Add(fromN * (2 * fromN - 1));
            }
        }
    }
}

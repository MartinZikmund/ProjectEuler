using System;
using System.Collections.Generic;

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solver().Solve();
        }
    }

    public class Solver
    {
        private const int MaxNumber = 1000000;
        private static Dictionary<long, long> _longestChains = new Dictionary<long, long>();

        public void Solve()
        {
            var maxLength = 0L;
            var bestNumber = 0;
            for (int i = 1; i <= MaxNumber; i++)
            {
                _longestChains[i] = CalculateChainLength(i);
                if (_longestChains[i] > maxLength)
                {
                    maxLength = _longestChains[i];
                    bestNumber = i;
                }
            }
            Console.WriteLine(bestNumber);
        }

        public static long CalculateChainLength(long i)
        {
            var chainLength = 1;
            while (i != 1)
            {
                if (_longestChains.TryGetValue(i, out var length))
                {
                    //reuse known value                    
                    return chainLength + length;
                }
                if (i % 2 == 0)
                {
                    i /= 2;
                }
                else
                {
                    i = i * 3 + 1;
                }
                chainLength++;
            }
            return chainLength;
        }
    }
}

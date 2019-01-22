using System;
using System.Collections.Generic;

namespace Problem37
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solver().Solve());
        }
    }

    public class Solver
    {
        private int _sum = 0;
        private int _foundCount = 0;

        private List<int> _discoveredPrimes = new List<int>();

        public int Solve()
        {
            int currentNumber = 2;
            while (_foundCount < 11)
            {
                if (IsPrime(currentNumber) && currentNumber > 10)
                {
                    bool isTruncatable = true;
                    var endCutting = CutEnd(currentNumber);
                    while (endCutting != 0 && isTruncatable)
                    {
                        if (!IsPrime(endCutting))
                        {
                            isTruncatable = false;
                        }
                        endCutting = CutEnd(endCutting);
                    }

                    var startCutting = CutStart(currentNumber);
                    while (startCutting != 0 && isTruncatable)
                    {                        
                        if (!IsPrime(startCutting))
                        {
                            isTruncatable = false;
                        }
                        startCutting = CutStart(startCutting);
                    }

                    if (isTruncatable)
                    {
                        _sum += currentNumber;
                        _foundCount++;
                    }
                }

                currentNumber++;
            }

            return _sum;
        }


        public int CutEnd(int number)
        {
            return number / 10;
        }

        public int CutStart(int number)
        {
            var remainder = number;
            var multiplier = 1;
            while (remainder > 9)
            {
                remainder /= 10;
                multiplier *= 10;
            }
            return number % multiplier;
        }

        public bool IsPrime(int number)
        {
            if (_discoveredPrimes.BinarySearch(number) >= 0) return true;
            if (number < 2) return false;
            var sqrt = (int)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            _discoveredPrimes.Add(number);
            return true;
        }
    }
}

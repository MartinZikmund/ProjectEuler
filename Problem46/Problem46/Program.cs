using System;
using System.Collections.Generic;

namespace Problem46
{
    class Program
    {
        private static List<long> _primes = new List<long>();
        private static HashSet<long> _doubleSquares = new HashSet<long>();
        private static long _maxGeneratedSquare = 0;

        static void Main(string[] args)
        {
            _primes.Add(2);
            for (int n = 3; ; n += 2)
            {
                if (IsPrime(n))
                {
                    _primes.Add(n);
                }
                else
                {
                    bool found = false;
                    for (int primeId = 0; primeId < _primes.Count && _primes[primeId] < n; primeId++)
                    {
                        var diff = n - _primes[primeId];
                        if (diff > _maxGeneratedSquare * _maxGeneratedSquare * 2 )
                        {
                            GenerateSquares(diff);
                        }

                        if (_doubleSquares.Contains(diff))
                        {                         
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine(n);
                        return;
                    }
                }
            }
        }

        private static void GenerateSquares(long target)
        {
            var current = _maxGeneratedSquare + 1;
            var doubleSquare = 0L;
            do
            {
                doubleSquare = current * current * 2;
                _doubleSquares.Add(doubleSquare);
                _maxGeneratedSquare = current;
                current++;
            } while (doubleSquare < target);
            
        }

        private static bool IsPrime(long number)
        {
            var sqrt = (long)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

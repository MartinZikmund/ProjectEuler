using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem32
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Problem32Solver().Solve());
            Console.ReadKey();
        }

    }

    public class Problem32Solver
    {
        private bool[] _firstDigits = new bool[10];
        private bool[] _secondDigits = new bool[10];
        private bool[] _thirdDigits = new bool[10];


        private readonly HashSet<long> _solutions = new HashSet<long>();

        private bool[] _usedDigits = new bool[10];

        public long Solve()
        {
            Array.Fill(_usedDigits, false);
            Permutate(string.Empty);
            return _solutions.Sum();
        }

        public void Permutate(string permutation)
        {
            if (permutation.Length == 9)
            {
                FindPermutationSolutions(permutation);
            }
            for (int i = 1; i <= 9; i++)
            {
                if (!_usedDigits[i])
                {
                    _usedDigits[i] = true;
                    Permutate(permutation + i);
                    _usedDigits[i] = false;
                }
            }
        }

        private void FindPermutationSolutions(string permutation)
        {
            for (var firstNumberLength = 1; firstNumberLength < 5; firstNumberLength++)
            {
                for (int secondNumberLength = 1; secondNumberLength < (9 - 2*firstNumberLength); secondNumberLength++)
                {
                    var num1 = int.Parse(permutation.Substring(0, firstNumberLength));
                    var num2 = int.Parse(permutation.Substring(firstNumberLength, secondNumberLength));
                    var product = int.Parse(permutation.Substring(firstNumberLength + secondNumberLength));
                    if ( num1 * num2 == product && !_solutions.Contains(product))
                    {
                        _solutions.Add(product);
                    }
                }
            }
        }
    }
}

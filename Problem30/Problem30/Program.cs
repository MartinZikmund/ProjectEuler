using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;

namespace Problem30
{
    class Program
    {
        private static readonly int[] _digitFifthPowers = Enumerable.Range(0, 10).Select(d => d * d * d * d * d).ToArray();

        private static List<int> _solutions = new List<int>();

        static void Main(string[] args)
        {
            CheckNumber(0,"");
            Console.WriteLine(_solutions.Aggregate(BigInteger.Zero, (bi, num) => bi + num));
        }

        private static void CheckNumber(int currentDigitSum, string currentNumber)
        {
            if (currentNumber.Length == 6)
            {
                if (currentDigitSum == int.Parse(currentNumber) && currentNumber.TrimStart('0').Length > 1)
                {
                    _solutions.Add(currentDigitSum);
                }
            }
            else
            {
                for (int i = 0; i < _digitFifthPowers.Length; i++)
                {
                    CheckNumber(currentDigitSum + _digitFifthPowers[i], currentNumber + i);
                }
            }
        }
    }
}

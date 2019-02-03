using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem49
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1000; i <= 9999; i++)
            {
                if (IsPrime(i))
                {
                    var currentPermutation = i;
                    while ((currentPermutation = GetNextPermutation(currentPermutation)) != -1)
                    {
                        if (IsPrime(currentPermutation))
                        {
                            var diff = currentPermutation - i;
                            var lastPerm = currentPermutation + diff;
                            if (IsPrime(lastPerm) && ArePermutations(lastPerm, currentPermutation))
                            {
                                Console.Write(i);
                                Console.Write(currentPermutation);
                                Console.WriteLine(lastPerm);
                            }
                        }
                    }
                }
            }
        }

        private static int GetNextPermutation(int number)
        {
            var numberString = number.ToString().ToCharArray();
            var breakPoint = -1;
            for (int i = numberString.Length - 1; i > 0; i--)
            {
                if (numberString[i - 1] < numberString[i])
                {
                    breakPoint = i - 1;
                    break;
                }
            }

            if (breakPoint == -1) return -1;
            
            int minHigher = breakPoint + 1;
            for (int j = breakPoint + 1; j < numberString.Length; j++)
            {
                if (numberString[j] > numberString[breakPoint] && numberString[j] < numberString[minHigher])
                {
                    minHigher = j;
                }
            }

            var swap = numberString[breakPoint];
            numberString[breakPoint] = numberString[minHigher];
            numberString[minHigher] = swap;

            var result = numberString.Take(breakPoint + 1).Concat(numberString.Skip(breakPoint + 1).Reverse());
            return int.Parse(string.Join("", result));
        }

        private static bool ArePermutations(int number, int otherNumber)
        {
            return number.ToString().OrderBy(c => c).SequenceEqual(otherNumber.ToString().OrderBy(c => c));
        }

        private static bool IsPrime(int number)
        {
            var sqrt = (int)Math.Sqrt(number);
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

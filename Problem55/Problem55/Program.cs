using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Problem55
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enumerable.Range(1, 9999).Count(IsLyrchel));
        }

        private static bool IsLyrchel(int number)
        {
            BigInteger input = new BigInteger(number);
            for (int i = 0; i < 50; i++)
            {
                input = Iterate(input);
                if (IsPalindromic(input))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsPalindromic(BigInteger number)
        {
            var strNumber = number.ToString();
            for (int i = 0; i <= strNumber.Length / 2; i++)
            {
                if (strNumber[i] != strNumber[strNumber.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        private static BigInteger Iterate(BigInteger input)
        {
            return input + Reverse(input);
        }

        private static BigInteger Reverse(BigInteger number)
        {
            return BigInteger.Parse(string.Join("", number.ToString().Reverse()));
        }
    }
}

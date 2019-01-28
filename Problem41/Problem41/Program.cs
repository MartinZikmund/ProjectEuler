using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Problem41
{
    class Program
    {
        private static char[] _allDigits = Enumerable.Range(1, 9).Select(digit => (char)('0' + digit)).ToArray();
        private static bool _found = false;
        static void Main(string[] args)
        {
            for (int length = 9; length > 0 && !_found; length--)
            {
                GenerateNumber(new StringBuilder(), new HashSet<char>(_allDigits.Take(length)));
            }
        }

        private static void GenerateNumber(StringBuilder builtNumber, HashSet<char> availableDigits)
        {
            if (availableDigits.Count == 0)
            {
                if (IsPrime(long.Parse(builtNumber.ToString())))
                {
                    _found = true;
                    Console.WriteLine(builtNumber.ToString());
                }
            }
            else if (!_found)
            {
                for (char digit = '9'; digit > '0' && !_found; digit--)
                {
                    if (availableDigits.Contains(digit))
                    {
                        availableDigits.Remove(digit);
                        builtNumber.Append(digit);
                        GenerateNumber(builtNumber, availableDigits);
                        builtNumber.Remove(builtNumber.Length - 1, 1);
                        availableDigits.Add(digit);
                    }
                }
            }
        }

        private static bool IsPrime(long number)
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

        private static bool IsPandigital(long number)
        {
            var numberString = number.ToString();
            var expectedDigits = _allDigits.Take(numberString.Length);
            return !expectedDigits.Except(numberString).Any();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem51
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int primeLength = 2; ; primeLength++)
            {
                var primes = GeneratePrimesOfLength(primeLength).Select(p => p.ToString()).ToArray();
                foreach (var positions in GetCombinations(primeLength).Select(i => Convert.ToString(i, 2).PadLeft(primeLength, '0')))
                {
                    var matches = new Dictionary<string, int>();
                    for (char digit = '0'; digit <= '9'; digit++)
                    {
                        var mask = positions
                            .Replace('0', '?')
                            .Replace('1', digit);
                        var extracted = primes.Where(p => MatchesMask(p, mask)).Select(p => ExtractMask(p, mask)).ToArray();                        
                        foreach (var extract in extracted)
                        {
                            if (matches.TryGetValue(extract, out int occurrences))
                            {
                                if (occurrences == 7)
                                {
                                    Console.WriteLine(extract);
                                    Console.WriteLine(mask);
                                    Console.WriteLine(sw.ElapsedMilliseconds);
                                    return;
                                }
                                matches[extract] = occurrences + 1;
                            }
                            else
                            {
                                matches[extract] = 1;
                            }
                        }
                    }
                }
            }
        }

        private static string ExtractMask(string number, string mask)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == '?')
                {
                    sb.Append(number[i]);
                }
            }
            return sb.ToString();
        }

        private static bool MatchesMask(string number, string mask)
        {
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] != '?' && number[i] != mask[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static IEnumerable<int> GetCombinations(int length)
        {
            for (int i = 1; i < (int)Math.Pow(2, length); i++)
            {
                yield return i;
            }
        }

        private static int[] GeneratePrimesOfLength(int primeLength)
        {
            List<int> primes = new List<int>();
            int minVal = (int)Math.Pow(10, primeLength - 1);
            int maxVal = (int)Math.Pow(10, primeLength);
            for (int i = minVal + 1; i < maxVal; i += 2)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
        }

        private static bool IsPrime(int number)
        {
            var sqrt = (int)Math.Sqrt(number);
            for (int divisor = 2; divisor <= sqrt; divisor++)
            {
                if (number % divisor == 0) return false;
            }
            return true;
        }
    }
}

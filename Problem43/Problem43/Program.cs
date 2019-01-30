using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace Problem43
{
    class Program
    {
        private static bool[] _usedDigits = new bool[10];
        private static string _allDigits = "0123456789";

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();   
                        sw.Start();
            BigInteger sum = new BigInteger(0);
            for (int end = 000; end <= 999; end += 17)
            {
                if (HasDigitConflict(end)) continue;
                AddUsedDigits(end);
                for (int middle = 000; middle <= 999; middle += 7)
                {
                    if (HasDigitConflict(middle)) continue;
                    AddUsedDigits(middle);
                    for (int start = 0; start <= 999; start += 2)
                    {
                        if (HasDigitConflict(start)) continue;
                        AddUsedDigits(start);

                        //check additional divisions  
                        var fullNumber = $"{start:D3}{middle:D3}{end:D3}";
                        var remainingDigit = _allDigits.Except(fullNumber).First();
                        fullNumber = remainingDigit + fullNumber;
                        RemoveUsedDigits(start);
                        if (int.Parse(fullNumber.Substring(2, 3)) % 3 != 0) continue;
                        if (int.Parse(fullNumber.Substring(3, 3)) % 5 != 0) continue;
                        if (int.Parse(fullNumber.Substring(5, 3)) % 11 != 0) continue;
                        if (int.Parse(fullNumber.Substring(6, 3)) % 13 != 0) continue;
                        sum += BigInteger.Parse(fullNumber);
                    }
                    RemoveUsedDigits(middle);
                }
                RemoveUsedDigits(end);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(sum.ToString());
        }

        private static void AddUsedDigits(int number)
        {
            for (int i = 0; i < 3; i++)
            {
                _usedDigits[GetDigitAt(number, i)] = true;
            }
        }

        private static void RemoveUsedDigits(int number)
        {
            for (int i = 0; i < 3; i++)
            {
                _usedDigits[GetDigitAt(number, i)] = false;
            }
        }

        private static bool HasDigitConflict(int number)
        {
            HashSet<int> numberDigits = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                var n = GetDigitAt(number, i);
                if (numberDigits.Contains(n) || _usedDigits[n])
                {
                    return true;
                }
                numberDigits.Add(n);
            }
            return false;
        }

        private static int GetDigitAt(int number, int position)
        {
            for (int i = 0; i < position; i++)
            {
                number /= 10;
            }
            return number % 10;
        }
    }
}

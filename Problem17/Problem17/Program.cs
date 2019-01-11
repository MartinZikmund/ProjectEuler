using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem17
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberToWordConverter = new NumberToWordConverter();
            Console.WriteLine(Enumerable.Range(1, 1000).Sum(n => numberToWordConverter.GetNumberLengthInWords(n)));
        }
    }

    public class NumberToWordConverter
    {
        public int GetNumberLengthInWords(int number)
        {
            var numberToWords = NumberToWords(number);
            return numberToWords.Count(char.IsLetter);
        }

        public static Dictionary<int, string> _specialCases = new Dictionary<int, string>()
        {
            {0,"zero" },
            {1,"one" },
            {2,"two" },
            {3,"three" },
            {4,"four" },
            {5,"five" },
            {6,"six" },
            {7,"seven" },
            {8,"eight" },
            {9,"nine" },
            {10,"ten" },
            {11,"eleven" },
            {12,"twelve" },
            {13,"thirteen" },
            {14,"fourteen" },
            {15,"fifteen" },
            {16,"sixteen" },
            {17,"seventeen" },
            {18,"eighteen" },
            {19,"nineteen" },
            {20, "twenty" },
            {30, "thirty" },
            {40, "forty" },
            {50, "fifty" },
            {60, "sixty" },
            {70, "seventy" },
            {80, "eighty" },
            {90, "ninety" },
            {100, "hundred" },
            {1000, "thousand" }
        };

        public string NumberToWords(int number)
        {
            if (number == 0) return _specialCases[0];
            var fullNumber = new StringBuilder();
            if (number == 1000)
            {
                return "one thousand";
            }

            if (number >= 100 && number <= 999)
            {
                var hundredCount = number / 100;
                fullNumber.Append(_specialCases[hundredCount]);
                fullNumber.Append(_specialCases[100]);
            }
            number %= 100;

            if (number == 0) return fullNumber.ToString();


            if (fullNumber.Length != 0)
            {
                fullNumber.Append(" and ");
            }

            var tens = number / 10;
            if (tens == 1)
            {
                fullNumber.Append(_specialCases[number]);
                return fullNumber.ToString();
            }

            if (tens != 0)
            {
                fullNumber.Append(_specialCases[tens * 10]);
            }

            number %= 10;

            if (number != 0)
            {
                fullNumber.Append(_specialCases[number]);
            }

            return fullNumber.ToString();
        }
    }
}

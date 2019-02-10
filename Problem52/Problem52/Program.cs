using System;
using System.Linq;

namespace Problem52
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1;; i++)
            {

                if (SameDigits(i, i * 2) && SameDigits(i, i * 3) &&
                    SameDigits(i, i * 4) && SameDigits(i, i * 5) &&
                    SameDigits(i, i * 6))
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }

        private static bool SameDigits(int number1, int number2)
        {
            return number1.ToString().OrderBy(c => c).SequenceEqual(number2.ToString().OrderBy(c => c));
        }
    }
}

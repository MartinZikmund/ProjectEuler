using System;
using System.Linq;
using System.Text;

namespace Problem38
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDigits = "123456789".ToCharArray();
            var maxResult = 0UL;
            for (long i = 1; i < 10000000; i++)
            {
                var current = long.Parse($"9{i}");
                var number = new StringBuilder();
                var ni = 1;
                while (number.Length < 9)
                {
                    number.Append(current * ni);
                    ni++;
                }

                if (number.Length > 9) continue;
                                
                if (!allDigits.Except(number.ToString()).Any())
                {
                    var currentNumber = ulong.Parse(number.ToString());
                    maxResult = Math.Max(maxResult, currentNumber);
                }
            }

            Console.WriteLine(maxResult);
        }
    }
}

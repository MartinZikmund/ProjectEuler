using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks.Sources;

namespace Problem29
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BruteForce(100));
        }

        private static int BruteForce(int limit)
        {
            List<BigInteger> allNumbers = new List<BigInteger>();
            for (int a = 2; a <= limit; a++)
            {
                for (int b = 2; b <= limit; b++)
                {
                    BigInteger num = new BigInteger(1);
                    for (int bi = 0; bi < b; bi++)
                    {
                        num *= a;
                    }

                    allNumbers.Add(num);
                }
            }

            return allNumbers.Distinct().Count();
        }        
    }
}

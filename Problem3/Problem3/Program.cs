using System;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 600851475143;
            var root = (long)Math.Sqrt(num) + 1;
            var maxDivisor = 0L;
            for (int i = 2; i <= root && i < num; i++)
            {
                while (num % i == 0)
                {
                    num /= i;
                    maxDivisor = i;
                }
            }

            if (num != 1)
            {
                maxDivisor = num;
            }
            Console.WriteLine(maxDivisor);
        }
    }
}

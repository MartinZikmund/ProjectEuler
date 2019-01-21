using System;

namespace Problem35
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(new Solver().Solve());
        }
    }

    public class Solver
    {
        private const int MaxN = 1000000;

        public int Solve()
        {
            var solutionCount = 0;
            for (int i = 2; i < MaxN; i++)
            {
                if (IsPrime(i))
                {
                    var canRotate = true;
                    var number = i;
                    while ((number = GetNextRotation(number)) != i)
                    {
                        if (!IsPrime(number))
                        {
                            canRotate = false;
                            break;
                        }
                    }

                    if (canRotate)
                    {
                        solutionCount++;
                    }
                }
            }
            return solutionCount;
        }

        public int GetNextRotation(int n)
        {
            var lastDigit = n % 10;
            int copy = n / 10;
            while (copy != 0)
            {
                copy /= 10;
                lastDigit *= 10;
            }
            lastDigit += n / 10;
            return lastDigit;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            var sqrt = (int)Math.Sqrt(n);
            for (int i = 2; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

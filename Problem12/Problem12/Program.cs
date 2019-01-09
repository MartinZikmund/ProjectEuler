using System;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem12();
            problem.Solve();
        }
    }

    public class Problem12
    {
        private const int RequiredDivisors = 500;

        public void Solve()
        {
            int number = 1;
            while (CalculateNumberOfDivisors(number * (number + 1) / 2) < RequiredDivisors)
            {
                number++;
            }

            Console.WriteLine(number * (number + 1) / 2);
        }

        public int CalculateNumberOfDivisors(int number)
        {
            var count = 0;
            var sqrt = (int)Math.Sqrt(number);
            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    count++;
                    if (number / i != i)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

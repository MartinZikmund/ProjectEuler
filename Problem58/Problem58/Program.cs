using System;

namespace Problem58
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeCount = 0;
            int currentLength = 1;
            do
            {
                currentLength += 2;
                var bottomRight = currentLength * currentLength;
                var bottomLeft = bottomRight - currentLength + 1;
                var topLeft = bottomLeft - currentLength + 1;
                var topRight = topLeft - currentLength + 1;
                if (IsPrime(bottomRight)) primeCount++;
                if (IsPrime(bottomLeft)) primeCount++;
                if (IsPrime(topLeft)) primeCount++;
                if (IsPrime(topRight)) primeCount++;
            } while ((currentLength / 2) * 4 + 1 <= 10 * primeCount);
            Console.WriteLine(currentLength);
        }

        private static bool IsPrime(int number)
        {
            var sqrt = (int)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}

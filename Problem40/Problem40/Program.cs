using System;

namespace Problem40
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = 1;
            for (int i = 1; i <= 1000000; i*=10)
            {
                position *= GetDigit(i);
            }
            Console.WriteLine(position);
        }

        private static int GetDigit(int n)
        {
            int position = 0;
            var currentBoundary = 10;
            var previousBoundary = 1;
            var digits = 1;
            var previousPosition = 0;
            while (true)
            {
                if ((currentBoundary - previousBoundary) * digits + previousPosition > n)
                {
                    //position falls in the current boundary
                    var locationOfBoundary = (n - 1) - previousPosition;
                    var targetNumber = previousBoundary + locationOfBoundary / digits;
                    return int.Parse(targetNumber.ToString()[locationOfBoundary % digits].ToString());
                }
                else
                {
                    previousPosition += (currentBoundary - previousBoundary) * digits;
                    digits++;
                    currentBoundary *= 10;
                    previousBoundary *= 10;
                }
            }
        }
    }
}

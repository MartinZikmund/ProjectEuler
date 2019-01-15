using System;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalSum = 0L;
            for (int i = 1; i <= 1001; i+=2)
            {
                totalSum += GetCornerSum(i);
            }

            Console.WriteLine(totalSum);
        }

        public static int GetCornerSum(int width)
        {
            if (width == 1) return 1;

            var topRight = width * width;

            var topLeft = (width - 1) * width + 1;

            var bottomLeft = (width - 2) * width + 2;

            var bottomRight = (width - 3) * width + 3;

            return topRight + topLeft + bottomLeft + bottomRight;
        }
    }
}

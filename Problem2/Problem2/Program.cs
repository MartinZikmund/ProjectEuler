using System;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lastFib = 1;
            var prelastFib = 1;
            int sum = 0;
            do
            {
                if (lastFib % 2 == 0)
                {
                    sum += lastFib;
                }
                var newFib = lastFib + prelastFib;
                prelastFib = lastFib;
                lastFib = newFib;                
            } while (lastFib < 4000000);
            Console.WriteLine(sum);
        }
    }
}

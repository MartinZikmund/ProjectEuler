using System;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentMcd = 1;
            for (int i = 2; i <= 20; i++)
            {
                var newMcd = currentMcd;
                while (newMcd % i != 0)
                {
                    newMcd += currentMcd;
                }
                currentMcd = newMcd;
            }

            Console.WriteLine(currentMcd);
        }
    }
}

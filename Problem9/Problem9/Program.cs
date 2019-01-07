using System;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int a = 1; a < 1000; a++)
            {
                for (int b = a + 1; b < 1000; b++)
                {
                    var c = 1000 - a - b;
                    if (b >= c) break; //no point trying higher values of b
                    if (a * a + b * b == c * c)
                    {
                        Console.WriteLine($"{a} * {b} * {c} = {a*b*c}");
                        return;
                    }
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem39
{
    class Program
    {
        private static Dictionary<int, int> _squares = new Dictionary<int, int>();
        private static Dictionary<int, int> _solutions = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                _squares.Add(i * i, i);
            }


            int maxSolutions = 0;
            int maxP = 0;
            for (int a = 1; a < 1000; a++)
            {
                for (int b = a; b <= 1000 - 2 * a; b++)
                {
                    //is right triangle
                    if (_squares.TryGetValue(a * a + b * b, out int c))
                    {
                        var p = a + b + c;
                        if ( b <= c && p <= 1000)
                        {
                            if (!_solutions.ContainsKey(p))
                            {
                                _solutions[p] = 0;
                            }
                            var newSolutions = _solutions[p]+1;
                            if (newSolutions > maxSolutions)
                            {
                                maxSolutions = newSolutions;
                                maxP = p;
                            }
                            _solutions[p] = newSolutions + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        var potentialC = 1000 - a + b;
                        if ( potentialC * potentialC < a*a + b*b)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(maxP);
        }
    }
}

using System;

namespace Problem31
{
    class Program
    {
        private static long _possibleSolutions = 0;

        private static int[] _coinTypes = new[]
        {
            1, 2, 5, 10, 20, 50, 100, 200
        };

        static void Main(string[] args)
        {
            FindSolutions(0, 0);
            Console.WriteLine(_possibleSolutions);
        }

        public static void FindSolutions(int currentValue, int lastUsed)
        {
            if (currentValue == 200)
            {
                _possibleSolutions++;
            }

            for (int i = 0; i < _coinTypes.Length; i++)
            {
                if (_coinTypes[i] > lastUsed)
                {
                    var nextValue = currentValue + _coinTypes[i];
                    while (nextValue <= 200)
                    {
                        FindSolutions(nextValue, _coinTypes[i]);
                        nextValue += _coinTypes[i];
                    }
                }
            }
        }
    }
}

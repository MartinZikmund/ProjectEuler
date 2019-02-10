using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Problem54
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = ReadInputStream("poker.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var handEvaluator = new CardEvaluator();
                    string line = null;
                    int firstPlayerWins = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var cards = line.Split(' ');
                        var firstPlayerHand = cards.Take(5).ToArray();
                        var secondPlayerHand = cards.Skip(5).ToArray();
                        if (handEvaluator.EvaluateWinner(firstPlayerHand, secondPlayerHand) == 1)
                        {
                            firstPlayerWins++;
                        }
                    }
                    Console.WriteLine(firstPlayerWins);
                }
            }
        }

        private static Stream ReadInputStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(typeof(Program).Namespace + "." + resourceName);
        }
    }
}

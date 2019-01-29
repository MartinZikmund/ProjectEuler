using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Problem42
{
    class Program
    {
        private static HashSet<int> _triangleNumbers = new HashSet<int>();

        static async Task Main(string[] args)
        {
            var wordsContents = await ReadResourceFile("words.txt");
            var words = wordsContents.Split(new[] { '\r', '\n', '\"', ',' }, StringSplitOptions.RemoveEmptyEntries);
            GenerateTriangleNumbers();
            Console.WriteLine(words.Count(w => _triangleNumbers.Contains(GetWordValue(w))));
        }

        private static void GenerateTriangleNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                _triangleNumbers.Add(i * (i + 1) / 2);
            }
        }

        private static int GetWordValue(string word)
        {
            int value = 0;
            foreach (var character in word)
            {
                value += (character - 'A') + 1;
            }
            return value;
        }

        private static async Task<string> ReadResourceFile(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream($"Problem42.{name}"))
            {
                using (var textStream = new StreamReader(stream))
                {
                    return await textStream.ReadToEndAsync();
                }
            }
        }
    }
}

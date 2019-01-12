using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Problem18
{
    class Program
    {
        private static int[,] bestSums;

        static async Task Main(string[] args)
        {
            var inputText = await ReadEmbeddedFile("Input67.txt");
            var lines = inputText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var lastRow = lines.Last().Split(' ');
            var maxWidth = lastRow.Length;
            bestSums = new int[lines.Length, maxWidth];
            bestSums[0, 0] = int.Parse(lines.First());
            var bestPath = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                var currentRow = lines[i].Split(' ');
                for (int x = 0; x < currentRow.Length; x++)
                {
                    var previousWidth = i;
                    bestSums[i, x] = Math.Max(x - 1 >= 0 ? bestSums[i - 1, x - 1] : 0,
                        x < previousWidth ? bestSums[i - 1, x] : 0) + int.Parse(currentRow[x]);
                }
            }

            for (int lastRowId = 0; lastRowId < maxWidth; lastRowId++)
            {
                bestPath = Math.Max(bestSums[lines.Length - 1, lastRowId], bestPath);
            }
            Console.WriteLine(bestPath);
        }

        private static async Task<string> ReadEmbeddedFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(typeof(Program), fileName))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }
    }
}

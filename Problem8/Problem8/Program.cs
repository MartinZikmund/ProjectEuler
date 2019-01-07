using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Problem8
{
    class Program
    {
        private const int WindowSize = 13;

        static async Task Main(string[] args)
        {
            var numberText = await ReadResourceTextAsync("Input.txt");
            var number = numberText.Where(char.IsDigit).Select(c => c - '0').ToArray();

            long bestProduct = number.Take(WindowSize).Aggregate(1L, (n1, n2) => n1 * n2);
            var currentProduct = bestProduct;
            for (int i = WindowSize; i < number.Length; i++)
            {
                //remove the i-13th digit from the product
                var toRemove = number[i - WindowSize];
                if (toRemove != 0)
                {
                    currentProduct /= toRemove;
                }
                else
                {
                    //aggregate again
                    currentProduct = number.Skip(i - WindowSize + 1).Take(WindowSize - 1).Aggregate(1L, (n1, n2) => n1 * n2);
                }

                var toAdd = number[i];
                currentProduct *= toAdd;

                bestProduct = Math.Max(bestProduct, currentProduct);
            }

            Console.WriteLine(bestProduct);
        }

        private static async Task<string> ReadResourceTextAsync(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Problem8.{fileName}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

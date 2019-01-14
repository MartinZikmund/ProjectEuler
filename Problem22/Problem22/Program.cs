using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Problem22
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sum = 0UL;
            var namesText = await ReadEmbeddedFile("names.txt");
            var names = namesText.Split(',').Select(name => name.Substring(1, name.Length - 2)).OrderBy(name => name).ToArray();
            for (int i = 0; i < names.Length; i++)
            {
                sum += (uint)((i + 1) * names[i].Sum(c => c - 'A' + 1));
            }

            Console.WriteLine(sum);
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

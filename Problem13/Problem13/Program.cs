using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;

namespace Problem13
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = await ReadInputAsync("Input.txt");
            var lines = input.Split(Environment.NewLine);
            BigInteger sum = 0;
            foreach (var line in lines)
            {
                var number = BigInteger.Parse(line.Trim());
                sum += number;
            }

            Console.WriteLine(sum.ToString().Substring(0, 10));
        }

        public static async Task<string> ReadInputAsync(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(typeof(Program).Namespace + "." + file))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }
    }
}

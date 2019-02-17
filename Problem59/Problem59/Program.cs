using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem59
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = (await ReadInput("cipher.txt")).Split(',', StringSplitOptions.RemoveEmptyEntries);
            string key = "";
            for (int i = 0; i < 3; i++)
            {
                var possibleCharacters = Enumerable.Range((int)'a', 'z' - 'a' + 1).Select(c => (char)c).ToList();
                var bestEFrequency = 0;
                var bestCharacter = 'a';
                for (int possibleCharId = possibleCharacters.Count - 1; possibleCharId >= 0; possibleCharId--)
                {
                    var currentTFrequency = 0;
                    for (int pos = i; pos < input.Length; pos += 3)
                    {
                        var xoredChar = int.Parse(input[pos]);

                        var originalChar = xoredChar ^ (int)possibleCharacters[possibleCharId];
                        if (originalChar == 'e' || originalChar == 'E')
                        {
                            currentTFrequency++;
                        }
                    }
                    if (currentTFrequency > bestEFrequency)
                    {
                        bestEFrequency = currentTFrequency;
                        bestCharacter = possibleCharacters[possibleCharId];
                    }
                }

                key += bestCharacter;
                Console.WriteLine(bestCharacter);
            }

            var decrypted = Decrypt(input, key);
            Console.WriteLine(decrypted.Sum(c=>c));
        }

        public static string Decrypt(string[] input, string key)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                builder.Append((char)(int.Parse(input[i]) ^ key[i % 3]));
            }
            return builder.ToString();
        }

        public static async Task<string> ReadInput(string fileName)
        {
            using (StreamReader reader =
                new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Problem59." + fileName)))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Problem11
{
    public class Program
    {
        private static readonly (int x, int y)[] Directions = new (int x, int y)[]
        {
            (0,1),
            (1,0),
            (1,1),
            (0,-1),
            (-1,0),
            (-1,-1),
            (-1,1),
            (1,-1)
        };

        public static int[,] _grid;

        public static async Task Main(string[] args)
        {
            var fileText = await ReadEmbeddedFile("Input.txt");
            var lines = fileText.Split(Environment.NewLine);
            var height = lines.Length;
            var width = lines[0].Trim().Split(' ').Length;
            _grid = new int[height, width];
            for (int y = 0; y < height; y++)
            {
                var line = lines[y].Trim().Split(' ');
                for (int x = 0; x < width; x++)
                {
                    _grid[y, x] = int.Parse(line[x]);
                }
            }

            var bestProduct = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //try all directions
                    foreach (var direction in Directions)
                    {
                        int i = 0;
                        int currentProduct = 1;
                        var currentPosition = (x: x, y: y);
                        for (; i < 4; i++)
                        {
                            if (currentPosition.x <= 0 || currentPosition.x >= width || currentPosition.y <= 0 ||
                                currentPosition.y >= height)
                            {
                                break;
                            }
                            currentProduct *= _grid[currentPosition.x, currentPosition.y];
                            currentPosition.x += direction.x;
                            currentPosition.y += direction.y;
                        }
                        //did all numbers fit
                        if (i == 4)
                        {
                            bestProduct = Math.Max(bestProduct, currentProduct);
                        }
                    }
                }
            }

            Console.WriteLine(bestProduct);
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

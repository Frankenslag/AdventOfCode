using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day11
    {
        private static int[][] Direction = { new int[]{0, 1}, new int[] { 1, 1}, new int[] { 1, 0}, new int[] { 1, -1}, new int[] { 0, -1}, new int[] { -1, -1}, new int[] { -1, 0}, new int[] { -1, 1 } };

        private static readonly string[] xdata =
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        };

        private static readonly string[] data =
        {
            "3172537688",
            "4566483125",
            "6374512653",
            "8321148885",
            "4342747758",
            "1362188582",
            "7582213132",
            "6887875268",
            "7635112787",
            "7242787273"
        };
        
        private static void Process(Action<int, int> proc)
        {
            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    proc(x, y);
                }
            }
        }

        public static void Run()
        {
            int[,] energyLevels = new int[data[0].Length, data.Length];

            void TryFlash(int x, int y)
            {
                if (energyLevels[x, y] > 9)
                {
                    energyLevels[x, y] = -1;

                    foreach (int[] d in Direction)
                    {
                        int nx = x + d[0];
                        int ny = y + d[1];

                        if (nx >= 0 && ny >= 0 && nx < data[0].Length && ny < data.Length)
                        {
                            if (energyLevels[nx, ny] >= 0)
                            {
                                energyLevels[nx, ny]++;
                                TryFlash(nx, ny);
                            }
                        }
                    }

                }
            }

            for (int y = 0; y < data.Length; y++)
            {
                int[] row = data[y].ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
                for (int x = 0; x < data[y].Length; x++)
                {
                    energyLevels[x, y] = row[x];
                }
            }

            int step = 0;
            int flashes = 0;
            int stepFlashes = 0;

            do
            {
                stepFlashes = 0;

                Process((x, y) => energyLevels[x, y]++);

                Process((x, y) => TryFlash(x, y));

                Process((x, y) => stepFlashes += energyLevels[x, y] == -1 ? 1 : 0);

                Process((x, y) => energyLevels[x, y] = Math.Max(energyLevels[x, y], 0));

                flashes += stepFlashes;

                step++;

                if (step == 100)
                {
                    Console.WriteLine($"Day 11 Part 1 Answer is {flashes} Flashes.");
                }

            } while (stepFlashes != data[0].Length * data.Length);

            Console.WriteLine($"Day 11 Part 2 Answer is {step} Steps.");
        }
    }
}

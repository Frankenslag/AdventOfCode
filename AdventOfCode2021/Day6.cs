using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day6
    {
        private static int[] data =
        {
            2, 5, 2, 3, 5, 3, 5, 5, 4, 2, 1, 5, 5, 5, 5, 1, 2, 5, 1, 1, 1, 1, 1, 5, 5, 1, 5, 4, 3, 3, 1, 2, 4, 2, 4, 5,
            4, 5, 5, 5, 4, 4, 1, 3, 5, 1, 2, 2, 4, 2, 1, 1, 2, 1, 1, 4, 2, 1, 2, 1, 2, 1, 3, 3, 3, 5, 1, 1, 1, 3, 4, 4,
            1, 3, 1, 5, 5, 1, 5, 3, 1, 5, 2, 2, 2, 2, 1, 1, 1, 1, 3, 3, 3, 1, 4, 3, 5, 3, 5, 5, 1, 4, 4, 2, 5, 1, 5, 5,
            4, 5, 5, 1, 5, 4, 4, 1, 3, 4, 1, 2, 3, 2, 5, 1, 3, 1, 5, 5, 2, 2, 2, 1, 3, 3, 1, 1, 1, 4, 2, 5, 1, 2, 4, 4,
            2, 5, 1, 1, 3, 5, 4, 2, 1, 2, 5, 4, 1, 5, 5, 2, 4, 3, 5, 2, 4, 1, 4, 3, 5, 5, 3, 1, 5, 1, 3, 5, 1, 1, 1, 4,
            2, 4, 4, 1, 1, 1, 1, 1, 3, 4, 5, 2, 3, 4, 5, 1, 4, 1, 2, 3, 4, 2, 1, 4, 4, 2, 1, 5, 3, 4, 1, 1, 2, 2, 1, 5,
            5, 2, 5, 1, 4, 4, 2, 1, 3, 1, 5, 5, 1, 4, 2, 2, 1, 1, 1, 5, 1, 3, 4, 1, 3, 3, 5, 3, 5, 5, 3, 1, 4, 4, 1, 1,
            1, 3, 3, 2, 3, 1, 1, 1, 5, 4, 2, 5, 3, 5, 4, 4, 5, 2, 3, 2, 5, 2, 1, 1, 1, 2, 1, 5, 3, 5, 1, 4, 1, 2, 1, 5,
            3, 5, 2, 1, 3, 1, 2, 4, 5, 3, 4, 3
        };

        public static void Run()
        {
            long[] fish = new long[9];

            foreach (int stage in data)
            {
                fish[stage]++;
            }

            for (int day = 1; day <= 256; day++)
            {
                long newFish = fish[0];

                for (int i = 0; i < 8; i++)
                {
                    fish[i] = fish[i + 1];
                }

                fish[6] += newFish;
                fish[8] = newFish;

                if (day == 80 || day == 256)
                {
                    Console.WriteLine($"Day 6 Part {(day == 80 ? 1 : 2)} Answer is {fish.Sum()} Fish.");
                }
            }

        }
    }
}

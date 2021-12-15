using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2015
{
    internal class Day17
    {
        private static int[] data = {11, 30, 47, 31, 32, 36, 3, 1, 5, 3, 32, 36, 15, 11, 46, 26, 28, 1, 19, 3};

        public static void Run()
        {
            int cnt150 = 0;

            Dictionary<int, int> distribution = new Dictionary<int, int>();

            for (int i = 0; i < 1 << data.Length; i++)
            {
                int sum = 0;
                int numContainers = 0;


                for (int j = 0; j <= data.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        sum +=  data[j];
                        numContainers++;
                    }
                }

                if (sum == 150)
                {
                    cnt150++;

                    if (distribution.ContainsKey(numContainers))
                    {
                        distribution[numContainers]++;
                    }
                    else
                    {
                        distribution[numContainers] = 1;
                    }
                }
            }

            Console.WriteLine($"Day 17 Part 1 Answer is {cnt150} Combinations.");
            Console.WriteLine($"Day 17 Part 2 Answer is {distribution[distribution.Keys.Min()]} Combinations.");
        }
    }
}

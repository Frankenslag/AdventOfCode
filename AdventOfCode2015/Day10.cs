using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day10
    {
        private static string LookNSay(string str)
        {
            int[] data = str.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
            StringBuilder retval = new StringBuilder();
            int cnt = 0; 
            int last = data[0];
            for (int i = 0; i <= data.Length; i++)
            {
                if (i == data.Length || data[i] != last)
                {
                    retval.Append($"{cnt}{data[i - 1]}");
                    cnt = 1;
                    last = i == data.Length ? -1 : data[i];
                }
                else
                {
                    cnt++;
                }
            }

            return retval.ToString();
        }

        public static void Run()
        {
            string answer = "1113122113";

            for (int i = 0; i < 40; i++)
            {
                answer = LookNSay(answer);
            }

            Console.WriteLine($"Day 10 Part 1 Answer is {answer.Length}.");

            for (int i = 0; i < 10; i++)
            {
                answer = LookNSay(answer);
            }

            Console.WriteLine($"Day 10 Part 2 Answer is {answer.Length}.");
        }
    }
}

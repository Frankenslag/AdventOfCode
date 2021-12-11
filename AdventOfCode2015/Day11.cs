using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day11
    {
        private static bool TestPassword(string pwd)
        {
            bool retval = false;

            for (int i = 2; i < pwd.Length; i++)
            {
                if (pwd[i - 2] - pwd[i - 1] == -1 && pwd[i - 1] - pwd[i] == -1)
                {
                    retval = true;
                    break;
                }
            }

            retval = retval && !pwd.Any(c => c == 'i' || c == 'o' || c == 'l');

            retval = retval && new Regex(@"(.)\1").Matches(pwd).Distinct().Count() >= 2;
           

            return retval;
        }
        public static void Run()
        {
            char[] aryPwd = "cqjxjnds".ToCharArray();

            for (int pass = 0; pass < 2; pass++)
            {
                do
                {
                    for (int i = aryPwd.Length - 1; i >= 0; i--)
                    {
                        aryPwd[i]++;
                        if (aryPwd[i] > 'z')
                        {
                            aryPwd[i] = 'a';
                        }
                        else
                        {
                            break;
                        }
                    }
                } while (!TestPassword(aryPwd.Select(c => c.ToString()).Aggregate((p, n) => p + n)));
                Console.WriteLine($"Day 11 Part {pass + 1} Answer is Password {aryPwd.Select(c => c.ToString()).Aggregate((p, n) => p + n)}.");
            }
        }
    }
}

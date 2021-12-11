using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day4
    {
        public static void Run()
        {
            foreach (byte mask in new[] {0xF0, 0xFF})
            {
                long n = 0;

                using (MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] hashBytes;
                    do
                    {
                        hashBytes = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes($"yzbqklnj{n++}"));
                    } while (hashBytes[0] != 0 || hashBytes[1] != 0 || (hashBytes[2] & mask) != 0);
                }

                Console.WriteLine($"Day 4 Part {(mask == 0xF0 ? 1 : 2)} Answer is {n - 1}.");
            }
        }
    }
}

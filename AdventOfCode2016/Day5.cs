
using System.Runtime.InteropServices.JavaScript;

namespace AdventOfCode2016
{
    internal class Day5
    {
        public static void Run()
        {
            long index = 0;

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hashBytes;


                for (int part = 0; part < 2; part++)
                {
                    int i = 0;
                    index = 0;

                    byte[] result = [0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF];

                    while (result.Any(b => b == 0xFF))
                    {
                        do
                        {
                            hashBytes = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes($"wtnhxymk{index++}"));
                        } while ((hashBytes[0] != 0x00 || hashBytes[1] != 0x00 || (hashBytes[2] & 0xF0) != 0));

                        if (part == 0)
                        {
                            result[i] = (byte)(hashBytes[2] & 0x0F);
                        }
                        else
                        {
                            if ((hashBytes[2] & 0x0f) < 8 && result[hashBytes[2] & 0x0f] == 0xFF)
                            {
                                result[hashBytes[2] & 0x0f] = (byte)((hashBytes[3] & 0xf0) >> 4);
                            }
                        }

                        i++;
                    }

                    Console.WriteLine($"Day 5 Part {part + 1} Code is {result.Aggregate(string.Empty, (c, n) => c + $"{n:x}")}.");
                }

            }
        }
    }
}

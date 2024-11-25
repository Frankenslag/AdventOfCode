
using System.Text.RegularExpressions;

namespace AdventOfCode2016
{
    internal class Day8
    {
        private static readonly string[] Data =
        [
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 5",
            "rect 1x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rect 2x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rect 2x1",
            "rotate row y=0 by 2",
            "rect 1x1",
            "rotate row y=0 by 3",
            "rect 2x1",
            "rotate row y=0 by 5",
            "rect 4x1",
            "rotate row y=0 by 5",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=0 by 10",
            "rotate column x=5 by 2",
            "rotate column x=0 by 1",
            "rect 9x1",
            "rotate row y=2 by 5",
            "rotate row y=0 by 5",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=2 by 5",
            "rotate row y=0 by 5",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate column x=40 by 1",
            "rotate column x=27 by 1",
            "rotate column x=22 by 1",
            "rotate column x=17 by 1",
            "rotate column x=12 by 1",
            "rotate column x=7 by 1",
            "rotate column x=2 by 1",
            "rotate row y=2 by 5",
            "rotate row y=1 by 3",
            "rotate row y=0 by 5",
            "rect 1x3",
            "rotate row y=2 by 10",
            "rotate row y=1 by 7",
            "rotate row y=0 by 2",
            "rotate column x=3 by 2",
            "rotate column x=2 by 1",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=2 by 5",
            "rotate row y=1 by 3",
            "rotate row y=0 by 3",
            "rect 1x3",
            "rotate column x=45 by 1",
            "rotate row y=2 by 7",
            "rotate row y=1 by 10",
            "rotate row y=0 by 2",
            "rotate column x=3 by 1",
            "rotate column x=2 by 2",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=2 by 13",
            "rotate row y=0 by 5",
            "rotate column x=3 by 1",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=3 by 10",
            "rotate row y=2 by 10",
            "rotate row y=0 by 5",
            "rotate column x=3 by 1",
            "rotate column x=2 by 1",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=3 by 8",
            "rotate row y=0 by 5",
            "rotate column x=3 by 1",
            "rotate column x=2 by 1",
            "rotate column x=0 by 1",
            "rect 4x1",
            "rotate row y=3 by 17",
            "rotate row y=2 by 20",
            "rotate row y=0 by 15",
            "rotate column x=13 by 1",
            "rotate column x=12 by 3",
            "rotate column x=10 by 1",
            "rotate column x=8 by 1",
            "rotate column x=7 by 2",
            "rotate column x=6 by 1",
            "rotate column x=5 by 1",
            "rotate column x=3 by 1",
            "rotate column x=2 by 2",
            "rotate column x=0 by 1",
            "rect 14x1",
            "rotate row y=1 by 47",
            "rotate column x=9 by 1",
            "rotate column x=4 by 1",
            "rotate row y=3 by 3",
            "rotate row y=2 by 10",
            "rotate row y=1 by 8",
            "rotate row y=0 by 5",
            "rotate column x=2 by 2",
            "rotate column x=0 by 2",
            "rect 3x2",
            "rotate row y=3 by 12",
            "rotate row y=2 by 10",
            "rotate row y=0 by 10",
            "rotate column x=8 by 1",
            "rotate column x=7 by 3",
            "rotate column x=5 by 1",
            "rotate column x=3 by 1",
            "rotate column x=2 by 1",
            "rotate column x=1 by 1",
            "rotate column x=0 by 1",
            "rect 9x1",
            "rotate row y=0 by 20",
            "rotate column x=46 by 1",
            "rotate row y=4 by 17",
            "rotate row y=3 by 10",
            "rotate row y=2 by 10",
            "rotate row y=1 by 5",
            "rotate column x=8 by 1",
            "rotate column x=7 by 1",
            "rotate column x=6 by 1",
            "rotate column x=5 by 1",
            "rotate column x=3 by 1",
            "rotate column x=2 by 2",
            "rotate column x=1 by 1",
            "rotate column x=0 by 1",
            "rect 9x1",
            "rotate column x=32 by 4",
            "rotate row y=4 by 33",
            "rotate row y=3 by 5",
            "rotate row y=2 by 15",
            "rotate row y=0 by 15",
            "rotate column x=13 by 1",
            "rotate column x=12 by 3",
            "rotate column x=10 by 1",
            "rotate column x=8 by 1",
            "rotate column x=7 by 2",
            "rotate column x=6 by 1",
            "rotate column x=5 by 1",
            "rotate column x=3 by 1",
            "rotate column x=2 by 1",
            "rotate column x=1 by 1",
            "rotate column x=0 by 1",
            "rect 14x1",
            "rotate column x=39 by 3",
            "rotate column x=35 by 4",
            "rotate column x=20 by 4",
            "rotate column x=19 by 3",
            "rotate column x=10 by 4",
            "rotate column x=9 by 3",
            "rotate column x=8 by 3",
            "rotate column x=5 by 4",
            "rotate column x=4 by 3",
            "rotate row y=5 by 5",
            "rotate row y=4 by 5",
            "rotate row y=3 by 33",
            "rotate row y=1 by 30",
            "rotate column x=48 by 1",
            "rotate column x=47 by 5",
            "rotate column x=46 by 5",
            "rotate column x=45 by 1",
            "rotate column x=43 by 1",
            "rotate column x=38 by 3",
            "rotate column x=37 by 3",
            "rotate column x=36 by 5",
            "rotate column x=35 by 1",
            "rotate column x=33 by 1",
            "rotate column x=32 by 5",
            "rotate column x=31 by 5",
            "rotate column x=30 by 1",
            "rotate column x=23 by 4",
            "rotate column x=22 by 3",
            "rotate column x=21 by 3",
            "rotate column x=20 by 1",
            "rotate column x=12 by 2",
            "rotate column x=11 by 2",
            "rotate column x=3 by 5",
            "rotate column x=2 by 5",
            "rotate column x=1 by 3",
            "rotate column x=0 by 4"
        ];

        private static readonly string[] Instructions=
        [
            "rect (?<A>[0-9]*)x(?<B>[0-9]*)",
            "rotate row y=(?<A>[0-9]*) by (?<B>[0-9]*)",
            "rotate column x=(?<A>[0-9]*) by (?<B>[0-9]*)"
        ];

        public static void Run()
        {
            const int screenWidth = 50;
            const int screenHeight = 6;
                                    
            byte[,] screen = new byte[screenWidth + 1, screenHeight + 1];

            foreach (string line in Data)
            {
                int i;
                bool processed = false;

                for(i = 0; !processed && i < Instructions.Length; i++)
                {
                    Match mx = Regex.Match(line, Instructions[i]);
                    if (mx.Success)
                    {
                        int varA = int.Parse(mx.Groups["A"].Value);
                        int varB = int.Parse(mx.Groups["B"].Value);

                        switch (i)
                        {
                            case 0:
                                for (int y = 0; y < varB; y++)
                                {
                                    for (int x = 0; x < varA; x++)
                                    {
                                        screen[x, y] = 1;
                                    }
                                }
                                processed = true;
                                break;

                            case 1:
                                for (int x = 0; x < screenWidth; x++)
                                {
                                    screen[x, screenHeight] = screen[x, varA];
                                }
                                for (int x = 0; x < screenWidth; x++)
                                {
                                    screen[(x + varB) % screenWidth, varA] = screen[x, screenHeight];
                                }
                                processed = true;
                                break;

                            case 2:
                                for (int y = 0; y < screenHeight; y++)
                                {
                                    screen[screenWidth, y] = screen[varA, y];
                                }
                                for (int y = 0; y < screenHeight; y++)
                                {
                                    screen[varA, (y + varB) % screenHeight] = screen[screenWidth, y];
                                }
                                processed = true;
                                break;

                            default:
                                throw new Exception("Invalid Instruction");
                        }
                    }
                }

                if (!processed & i >= Instructions.Length)
                {
                    throw new Exception("Invalid Instruction");
                }
            }

            int cntPixel = 0;

            Console.WriteLine("Day 8 Part 2 Answer:");

            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    Console.Write($"{(screen[x, y] == 0 ? " " : "1")}");

                    if (screen[x, y] != 0)
                    {
                        cntPixel++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            Console.WriteLine($"Day 8 Part 1 Answer is {cntPixel} pixels.");
        }
    }
}

using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2016
{
    internal class Day1
    {
        private static readonly string[] Data =
        [
            "L3", "R2", "L5", "R1", "L1", "L2", "L2", "R1", "R5", "R1", "L1", "L2", "R2", "R4", "L4", "L3", "L3", "R5", "L1", "R3", "L5", "L2", "R4", "L5", "R4", "R2", "L2", "L1", "R1", "L3", "L3", "R2", "R1", "L4", "L1", "L1", "R4", "R5", "R1", "L2", "L1", "R188", "R4", "L3", "R54", "L4", "R4", "R74", "R2", "L4", "R185", "R1", "R3", "R5", "L2", "L3", "R1", "L1", "L3", "R3", "R2", "L3", "L4", "R1", "L3", "L5", "L2", "R2", "L1", "R2", "R1", "L4", "R5", "R4", "L5", "L5", "L4", "R5", "R4", "L5", "L3", "R4", "R1", "L5", "L4", "L3", "R5", "L5", "L2", "L4", "R4", "R4", "R2", "L1", "L3", "L2", "R5", "R4", "L5", "R1", "R2", "R5", "L2", "R4", "R5", "L2", "L3", "R3", "L4", "R3", "L2", "R1", "R4", "L5", "R1", "L5", "L3", "R4", "L2", "L2", "L5", "L5", "R5", "R2", "L5", "R1", "L3", "L2", "L2", "R3", "L3", "L4", "R2", "R3", "L1", "R2", "L5", "L3", "R4", "L4", "R4", "R3", "L3", "R1", "L3", "R5", "L5", "R1", "R5", "R3", "L1"
        ];

        private record BlockLocation(int XLocOff, int YLocOff)
        {
            public int XLocOff { get; set; } = XLocOff;
            public int YLocOff { get; set; } = YLocOff;
        }

        private static readonly BlockLocation[] Directions = [new(0, 1), new(1, 0), new(0, -1), new(-1, 0)];

        public static void Run()
        {
            int direction = 0;
            HashSet <BlockLocation> locations = [new(0, 0)];

            Regex rx = new(@"([RL])(\d+)");

            for (int run = 0; run < 2; run++)
            {
                BlockLocation blockLocation = new(0, 0);

                foreach (string line in Data)
                {
                    Match mx = rx.Match(line);

                    if (mx.Success)
                    {
                        direction = (direction + (mx.Groups[1].Value == "R" ? 1 : -1) + 4) % 4;

                        for (int step = 0; step < int.Parse(mx.Groups[2].Value); step++)
                        {
                            blockLocation.XLocOff += Directions[direction].XLocOff;
                            blockLocation.YLocOff += Directions[direction].YLocOff;

                            if (run == 1)
                            {
                                if (!locations.Add(blockLocation))
                                {
                                    goto loopEnd;
                                }
                            }
                        }

                    }
                    else
                        break;
                }

                loopEnd:;

                Console.WriteLine($"Day 1 Part {run} Answer is {int.Abs(blockLocation.XLocOff) + int.Abs(blockLocation.YLocOff)}.");
            }

        }
    }
}

namespace AdventOfCode2015
{
    internal class Day20
    {
        private const int Presents = 36000000;

        private static void Execute()
        {
            int[][] houses = new int[2][];
            houses[0] = new int[Presents / 10];
            houses[1] = new int[Presents / 10];

            for (int elf = 1; elf < Presents; elf++)
            {
                for (int house = elf, cnt = 0; house < houses[0].Length - 1; house += elf, cnt++)
                {
                    houses[0][house - 1] += elf * 10;

                    if (cnt < 50)
                    {
                        houses[1][house - 1] += elf * 11;
                    }
                }
            }

            Console.WriteLine($"Day 20 Part 1 Answer is House {houses[0].Select((v, idx) => (v, idx)).First(v => v.v >= Presents).idx + 1}.");
            Console.WriteLine($"Day 20 Part 2 Answer is House {houses[1].Select((v, idx) => (v, idx)).First(v => v.v >= Presents).idx + 1}.");
        }

        public static void Run() => Execute();
    }
}

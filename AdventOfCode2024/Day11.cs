
namespace AdventOfCode2024
{
    internal class Day11
    {
        private const string Data = "5178527 8525 22 376299 3 69312 0 275";

        private static readonly Dictionary<(long stone, int depth), long> Cache = new();

        private static long CountStones(long stone, int depth)
        {
            if (!Cache.TryGetValue((stone, depth), out long retval))
            {
                if (depth == 0)
                {
                    retval = 1;
                }
                else
                {
                    if (stone == 0)
                    {
                        retval = CountStones(1, depth - 1);
                    }
                    else if (stone.ToString().Length % 2 == 0)
                    {
                        string sVal = stone.ToString();
                        retval = CountStones(Convert.ToInt64(sVal[..(sVal.Length / 2)]), depth - 1) +
                                 CountStones(Convert.ToInt64(sVal[(sVal.Length / 2)..]), depth - 1);
                    }
                    else
                    {
                        retval = CountStones(stone * 2024, depth - 1);
                    }
                }

                Cache.Add((stone, depth), retval);
            }

            return retval;
        }

        private static void Execute(string inputdata)
        {
            long[] stones = inputdata.Split(' ', StringSplitOptions.TrimEntries).Select(s => Convert.ToInt64(s)).ToArray();

            Console.WriteLine($"Day 11 Part 1 Answer is  {stones.Sum(s => CountStones(s, 25))} stones.");
            Console.WriteLine($"Day 11 Part 2 Answer is  {stones.Sum(s => CountStones(s, 75))} stones.");
        }

        public static void Run() => Execute(Data);
    }
}
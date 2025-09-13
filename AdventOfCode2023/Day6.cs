
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal class Day6
    {
        private static readonly string[] DataProd =
        [
            "Time:        35     93     73     66",
            "Distance:   212   2060   1201   1044"
        ];

        public static void Run()
        {
            string[] data = DataProd;

            for (int part = 0; part < 2; part++)
            {
                List<(long duration, long target)> races = [];

                if (part == 0)
                {
                    races = Regex.Matches(data[0], @"(\d+)").Select(m => long.Parse(m.Value)).Zip(Regex.Matches(data[1], @"(\d+)").Select(m => long.Parse(m.Value))).ToList();
                }
                else
                {
                    races.Add((long.Parse(Regex.Matches(data[0], @"(\d+)").Aggregate(string.Empty, (curr, next) => curr + next)), long.Parse(Regex.Matches(data[1], @"(\d+)").Aggregate(string.Empty, (curr, next) => curr + next))));
                }

                Console.WriteLine($"Day 6 Part {part + 1} Answer is {races.Select(race =>
                {
                    double centre = Math.Sqrt(Math.Pow(race.duration, 2) - 4 * race.target);

                    double bottomVal = (-race.duration + centre) / -2;
                    double topValue = (-race.duration - centre) / -2;

                    return Math.Floor(topValue) - Math.Ceiling(bottomVal) - (bottomVal % 1 == 0 ? 1 : 0) - (topValue % 1 == 0 ? 1 : 0) + 1;
                }).Aggregate(1, (curr, next) => curr * (int)next)} ways.");
            }

        }
    }
}

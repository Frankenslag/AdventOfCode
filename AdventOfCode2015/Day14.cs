using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2015
{

    internal class Reindeer
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Time { get; set; }
        public int Rest { get; set; }
        public int Stop { get; set; }
        public int Start { get; set; }
        public int Distance { get; set; }
        public int Points { get; set; }
    }

    internal class Day14
    {
        private static string[] data =
        {
            "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds.",
            "Blitzen can fly 13 km/s for 4 seconds, but then must rest for 49 seconds.",
            "Rudolph can fly 20 km/s for 7 seconds, but then must rest for 132 seconds.",
            "Cupid can fly 12 km/s for 4 seconds, but then must rest for 43 seconds.",
            "Donner can fly 9 km/s for 5 seconds, but then must rest for 38 seconds.",
            "Dasher can fly 10 km/s for 4 seconds, but then must rest for 37 seconds.",
            "Comet can fly 3 km/s for 37 seconds, but then must rest for 76 seconds.",
            "Prancer can fly 9 km/s for 12 seconds, but then must rest for 97 seconds.",
            "Dancer can fly 37 km/s for 1 seconds, but then must rest for 36 seconds."
        };

        public static void Run()
        {
            List<Reindeer> reindeer = new List<Reindeer>();

            Regex rx = new Regex(@"(?<name>\S+?) can fly (?<speed>\d+?) km/s for (?<time>\d+?) seconds, but then must rest for (?<rest>\d+?) seconds\.");

            foreach (string line in data)
            {
                MatchCollection mx = rx.Matches(line);
                reindeer.Add(new Reindeer
                {
                    Name = mx[0].Groups["name"].Value,
                    Speed = int.Parse(mx[0].Groups["speed"].Value),
                    Time = int.Parse(mx[0].Groups["time"].Value),
                    Rest = int.Parse(mx[0].Groups["rest"].Value),
                    Stop = int.Parse(mx[0].Groups["time"].Value)
                });
            }

            int s = 0;

            do
            {
                foreach (Reindeer r in reindeer)
                {
                    if (s >= r.Start && s < r.Stop)
                    {
                        r.Distance += r.Speed;
                    }
                    else if (s >= r.Start)
                    {
                        r.Start = s + r.Rest;
                        r.Stop = r.Start + r.Time;
                    }
                }

                _ = reindeer.Where(re => re.Distance == reindeer.Max(r => r.Distance)).All(r => { r.Points++; return true; });

                s++;
            } while (s < 2503);

            Console.WriteLine($"Day 14 Part 1 Answer is {reindeer.Max(r => r.Distance)} km.");
            Console.WriteLine($"Day 14 Part 2 Answer is {reindeer.Max(r => r.Points)} points.");
        }
    }
}

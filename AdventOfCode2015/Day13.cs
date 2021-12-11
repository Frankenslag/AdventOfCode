using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day13
    {
        private static string[] data =
        {
            "Alice would lose 2 happiness units by sitting next to Bob.",
            "Alice would lose 62 happiness units by sitting next to Carol.",
            "Alice would gain 65 happiness units by sitting next to David.",
            "Alice would gain 21 happiness units by sitting next to Eric.",
            "Alice would lose 81 happiness units by sitting next to Frank.",
            "Alice would lose 4 happiness units by sitting next to George.",
            "Alice would lose 80 happiness units by sitting next to Mallory.",
            "Bob would gain 93 happiness units by sitting next to Alice.",
            "Bob would gain 19 happiness units by sitting next to Carol.",
            "Bob would gain 5 happiness units by sitting next to David.",
            "Bob would gain 49 happiness units by sitting next to Eric.",
            "Bob would gain 68 happiness units by sitting next to Frank.",
            "Bob would gain 23 happiness units by sitting next to George.",
            "Bob would gain 29 happiness units by sitting next to Mallory.",
            "Carol would lose 54 happiness units by sitting next to Alice.",
            "Carol would lose 70 happiness units by sitting next to Bob.",
            "Carol would lose 37 happiness units by sitting next to David.",
            "Carol would lose 46 happiness units by sitting next to Eric.",
            "Carol would gain 33 happiness units by sitting next to Frank.",
            "Carol would lose 35 happiness units by sitting next to George.",
            "Carol would gain 10 happiness units by sitting next to Mallory.",
            "David would gain 43 happiness units by sitting next to Alice.",
            "David would lose 96 happiness units by sitting next to Bob.",
            "David would lose 53 happiness units by sitting next to Carol.",
            "David would lose 30 happiness units by sitting next to Eric.",
            "David would lose 12 happiness units by sitting next to Frank.",
            "David would gain 75 happiness units by sitting next to George.",
            "David would lose 20 happiness units by sitting next to Mallory.",
            "Eric would gain 8 happiness units by sitting next to Alice.",
            "Eric would lose 89 happiness units by sitting next to Bob.",
            "Eric would lose 69 happiness units by sitting next to Carol.",
            "Eric would lose 34 happiness units by sitting next to David.",
            "Eric would gain 95 happiness units by sitting next to Frank.",
            "Eric would gain 34 happiness units by sitting next to George.",
            "Eric would lose 99 happiness units by sitting next to Mallory.",
            "Frank would lose 97 happiness units by sitting next to Alice.",
            "Frank would gain 6 happiness units by sitting next to Bob.",
            "Frank would lose 9 happiness units by sitting next to Carol.",
            "Frank would gain 56 happiness units by sitting next to David.",
            "Frank would lose 17 happiness units by sitting next to Eric.",
            "Frank would gain 18 happiness units by sitting next to George.",
            "Frank would lose 56 happiness units by sitting next to Mallory.",
            "George would gain 45 happiness units by sitting next to Alice.",
            "George would gain 76 happiness units by sitting next to Bob.",
            "George would gain 63 happiness units by sitting next to Carol.",
            "George would gain 54 happiness units by sitting next to David.",
            "George would gain 54 happiness units by sitting next to Eric.",
            "George would gain 30 happiness units by sitting next to Frank.",
            "George would gain 7 happiness units by sitting next to Mallory.",
            "Mallory would gain 31 happiness units by sitting next to Alice.",
            "Mallory would lose 32 happiness units by sitting next to Bob.",
            "Mallory would gain 95 happiness units by sitting next to Carol.",
            "Mallory would gain 91 happiness units by sitting next to David.",
            "Mallory would lose 66 happiness units by sitting next to Eric.",
            "Mallory would lose 75 happiness units by sitting next to Frank.",
            "Mallory would lose 99 happiness units by sitting next to George."
        };

        private static void Permute(List<string> v, int n, List<List<string>> result)
        {
            if (n == 1)
            {
                result.Add(new List<string>(v));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Permute(v, n - 1, result);
                    (v[n % 2 == 1 ? 0 : i], v[n - 1]) = (v[n - 1], v[n % 2 == 1 ? 0 : i]);
                }
            }
        }

        private static List<List<string>> Permute(List<string> v)
        {
            List<List<string>> retval = new List<List<string>>();

            Permute(v, v.Count, retval);

            return retval;
        }

        public static void Run()
        {
            List<string> guests = new List<string>();
            Dictionary<(string, string), int> preferences = new Dictionary<(string, string), int>();

            Regex rx = new Regex(@"(?<name1>\S+?) would (?<sign>gain|lose) (?<units>\d+?) happiness units by sitting next to (?<name2>\S+?)\.");
            foreach (string line in data)
            {
                MatchCollection mx = rx.Matches(line);
                if (!guests.Contains(mx[0].Groups["name1"].Value)) guests.Add(mx[0].Groups["name1"].Value);
                if (!guests.Contains(mx[0].Groups["name2"].Value)) guests.Add(mx[0].Groups["name2"].Value);
                preferences[(mx[0].Groups["name1"].Value, mx[0].Groups["name2"].Value)] = int.Parse(mx[0].Groups["units"].Value) * (mx[0].Groups["sign"].Value == "gain" ? 1 : -1);
            }

            Console.WriteLine($"Day 13 Part 1 Answer is Optimal Happiness {Permute(guests).Max(p => p.Select((_, index) => index).Sum(index => preferences[(p[index], p[(index + 1) % p.Count])] + preferences[(p[(index + 1) % p.Count], p[index])]))}.");

            foreach (string guest in guests)
            {
                preferences.Add((guest, "Me"), 0);
                preferences.Add(("Me", guest), 0);
            }

            guests.Add("Me");

            Console.WriteLine($"Day 13 Part 2 Answer is Optimal Happiness {Permute(guests).Max(p => p.Select((_, index) => index).Sum(index => preferences[(p[index], p[(index + 1) % p.Count])] + preferences[(p[(index + 1) % p.Count], p[index])]))}.");
        }
    };
}

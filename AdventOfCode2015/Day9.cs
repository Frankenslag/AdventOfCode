using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day9
    {
        private static string[] xdata =
        {
            "London to Dublin = 464",
            "London to Belfast = 518",
            "Dublin to Belfast = 141",
        };

        private static string[] data =
        {
            "AlphaCentauri to Snowdin = 66",
            "AlphaCentauri to Tambi = 28",
            "AlphaCentauri to Faerun = 60",
            "AlphaCentauri to Norrath = 34",
            "AlphaCentauri to Straylight = 34",
            "AlphaCentauri to Tristram = 3",
            "AlphaCentauri to Arbre = 108",
            "Snowdin to Tambi = 22",
            "Snowdin to Faerun = 12",
            "Snowdin to Norrath = 91",
            "Snowdin to Straylight = 121",
            "Snowdin to Tristram = 111",
            "Snowdin to Arbre = 71",
            "Tambi to Faerun = 39",
            "Tambi to Norrath = 113",
            "Tambi to Straylight = 130",
            "Tambi to Tristram = 35",
            "Tambi to Arbre = 40",
            "Faerun to Norrath = 63",
            "Faerun to Straylight = 21",
            "Faerun to Tristram = 57",
            "Faerun to Arbre = 83",
            "Norrath to Straylight = 9",
            "Norrath to Tristram = 50",
            "Norrath to Arbre = 60",
            "Straylight to Tristram = 27",
            "Straylight to Arbre = 81",
            "Tristram to Arbre = 90"
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

        public static void Run()
        {
            List<string> locations = new List<string>();
            Dictionary<(string, string), int> edges = new Dictionary<(string, string), int>();
            List<List<string>> perms = new List<List<string>>();

            int Compute(List<string> permutation)
            {
                int retval = 0;

                for (int i = 0; i < permutation.Count - 1; i++)
                {
                    retval += edges[(permutation[i], permutation[i + 1])];
                }

                return retval;
            }

            foreach (string s in data)
            {
                string[] aryData = s.Split(' ');
                if (!locations.Contains(aryData[0].Trim())) locations.Add(aryData[0].Trim());
                if (!locations.Contains(aryData[2].Trim())) locations.Add(aryData[2].Trim());
                edges.Add((aryData[0].Trim(), aryData[2].Trim()), int.Parse(aryData[4].Trim()));
                edges.Add((aryData[2].Trim(), aryData[0].Trim()), int.Parse(aryData[4].Trim()));
            }

            Permute(locations, locations.Count, perms);

            Console.WriteLine($"Day 9 Part 1 Answer is {perms.Select(p => Compute(p)).Min()}.");
            Console.WriteLine($"Day 9 Part 2 Answer is {perms.Select(p => Compute(p)).Max()}.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day12
    {
        private static string[] data =
        {
            "vn-DD",
            "qm-DD",
            "MV-xy",
            "end-xy",
            "KG-end",
            "end-kw",
            "qm-xy",
            "start-vn",
            "MV-vn",
            "vn-ko",
            "lj-KG",
            "DD-xy",
            "lj-kh",
            "lj-MV",
            "ko-MV",
            "kw-qm",
            "qm-MV",
            "lj-kw",
            "VH-lj",
            "ko-qm",
            "ko-start",
            "MV-start",
            "DD-ko"
        };

        public static void Run()
        {
            List<(string, string)> edges = new List<(string, string)>();

            List<List<string>> PermutePaths(string s, bool blnAllowTwo = false, List<string>? path = null, List<List<string>>? paths = null)
            {
                paths ??= new List<List<string>>();
                List<string> currPath = new List<string>(path ?? new List<string>());

                currPath.Add(s);

                if (s == "end")
                {
                    paths.Add(currPath);
                }
                else
                {
                    foreach (string np in edges.Where(e => e.Item1 == s || e.Item2 == s).Select(e => e.Item1 == s ? e.Item2 : e.Item1))
                    {
                        if (char.IsUpper(np[0]) || !currPath.Contains(np) || (blnAllowTwo && np != "start" && np != "end" && currPath.Where(s => char.IsLower(s[0])).GroupBy(s => s).All(g => g.Count() == 1)))
                        {
                            PermutePaths(np, blnAllowTwo, currPath, paths);
                        }
                    }
                }

                return paths;
            }

            foreach (string line in data)
            {
                string[] aryLine = line.Split('-');
                edges.Add((aryLine[0], aryLine[1]));
            }

            Console.WriteLine($"Day 12 Part 1 Answer is {PermutePaths("start").Count(p => p.Any(s => char.IsLower(s[0]) && s != "start" && s != "end"))} Caves.");
            Console.WriteLine($"Day 12 Part 2 Answer is {PermutePaths("start", true).Count()} Paths.");
        }
    }
}

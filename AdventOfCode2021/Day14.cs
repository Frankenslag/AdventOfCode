using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode2021
{
    internal class Day14
    {
        private static string[] xdata =
        {
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
        };

        private static string[] data =
        {
            "CK -> N",
            "VP -> B",
            "CF -> S",
            "FO -> V",
            "VC -> S",
            "BV -> V",
            "NP -> P",
            "SN -> C",
            "KN -> V",
            "NF -> P",
            "SB -> C",
            "PC -> B",
            "OB -> V",
            "NS -> O",
            "FH -> S",
            "NK -> S",
            "HO -> V",
            "NV -> O",
            "FV -> O",
            "FB -> S",
            "PS -> S",
            "FN -> K",
            "HS -> O",
            "CB -> K",
            "HV -> P",
            "NH -> C",
            "BO -> B",
            "FF -> N",
            "PO -> F",
            "BB -> N",
            "PN -> C",
            "BP -> C",
            "HN -> K",
            "CO -> P",
            "BF -> H",
            "BC -> S",
            "CV -> B",
            "VV -> F",
            "FS -> B",
            "BN -> P",
            "VK -> S",
            "PV -> V",
            "PP -> B",
            "PH -> N",
            "SS -> O",
            "SK -> S",
            "NC -> P",
            "ON -> F",
            "NB -> N",
            "CC -> N",
            "SF -> H",
            "PF -> H",
            "OV -> O",
            "KH -> C",
            "CP -> V",
            "PK -> O",
            "KC -> K",
            "KK -> C",
            "KF -> B",
            "HP -> C",
            "FK -> H",
            "BH -> K",
            "VN -> H",
            "OO -> S",
            "SC -> K",
            "SP -> B",
            "KO -> V",
            "KV -> F",
            "HK -> N",
            "FP -> N",
            "NN -> B",
            "VS -> O",
            "HC -> K",
            "BK -> N",
            "KS -> K",
            "VB -> O",
            "OH -> F",
            "KB -> F",
            "KP -> H",
            "HB -> N",
            "NO -> N",
            "OF -> O",
            "BS -> H",
            "VO -> H",
            "SH -> O",
            "SV -> K",
            "HF -> C",
            "CS -> F",
            "FC -> N",
            "VH -> H",
            "OP -> K",
            "OK -> H",
            "PB -> K",
            "HH -> S",
            "OC -> V",
            "VF -> B",
            "CH -> K",
            "CN -> C",
            "SO -> P",
            "OS -> O"
        };

        public static void Run()
        {
            Dictionary<string, char> rules = new Dictionary<string, char>(data.Select(s => { string[] aryLine = s.Split(" -> "); return new KeyValuePair<string, char>(aryLine[0], aryLine[1][0]); }));
            Dictionary<string, long> pairs = new Dictionary<string, long>();
            Dictionary<char, long> elements = new Dictionary<char, long>();

            string s = "SHHBNFBCKNHCNOSHHVFF";

            elements[s[0]] = 1;

            for (int i = 1; i < s.Length; i++)
            {
                string key = $"{s[i - 1]}{s[i]}";
                pairs[key] = pairs.ContainsKey(key) ? pairs[key] + 1 : 1;   
                elements[s[i]] = elements.ContainsKey(s[i]) ? elements[s[i]] + 1 : 1;
            }

            for (int step = 0; step < 40; step++)
            {
                Dictionary<string, long> newPairs = new Dictionary<string, long>();

                foreach (string pair in pairs.Keys)
                {
                    if (rules.ContainsKey(pair))
                    {
                        string newPair1 = $"{pair[0]}{rules[pair]}";
                        string newPair2 = $"{rules[pair]}{pair[1]}";
                        newPairs[newPair1] = newPairs.ContainsKey(newPair1) ? newPairs[newPair1] + pairs[pair] : pairs[pair];
                        newPairs[newPair2] = newPairs.ContainsKey(newPair2) ? newPairs[newPair2] + pairs[pair] : pairs[pair];
                        elements[rules[pair]] = elements.ContainsKey(rules[pair]) ? elements[rules[pair]] + pairs[pair] : pairs[pair];
                    }
                    else
                    {
                        newPairs[pair] = pairs[pair];
                    }
                }

                pairs = newPairs;

                if (step == 10 - 1)
                {
                    Console.WriteLine($"Day 14 Part 1 Answer is {elements.Max(kvp => kvp.Value) - elements.Min(kvp => kvp.Value)}.");
                }
                else if (step == 40 - 1)
                {
                    Console.WriteLine($"Day 14 Part 2 Answer is {elements.Max(kvp => kvp.Value) - elements.Min(kvp => kvp.Value)}.");
                }
            }

        }
    };

}

using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    internal class Day19
    {
        private static readonly string[] Data =
        [
            "Al => ThF",
            "Al => ThRnFAr",
            "B => BCa",
            "B => TiB",
            "B => TiRnFAr",
            "Ca => CaCa",
            "Ca => PB",
            "Ca => PRnFAr",
            "Ca => SiRnFYFAr",
            "Ca => SiRnMgAr",
            "Ca => SiTh",
            "F => CaF",
            "F => PMg",
            "F => SiAl",
            "H => CRnAlAr",
            "H => CRnFYFYFAr",
            "H => CRnFYMgAr",
            "H => CRnMgYFAr",
            "H => HCa",
            "H => NRnFYFAr",
            "H => NRnMgAr",
            "H => NTh",
            "H => OB",
            "H => ORnFAr",
            "Mg => BF",
            "Mg => TiMg",
            "N => CRnFAr",
            "N => HSi",
            "O => CRnFYFAr",
            "O => CRnMgAr",
            "O => HP",
            "O => NRnFAr",
            "O => OTi",
            "P => CaP",
            "P => PTi",
            "P => SiRnFAr",
            "Si => CaSi",
            "Th => ThCa",
            "Ti => BP",
            "Ti => TiTi",
            "e => HF",
            "e => NAl",
            "e => OMg",
            "",
            "CRnCaSiRnBSiRnFArTiBPTiTiBFArPBCaSiThSiRnTiBPBPMgArCaSiRnTiMgArCaSiThCaSiRnFArRnSiRnFArTiTiBFArCaCaSiRnSiThCaCaSiRnMgArFYSiRnFYCaFArSiThCaSiThPBPTiMgArCaPRnSiAlArPBCaCaSiRnFYSiThCaRnFArArCaCaSiRnPBSiRnFArMgYCaCaCaCaSiThCaCaSiAlArCaCaSiRnPBSiAlArBCaCaCaCaSiThCaPBSiThPBPBCaSiRnFYFArSiThCaSiRnFArBCaCaSiRnFYFArSiThCaPBSiThCaSiRnPMgArRnFArPTiBCaPRnFArCaCaCaCaSiRnCaCaSiRnFYFArFArBCaSiThFArThSiThSiRnTiRnPMgArFArCaSiThCaPBCaSiRnBFArCaCaPRnCaCaPMgArSiRnFYFArCaSiThRnPBPMgAr"
        ];

        private static void Execute(string[] inputdata)
        {
            Regex rx = new(@"(\S+)\s=>\s(\S+)");

            Lookup<string, string> replacements = (Lookup<string, string>)inputdata.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).Select(line => rx.Match(line)).Select(mx => (key: mx.Groups[1].Value, val: mx.Groups[2].Value)).ToLookup(kvp => kvp.key, kvp => kvp.val);
            Dictionary<string, string> revReplacements = inputdata.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).Select(line => rx.Match(line)).Select(mx => (key: mx.Groups[1].Value, val: mx.Groups[2].Value)).ToDictionary(kvp => kvp.val, kvp => kvp.key);

            string molecule = inputdata.TakeLast(1).First();

            HashSet<string> part1 = [];

            for (int i = 0; i < molecule.Length; i++)
            {
                string? key = replacements.Select(grp => grp.Key).FirstOrDefault(key => molecule[i..].StartsWith(key));

                if (!string.IsNullOrEmpty(key))
                {
                    foreach (var replacement in replacements[key])
                    {
                        part1.Add(molecule[..i] + replacement + molecule[(i + key.Length)..]);
                    }
                }
            }

            Console.WriteLine($"Day 19 Part 1 Answer is {part1.Count} steps.");

            int part2 = int.MaxValue;

            Random random = new();

            for (int i = 0; i < 100; i++)
            {

                string str = molecule;

                int steps = 0;

                while (str != "e")
                {
                    string strOld = str;

                    foreach (string revKey in revReplacements.Keys.OrderByDescending(_ => random.Next()))
                    {
                        int idx;
                        while ((idx = str.IndexOf(revKey, StringComparison.Ordinal)) != -1)
                        {
                            str = str[..idx] + revReplacements[revKey] + str[(idx + revKey.Length)..];
                            steps++;
                        }
                    }

                    if (str == strOld)
                    {
                        str = molecule;
                    }
                }

                part2 = Math.Min(part2, steps);

            }

            Console.WriteLine($"Day 19 Part 2 Answer is {part2} steps.");
        }

        public static void Run() => Execute(Data);
    }
}

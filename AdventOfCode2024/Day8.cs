
namespace AdventOfCode2024
{
    internal class Day8
    {
        private static readonly string[] Data =
        [
            "...........6.b....................................",
            "........6................8........................",
            "..Y.......................................o.......",
            "....V...j............B.............c..............",
            "............8.........X.......L...................",
            ".....j..v6.......3.L..................c...........",
            "..Mj.....p3.......b........Z....................J.",
            "..........M...X...................................",
            "V..............v......p.........Z.........c.......",
            "..............3...................................",
            ".......V......U3.............c....................",
            "..........b..v.M.U8...............................",
            "..........j........8.....................J........",
            "..........Y......q........LH..Z...D...........y...",
            "..2Y........PX......6..................BQ.........",
            "...0.Y...............XP...........w...............",
            ".........U.......2...............oH.y.............",
            "0..............9........U.........................",
            "...........P..............W.......z...Oy..........",
            "...................t...p.W..o.............Q.......",
            ".....S.................t.....Q....B...............",
            "S.k..................V..W...p.......H...O......m..",
            "....S.h................W.......................O..",
            "..h..P.2.............Z.............J..............",
            ".........k.......5v.......q...t.s.................",
            ".....Q.....h..........................J...B.......",
            "........0.........l...............................",
            ".S................................................",
            ".............................M....................",
            "2..................e.....o.....y..................",
            "................k.................................",
            "......4......k....t...s.q.........................",
            ".4.......................q........................",
            ".......................z....E.....................",
            ".............0.....d..............................",
            "7..........D........z.............................",
            ".......D..5......7..9.............................",
            "......5..................E........................",
            "D..............K......d..9E..........w.....1..C...",
            ".......K..x.........d....s...........l............",
            "........7......................u...C..............",
            "..K........x..............9..C...u................",
            "4..............s.........................l...T..w.",
            ".......5.....7..................m......T......1...",
            "...........................E...z.m................",
            "......................................u...C.......",
            ".............................em...................",
            "..............................................T...",
            "....................x.......................e.....",
            ".............................1e....w....l........."
        ];

        private record struct Location(int X, int Y);

        public static void Run()
        {
            int width = Data[0].Length;
            int height = Data.Length;

            IEnumerable<(Location, char ch)> antennas = Data.SelectMany((line, y) => line.Select((ch, x) => (new Location(x, y), ch)).Where(l => l.ch != '.'));

            Dictionary<char, List<Location>> antennaGroups = antennas.Aggregate(new Dictionary<char, List<Location>>(), (curr, next) =>
            {
                if (!curr.ContainsKey(next.ch))
                {
                    curr[next.ch] = [];
                }

                curr[next.ch].Add(next.Item1);

                return curr;
            });

            for (int part = 0; part < 2; part++)
            {
                List<Location> antinodes = new();

                foreach (char antenmGrpKey in antennaGroups.Keys)
                {
                    var pairs = antennaGroups[antenmGrpKey].SelectMany((_, i) => antennaGroups[antenmGrpKey].Where((_, j) => i < j), (a, b) => (a, b));

                    foreach (var pair in pairs)
                    {
                        int offsetX = pair.b.X - pair.a.X;
                        int offsetY = pair.b.Y - pair.a.Y;

                        for (int endNode = 0; endNode < 2; endNode++)
                        {
                            int depth = 0;

                            Location currentLocation = endNode == 0 ? pair.a : pair.b;

                            if (part == 1 && !antinodes.Contains(currentLocation))
                            {
                                antinodes.Add(new Location(currentLocation.X, currentLocation.Y));
                            }

                            currentLocation.X = endNode == 0 ? currentLocation.X - offsetX : currentLocation.X + offsetX;
                            currentLocation.Y = endNode == 0 ? currentLocation.Y - offsetY : currentLocation.Y + offsetY;

                            while ((part == 1 || depth == 0) && currentLocation.X >= 0 && currentLocation.X < width & currentLocation.Y >= 0 & currentLocation.Y < height)
                            {
                                if (!antinodes.Contains(currentLocation))
                                {
                                    antinodes.Add(new Location(currentLocation.X, currentLocation.Y));
                                }

                                currentLocation.X = endNode == 0 ? currentLocation.X - offsetX : currentLocation.X + offsetX;
                                currentLocation.Y = endNode == 0 ? currentLocation.Y - offsetY : currentLocation.Y + offsetY;

                                depth++;
                            }
                        }

                    }

                }

                Console.WriteLine($"Day 8 Part {part + 1} Answer is {antinodes.Count} antinodes.");

            }
        }
    }
}

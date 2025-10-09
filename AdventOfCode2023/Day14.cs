using System.Text;

namespace AdventOfCode2023
{
    internal class Day14
    {
        private static readonly string[] DataProd =
        [
            "#.....OO..O#.O.#O......#...#...#.O......OOO.....O#...OO##...#..#O..O...........O..#O....O......O..#.",
            "#....O#..OO#..O.#O#O......O..#..#.O..#.....###....#.O.....#O#.##..##..............O..OO.#O.##OO.O.O.",
            "OO..#.O.O....O..#..##.O..#.O..#O..#..#..#..O.O..#...O#.OO.O.#.....#..#.O..OO.#......#....#.O..#.#.#O",
            "....#..#.#.O...O.........#...O...##.....O......#O#O.#O.............O..#O.....O.O.O..O#......#.O.#..O",
            "#...O..#..#..#..OO......#.....O.OO...#...OO.O......#O.....OOOOO.##......#.#....OOO#...#.......O.....",
            ".O.O...O.#.....O..##......##O#....O.##.#OO#...#OO..O..##...#....#..O.O.##......#..O.O#...........#.#",
            "....#....#...OO....#..#.O...O...O.OO#O.OO..O...OO.O....#OO#.#....O....O..#...#.#.##.O...O.O..O..##..",
            "...OOO..#..##..O..O.#...#O......OOO....#.#.OO.#.#..#.##O...O.O....##OO..............O#.O..##.O#..OO.",
            "##..#.......OOO..O....#.O...O.O......O#..O##.OO###..OO....O......#....##.O.....#O#O...#..O....#.....",
            "#..OOO..#.O##O.......O..O....O...#.....#OO..#.......##.O...#....#.#..O.O.#O.....OOOO##..##O#O....O..",
            "#.O#..O.#..OO.O.#O.OO#O....OO.....#..O...#..........#....OO..O#O.#OO......#....OO...#....#O.O.O.##..",
            "#......#.#.#.##.#O#.O....OO....##.O.#..O..O..O...#O.........#.O#.#..#..#...#....#OO..#OO..#........#",
            "...#..O.O.OOO#O#..OO......OO....#..##.....#O.....#.##.OOO#O#..#.....O....#......O.#.#O.O.O..OO.#....",
            ".#O..OO#O...#...#O..O#.OO....O..##..#..#...........#..OO#O.#..#...OO...O.#..#..O..##......OO....O..O",
            ".O..O#O..#...#O#O#.#......#.#..O...............O..O.O#.O..........##..#.O.....OO#.OO.#....#.####....",
            "O..#.O#..O.O.O...#.#O.#.......O....OO.O.#.O.O....#O##.O.......##O..OO#O...##.##O#...........O#.O###.",
            ".O..#O..#....#..O#O....OO#....O#........#.#.#...#......#..##...O.......#O.#.#O#.O...#O.#.OO.#.......",
            "###O.......#.....O.O..#.#.....O.....#...#.#......#O.O.......##......##......OO.#.O..OO...O#.........",
            "..O..O.OO#..OO#O##....O..OO...O.O..OO....#.O...#O.##..#.O........#....#OO#....#...O...O.##.#.#O#OO##",
            "....#OO.O.....#.OO.#.#.#.#......OO......O...#.#.#....O..O#......#O.O#...O#.......#..O..O..O.##....OO",
            ".OO#OOO.....O.OO...O...#....#OO........OOOOO..O..#...O#..O.....#..O#.#......#O.#..###.O.O..#.O.....#",
            "O##.####O.##.OO..#..........O#.O...........#..O..........O...#.....O......#........O.#O.#O#O.O..O...",
            "...#.OO..##.....##.O.##...O....O.##.....#.O..O.O.....O.....#....O..#.#..O..O....O....#O..#O..O..O...",
            "...O#..OO#O..O...O.....#..#..#.O.O......O#......O.##.OO....O...#....#..O............O...OO#.O..O#.O.",
            "O..O..O.#O....O#.##O..#..#.#.O.....####OO...O.##..O#..OO...OO.#O.......##..#.O.....O..O.#O...O..O..#",
            "........#O..#O..O..#.#.....#..#...O.......O...#..OO.##.....O...O..O.#.....##.......#O.#O.#O...#O.#..",
            "......O...#O#OOO.##.##O..#...O....#O.......OO....#...OO....O...#..O...#O.....OO#O#O##..O..OOO.#..#.O",
            "##O..O.O..O.........#O....OO.##O..O..#OO....O.......O#O#.O..O......#....O...#..O#....#.OO#..#....O.#",
            "..O....#...........#.O.O.O...#.#....#.#.........O.#..O.#.#..O........#O....##..#O...O.O#...O.#...O.O",
            "#....O............#....#..O.O......#....#.#O......#.OOO...#.O..O##...#.#..#...O..O..#..#....O...O...",
            "........#..O#.......#O.O.........O.###..#...O#..O.....OO#O...O...OOO.#..........#.O.OO#...O.........",
            ".#.....##.#.#O###.O...#.O##O.#..#..OO.....#.....#....#...O........#..##O.#...O.....O........O#.O.O..",
            ".O.O##...O..##O...#.........OO#O.#...#O.......O.....O#....O.O.....###...O.#..#....O........OO..O....",
            "#.##OO.O.....OOO.#...O......O....#..OO..#O..##...OO.....#.#...O.O#..#O##...OO..#....O#..#.O.#.#..OO.",
            ".O........OO.##....O.#.#....#...O.O#..O...##....OO.O....O.##O..#.O....#O....O.....#..O..O.#...OOO..#",
            ".OOOO..O#O..##......O##....#OO.#..#...#...OO#.........O.#...#..##..O...O.##.OO##..O.#.......#...#O..",
            ".O##......#...#O..OO.O.O.O.......O.#................OO.......O.OO....O......#..O..#....OO#.OO....O#.",
            "....#OOO...#..O..#..OO..##...##...#...O.O...#.O..OO#O....#.....##OO...O.O....#.OO.O.#.#O..O.O#.#...#",
            "OO...#OO.OO#...#.#....O.#.O...#.....OO..O.....#O..#....O.#.#...............O#..#...###.O.O..#......O",
            "#O#.#.....##.O#....#O....O...O.#.OO#.OOO...OO.....OO...O....#.#O....OO..O..#OO#.O...O..#O.##...#....",
            ".#.#O#...OO.....#.O##.OO.....#O.#O....O#..O#..O...O....O#.O...#O........#..#OO...#...O.O.#O##....O..",
            ".O..#.O#O..O....O...#........O....O........OO..O.#..O..#...O.O.#.O.#.O...O........O..#.#.O#...#...#O",
            "....O..O.##O#..O.....OO.O.......##.#....O.....O.OO....#.#..O....#...#O#O.#.#.O..O.#...##.#.O..O.O...",
            "#..OO.OO.#...O##O#.O.#.OOO..#O.#.........OO.O..##.#..#..............OO#..##OOOO.O.#..#....#...#....O",
            "..O..#.....##.#...OO..O.....OO.....O#.O.##.#...O.#O..#............##....##.....##..#.#.O...O#..OO..O",
            "O.#..O.#.........#...OO....OO....#..#...OOO.O..OO.#...OO.......#.#.O..O..O....O.......#O..#O..O..O..",
            "#.O#...OO......#..OO#.....#..O....O#....#O...O....#...O...#.O.O..O.O..#O...O.O...OO.#O..#.O.......O#",
            "#O........##..O...........O#.........#.O.......O...##..OOO..#...###O....#..#.#.#OO#...#O....O.O...O.",
            "#......OO.........O......OO..#..OOO.#......#...O....#.O.#.....OO.#...O..O..........###.O...O......#O",
            "####O..OO#....O#...#.O.......O.#...O.....O##....O.O#........#.....#O.#......O.#O....O.#.OO.O.O.#OO.#",
            "..#.....#.....O...#..O......##.###...#..O...OO#O...O.#..OO...O#...#.....O..#....#O..OO.O#.....#...##",
            "......O#O...O..O...#..O..O.O..#OO.O.#...O##..OOO.#.#.....O....##....#O...O.....OOO..#O.O..O#.OO.O#.#",
            ".....O.....O.OO##...OO#....###..#..OO.#O.#.#..#.....#.....O......OO.#.#OO...##......#..O##.#..O#O...",
            "...#O..#...O...O.O...#....O.#...O..O.O.......#.#O...O.O...O#.....#.O.#.......OO.#..O..O#.....O......",
            "......#.O#.............O...O..O#O...O#.O.#..O..O.O#....#.....O...#...#O.........##...OOO.OO.#.#....O",
            "..O..#O...##.O.O......O##...####.#...#..O#....#...O.O.OO........#...O.#.#........#...O......#....O.O",
            "..O..#O.OO...O..#...#O....O.....#O......#OO.....#...#..#....O..#..##O..O..##...........O.O##...####.",
            "#.OO.O........O.....#O....O..#..##.##.O.....#..........#OO.O.O#O#.....#.O#..O...#O##.....#.#OO......",
            "#.....#....O##..O..OO..O...#..O.##.......#..O..O....#.OO..#..#...O..#..O.#.....O.O..#O#.....#.......",
            "..O...O..O..#O#...........O.....O....OO.....O..OO...###O##..#.O..O..O..O.#.#OOO#O.O......#.O..#.#...",
            "...O#O.O.#..#..........#..OO.###..#O##..O#..OOO....O.#.....##.O##..#...OO...#O....#....OO.O.#.#.#...",
            ".O...#..O#O.O.OO....OOO....O#..OO.#O...O.O..#......O.O...##..#..#O.O.#OO...O.O##...........O#O...O..",
            "..#..#..##...OO#.....O#O.O#..O...O.##O.##...OOO.O.#O#O..O....O#....O..#...#.O##.....#.O.OOO..#.....#",
            ".OO....##O..O#O.O..#.#....OO..O.#.......OOO#.O.......#O.O.O.O.#...O....O.O...##O...O..#OO#.....#...O",
            ".......O.O.O#.OO.#.#OO...#.O#..#...O...#...#.#.....O.#O..OO........O#OO##..#.O.O.O#.O..OO#..#.O##...",
            "...........O...#..#.OO.....O#.#.#...#O......O..OO..#.#...#.O.O.#.O...O.#.O.O..OO.............#.#O...",
            ".#.O#..O.O.O.OOO.##.......#..O.O..O##...O......OOO.......#O#.O.##..#..O...#..#.O.#.O..O...OO#O#.#...",
            ".........OO....O..#.......O..O.OOOO#O....O...O..O.O..#OOOO.O.OO.O...O.......#..O....#..O####..O...O.",
            "O.O.............#..##O#..O..#..............##.O....#O....OOOO............O.#.#O.O....O.#.......O.O#.",
            "....#O.O.#......#....O.O...#O#O#OO#.O.O.....O...O.#...O.OO#...OO#.OO............#....#..O....##.#...",
            "#.O..O.O.O.O.............#.#...#....O..#OO.#........O.........O....#..#.O.O.#....#....#..#O..O......",
            ".#OO..O..O.O.O#...........#...OO.#.....O.O........O..O.....#.##.OO.O..O..........O...#.O...#..O..#O.",
            "...#O#O#.......#.O..O.O.#....#..#..O.O.O..O#..O##........O.O.#....#.......#..O.O..O.#...O..O...#...#",
            "OO.O...#..O.#...#O#......##.#O....O...O.......O.O.O......#...........O.O.#O#.........O...O#..O#.#O..",
            "O.OO.O.O.O.O..#..OO......OO....OO......OO....#.....O........O.#O.O##.O.O.O.#OO.O....OO..##O#...O....",
            "..O..OOO.O...#....O..O#.O...O..O.O#O..OO...#OO.#....#.#.#OO.....#...O..OO#OOO....O..OO.O.O.O#..#.O##",
            "O....O............#.O...O...O.O.O.......#..O....#O..#..O#O...#........#....O...#O.##O.#.O.##O....O..",
            ".O.O....O..O..O..O..O..O.O.O.#....##...O.O.....O..##.O#.O.O.#.OOO.O........O#OO..OOO.#.#..O.....#O.#",
            "OOOO..#.........O...O.....#O.O..#.O.#......O..OO.......#O.............O...#.#.O..#.#.......#.O......",
            ".....OO.O...OO.#O...O.#.#.O.#.#..O.O.....O.O.##O..#...O.#...##O.O##...#O#...#O..........O#....##.O..",
            ".#..#.....#.O..##O.O...O.#..#.#..###...........O..#.....O#.OOO#..#OO.#.##.O#.....OO..##O.#.O..#O...O",
            "#....O...O...O#..O.O......##O...O....##....##.O#.O.....#..##.O#.O#.#...#O.###...#..OO.#O..O.OO....#.",
            "..O.OO.#....O.#.OO....O......##.OO.....#.......#.#..O.O.O...O.........#O#..O.O....O....#O.O.O....###",
            ".O...#......#OO.#.O#.O.#.O...O....OOO##O#.O##....#.O#..#O#......#.#.........OO....O.#....O.....O....",
            ".#..O.O..#O.#....OO....O.O.#.....OO.O#.O#...##O...O#............#.OO.....O...O....#.#O#...#..#.O#.O.",
            ".#O.......O.O.#...O.......#..O..#O..O.##..O#.O#....O..O....O.O#...O..OO................#.OO..O.O.#O.",
            ".....O.#...O.O.#...#...O.O.O.#......#.O.#.##.........#.#.#O.............#O#.....O.#....O..OO#......#",
            "O....O..#.#...#O#.....O.O...#....O..#.O#....O....##.OO..##.....#.O.O...#O...O##....O#OO#...#O#O#.O..",
            "..O.#..#O.O...#......#...O.O..O...O......OO#...O...#OO.OO.#.O##..OOO....O..#...OO.O...#O#O..#OOO.#..",
            ".##....O.#..O#.#OO..#...O....#O...#..OO................O....O....O#.O.#.OO.O....#...OO.#.O#..#O#...#",
            ".....#....#.OO..#O....#.#.....#..##.....O...#.O..O...............#O##....OO.#OO.OO.....O..O......##.",
            ".##..##O..#......#O..O...OO....O.#.#OO..#.....O....#O.#.#.#..O...#O.#....#O.O.....#.#O.O..........O.",
            ".......O##.O..##..##..O#....O.OOO.OO.#..##O...O#.#......#O.....O..#..#...#...#O..#.#..#..#....#..O..",
            "...#.O..O.#....O....O###....O#...#..#O..O...#.#..O.O.OO...O.##......#..##.OO#O..O.......O#.O...O.O..",
            "....O.O.O..#O...O.................OO.O.......O.OO.O#.OO..#.O.OOO.O.O....O...OOO....OO....OO#.#...O.O",
            "OO.....O.#.##.#O..O.O...#.O.O#...O...O.OO....#..#..........O...##..#.....#.#O...#..O#..###...OO#..#.",
            "....#O.....O..O..#.O##.#...###..O...O.O...O#..#.O.#O..#..O.#..O..#....#...#..O..O.O....#..#.....#...",
            "#O.......#..O.O..#.....O#O..O..O.O..##..#....O.O#.#..#.O.#.OO..O...#O....O....O#O#..#.#O.O.....#...O",
            ".O.###.O..#..#..#.......O.O....#..OO...##..O#O#O#.....O.##O.#..O.O.OO.#.O...OO...OO.O..OO.O..#...O#.",
            ".O#OO.#.....O..#.O#.#O.O......O..###.#...#.......O#...#O.#..#..O.#.#......O.O..#O..#...#O..#O.OOO.#."
        ];

        private enum Rock
        {
            Cubed = '#',
            Round = 'O',
            None = '.'
        }

        private static long SumColumn(Rock[] aryRow, int row = 0) => (aryRow[row] == Rock.Round ? 1 : 0) * (aryRow.Length - row) + (row < aryRow.Length - 1 ? SumColumn(aryRow, row + 1) : 0);

        private static void TiltPlatform(Dictionary<(int col, int row), Rock> platform, int dx, int dy)
        {
            int width = platform.Max(t => t.Key.col) + 1;
            int height = platform.Max(t => t.Key.row) + 1;

            bool IsValidPosition((int col, int row) pos) => pos.col < width && pos.col >= 0 && pos.row < height && pos.row >= 0;

            void MoveRock((int col, int row) startPos)
            {
                (int col, int row) currPos = startPos;

                while (IsValidPosition((currPos.col + dx, currPos.row + dy)) && platform[(currPos.col + dx, currPos.row + dy)] == Rock.None)
                {
                    platform[currPos] = Rock.None;
                    currPos = (currPos.col + dx, currPos.row + dy);
                    platform[currPos] = Rock.Round;
                }
            }

            for (int row = dx + dy == 1 ? height - 1 : 0; (dx + dy == 1 && row >= 0) || (dx + dy == -1 && row < height); row += -(dx + dy))
            {
                for (int col = dx + dy == 1 ? height - 1 : 0; (dx + dy == 1 && col >= 0) || (dx + dy == -1 && col < height); col += -(dx + dy))
                {
                    if (platform[(col, row)] == Rock.Round)
                    {
                        MoveRock((col, row));
                    }
                }
            }
        }

        private static void TiltPlatformCycle(Dictionary<(int col, int row), Rock> platform, int cycles)
        {
            Dictionary<string, long> cycleCache = [];
            List<string> cyclePatterns = [];

            long cycleStartPoint = -1;


            for (int cycle = 0; cycle < cycles; cycle++)
            {
                //North
                TiltPlatform(platform, 0, -1);
                //West
                TiltPlatform(platform, -1, 0);
                //South
                TiltPlatform(platform, 0, 1);
                //East
                TiltPlatform(platform, 1, 0);

                string key = Enumerable.Range(0, platform.Keys.Max(k => k.row) + 1).SelectMany(r => Enumerable.Range(0, platform.Keys.Max(k => k.col) + 1).Select(c => (c, r))).Aggregate(new StringBuilder(), (curr, next) => { curr.Append((char)platform[next]); return curr; }, sb => sb.ToString());

                if (cycleCache.TryGetValue(key, out long value))
                {
                    if (cycleStartPoint != -1) // 2nd cycle started
                    {
                        if (cyclePatterns[0] == key) //if this key is at the top of the cycle then we have a 2nd repeated cycle
                        {
                            foreach(var t in cyclePatterns[(int)((cycles - 1 - cycleStartPoint) % cyclePatterns.Count)].ToCharArray().Select((c, idx) => (col: idx % (platform.Keys.Max(k => k.col) + 1), row: idx / (platform.Keys.Max(k => k.col) + 1), c)))
                            {
                                platform[(t.col, t.row)] = (Rock)t.c;
                            }
                            break;
                        }

                        cyclePatterns.Add(key);
                    }
                    else // cycle start point not set ao thia ia the first time a duplicate has been found.
                    {
                        cycleStartPoint = value;
                        cyclePatterns.Add(key);
                    }
                }
                else // key not in cache yet so not found the first repeat
                {
                    cycleCache[key] = cycle;
                }
            }
        }

        public static void Run()
        {
            string[] data = DataProd;

            Dictionary<(int col, int row), Rock> platform = data.SelectMany((line, row) => line.ToCharArray().Select((c, col) => (col, row, c))).ToDictionary(v => (v.col, v.row), v => (Rock)v.c);

            //North
            TiltPlatform(platform, 0, -1);

            Console.WriteLine($"Day 14 Part 1 Answer is {platform.Keys.GroupBy(key => key.col).Select(grp => grp.Select(t => platform[t]).ToArray()).Select(aryRow => SumColumn(aryRow)).Sum()}.");

            platform = data.SelectMany((line, row) => line.ToCharArray().Select((c, col) => (col, row, c))).ToDictionary(v => (v.col, v.row), v => (Rock)v.c);

            TiltPlatformCycle(platform, 1000000000);

            Console.WriteLine($"Day 14 Part 2 Answer is {platform.Keys.GroupBy(key => key.col).Select(grp => grp.Select(t => platform[t]).ToArray()).Select(aryRow => SumColumn(aryRow)).Sum()}.");
        }
    }
}

using System.Text;

namespace AdventOfCode2024
{
    internal class Day15
    {
        private static readonly string[] Data =
        [
            "##################################################",
            "##.#...OO#O...O.O..#.#O.............O...O.O.O.OO.#",
            "#O#O.....O...O..O#OO..O..OO....OO........#..#....#",
            "#..O.O.O...OOO..O..#.#..O.OOO....O.....OO#.O#.#.O#",
            "#.....#....O.O..#.#.O...OOO..#...O...O....OO.....#",
            "#O.O#.....O....O#.O..OO.O...#O.........O...O.O.OO#",
            "#..O..#OO.........O.#...O....O..OOOOO.O....O..O.##",
            "##O#....OOO......#O#.#.##O..O...O.O.OOO#.........#",
            "#O....O...O...O#OO.........O.........O.O.......O##",
            "#......OOO...OOO.O........OOOO.....O..O.O......O.#",
            "#.O....O#...#O.O.OOO...O...O..O...#OO.........O..#",
            "#....#O..O.O#.............O...O#.O.#.O....#......#",
            "##..O..O.OOO.O...................O#...O.....#...O#",
            "#....O.O........O.O.#O.OO...O....O.....OO....O...#",
            "#O...O.O....OOOO.O..#..O..O.#....OOOO#.....OOO.#.#",
            "#...#O.........O......OO..O.O..#...OO#.##.#...OO##",
            "#...O...OO.#...O....#..O...........#.......O#.O..#",
            "#....OO.......O...##.#...O..O.O..#..O.....O.O.O..#",
            "#..O.O...O....O..O....O.O..O.O.O.......OO.....O.##",
            "#O..O.........O.......O.O.O..O#.OO.O.O.OO......#.#",
            "#OO.O..OOO.....OO.#..#....OO..O.#.#.O..O.O.O.O.#.#",
            "#..O...O.....OO..#..O...#....O..OO.#O.O...O.O..OO#",
            "#.....#OO.O...O...#O..#..OO...O..#OO...........OO#",
            "#..#O...O..#.O...O#.....#O.OOOOOO...#.O.O.O.O..O.#",
            "#O......##.O..O........#@.....O..O#......O..OO...#",
            "#......OOO..O.......#.....OO##...O.#O...#.O..O...#",
            "#...O..O.....OO.O.#O.#..O.....O.O...#....O..O....#",
            "#O....O.O..O..O..O..O..O..#...O.O.....O#.O.#.#OO##",
            "#.O.....OO...OO#........OO....O...O....#........O#",
            "#.#.....OO..O.O.#O#.##.O..#O#................OO.##",
            "#.........O#OO.O.....#..#...O#O....O.O..O..O.....#",
            "#OO....OOO.....O.............#OO#...#....#.O.....#",
            "#.O#.....O#...#.O..O...O...#.OO..O...OOO#..#....O#",
            "#.#.O.O..O......#...OOO.......##.O..OOO#.O.O.....#",
            "#.........#.......#..O.OO.#.OO..O..O.....OOO..O..#",
            "#..#...O#O...............OO.O.O.O..O..OO.....#.#.#",
            "#O#.O.O.#.O..O#...O..O....O....OO#O.O.OOO.#..O...#",
            "#...#.##........OO.O.O..O.....O.O#OO..O.O.O.##O..#",
            "#O#...##.#...OO.OO.#O..O..#OO..O.O......O.O......#",
            "#.OO....#.O...O........OO..O.......O.O#..O.......#",
            "#O..O..O...O...O......OO..O..O.OOO.#...O....#O...#",
            "#.....#...#...OO.O...O.#..#..#OO..........O.O.#O.#",
            "#....O......O#.O.O...#...O..O.O.....O.O..O.....OO#",
            "#..O...#.O..O.O...O......#.#OOO..................#",
            "#.O.....OO.O...OO.......O.#...#...O....O.....O...#",
            "#O##O.#..OOO...#......O..O..#OO.........O..O...OO#",
            "#..O.O...O....O..O....#O.......O......O..OOOO##.O#",
            "#..O.#O..O.OOO..#O.......O.#.#OO.O.O.O.O..O.#..#.#",
            "#.....O.OOO...#.O.O..O...O.OO...OOO..#.O.O.OO.OOO#",
            "##################################################",
            "",
            "<v><v><><vv>v<v<^>><><>v^v>v>v<>^v<<>>v>>v>v^><>><v^v><v>v^v>v<^vv>vv><>v^^v>>v>^>>^v<v<^<v^^^<<<<v>>vvv<v<vv^><<>>^>v^^v>v^v>>^vv<^>^v>>^^>>>>v<<>^v>^^><^v>^<<<^<<<v<<v^>>^v<>v>>v<v^^v>v><<^vvv<>>v>>v^^^<vv<>^><^>^<<>>^<>v>v<v<><^>^v>^<^<^^^v>^>v<v^vv^<vvv><v><v><<^<v<v>vv<>>v>>^^v>v<<^<^v<<<^>v<<<^><>v<>v>vvv^^^<v><v^<vv>v^^<v^vv<<^<^v^>v<vvv^^^^<>v>>^>>>>^<>><>v<^^<v<>v^<^v<^v^^^v<><<vv<><vv^>v<><vv^>vv>vv^>vv>v>v>>><v>vv^>v^^v>^vvv^>^v^^<<<^>^>>>^<>^>^v^v^<>v^>^<vv>v<>^^v>>v^<>^><vv^<<<>v>^>>^<<v>vvv>><^><^^<v^>v<^>^<><^><vv<v>v<^><>^^>v^<v<>>vv^><^>v^^<^^vv^>vv^^v>>v<^^v^v>><v<v^^v^v^vv>>^^vv^^v^vv^v<^^>>><><^^<<>v><>v<^^>^<^<v><^vv>v>>>v<<v<<^^>><^>>^^v^<v<>vvvv<vv>^^<>><>>>^^v<><>>^<<<v<<v^^>>>v^>^v><><>^vvv^>>v^^^v>^><v^v^><^^<>v>vvv>vvvv>>>v<^v^^^vv>>v><<v>^<>>^<v^<v>>>v>^v<<^v<^^<^<^vv^v<>v<v<>>v^v<<^^^v>>><v>v^><v<<>>vv<<<v^>^v^^v^>^^^^>v^v<<^^v^>^<>^<<<<v><<><><<<<^vv<^v^<^>>v>>v<^><^>^<^v<^v^>^^v<^^^v^>^><^v>>^<^^^>^^^^v<><<^^<>>>vvvv<<^>v>^>v>^<^v<^^v^<v^><>^^^<^>><<^^><<",
            ">^><<>vvv^<>>>^>vv<v^v<<^<><<><<>>^>^>v>vv<v<vvv<<<vv<v><^^><^>vv^v<v>vvv>^^^<>>v^<v<^v<>>^<vv^<v^^v<vv^<<^<>^v><v><>^^>>>^<^v><^^^><<vv^>^>v<<<<>>><>>^>v^^vvvv<>v^^v><v<>><>v<^^<>>vv^v<^<>>>^^^<^^>vvv<^<<v<><v>><^^<^vv<v>vv><>v<v><^^>vvv<><<>v<<^<<<<^v>>><<v^vvv>><v><v><^^^>vvvv><<>^<^>^^>>^^<<^^v^^<<^vvvv<v>vv><>>^v>^>v^<<>>><v><>><<>vv><v^><<v<>><>v><<<>v>v<>^^^v<^>^<^<^<>>>><>v>vv^<<<^v^<<^<>^<v>^^v^>>v^<<^^<><><<<^>>><><v>vv^>v^>><^>>^v>>vv^<v^v<v<v><<^vv<<vv>^vv<v^v>v>v>>v^<vv^<v<>^>>v><>>vvv><>>>>v^<<^^<<^vv>^v>v<v<^<^^><<v>^^>>^<^<vv>>><^vv^^^>v<^^<>v>^^^>^<<<><>vv>^^<^<^<<<vv^v><^>v^v^<>^><^v<<>^>>^v^<<v>v^><v^^<^<<v^^v>v<><v>vvv^<>^v>>^^^v><>>v<<vv^v<^<>^<>>v<><<v<^>^<^v^^^vv><^vv>>^<>>>v<vv^<v^<^>v>>^<v<><>>>>><>v><v^<v^<v^<>vv^v<v^<v^^<v^<>v^v^>vvv<>^v<><^>>v>^<><<^<>^<v^>><^^v<<<vv^v^<v^>^><^^v><><v>v^<<<><v^>v<>^^<<<><>v<^<<<><^^>^^v<<v>v>><<v^vv^>^>^vv^v>v<<v^<v^<<>^<v^><>v>>v><>^v^<^vv<v^<vvv>vv<^vv>v<<>v^^<^<<>^><^^<^v^<v<v>^v<v<<<>^^><<<v<v>v>v><>^<<v^>v<vvv>^v^vvv<<<",
            "vv^^><^>v<<vv<<vvvvvv>^>v^><^<v^<><^<v>^v>^<>^^^^><<>^^>>>^>^<>v^<^v^^v<v>vv><><<>>^>>>v<vvvvvv<^>>v<<><<>v^^v<v>^>^<v>^v>vvvv^vv<^><^<v^vvv>>>vv^v<>^>^>^>vvv^><v^<v^>^^^v>>v<^>><<^^v^<>v>><^v<v>v<v<<>^^vv^^v<<<<vv><>>^vv^<^vv<>>v^>vv<^<v>><<^>^>>>^v>vvvv^<v<^^<>vvv><^v<>^<<v<>>v<<^^><v<<v^>>><vv>>v^^<<>v>v^^^<<v<^>v^>^v<^<v^^>><<><^<<<><>^^<v<<><>^v^>>^<>>v>>v<<vv^vv>>>^>vv^v^<>v<<v<<^^<^^<<vv>>>^>v<v^^^v>^<^^<^<>vv>v<^v^><<vv^^^v>>>>^^^>^<v^>>>>^><>><<v^><v^^<<^><v^^<>>>>vv><v^^vv^v>^v^><>v^^<><><^<><<<<v>>v<^>^vv^^v^<^>>>>^v^^^<v^v<^vv>vvvv^^vv<^<>><vv^^<^<>^^<^v^^><<>>^v>><^>v^vvvv><<^v>v>>^v^v<<>v^<^^<v^v>^vv^v<^v<>^v<vv>^>vv>>v<v^><^v<<>^^<v><^>><vv><>v<>^>^>vv^v><vv<v>vv^<<>v>v^^><>vvv>v^<<>^v<<>v>v>>><v<^^^^<>^^v<^vv<v<vv>vv>^vvv>>^^<v>v><^vvv<>^v^<^vv^<vvv^v^v^^><<<>^vv>>>>v><v^<^^^<vvv<^^^^<><>v^v>>^^^^v^>^<v<^^^^>^^>^^><^<^><^<<vv^<vv>>vv<v^<v^^><>^>>><^^^<v<vv^<<^vv><><vv<>>>v^>>v<>v>>>^v^>^<<<^<>v^>^v>>^<<v^<><^<>>v^v<^>^><^>v>><^v^^^>v^>^^<^v^^v>vv>v<^^^<^><^vv^v>v<>v<^vv",
            "^^>v<><<^vvvv>^v>>><^^<vv>v>><<>v>vv>^>>^^>>^><<v^<<><vv<<>v><<><>vv<v><<vv<^<^><v><>^v^<>v>^^>v>^<<<^<>v<<>v<><>v<<v><^>v<<^v<<^v>>v<^<<<^<><^>>^<>^^>>^<v^>^vv<>>^v^<><>^v><<<<^^><^^>>^^^>^v><v<><<^>^<<^<^^<v^>^vv>^>^v<>>>><^v>v^^^>>><>^<>>^^<vv^v>^>>><v>v>><^^v<^><vvv><><>v^><>>>^v<>>vvv><>v><<v>>>v<>v><^><<^<v<>v<><<^><<^v>>^^>><^^v^><v>vv<<^><><v>^>><^><^<^>^v><v>^^v<^^<v^<>v<vv><^<>v^>^^<^v>^<^^>v><<^>^>v>^>^><>^<v>>^<v<^>v<^vvv><v^v<^v^>^v^^^>>>vv<^<>^>>>>v^>^>v^vv^^v<^^v^^>>>^^vv>v>^v<^^v<vv^^>>v^^^^>^^>^^<vv^>v^v<><v^vv^vv><^<^><<<<<<v><<>^vv><vv>><<<v<^^<^<v><^><>>v>>v<v<v>^^v<^^<>^^v<>>v<>>><^>^<><<v<><>^^v<<vv><^v^<<<>v^<^<<^vv^^^<<<>v<^^>^^v>>>>v>>^>^>^<^v^vv^^<>v>><<^v<>v>>><<v>vv^><v>>^^<><<>>>>><^^^<<^>vv^v>^<>>^^^v><v^<<>v>^>vv^<v<^<<^v^v<^<<<vv^<v<vv><^^^><<v<vv^v><<<v><vv<vv<>^^^^v^^vv>>vv^v><^vv<^^v^v<v^>v<<v^>v<>^>>>><^>^>>vv>^>v^v<<<<<v<v<^<>^>vv^<^^><^<^<<>><>^>>>^v><^<<>>^><><<>v<<^v^^<^>v><vv^^vv>^^>^v>>^>vv<<>>>>v<<^>>v<^<><^<>^<<^^v^^<<v><<<^v>v<^>^v<<^><^<^v^",
            "^>v><>^>v^>^vv^^v<<<<><^^<^><<^v<v>v<<>>>><>^^^v><>v<^v><<<<^<>v>v>^>^><vv<<^>^<><vv>^^>v<v>vvvv>^^^<>vv^>><v>^<^vv<<v<<^^<vv<^<^v^vv><v^^vv^<^>^>^^^^>><^>v^v^^v^<vv^>>><^^^v<^v>>v^<^^v>v>^v>^<vv<^v^v^vvv>>v^><v^><<<>>v^^><v>v><<<^v><>v^^vv^v>>v><>^^^v<v>^<vv>v>^>^v<>><>>v^<><><^vvvv^>^^<>vv<v<<>><<<>><<<<>^v>>v^^^v>vv<<v<vv^<v>><>vv<v<<<<><v^<>^v^v<^>><^<<>^>v>^>v>^>^>>>v^>v>v^v^^^v<^>>>v>><<<<v^v<^<v^v^vv>vv^vv>v^v^><<^<><<<^^>vv<<^<^<v<vv^v>vv^<^^>>>vv^><<<^<><>^>>v<^^v><<<>v^v<<<^<<v<<^v<^v^^^>^<^^<<vv>^<^>^vvv>^^><^><^v>v^>v<v><<<><>v^vv^v<<<<>v^<^^v>v>v^^>^v>^<<>v<^<><^<vv<^<>>^<>>^<v^^vv<<<v<<^>^><^^vv^<<<^vvv^^^>^v^^v^<><^^>^^<^<><>>><^v^>vv^>>><v^v^>v^<<>v<v^<vv>^<^^^<<>^<v^vv>>^^<v^<>>>>^<>v<v<^^><<>v^^<<<^>>^v^^<>>v><v>^v^v^>>^^>^<<<>><<>^^>>>^^<>><>><<<<^<>^>^v^^vv>><v^^<v^><<v>>><v<<<^><>^<<>>v<^v<v><>><^>>^>^<<<^v>^>v^>vvv>>v^^><>>v^v<>v<<v^^>vv><<<^<v^>vv<>^v^^^>^>^<>^>^<v^<>^vvv<<<>^>><><^^^v^<^^>v^<v^<^^v^>^<^^<>v<<>>v>^>^<<>vv^^^<>^v>v^<^v<<v^><v>>^^<<vv<<>>v<<><v>>^v",
            "<^>^vvv>>^vv<><>v<v><^>>vv^v^v^<^<<<^<vv<>v>><<v<^>><vv<<v>vv<><>v^v>^><^>>^v<^<<<^v><><><<v^<<<^^<vvv<v>vv<^<v<^v<<><<^v^^v<^<><^<<><<^v<<<><<^v<<^<^<v>^>>v>>>^^>>^vv>>^>v<^v^>^<^<v<^<<<v^v^^><v^^><^<>^v^^><v<>v^><^<<vv^v>v<>v<>^<v^vvv^^v<^^>v^><>><^^>vv><>>v<>>vv^>v^^vvv<v<v>>^v<v>>v>v><vvv<>^>><^vv^<<^>^>^vv^vv<>v^<vv^^><>vv^<<^><^v>>^^^>v^v<><>><v>^^vv<><<^<^v^<>v^v>^<><<<>vv>^<^^>v<>>v>v<^<<>^v<>>>^<v>^>^^<v>>^<<^><v>>v^v<vv>>>^<^v^<^>^<v>><vv^^><^>v>^>^^>><><v<^<<v<v<^^v^><^<<^v<>v>^^v^>v><<<<^>^v<v<v^^^>v>>v^vv>v^^>^><<>^<^<>vv<<v<^^^>><^v^v<v^^<^v^<^^v<^v<><^^v^<^<^^>>^>vvv^<<<^v<<<<<^v^^<>^<>v<<v<^>>^>^>vv^v<vv<^v>vv^v^v<>>^>v^v<v^^v>^v^v^^v^^<<><<^>><>^<>v^<<<><<<^vv>v<vv^>v<vvv<<><<^<<vv^^^v<vvv<^<vvvv>v>^>^v<>>><><^<vv<<v<^<v>^v><<><<v>^<^<<vv<^>v>^>>vv^^>>v<>^vvv>>v><^<<v^v^^^>^>v<><>><>v><<<>v^^vv<^>v<>>^vv>v<^^>v>^>v<<^<^<><v^^<^><v<<<>^^vv^>><v<v<>>^>^^^v^<>^v>>>v^v<>^<<^>>><<v>^>vv<>v>v>^vv^vv^v<v<^^<>><>^v^>^>v><^^^>>^vv^>v>v>v<vvv^v^><^>v^^^>vv>^^>><^^^^<^v<v<><v>^>^",
            ">vv^^vv<^vv>^>^v>^^<^^^<>^^<<^<v><vv<>v><vv^v^<>>vv><<^^<<>^>v^<<v^v<>v^v>v>v<^^v<<vv<>^^<><v^<>^>^<^>><>v^^^>^vv>v<<><v<<<v>><^v<^v^^<>>v^<^vv^<^v^v^^v^^^>^v^^><^><^>^><v>^v>^<>v^v>v^^^^>>v<v<><^^v>><<v^<>>>>^v^v>vvv^v><v>vv<^^v>v<^<vv^<<v>>vv^>v<^^<<^<^v>v^v>>>v^v^v<v>v^v^>><v^>vvvv^>v><^^vvv<vv<<<><>^^<^<>><vv^vv<^>>^v<v^<>^^v<v>>>><v<>v><^v^^<<v^>><^<^v^^>vv<<<v><v^>v>v<vv><v<<v^<^>>v^^<<>v><<<v><>>>>vv<<^v<v^v^v<>>vvv^v^v<^>>v^>^<v><><>><>^<<>v^vv><<><>^^vv^v^^v^><v<<^^>>v^v>v^>>^<v>^<>v^vv^^v^v>v<>^v^<^<>v>v<^v^><vvv^><v<><<^v<>><^v^>>^v<<v^^<<<><v<vv^><><^>vv<<v>^>^<v<^v^>^vv^><v<^>>v<^v^vv<vvv<<^^<<<v><<^^v^^<^<>^v^><><<^^><><<<v^>><>v<>>v>><^^v<v>>vvv>vv>>>><>vv><v<<vv><vv<<^v>^^^>vvvvv>^^<<<v>^vv^^><^<^>^vv^><>>v<>v<^>v>>v^^><^v>>v<>vv^^v<v^v<v>^><>^^<>^^<^>^<>><<v<v>>><>v>vv^<^<<>>^>^vvv>v^><^<<<>><v^v<v^<<<>^>><v<^<v>v^<^>^><v>^><v^vv^>>v<^^^v<<<v<v<v>v<<^<vv^vv^v>>^<>>>v^^vv^<<^><^v<>><^<^<<<^<^v<>><^v^<^v^<<<vv<v^<^<^^v<>v<>vvvvvv>>><>><v>^^<>^>><v^vv^v^>vvv>^>v<v><v^>^vv",
            "<<vv><>v>>v>>vvv^>v><<<v>^>^<>^<<^v><^v^v<<v>^<>v>^>vvv<><^^>vvv^v^>><<><<>^<<<><v^^>vvvv>vv>^vv<^>v<>v<^v>v<^^>v<^vvv^^<<<vv<v<<v<v>vv>v><v>><v^v^<<>>>v>^^v^>v^^^>^><<v^vv^v<^v<><v<^<^><vvv>>vv>v^<vv^><><>v>><^v><>vv^^<vv<^v<>>v>^<<^>>>^>vv^<><v<^>v>vv<v><v^<<v<^><^>>><v<^<>>^<v^<<^>^>^v^<<v^v<^^v><>v<<^<v^vv<^>^^^^<>^vvv<<^>>><^><^<v^^^v<>^>^vvv<>^<<>>v<<^^<v^<vv>>^>><^v^<<^^vv><vv<<^v^>><v^^<<v<<vv<<^vv<<vv^v>>^^>v>>v^v^^<v>^><<>^^^>>^v^<v<^^^<v<>v^^v>^>^<<^>>v^v^^^><>>>v^>>^<^><<>^v><<v>^<^>v>><<>>>>v<v>^><^^>>^^>vv>^>^<^v>v^v<<><^v^<^vv>^<<v><<<<v>^v<vv^v>vv<<<><>>><^v^>^><^>>>v<>>^v>>^v^v^>>>v<<^><>v<v<^>>^>^<^><^<v<<^^v^^><vv^>^<><vvv<v<v^^^<v<^><vv^v>>v<<>^<>vv^<<><<<^<>^vv>v^>^v^v^<^<>^><^>>v^^<<<v>>^><<>><<v>><^<<<>^><>vv><^v><<>v^^^^^^>^vvv^^>v>v<^vv^^<<vv>>v^v^>^<<v<v<v>vv><^v<>><^^>>^^<v^<^v>v>>v^v<v>>>v^<>v><^^^<>^>^vv<^v>><^v^><v>>>v<v<<<><<>v^v<<v>^^v^v^<<>^><>v^^><v<vv<^<^^<^v<<>^<^<<^v<><v>^>^<>>v>>v^v<<^^^^<v<>><>>v>><^><v^>>^^>^^<vv^^<<^^>^>^<vvv><<>>vv<<>>><^vvv>><",
            "<<^vv><v><>v><>v^<>>v^v<v<>v^^>vv><>v>>>^v^^>v<^>^^<><^<^<v^^<<>>>^^v><>^<vv^vvv^^vvvv><><^^vv>>^^<^<v<><^^^v>^v^>>^<v^>^^^><<v>><^^>vv<^<^vv^>^>^>^><^v^>^^><v>^<<vv<>v^<^^<vv<<v^^v<^>>^>vvvv<^^<><><vv<>v<^v><v^<<vv>>v<^v><v>^v^^v<^<>>^>v>^<v<<>>>^v>^><<<v<^<vv><v^v^v>^<<><^v<<>^>^vv<<^v><>vvv>vv<v^v>>^<<<v>>v>>>^<^<v>>^>^>^><^<>^>>v><^<v^^<v><>^^<^<^^<^v^^<><^<>>v<^>v<^<v><^v>^>v^>>v>v<<><><<>^<<>vv>v<<^v^^^><v^><><v^><^<<vvv>^<^^vv<><<vv><v>v>^v><v^<<<<>v>v>v<v<v>^>^><vv><<^>vv<>vv^^>>vvv^><><v<^>>^<>v><>vv>>><<>>^>^<<<v^<<^>>>^^^><>>v>>>>>v<>vv<><<^vv>^<^<vv<>>v^vv>>^<^v>v^v^<>>^>>^^<<><^<<>v<<>>>^<<<>v^^>><<vv<>v^v^>><v^^>>^<v^v<vv>>><<v<>vv^v^<v<^vv<<vv>v>^^v><><>v><<>^^<^^^>^v^^>vvv<><><>^><vv^<^v><><<>>v>>>^v^<^v<<<<v>v<><<<>>^<<>^^<<><><>v><<vv^>v^<v<v^vv<v>v>v^^v^v^^v>vv<v>^^>v<>v^<>v>^v^>^>^<v<^^<^v<vv^^>v^^^vv>>>^v>vv>v^^vv^^v^^v^>>^>><^v^>^v<^^>^>>^>^>>>>>vv<>v>^><^^^vvv><v^<^v^<v<>>^vvv<v<>v<<>v^v^<^v<<>>^^v<><^^<vvv>^v<v^^>^v^>><v><^<<>v^<v<>vv>>>><v<>v^v<^<><v^v^vvvv<^<>",
            "^>><>^v^vv<^v^v<^>>vv<<^^^^<><^>>><v<v>^v^^>^<>>vv>vv<><^>>v<<<><^<><^<>^<<><v^<v><v^<^>>>v<^^>^<>^>^<^^>><^>^vvvv^^v^v^>^<>vvvv<>^<v<^v>^^>^<<^><<v^<><vv<^v<v^>^>^<<v^v^v>vv^><<^<v<<v>v<<^>^<>>vv>v<>>>^>v^v>><>>>>v>>^<vv^>^>>vv<vv>v<<^><v>>vvv<<><^^<>^>v^<vv><vv><<^<>^<>vvv><vv^>^vv^vvv^^>^v>>^><vv>v<v^^<^vvv^<<><^>>v^<^<v<<^<vvv<>^><<^><>v<<v^^^v^>v>^vv>v^v^^^>><^>^<<<>^<>v>^^v>v>v<>^vv<<v^><v><><^v^v>^<v>^<^<^v<^vv^>v^^v^>v>^<v<<v<>^<><<v<<<>><v^^^<>^>><>>><v>v<^vv<^v^>>>^^^^v^<><vv>vv>^^v^<v>vv^^^<v>^v>v>^^v<v<v^vv<>><<^^<<^<v^v^^^^>vv^><vv<^>>^><v<vv>^^<^<^^>^^<<<v>>v<vv>v<>>>>v<v>^^^>>vv<^v<><v<<^<>^v>^>v>>^<<^>v<vv><<v<v^>>^v^>>><v>>vv<<<v>>^v<<><vvvv<vv<^<<vv>^<><^<^v<<>v>v^v><vv<^>^>>vvv^^>>v^<vv^<^^<<^>>^>><^>v<<^<>^vv<><^v<^>vv>vvvv^v>^<vv<>vvvv>>>>>v>v>^<>vv<<v>>^v^v<v>>>^vvvv<v><^>vv><>>v>^<^<<^^<>vv>v<^v<^<^><v^vv<>><>^vv<v^<^>^^<v^^>^vvv^>^v^v>v^v><<<<<vv<^^vv^^<>>>>vvv^<^>v^<^>>vv^>v<>^v^<v>vvv>><<>^<v<^>v<v^>^^<v>><vv><v^^v^v<<<<<<<<>>>>>v<^^^v<<^^v^<>v<<<>v>^<>>^^^>><",
            "><<>v<^<<^v>v^^>vvv^>vvv^>^v><^<v<^<^^<v^v<v>>^><>>vv^<>^>><>^v^><<><vvv<^^^vv<vv^<><><<v^<^v>^^v^<<^<>vvvvv<v>v^><^>v<<^<^^<^>^>v^vv<>vv<>><<>vvv<>vv>^^^v<><v<<<>vv<<>>v^^<^<v>^v>v<<vv^^vv<^<<<<>>><^>>vv<<>^v<<v>^<<v^vv><v>^<^<>v<^vvv>>v>vvv><vvv^<^v><>v<v^<v<v^^^><^>>><vv<^v>^v<^>v^v^v><^>^><<>v^<vv>vvvvv^<v<<vvv<^<>>v>^<<v^<<^^>><v>>vvv<<<>^^<^>^^^<<<v^><^>^>>v>v<^v<^>vvv>vvv^v^v>v>v<^^v<^v>^>><<^><<<><<>>^<<<<^<v^vv><<>vv>^v>>vv>^^>>^<>>^<<<<>v>^^^<^<^<<^^>^v^v^^vv^<>><^vv^>>v>^>>>>vv>^><<v<v^><^v<>^<>>v<v^v<^<v<^><<<v><^<<v>^>><^<><vv<^<^>v<^>v^^v^v<<^>^><vvv>>><<v<<><vv^vv<><^v^>>>vvvv<vv<^v^>v^^v<<<^^<<<v>>^<>^v<<>^^>^^v^<vv^<<>><^<^><>><^^<vv>v<<v>vv<><^^v><<<^v^^>vv<^<<^v^v^^>^><vv><>^vvvvv>>>>^v>><^<><<<>^>v^^^><><^v<^vv^^v<^>>>^><^^<>>v<v^^<<<<<>^v^^><^<<<>^<>^v<>>><>v><<<^vvv<^v^<<v^v^^<v<vvv^<^<^^<v<v^<v^vv^<^vv>v><v^vv<v^<^vv>v^><^>vv>vv<^<v<v^<^^>^<><><<^>^^>v^<^>^^v^v^^<<v^v^v>>v<>v>>^v>>^><v<^v<v><<<><<<v>^v><><^<^v<><<><<>v^<<>v<>vvvv<><^^^<<^^>^>>^>><v<>vv^<<^vv^>>^<",
            "<^vv><v^>v>^v><>^<<^>v<>v><^<<><<^v><<v>^>^^<<v^<^><>>v><v>^<><^<v<v^>v<^v>>^^>v><>^>^v^vv>>><<^vv>^<>^<^v^>vv><v>vvvv>^v>>>>v^v^v^v^>><^v^>v<^<v<<^<<vv<^^v>>^>>>^>^^^v<vv>v^<^^>^>^v^^v>v<^<vv^^^>^<^v^v>^vvv<>>vv^v<<v^>^v>>v>^<^^>>>v><<^<<^<^v<v<v>vv^^>>^<^^><<<^^^>^^<>>^<<v<v><^vv>>^v<vvv<>v><><^<v>v<><v<<^v^^>vvv<>^^^><<<<v>^^>>>vv<^v^^>^>^v>>><v^<v<^<<v>^><>^^<<^v^<^>>v<^v^^^>^><><vv<v<v<^^>^v^^<vv<><<^v^><<>>^^^>^^><<<v>v^>^<vv<><<>v><>>v^<^<><><>^^^^>>^v^<v<>^^^<^^>v^^v<vvv<>><v<>v>^<>^vv<^<^^>>vv<<>^^>vvvv><v^v>vv<v>><^v^>^^vv><>v><>v^^><v>^>^^>^<v^^vvv^v>v<^>^<^v<v<vv^>^><>^v<><vv>^<<v<<<>>v>v>v^<v<>^>v<>v^<<^v>^vvvv^v>^vvv<<v>vv>><^v>^<<v<^vv^>vv<v<>^^v<v<<v<^^v^vvv<<vv>v<<<^>vv>v^^v^^^<<><^<v<^^<v^^^>v<^^v<><>^>>><><>^^^v^<>><vv<v><<>v<>>^>^v>^>vv^<<^v^^^<<^vv>>>>^^^^^^<<<<<^vv^v<<<^v<<<<><^^><^<<>>v><<<v^^<>^>>><^^v<^v>>><>v<>>v<^>><^>vv<^><<v>v<<>^^^<<<v^>>>v<v>^<^>>^v<>>^^<^v>v^vv>>^vv>^>>v<<><>^><<>vv<^v><v^<vvvv<^^v<v><^>><^<^<^<<<v<v<>>^vv>^<<^<v^v>>>vv<v<^<v^>v^v>^^^<v<",
            "<^>v^^<v^<v^>^>vv<<^<^vv>v>^><^<<vv><^^vvv^>^><v<^v<<^>>v<vvv<v>^>^v>vv^^>^^><v<>>>vv<<^<^v^^^^>^^vv<<<>><^v<<>^^>v^<<v>>vv<v>vvv^v<v>>>vvv>vv^>^^^^^>^v^<<><v<^v><v<v^v>^><v>>v><<<>v^v<>>v>v>^>^<^v>v^v<v>^><>vv^^^>><v<v<<>><>^v^v^^<vv^<^<<vv<^^>>v>v<>^>^^v<v<vv>^>vvv>v^v^><>>^<v>>v^^^v^>>^^v<<<<v>^^>^<>v^v^><v<>v<><<vv>^^^^<v<v<v>v>^^<<<>^v^>v<<<^v^>>^<>^v<^^v^<^><<v^<v^^^v<v^^^^^>^^^v<>>>>^>>v^><v^<<^^^^<^<>v<<<^^>>v^<><v>>v^<>^>><><><<^>^<^>>^v^vv>^<^<>><v<>^<^^^^>^^>^^><v<>v>>><>^^<v^^^^vv<vv^^>^<>v><><^>^^<><><<^<vv><>><^^>>^<v<v<v^<^<<<^v>>v>v>^v^v^^^<^vv<<v<vv^<^<v>>^<v^v>v^>>v<^>^<<><<^<><v^^v><>^v>vv>>>vv><^<v^<^^^^>v^v<<v>>v<>v<<^<><v<<^^vv><><^>^<vv^<<>>>>vv>^>>^^>vv^>^<<v<<^v^><^<>^^^><>v<<>><<>v><^><^v<>^><>v><^<><^v^^vv>>v>^^<^>^^<<^^<<<>^>^>^<><<^>^vv<<^>^v^v<v<>>v^<<<<^>v><>^><v<v>^>v<>^v>>>v^<><<>>v<<<v<<><^>v<vv<v<^>v<^^v^><<>^<^^v^^>>><>v<<<v<^<vv><v<<^<>vv>v>v>v^<>>^<^^<^>vv^<^>^<>^>^vv<vv<>>^><^v^v^>>vvvvv<^<v<<^<^><v<><v>^^vvv<v<^^<>>v^^v<<vv<^^v^<^v><^<<><^><^>^>v",
            "<^vv^>^^v^<^v>vv<><<v<^>><v<><<<>>>vv^>^>vv<v<<^^>^^v>v^>^^<<v^v>^<v<<^^<v<><<v^v>^>v^v^vv>>vv<v^>v^><^<^>>>^<<vv><vv^^v^<<<^vvv><v>v>><vv^^>^<^v>v^^>>>><v^<v^<>^vvv<v<v><<>^v<^<<>v>^v<vv<>>v<<^^<v^^v<v<<<>>v><>^v><<v^v>>^v<><<<^v^^^<v>^v^<^vvv<><>>><^^^^<^^^v^v<^>vvvv>vv^>>v<>vvv<v<><>v>v<^vv>v^<<^^<><>v<><<>>>^<vvv<>>^<<>>^vvv>^v>>>>v^>^^<^>>v>>^v^v><^^<>vv^>v^<>v<^>v><<^>^^<>^^v><<<<^v>^v^^^^^v^><v^<^><^^>>>^<^v<^v<>v<vvv<v>^>>v<v<^v>>^>>^^>>v^<>v<>^>v^vv>v^^vv^><>v>^><^v<>>^>>^><>v^^>^^><^v><><<<<><vv^^v^>^<<>^^v^>>><vvv^>^v^v^><^<>vv^vv>^<vv<>v^v>^^<>>vvvv^v^^<^><v><>vvv<<><vv^>><<<^^<<^<>>^>^<>>^<<^^>>>>vv>><v^v^<v^>^<^vv<>v^><>>><vvv<v>vv>vv<v<v^^<>v><>vvv<^^^>vv><vv>>v<^>^<>^<<<^<<^^>v>^vv^>v<<^^^><^>^v><^v>vv^^^v>><v^<^><<^<>><^>v<>^<v>v^<<v><^>>^<<^<vv^><<^^vv^v<vvv><vv^^^<^^^^<vv><<v<v><^v<v^<^vv^>^^<><<>^^^v^<^<<^^v<^><^<<<><><<vv>>^>>>v<<^v^<v><^vv<>><>>^^v<<v><<>>^<>>>^<>^vv<<>v<>vvv>v<^^^v<>>v><^v^^<^^>v<><<^<<^>^^vv>v<v^v><>^^^vv^^>>^vvv>>^>>^v^^>v<>><^><vvvv<><v><^v^>>",
            "<v^<^v^^>><^>v><^^<><>v>^>v^<>v<<vvvv>v^^>>^<<vv^vvv>^v^><^>^>>><v^^<>^>>^<v^<^v^^<v^v^>v<>v^<vv^><><v<^<v^v^^><v<^>v^<<<><^v^^>v><>v^<vv<>><^>>^^vv>^^>>vv^<<<^v^vv^>>^<<v>>v>^><vv^^v<^>>v^<^><^<^^^>^^>^v<<>v^<^v>v><<v<<v^>^v^>^^<v<><<^>^v^^vv>vv^^^v>^v>>vv^v^^^>^v^^^^<<<>^^vv^^^><<^vvv^v<vvv><>^<v^v^<v^^<^vvvv<^^<vv<^<>><<v^^>^v^^<^v>^^<v^>^^>>>^<>v^^vv^v^v<v>>><^<>^^><>v<>^<<>>>v<^^<<>>^>>^^^><<><><v^^v<>v^<><>v<>v^<>v^^<^v^^^<>^^v><<^v<v^v>><<>v>v^^v^<<>>^^<>><^^<<<>^v^><^<<^^^^>><^<^^<<v^^><><v><<v^>v^>>^v^>>vvv^^v<^^v^>>v^v><^>^>>^>vv<^><<^^^><>^<v^^v<<<<^^vv^^vv>>^<<<>^>>vv<<v<>>v^v>^^^<^<v^>>^<^>^v^>>^^>>^vv^><^v>>^><<>>^>>v^v<>^^v<<<<^<>v^>><>>v^v^^^^^^vv>vv<^v^><^<>vv>^v<><>vv><v>>^>v^vv^><<><v<vv><<<<v>>^^v<v>>^v>^^><v<v^vv^v^^v<<^<^^v^<<^><<>><vv<^><^>>v^<^^><>^^<>v<^<v<<>>^v^v>>>><vv>v><>>><><^<>^<><v<v>v^>v<>vv<^<<vvv<><v>v<v^v^v>^>vv>^>^^<>v^v>>^><>><<v><<v>>>>v^>>v<v<>v<<<>v><^^^>>^vv^>^v><^^>^^<v^^>^^v><<>v<^<^>^v^<>^><^>><>^>^>>^>^^v>^v<^>^>^><<><>^>>^<v<^>v^<^><v><>^>",
            "v>>v^<v^>v^<>>><vv>v^<<>v<<v>>v><>^<>vv<^^^v<<v^v<^><>>>>>^^v^^<<<><>>^v^v^^v>>>><vv<<>>v^<vv><^^^>v^<v^>><<v>v<<<<>v<>>><<<vv<<>^^>v>^v<v><v>>><^<^><^<>vv>v<>vv<><v>^>^v^^v<<>vv<v>v<<<^v>^><<<>^>v><<><^<>^^^^v^>^><>><v^>>^<v<><>^^<^><>>v<v>vv>^<v^^>^<^^><^^<v>v^<^>>vvv<vvv>v>>><<<><<><>vv^^<v^>^^<>>><>>v>^>^<>>v><v^^vv^vv^<><^<vv>>v<^<<^^<<^>>v>><<v<^v<<<>^>>>^v^<v^<vv>>^v<^vv<v^vv^<v<v<<<v<v<^^<v^<><<^<v<<>>v>^vv^><^v<<v>^v>>v^v^><^<^^>^>vv>>^^<><v>v^^<v^^>>>v^>><>>^<>>>>>v>v<<vv^>v^^^^<v>><><^<^^<v>^^>^>^<<<><v^<>>v><<<>^v^^<v>>^>^><>^v>><vvv>v>^><^^<v<><vv^>v^<<<^v^^^v<>v><^^<vv^^v><^v><^^^>^<>vv^^v<vv>^^<<^^><><><<^>^v>><v^>^>>^^v>>^>>>v^<^<^<v<>v<<<<vv^^><<>^>v^^>^>vvv>>^v>^^^><><^<vv<><<<>v>v>v^<<^^<^vv^<vv^>>^v<<^<>^>>^>^<^^v<v<>>v>>^<^>^<^>^^<^>>>><<<vv>vv^^^<^<v><<^^<v^^<>><<v>^v^v^^^^vv^><<v<^<><>^v<^v<^>v^<><^^^>^v<>><^<^v<^v<^^>^<v^v^^^>v^><v>vv<>^><v>>v>v>^<vvvv<^>v<v<>v^<<<v<>v^^^^><<v^^^<^^<v>v>^>v>^v<^<^><<v^v<<^^v>>>><^<>v^><<v<^^^<v<<^vv>^^<^<>v^vv><<<^<<>v^<>^v><^<<",
            "^<^^><v<vv<<<>vvv<v^>>^^><^vv><<^^<<>>>v^v<><v^><v>>>>>^<v^<>^><>vvv^^^<vv>><^<v^><v^^>vv^<>^^v^^v<v^v<>vv>^v^<<<<v>>v<>>><v>^<<>^>>v><^^^>v><<vv<>v<^<<<vv^^^<^>>^<v<>>^>v<><<<><><<vv<^><><><<vv<>>^<<v^>>v>>^<v<v>>><<><v><<><^<>^v^<>^vvv^v<^<<^v^<<^v<^v^^^^v<^>^^<vv>v^><^^^>v>v^>^<>v>vvv^<>v^v<^>>^^>^>^<>>^^<<^>v<<>>^>^<<<><^vv><>><><<^><v^vv<^>v>>^v>^^vv^^<v>^<<v<^<<<^<><v^>v>vv<^><^v^v>vv^>>>v>^>^>vv^>v<v>>vvv^<^v^^<<>><vvv<<v>>^<><<>^<^>^vv^>^vvvv<><<<<^^>v><^^v>^<>>vv^<^v>><^>>^>><^v<^^^>v><<^<<>^^v>vv><^>v^v<>><vv^v>^^<^><^>^>v<<><^<v>^<v^<v<<^^vv<>v^>^^vv>^<vvv<^v>^v><v^v>^<><<><<v>v<^>>v<>^>><v^<<><<><vv<^<>>^v<v<<>>><v^><<<vv<>>v^>vv^^^^<v^^^^vv<^v<<^vv><<v^<<><>^>vv>>^>^>^<>vv><<^^><v^vv<<^><vv^^<^<>^v>^<v<vv^^><^v>^^^<>^vv<v>v>vv>^^><v^^^<^^v<v<<vvv<>v><>>^>>vv^^v^><<<^^<v<v<v>>><v>^^^>^vvv^v<<^<>vv^<<>>><<^<>><>><v><^<v><^vv<^^<v^^v<vvv<<vvv><vvv^vvvv^^<^<^^^<^<^v><^^^<v>v^<<^^>^vvvv^<<vv<^^v^>v>vv<vv<>v^v^^v<^vvv^>>v^<v<^<><v<><v<^v<vv<v<v><^>>^><^v>^vvvv><v<>^^^vv>v^<><^vv",
            "^><<^<<>v^>>v><vvv^v<^>vvvv<>^>>vv<^>>v<v^<<>^^<^<^^^^^^<<^<v^>v^>^^vv^^>v<^><^^><v^<v><<^v>v>>>^^<v>><^^>><<^^>^^^<v^>vv<><vv>>>vv^v^<>v<><^>>v^<v>v>^><<v^v>>^v^^^<<<>v^><v^<^vv<>>>>^>>>>^v^v>><<^>^>>^><^v^>^<v<v><<^>>^>^v<<v^<>^v^v<^>vv>vv^v^<vv<v>^^^v^^>vv>^^^>>v^<<v<>^^<<v>v^v^<v^v><<<v<vv<^v^^vv<vv^vv<<v>><^>v<v<<v>><v^^^<^<v^<>v^vv^>><^>v>>^><<v<^<^v^<<><>v>^<>>v><<^^vv<<v<>^<v^^v^vv>>^v><<>v>v<^<vv^^>v>^<^^<v^^<<v<^<^^>^<^v>>^<<v<>><v<v>v^^^>vv^>^<>v^>v^<<>^<><^>v<v<<v><^<<vvv>^v<><v^><><>>>^<<^<<>v<v<><<^<v<>v>vv>v<><<^v>>><v<^^v^<v>vv>>^<<v^<^>^><<<v^>>^<v>v<<>^>v>>>v<v^vv>^^v<v<<^<^^>^<>>vvvv^v>^^vv^<^><v><<^^><>>><<>^<v^^vv>><<^v><><v<vv><v<<><><vvv^<^^<^><<^<<^<><><>vv<>>^>^^vvv<v^v<<v<><<>^^^^vv<><>^<><v>^<>>>v^v<>^><<<<^<^>^<>vv<>^<v^v<>>><vv>v^<^<><<^>vv^v>v>^>>>^vv<><^>>>>>^^<>^>^^>^^>>vv>v>vv^^v<><v^<^><^<<>v>^<><^v<<><^v><><>^^<^^v^>^^>v^<><><^>v><^><<^vv<<<>^v^<<^^<^<><^<>^<><v<v<^<^<vvv>>><<<v^v^>vv<^>v><<><<^<^v>vv^<>^^v>v^>^<<>v><^<><<v<v><>>^>>v>v>^>v<>^<<v^vvvv>",
            "^^^<><vv<><<<vv<^v>v>>v><><v>><<<v^^vv<><^v><>vv^<^><<<^v>>vv>v<>v<><>>>^^v>>vv<^^<<<v>^^^>v<<>^v^^<<^>^v^<<<<^^>>vv><>>^<v^^v^<<><>>>v>^<v><vv><<v<>^>^<<^v^<>^>vvvv>>>>^><^vv>>^<<^>v^<^^>vv^^>v<<>^<>>v<<^<vvv<^^^><>v>>>^><^^<^><^^<>^>v<>>><<<v^v^vvvvvv^<<^v>><<^><>>v<^<v^<^<>>><v<>vv^><v><^^>v<^vv><><<^<<vv^v>v^><v>^^v<^<v<v^vv>>^^<<<<vvvvvv^>v<>><v>>>^<<^^<v>>^<<v^><><>vv<v^^^<^><>^v^<v^vv^vv>><<^><><v^>^v>^v<v<>^v^v>v>^^v><<>v<<<<>v>v>^<><<><><>v<v^^>^vv>vv><<><<><v<v>^^^^^vv><vvv<><><>><<<>>^>^v>^^<^v^^^>v^><v><><<^<v>^><>vv>vv<^^v<^><^><^<v^<>^<>v^vv<v^v>^>v^^>^^>><>^>>>vv<^^^<<<>v^><<^v><>v><<vv^^><vv^<^><<>>>^^><v<v><<<vv^v><>v><<^<^<v<v^<^<vv<>>><><v^>vv<<v^<vv><v^<><>^v^><><<<v<^^^>v<<vv<<^>>>^^v><>>>vv>><vvv^vv^><<<^v^^^vv<<<^^^<>><v^<v>v>>^><>^^vv<^^vv<^^^vv^>v^>^^<v<v>>>vv^v<<<v^vvv><v<^><v^>^^<v<^>v<^<^v>v^<^v^<^<>>v>>>>v^v>^^<v><^v^v<v<v<>><v^v<>v<^>v<>^<vv>^^<<vvvv<^v^<<<>v^v<^v<><^>><^^^v<<^^<v^v^>>vv^<vvv>>>v>^^>>>^>>^v^>>><>>>>^v^vv<^>><^<v>v>^v><>^^><>v<<v<>>>^<<>><^",
            ">v^^v<<>>^>^<v<<<^^vv<<><^^^v>^>^>v^<>^^<^v><<v>v^><v^>^>>>vv^vv<<<v^<v>^vv^v><^v<<^vv>>^><v>v><>v^v<<>v<<v^v>v><><v>^v<v<v>v^^v>^^>^><^<^v<^>v<vv><v<^^>v<>>^^^v<^vvv<>^<<><>^<^>^v>>^>v<^^>v><<>v<^^>>><^<^>vv<>^<v^<^^<>^^vv>^v><^<^v^^v^><<<^<v>vv<<^^v^^^<^^^^vv>^v>^v^<<v>v^<v>>v<^v>^v^<^><<vv>>v>^>^^<vv<>^^vvvv>^>vvv>><v>vv<v>^><v<^^>>^^vvv>v<<vvv<^^><>v<v<<<<><v^v<<<^^>v<v>>>^>vv^<><v^<v>v<<<>^^v<>^v^v>v>>^<<>>^v>^<v>^<^>^<><>^v^^>>v^<<v><v^>vvv^>><^^>>v^<>^^^>>>><^>^<<^>^<><^<^v>^>^<<v<v<>^^v^^>v><<<<v>>>v^<<^>v^v<><^<>^^vv^vv<^<^v<^^><<v<><^><^<>v^v<^^<^<<^^>><<>^>^>^><<^^v^<>^^^<^>^<>>><v><^^<^^>v^v>^^>^<^vv^>v^<v>^>v><>v^v<<v^v>>>^v<vv<v>>^^^<^^<v<<vv^>^>^<>>^>v^^v<v>^<<>>>^v^>^<^^<^v>^<vvv<^^v^>^<v<^vv<>><<<^v^v><^v^<v^<<>^>^>^<^^^>><><v<v<<vv>^^><>><^v><v^v<><<^^v>>^v<v>>v<>v>^>vvv>>v>^<^^v>vv^^<^>^<><>>>>v^^^v^<<>>v>v^>^<<v^>^><<^v<>>v>^^<<<>^>vv<^^v<>>^<><<<v^v<v>><>^<>>v<^v^<<<<>>>><v>^>vv<v>>^^>v^v><^v<v^><>^<<>v^<^<^<v<><>v<>^v>v>v>^v^^<<<><v^v><<>>v><>v<>^vv<v<vvv^^<<>^<^v"
        ];

        private enum WarehouseItemType
        {
            Wall,
            Box,
            LBox,
            RBox,
            Robot,
            Space
        }

        private static readonly (int dx, int dy)[] Directions = [(0, -1), (1, 0), (0, +1), (-1, 0)];

        private class WarehouseItem((int x, int y) startingLocation, WarehouseItemType warehouseItemType)
        {
            public (int x, int y) CurrentPosition { get; set; } = startingLocation;
            public WarehouseItemType WarehouseItemType { get; } = warehouseItemType;
        }

        private static void Execute(string[] inputdata)
        {
            List<WarehouseItem> warehouseMap;

            var dataBreakLine = Array.FindIndex(inputdata, string.IsNullOrEmpty);

            for (int part = 0; part < 2; part++)
            {
                warehouseMap = inputdata.Take(dataBreakLine).SelectMany((line, row) => line.Select((ch, col) => (ch, col, row))).Aggregate(new List<WarehouseItem>(), (curr, next) =>
                {
                    if (next.ch != '.')
                    {
                        curr.Add(new WarehouseItem((next.col * (part + 1), next.row), next.ch switch
                        {
                            '#' => WarehouseItemType.Wall,
                            'O' => part == 0 ? WarehouseItemType.Box : WarehouseItemType.LBox,
                            '@' => WarehouseItemType.Robot,
                            _ => WarehouseItemType.Space
                        }));

                        if (part == 1 && next.ch != '@')
                        {
                            curr.Add(new WarehouseItem((next.col * (part + 1) + 1, next.row), next.ch switch
                            {
                                '#' => WarehouseItemType.Wall,
                                'O' => WarehouseItemType.RBox,
                                '@' => WarehouseItemType.Robot,
                                _ => WarehouseItemType.Space
                            }));

                        }
                    }
                    return curr;
                });

                WarehouseItem robot = warehouseMap.First(wi => wi.WarehouseItemType == WarehouseItemType.Robot);

                foreach (char instruction in inputdata.Skip(dataBreakLine + 1).Aggregate(new StringBuilder(), (curr, next) => curr.Append(next), sb => sb.ToString()))
                {
                    (int dx, int dy) direction = Directions[instruction switch { '^' => 0, '>' => 1, 'v' => 2, _ => 3 }];

                    (int x, int y) nextLocation = (robot.CurrentPosition.x + direction.dx, robot.CurrentPosition.y + direction.dy);

                    switch (ItemType(nextLocation))
                    {
                        case WarehouseItemType.Space:
                            robot.CurrentPosition = nextLocation;
                            break;

                        case WarehouseItemType.LBox:
                        case WarehouseItemType.RBox:
                            if (PushBox(nextLocation, direction))
                            {
                                robot.CurrentPosition = nextLocation;
                            }
                            break;

                        case WarehouseItemType.Box:
                            if (PushBox(nextLocation, direction))
                            {
                                robot.CurrentPosition = nextLocation;
                            }
                            break;
                    }
                }

                Console.WriteLine($"Day 15 Part {part + 1} Answer is gps position {warehouseMap.Where(whi => whi.WarehouseItemType is WarehouseItemType.Box or WarehouseItemType.LBox).Sum(whi => whi.CurrentPosition.y * 100 + whi.CurrentPosition.x)}.");
            }



            return;

            bool PushBox((int x, int y) sourceLocation, (int dx, int dy) direction, bool test = false)
            {
                bool retval = false;

                bool doubleWidth = ItemType(sourceLocation) != WarehouseItemType.Box;

                (int x, int y) destLocation = (sourceLocation.x + direction.dx, sourceLocation.y + direction.dy);
                (int x, int y) peekLocation = (sourceLocation.x + direction.dx * (doubleWidth ? 2 : 1), sourceLocation.y + direction.dy);

                if (ItemType(peekLocation) == WarehouseItemType.Space && (direction.dx != 0 || !doubleWidth || ItemType((destLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), destLocation.y)) == WarehouseItemType.Space))
                {
                    if (!test)
                    {
                        if (doubleWidth)
                        {
                            if (direction.dx != 0) // move on x axis
                            {
                                warehouseMap.First(m => m.CurrentPosition == (sourceLocation.x + direction.dx, sourceLocation.y)).CurrentPosition = (destLocation.x + direction.dx, destLocation.y);
                            }
                            else // move on y axis
                            {
                                warehouseMap.First(m => m.CurrentPosition == (sourceLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), sourceLocation.y)).CurrentPosition = (destLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), destLocation.y);
                            }
                        }
                        warehouseMap.First(m => m.CurrentPosition == sourceLocation).CurrentPosition = destLocation;
                    }
                    retval = true;
                }
                else if (ItemType(peekLocation) != WarehouseItemType.Box && (ItemType(peekLocation) is WarehouseItemType.LBox or WarehouseItemType.RBox || direction.dx != 0 || ItemType((peekLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), peekLocation.y)) is WarehouseItemType.LBox or WarehouseItemType.RBox)
                         && ItemType(peekLocation) != WarehouseItemType.Wall && (direction.dx != 0 || ItemType((peekLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), peekLocation.y)) != WarehouseItemType.Wall)) // if there are double width boxes above this one.
                {
                    if (direction.dx != 0) // move on x axis
                    {
                        retval = PushBox(peekLocation, direction);
                        if (retval & !test)
                        {
                            warehouseMap.First(m => m.CurrentPosition == (sourceLocation.x + direction.dx, sourceLocation.y)).CurrentPosition = (destLocation.x + direction.dx, destLocation.y);
                            warehouseMap.First(m => m.CurrentPosition == sourceLocation).CurrentPosition = destLocation;
                        }
                    }
                    else
                    {
                        IEnumerable<WarehouseItem> locations = warehouseMap.Where(whi => whi.CurrentPosition.y == peekLocation.y && whi.WarehouseItemType == WarehouseItemType.LBox && whi.CurrentPosition.x >= peekLocation.x - (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : 2) && whi.CurrentPosition.x <= destLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : 0) && whi.CurrentPosition.y == destLocation.y);

                        retval = locations.All(whi => PushBox(whi.CurrentPosition, direction, true));

                        if (retval & !test)
                        {
                            foreach (WarehouseItem whi in locations)
                            {
                                PushBox(whi.CurrentPosition, direction);
                            }
                            warehouseMap.First(m => m.CurrentPosition == (sourceLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), sourceLocation.y)).CurrentPosition = (destLocation.x + (ItemType(sourceLocation) == WarehouseItemType.LBox ? 1 : -1), destLocation.y);
                            warehouseMap.First(m => m.CurrentPosition == sourceLocation).CurrentPosition = destLocation;
                        }

                    }
                }
                else if (ItemType(peekLocation) == WarehouseItemType.Box)
                {
                    retval = PushBox(destLocation, direction);
                    if (retval)
                    {
                        warehouseMap.First(m => m.CurrentPosition == sourceLocation).CurrentPosition = destLocation;
                    }
                }

                return retval;
            }

            WarehouseItemType ItemType((int x, int y) location) => warehouseMap.FirstOrDefault(wi => wi.CurrentPosition == location)?.WarehouseItemType ?? WarehouseItemType.Space;
        }

        public static void Run() => Execute(Data);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day15
    {
        public static void Run()
        {
            int maxScore = 0;
            int maxScoreCal = 0;

            for (int frosting = 0; frosting < 100 - 3; frosting++)
            {
                for (int candy = 0; candy < 100 - frosting - 2; candy++)
                {
                    for (int butterscotch = 0; butterscotch < 100 - frosting - candy - 1; butterscotch++)
                    {
                        int sugar = 100 - frosting - candy - butterscotch;
                        int capacity = Math.Max(0, frosting * 4 + candy * 0 + butterscotch * -1 + sugar * 0);
                        int durability = Math.Max(0, frosting * -2 + candy * 5 + butterscotch * 0 + sugar * 0);
                        int flavour = Math.Max(0, frosting * 0 + candy * -1 + butterscotch * 5 + sugar * -2);
                        int texture = Math.Max(0, frosting * 0 + candy * 0 + butterscotch * 0 + sugar * 2);
                        int calories = frosting * 5 + candy * 8 + butterscotch * 6 + sugar * 1;

                        maxScore = Math.Max(capacity * durability * flavour * texture, maxScore);

                        if (calories == 500)
                        {
                            maxScoreCal = Math.Max(capacity * durability * flavour * texture, maxScoreCal);
                        }
                    }
                }
            }

            Console.WriteLine($"Day 15 Part 1 Answer is Score {maxScore}.");
            Console.WriteLine($"Day 15 Part 2 Answer is Score {maxScoreCal}.");
        }
    }
}

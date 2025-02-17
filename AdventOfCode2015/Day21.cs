namespace AdventOfCode2015
{
    internal enum Weapon {Dagger, Shortsword, Warhammer, Longsword, Greataxe}

    internal enum Armour {None, Leather, Chainmail, Splintmail, Bandedmail, Platemail}

    internal enum Ring {None, Damage1, Damage2, Damage3, Defense1, Defense2, Defense3}

    internal class Day21
    {
        private static readonly Dictionary<Weapon, (int Cost, int Damage, int Armour)> WeaponData = new()
        {
            {Weapon.Dagger, (8, 4, 0)},
            {Weapon.Shortsword, (10, 5, 0)},
            {Weapon.Warhammer, (25, 6, 0)},
            {Weapon.Longsword, (40, 7, 0)},
            {Weapon.Greataxe, (74, 8, 0)}
        };

        private static readonly Dictionary<Armour, (int Cost, int Damage, int Armour)> ArmourData = new()
        {
            {Armour.Leather, (13, 0, 1)},
            {Armour.Chainmail, (31, 0, 2)},
            {Armour.Splintmail, (53, 0, 3)},
            {Armour.Bandedmail, (75, 0, 4)},
            {Armour.Platemail, (102, 0, 5)},
            {Armour.None, (0, 0, 0)}
        };

        private static readonly Dictionary<Ring, (int Cost, int Damage, int Armour)> RingData = new()
        {
            {Ring.Damage1, (25, 1, 0)},
            {Ring.Damage2, (50, 2, 0)},
            {Ring.Damage3, (100, 3, 0)},
            {Ring.Defense1, (20, 0, 1)},
            {Ring.Defense2, (40, 0, 2)},
            {Ring.Defense3, (80, 0, 3)},
            {Ring.None, (0, 0, 0)}
        };

        private static void Execute()
        {
            int minGold = int.MaxValue;
            int maxGold = 0;

            foreach (Weapon weapon in Enum.GetValues<Weapon>())
            {
                foreach (Armour armour in Enum.GetValues<Armour>())
                {
                    foreach (Ring ring1 in Enum.GetValues<Ring>())
                    {
                        foreach (Ring ring2 in Enum.GetValues<Ring>().Where(r => r == Ring.None || r != ring1))
                        {
                            int cost = WeaponData[weapon].Cost + ArmourData[armour].Cost + RingData[ring1].Cost + RingData[ring2].Cost;

                            if (Math.Ceiling(100 / (double)Math.Max(8 - (ArmourData[armour].Armour + RingData[ring1].Armour + RingData[ring2].Armour), 1)) >= Math.Ceiling(100 / (double)Math.Max(WeaponData[weapon].Damage + RingData[ring1].Damage + RingData[ring2].Damage - 2, 1)))
                            {
                                minGold = Math.Min(minGold, cost);
                            }
                            else
                            {
                                maxGold = Math.Max(maxGold, cost);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Day 21 Part 1 Answer is {minGold} gold.");
            Console.WriteLine($"Day 21 Part 2 Answer is {maxGold} gold.");
        }

        public static void Run() => Execute();
    }
}

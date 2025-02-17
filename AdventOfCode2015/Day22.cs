using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2015
{
    internal enum Spell {MagicMissile, Drain, Shield, Poison, Recharge}

    internal enum GameResult {Win, Lose, Continue}

    internal class Day22
    {
        private static readonly Dictionary<Spell, (int cost, int damage, int armour, int heal, int mana, int turns)> SpellData = new()
        {
            {Spell.MagicMissile, (53, 4, 0, 0, 0, 1)},
            {Spell.Drain, (73, 2, 0, 2, 0, 1)},
            {Spell.Shield, (113, 4, 7, 0, 0, 6)},
            {Spell.Poison, (173, 3, 0, 0, 0, 6)},
            {Spell.Recharge, (229, 0, 0, 0, 101, 5)}
        };


        private static (int playerHitpoints, int playerMana, int bossHitpoints) GameStep(Spell spell, int playerHitpoints, int playerMana, int bossHitpoints, int bossDamage, List<(Spell spell, int timer)> effects)
        {
            (int playerHitpoints, int playerMana, int bossHitpoints) retval = (playerHitpoints, playerMana, bossHitpoints);
            int armour = 0;

            bool GameOver() => (retval.playerHitpoints < 1 || retval.playerMana < 1 || retval.bossHitpoints < 1);

            void ProcessEffects()
            {
                armour = 0;
                List<(Spell spell, int)> newEffects = effects.Where(e => e.timer > 0).Select(e => (e.spell, e.timer - 1)).ToList();
                effects.Clear();
                effects.AddRange(newEffects);
                foreach (var effect in effects)
                {
                    switch (effect.spell)
                    {
                        case Spell.Shield:
                            armour = 7;
                            break;
                        case Spell.Poison:
                            retval.bossHitpoints -= 3;
                            break;
                        case Spell.Recharge:
                            retval.playerMana += 101;
                            break;
                    }
                }
            }

            if (!GameOver())
            {
                retval.playerMana -= SpellData[spell].cost;
                ProcessEffects();

                if (!GameOver())
                {
                    if (spell is Spell.MagicMissile or Spell.Drain)
                    {
                        retval.bossHitpoints -= SpellData[spell].damage;
                        if (!GameOver())
                        {
                            retval.playerHitpoints += SpellData[spell].heal;
                        }
                    }
                    else
                    {
                        effects.Add((spell, SpellData[spell].turns));
                    }
                }
            }

            if (!GameOver())
            {
                ProcessEffects();
                if (!GameOver())
                {
                    retval.playerHitpoints -= bossDamage - armour;
                }
            }

            return retval;
        }

        private static GameResult Game(List<Spell> spells, int playerHitpoints, int playerMana, int bossHitpoints, int bossDamage)
        {
            List<(Spell spell, int timer)> effects = [];

            (int playerHitpoints, int playerMana, int bossHitpoints) state = (playerHitpoints, playerMana, bossHitpoints);

            foreach (Spell spell in spells)
            {
                state = GameStep(spell, state.playerHitpoints, state.playerMana, state.bossHitpoints, bossDamage, effects);

                if (state.playerHitpoints < 1 || state.playerMana < 1 || state.bossHitpoints < 1)
                {
                    break;
                }
            }

            return state.bossHitpoints switch
            {
                > 0 when state is {playerHitpoints: > 0, playerMana: > 0} => GameResult.Continue,
                <= 0 => GameResult.Win,
                _ => GameResult.Lose
            };
        }

        private static void Execute()
        {
            var r = GameStep(Spell.Recharge, 10, 250, 14, 8, effects);
            r = GameStep(Spell.Shield, r.playerHitpoints, r.playerMana, r.bossHitpoints, 8, effects);
            r = GameStep(Spell.Drain, r.playerHitpoints, r.playerMana, r.bossHitpoints, 8, effects);
            r = GameStep(Spell.Poison, r.playerHitpoints, r.playerMana, r.bossHitpoints, 8, effects);
            r = GameStep(Spell.MagicMissile, r.playerHitpoints, r.playerMana, r.bossHitpoints, 8, effects);

            Console.WriteLine($"Day n Part 1 Answer is calibration value {1}.");
        }

        public static void Run() => Execute();
    }
}

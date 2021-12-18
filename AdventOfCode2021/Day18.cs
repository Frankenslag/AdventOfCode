using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Snailfish
    {
        public int LValue;
        public int RValue;

        public Snailfish? LChild;
        public Snailfish? RChild;

        public string Dump()
        {
            return $"[{(LChild == null ? LValue : LChild.Dump())},{(RChild == null ? RValue : RChild.Dump())}]";
        }

        public bool Split()
        {
            bool retval = false;

            if (LChild == null)
            {
                if (LValue > 9)
                {
                    LChild = new Snailfish();
                    LChild.LValue = LValue / 2;
                    LChild.RValue = (LValue + 1) / 2;
                    LValue = 0;
                    retval = true;
                }
            }
            else
            {
                retval = LChild.Split();
            }

            if (!retval)
            {
                if (RChild == null)
                {
                    if (RValue > 9)
                    {
                        RChild = new Snailfish();
                        RChild.LValue = RValue / 2;
                        RChild.RValue = (RValue + 1) / 2;
                        RValue = 0;
                        retval = true;
                    }
                }
                else
                {
                    retval = RChild.Split();
                }
            }

            return retval;
        }

        public Snailfish? Explode(int depth = 0)
        {
            Snailfish? retval = null;

            if (LChild != null)
            {
                if (depth < 3)
                {
                    retval = LChild.Explode(depth + 1);
                }
                else
                {
                    retval = LChild;
                    LChild = null;
                    LValue = 0;
                    if (RChild == null)
                    {
                        RValue += retval.RValue;
                        retval.RValue = 0;
                    }
                }
            }

            if (retval == null && RChild != null)
            {
                if (depth < 3)
                {
                    retval = RChild.Explode(depth + 1);
                }
                else
                {
                    retval = RChild;
                    RChild = null;
                    RValue = 0;
                    if (LChild == null)
                    {
                        LValue += retval.LValue;
                        retval.LValue = 0;
                    }
                }
            }

            if (retval != null && depth < 3)
            {
                if (retval.LValue > 0 && LChild == null)
                {
                    LValue += retval.LValue;
                    retval.LValue = 0;
                }
                if (retval.RValue > 0 && RChild == null)
                {
                    RValue += retval.RValue;
                    retval.LValue = 0;
                }

            }

            return retval;
        }

        public Snailfish Add(Snailfish rFish)
        {
            bool blnContinue = true;

            Snailfish retval = new() {LChild = this, RChild = rFish};

            while (blnContinue)
            {
                Console.WriteLine(retval.Dump());

                blnContinue = retval.Explode() != null;

                if (!blnContinue)
                {
                    blnContinue = retval.Split();
                }
            }

            return retval;
        }

        public Snailfish()
        {
        }

        public Snailfish(string strLine)
        {
            void parseValue(string str, out int val, ref Snailfish child)
            {
                if (!int.TryParse(str, out val))
                {
                    child = new Snailfish(str);
                }
            }

            if (strLine.StartsWith('[') && strLine.EndsWith(']') && strLine.Length > 2)
            {

                int i;
                int depth = 0;

                strLine = strLine[1..^1];

                for (i = 0; i < strLine.Length; i++)
                {
                    if (strLine[i] == ',' && depth == 0)
                    {
                        break;
                    }
                    else if (strLine[i] == '[')
                    {
                        depth++;
                    }
                    else
                    if (strLine[i] == ']')
                    {
                        depth--;
                    }
                }

                if (i < strLine.Length)
                {
                    parseValue(strLine[..i], out LValue, ref LChild);
                    parseValue(strLine[(i + 1)..], out RValue, ref RChild);
                }
            }
        }
    }
    internal class Day18
    {
        private static string[] data =
        {
            "[1,2]",
            "[[1,2],3]",
            "[9,[8,7]]",
            "[[1,9],[8,5]]",
            "[[[[1,2],[3,4]],[[5,6],[7,8]]],9]",
            "[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]",
            "[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]"
        };

        public static void Run()
        {
            Snailfish x = new Snailfish("[[[0,7],4],[[7,8],[0,[6,7]]]]");

            
            var p = x.Add(new Snailfish("[1,1]"));

            return;

            Snailfish? accumulator = null;

            foreach (string line in data)
            {
                if (accumulator == null)
                {
                    accumulator = new Snailfish(line);
                }
                else
                {
                    accumulator.Add(new Snailfish(line));
                }
            }
        }

    }
}

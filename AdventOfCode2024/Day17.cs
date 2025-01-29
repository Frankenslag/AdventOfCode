using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    internal class Day17
    {
        private static readonly string[] Data =
        [
            "Register A: 27575648",
            "Register B: 0",
            "Register C: 0",
            "",
            "Program: 2,4,1,2,7,5,4,1,1,3,5,5,0,3,3,0"
        ];

        // bst 4 B = A % 8
        // Bxl 2  B = B ^ 2
        // Cdv 5 C = A / 2^B
        // Bxc B = B ^ C
        // Bxl 3 B = B ^ 3
        // Out 5 Out B
        // Adv 3 A = A / 8
        // JNZ 0

        private enum Opcode
        {
            Adv, Bxl, Bst, Jnz, Bxc, Out, Bdv, Cdv
        }

        private static long Machine(long a, long b, long c, int[] instructions)
        {
            long[] registers = [a, b, c];

            long retval = 0;

            long ComboOperand(int operand) => operand < 4 ? operand : registers[operand - 4];

            int ip = 0;

            while (ip < instructions.Length)
            {
                int operand = instructions[ip + 1];

                switch ((Opcode)instructions[ip])
                {
                    case Opcode.Adv:
                        registers[0] /= 1L << (int)ComboOperand(operand);
                        break;

                    case Opcode.Bxl:
                        registers[1] ^= operand;
                        break;

                    case Opcode.Bst:
                        registers[1] = ComboOperand(operand) % 8;
                        break;

                    case Opcode.Jnz:
                        ip = registers[0] != 0 ? operand - 2 : ip;
                        break;

                    case Opcode.Bxc:
                        registers[1] ^= registers[2];
                        break;

                    case Opcode.Out:
                        retval <<= 3;
                        retval |= (uint)(ComboOperand(operand) % 8);
                        break;

                    case Opcode.Bdv:
                        registers[1] = registers[0] / (1 << (int)ComboOperand(operand));
                        break;

                    case Opcode.Cdv:
                        registers[2] = registers[0] / (1 << (int)ComboOperand(operand));
                        break;

                    default:
                        throw new Exception();
                }

                ip += 2;
            }

            return retval;
        }

        private static long Part2(long b, long c, int[] instructions)
        {
            List<long> retval = [];

            void Traverse(long lead = 0, int index = 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    var res = Convert.ToString(Machine(i + lead, b, c, instructions), 8).PadLeft(index + 1, '0').Select(chr => int.Parse(chr.ToString())).ToArray();

                    if (res.SequenceEqual(instructions[(15 - index)..]))
                    {
                        if (index < 15)
                        {
                            Traverse((i + lead) * 8, index + 1);
                        }
                        else
                        {
                            retval.Add(i + lead);
                        }
                    }
                }

            }

            Traverse();

            return retval.Min();
        }

        private static void Execute(string[] inputdata)
        {
            Regex rxReg = new(@".+:\s+([0-9]+)");
            Regex rxInstructions = new(@".+:\s+(.*)");

            int[] registers = inputdata.Take(3).Select(s => int.Parse(rxReg.Match(s).Groups[1].Value)).ToArray();
            int[] instructions = rxInstructions.Match(inputdata[4]).Groups[1].Value.Split(',').Select(int.Parse).ToArray();

            Console.WriteLine($"Day 17 Part 1 Answer is output {Convert.ToString(Machine(registers[0], registers[1], registers[2], instructions), 8).Aggregate(string.Empty, (curr, next) => $"{curr}{(string.IsNullOrWhiteSpace(curr) ? "" : ",")}{next}")}.");
            Console.WriteLine($"Day 17 Part 1 Answer is A = {Part2(registers[1], registers[2], instructions)}.");
        }

        public static void Run() => Execute(Data);
    }
}

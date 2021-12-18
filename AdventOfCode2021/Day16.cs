using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode2021
{

    internal enum PacketType : byte
    {
        Sum = 0,
        Product = 1,
        Minimum = 2,
        Maximum = 3,
        Literal = 4,
        Greater = 5,
        Lesser = 6,
        Equal = 7
    }

    internal class BitList
    {
        private readonly BitArray _bits;

        public int Length { get; private set; }

        public BitList(string hexData)
        {
            _bits = new BitArray(hexData.ToUpper().ToCharArray().Select((item, idx) => (item > '9' ? item - 'A' + 10 : item - '0', idx)).GroupBy(g => g.idx / 2).Select(v => v.Aggregate<(int, int), byte>(0, (curr, next) => (byte) (curr + (next.Item1 << (next.Item2 % 2 == 0 ? 4 : 0))))).Select(b =>
            {
                byte retval = 0;

                for (int i = 0; i < 8; i++)
                {
                    retval <<= 1;
                    retval |= (byte)(b & 0x01);
                    b >>= 1;
                }

                return retval;
            }).ToArray());

            Length = _bits.Length;
        }

        public BitList(BitArray bitArray)
        {
            _bits = bitArray;
            Length = bitArray.Length;
        }

        public BitList GetSubList(int nBits)
        {
            BitArray retval = new(nBits);

            for (int i = 0; i < nBits; i++)
            {
                retval[i] = _bits[i];
            }

            _bits.RightShift(nBits);

            Length -= nBits;

            return new BitList(retval);
        }

        public uint GetData(int nBits)
        {
            uint retval = 0;

            for (int i = 0; i < nBits; i++)
            {
                retval <<= 1;
                retval |= _bits[i] ? (uint)1 : 0;
            }

            _bits.RightShift(nBits);

            Length -= nBits;

            return retval;
        }
    }

    internal class OperatorPacket : Packet
    {
        public List<Packet> SubPackets { get; private set; } = new List<Packet>();

        public override int VersionSum => PacketVersion + SubPackets.Sum(p => p.VersionSum);

        public override Decimal Value
        {
            get
            {
                Decimal retval = 0;

                switch (PacketType)
                {
                    case PacketType.Sum:
                        retval = SubPackets.Sum(p => p.Value);
                        break;

                    case PacketType.Product:
                        retval = SubPackets.Aggregate<Packet, decimal>(1, (curr, next) => curr * next.Value);
                        break;

                    case PacketType.Minimum:
                        retval = SubPackets.Min(p => p.Value);
                        break;

                    case PacketType.Maximum:
                        retval = SubPackets.Max(p => p.Value);
                        break;

                    case PacketType.Greater:
                        retval = SubPackets[0].Value > SubPackets[1].Value ? (uint)1 : 0;
                        break;

                    case PacketType.Lesser:
                        retval = SubPackets[0].Value < SubPackets[1].Value ? (uint)1 : 0;
                        break;

                    case PacketType.Equal:
                        retval = SubPackets[0].Value == SubPackets[1].Value ? (uint)1 : 0;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return retval;
            }
        }

        public OperatorPacket(byte packetVersion, PacketType packetType, BitList bits)
        {
            PacketVersion = packetVersion;
            PacketType = packetType;

            if (bits.GetData(1) != 0)
            {
                uint numSubs = bits.GetData(11);

                for (int i = 0; i < numSubs; i++)
                {
                    SubPackets.Add(Packet.Factory(bits));
                }
            }
            else
            {
                BitList subBits = bits.GetSubList((int)bits.GetData(15));

                while (subBits.Length > 0)
                {
                    SubPackets.Add(Packet.Factory(subBits));
                }
            }
        }
    }

    internal class LiteralPacket : Packet
    {
        public override Decimal Value { get => _value; }

        public override int VersionSum { get => PacketVersion; }

        private Decimal _value;

        public LiteralPacket(byte packetVersion, PacketType packetType, BitList bits)
        {
            uint v;
            long val = 0;

            PacketVersion = packetVersion;
            PacketType = packetType;
            do
            {
                v = bits.GetData(5);
                val <<= 4;
                val |= v & 0x0F;
            } while ((v & 0x10) != 0);

            _value = val;
        }


    }

    internal abstract class Packet
    {
        public byte PacketVersion { get; protected set; }
        public PacketType PacketType { get; protected set; }

        public abstract int VersionSum { get; }

        public abstract Decimal Value { get; }

        public static Packet Factory(BitList bits)
        {
            Packet retval;

            byte packetVersion = (byte)bits.GetData(3);
            PacketType packetType = (PacketType)bits.GetData(3);

            if (packetType == PacketType.Literal)
            {
                retval = new LiteralPacket(packetVersion, packetType, bits);
            }
            else
            {
                retval = new OperatorPacket(packetVersion, packetType, bits);
            }

            return retval;
        }
    }

    internal class Day16
    {
        private static string data = @"005410C99A9802DA00B43887138F72F4F652CC0159FE05E802B3A572DBBE5AA5F56F6B6A4600FCCAACEA9CE0E1002013A55389B064C0269813952F983595234002DA394615002A47E06C0125CF7B74FE00E6FC470D4C0129260B005E73FCDFC3A5B77BF2FB4E0009C27ECEF293824CC76902B3004F8017A999EC22770412BE2A1004E3DCDFA146D00020670B9C0129A8D79BB7E88926BA401BAD004892BBDEF20D253BE70C53CA5399AB648EBBAAF0BD402B95349201938264C7699C5A0592AF8001E3C09972A949AD4AE2CB3230AC37FC919801F2A7A402978002150E60BC6700043A23C618E20008644782F10C80262F005679A679BE733C3F3005BC01496F60865B39AF8A2478A04017DCBEAB32FA0055E6286D31430300AE7C7E79AE55324CA679F9002239992BC689A8D6FE084012AE73BDFE39EBF186738B33BD9FA91B14CB7785EC01CE4DCE1AE2DCFD7D23098A98411973E30052C012978F7DD089689ACD4A7A80CCEFEB9EC56880485951DB00400010D8A30CA1500021B0D625450700227A30A774B2600ACD56F981E580272AA3319ACC04C015C00AFA4616C63D4DFF289319A9DC401008650927B2232F70784AE0124D65A25FD3A34CC61A6449246986E300425AF873A00CD4401C8A90D60E8803D08A0DC673005E692B000DA85B268E4021D4E41C6802E49AB57D1ED1166AD5F47B4433005F401496867C2B3E7112C0050C20043A17C208B240087425871180C01985D07A22980273247801988803B08A2DC191006A2141289640133E80212C3D2C3F377B09900A53E00900021109623425100723DC6884D3B7CFE1D2C6036D180D053002880BC530025C00F700308096110021C00C001E44C00F001955805A62013D0400B400ED500307400949C00F92972B6BC3F47A96D21C5730047003770004323E44F8B80008441C8F51366F38F240";

        public static void Run()
        {
            Packet packet = Packet.Factory(new BitList(data));

            Console.WriteLine($"Day 16 Part 1 Answer is {packet.VersionSum}.");
            Console.WriteLine($"Day 16 Part 1 Answer is {packet.Value}.");
        }
    }
}

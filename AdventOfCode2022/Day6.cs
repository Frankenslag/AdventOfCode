namespace AdventOfCode2022
{
    internal class Day6
    {
        private const string Data = "qhbhzbzzfrzrbzzcjzjrrvcvrvqvvnggnngcgssswbblplrlflfnnnmmjppgddqndnrnlnccpfcfjcjvjdjqqqmhhmwhwmmsnsvsjvjnvjnvjvsjsmjsjccwcqwcqwqjqwjwmwbmmbzbsbvsslbsbbbntnvvphpqqvrrtbrtrfftppbggpzzfhfcfsfmssffmbmzzmqzzblzzzmwwnggjwgjwgjgpgmmjvvmcvmmcfchfhllwmlljqqldqdqttsgsvscsmsnsmstmtssvgsgddwdffbppwfpplhlchhhdvvdrrmttmptmmmjsmshmmmgqmgggzjgzzmwzwcwhchqqfpfvvbqvbqbrblrrmtmstmmjvmmdnmmzczdzpztppjhjjwzjjjtdjjpljpjcppjllsffhbffbhhgttqjqzzfzbzcbzcbcrrjjrwrgwwbcbpcccctrtqtfqqfjjpgpdgdfgfrggpjjljglgclcqcqmcqmmgjjllpmphpjjgfjjqrrbppwmpmccftctjtjgjtgggzffcggwzzzdjdzzlgzgjzzvqvppczzjnjvvfhhtwtttdwtdtvddpzpnpcnppmvmcmcsmstthctchcggtssdttvztvvldlfftqqbzzjttvzztppscctzccgmcmvmhhchcscbbshbssgwwthwhmwwcgwcwrrvrzvrzzzvhvdvmmprrdmrmfmrmbmjbbmqbmbqqhbbszsjjlqjljtjstshhgphpffdhhtggtgbbqcqgqccfffcpcbpbfppwqpqcclbbwdwsscpchhfpfmpfmflfnnmggwrrznnghgvhhghrrhwrrcschcscqcmcfcvvgzztjtqjjshspsqsmmjnnmttsshvhmmqfqzztbzttvhttmwttnqnfncfcpfflmllmtlmmphmhlmmltmtztcczhzbbfmmlglnnfpppqplljwjfwfdwdzwddszddqzqnzzzwwlzzqvvjlllrwlrrmpmrmbmpplpspqsqmqcmcjjshsvstvvwtvthvvrfvvqmmjpmjmrjmmlvvnnrjjrcrwrhwwqzzvgvngncgcqqcffmfzfssbnbfblbggwhggmtgtvvqhhpttbcbczcjjbqbhqbhqbbccbhbqhbbmppdlpdllbvvdpvdvwvsvppllgblbttmcmtccbsswmswwwzfwfhhtfhthctchcfhhhfjjvhjhgjjjcwjwggrtgrttcqcwcswccfdffvpvtptprrvjjqvjjghggshhwmmcscmsmhmvmppprfrwwrhhvghhtnhncctbbbwzzbgzgdzgdzdpdvpvbbwgbwwrqwrqwqbqvvclccfcfzfdfrrthrrqcqddplpqlppbbfrfmmrmnnwhhgddmwwrzrsswpwhwdwhhsmhshqsqllbvlbllwbwbpwwfwmwsmspsvsdsbscctpctppvvpggtjjdmdqqgqbgglccvzcvcnczcgzgmzznpzzpcpnpvpcvvffrttqrqttflfbfjfnnwnlwlhwwqzqnqfftstdsttglldwwgqwwvqqzczfzdffbfsfssfwswdwnwdnnbcncwctttvsvjsvsrvvbtvvzhhvjvtvtjtsjjvhjjwpjjnzzpczzppgcpgcpgcgsgvsgvsscrcpcpspllzvzddpssssdpsddhffllzmzhzfhhdvhhvbvwwpwqpwqpwwmvwmvwvgvmvpvmpmrmzrrblltjtggvnggvppthhzjhzhffrvrhvrhrlrslsflfhhtvhvmmhppjgpjpcccmqcqvqhvvfssrtmnwjjslwhjgpvrwspjlwdwrmvfgwmplrmjrllndrjzvjfbwvzpjpfqrnjspwcpsgcvdlmfdfrvwdcvmbrnzncgnqlcvgqtpsbbpvprncdsgvpqbpcnffwqmmfsvnzspchhrlnzbhcdfdgtsllmqfbrcqwbmmzrfvsghjpmrndsdbqvtprmblnbvbnpvhtphbpjwdssvwgdzwztbpzdcsqzldjzrgcwhhspblrtncvntppcgttlflflnntcnzpbpgsclcjvbjhldcdzwjjhnfwzjmgcwtljhvbncwqnjhbrhfqcmnsdvntsbgnpqttzvbhzzpdznrhjpnsqzsztsblstbghlpwbmqjctlnqnttwshfvmjdhgbgjdhbzrfjqndrrhlqcmplczjtwpstlsmwwzqzmgvhsvjgbrtfwmvwlbhpccbqvmfmlgmbmbmldbcwmmhpnnbnffbnqgwhclgpzgbpjqvzmqhhhpltnwrdfrrnmlfrzflpnjztlnfzzzgmncprtblpsvrqgrnzbzfzhzhjjjdrnpvjpnwmlmlgvvtqmdvpnhvcrdmthcnnnvhnzmvgrtdvcthgjtvcgmtpsvmfztrflrrzbmcfhftwwcnjfpjtsnzjccmvdnrrwvbfjgcjttdvzncqhlqqphwphclztbhlqcfmnhcjmsscplnrsjqpdzrrzbthbcdnrzgdmstpgqqsvzclvmzjjdfqhhhttwcjtmwcbltghmslqvltqbjqqjpjvgntvnlttjcnhltflglgsmjwjjfldpfgjgrhttbwfhpsdbsmsfmfbtjlnhvjfqjrqhwdrcwpfthdgqzjjjfcvgdffrhvvwzfghpszmjjgscjvjnlgnbfbgfrbbzbzbnzngthrddfmsgsqqdddpfqwlchfblrvjdcgnzfzwmmnmvnzmpfmhbbhsbfdfclzcnbrlgpbsvfgfpshrpvpgccmmghphrcvzwnlqjcfwrtwvlvcsdldldvnpwgrcsqlftllcctnvcwbdswvqlzwzzbpmvvctcrgnjfstbqvnzczrjlljfqzrwtfwmlvvdfbfntrrljtbrtbdfsqpnppfbppbsmghbnqddhrvwmgzttnqjrqlfrdhqjndmnjlbctgclltmznmrqtfjsjwnztdvhnhlfwpnnqlhhsrfzglsnrdnfvrqssbtlthzfnjdvrcgzsbnpdgqhhrlwspfqfqpvzdfwgrlhwplzvbzprsqzcwvhggvzpgjztnvwvddsflgsvqljmmhhdzqsqmthwzvllqwmsnvdpdbjcgdtrsnmwhnzhbhgjssstmhrpssnhnntmrbbbjgmjqtncbdljcgtmbctpgdrnqcnrpssrdtpbsmlzlcztbrggglswnjzqgbsmgbqdzppqrwgtnlrjrvlpnqlcdwhltzzlqdwwrglldzcqrjtjtlgdqrtwzjgtdthsdccsmsrbjjsgdqcwdltvnjwtddsnpnsvzcdbfqnvsjbngqrztmbrnbvhhjzdtqrgldpvjqjpnshbjdsdgbjdjzdmrvzhwmtgcjrfnprstqgfgnwfpcjzhlnwpdbtqbspssqdrzhmmsrqtlwngvbrvgdgztnrlwcnqwvcdmhhdrmpfqbgbjpvzwbsbgcpsnpjplcrjdhflqvsdctclqqnmprngtvbmlmpqrsqdsrzgsmzmsczpsnmfmtfnjvnddjhqbjdvtgftjfvjhgpjqdhlszqjmcbnwrppzwjvmgblspjmfhjdbnmrllnfqlpcbndvqdzhhmmrpsljgdshpnrgnmwfjsdncqcwlctccrqghfdbsqqbnwctcqpvlrqqqvdjwlcnzmvdmcvlwnftjnqqldfwhmdtcpnlgfcdjdrfvmwqdzsjzctmmmrswhlwthttvcsqqscdcsmjgqfjhswlpsfjrppdmbwrthcwszqwwgnjsdqdrswmnzbrvqcwlrlwwvjmrrhsnzprggbzhhdqwvnspsmzzqdtbphzvwrzvqnbntjndrwllzwchczdwvnfjjdwfhdlgncftldzwdtjzjrmnfwwgmqdrltmgrfsjztfcvwjsggtvbnsvthflwfdtljrgqhmfqhmhfffqhtgwtlmwgzsglqnfwnrnvgvbdgqjrqtsmgsmzdpffnnzwlpbqphqmgdzspfrdqlptwmfwlgnqqdhtbbjtfhllrhhdcszjtmrprzhzzlgjqbcnhzcmhzrsnmmrzztffrldthhfvwhgjhwmjfbdvnllfmlpdsldjnpcwlpbwqzdwbgjb";

        public static void Run()
        {
            Queue<char> queue = new(14);

            for (int part = 1; part <= 2; part++)
            {
                int marker = -1;

                queue.Clear();

                for (int i = 0; i < Data.Length; i++)
                {
                    if (queue.Count == (part == 1 ? 4 : 14))
                    {
                        queue.Dequeue();
                    }

                    queue.Enqueue(Data[i]);

                    if (queue.Distinct().Count() == (part == 1 ? 4 : 14))
                    {
                        marker = i + 1;
                        break;
                    }
                }

                Console.WriteLine($"Day 6 Part {part} Marker is after character {marker}.");
            }
        }
    }
}
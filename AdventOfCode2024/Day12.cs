﻿namespace AdventOfCode2024
{
    internal class Day12
    {
        private static readonly string[] Data =
        [
            "OOOBBBBXXXXXXXOOOOOOOAAAAAAAAAOOOOUUUUUUUUUUUUUUUUJJIFFFIIIIRRRRRRRRRRRRRRRRRRRRRNNNVVVVVVVVVVVPPPPPPPPPPPPPDDDDRRDDDDVVVVVVVVVVVGGVVGVVVVVV",
            "OOBBBBBXXXXXXOOOOOOOOOAAAAAAOOOOOOUUUUUUUUUUUUUUUUJJIFIIIIIIIRRRRAAARRRRRRRRRRRRRRVVVVVVVVVVVVVVPNNNNPPGPPPPDDDDDDDDDVVVVVVVVVVVVGGGVGGVVVVV",
            "OBBBBBBXXBXXOOOOOOOOOOAAAAAAOOOOOOUUUUUUUUUUUUUUUUJJIIIIIIIIRRRRAAAARRRRRRRRRRRRRRVVVVVVVVVVVVVFNNNNNPPGGPDDDDDDDDDDPPPVVPVVVVVVGGGGGGVVVVVV",
            "BBBBBBBBBBOOOOOOOOOOOOAAAAAAOOOOOOOOUUUUUUUUUUUUUUUIIIIIIIIRRRAAAAAAARRRRRRRGRRRRRRRVVVVVVVVVVVFNNNNNNPGGGGDBBDDDDDDDPPPPPPVVVGGGGGGGGGVVVVV",
            "ZZBBBBBBBBOOOOOOOOOOOOAAAAAAAOOOOOOOUUUUUUUUUUUUUIIIIIIIIIIIAAAAAAAAAARRARRRRRRBRRRVVVVVVVVVVVVVNNNNNNNNGGGBBBDDDDDDDPPPPPPPVVGGGGGGGGGGGVVV",
            "ZZBBBBBBBOOOOOODOOOOOOAAAAIIIROROOOOUUUUUUUUUUUUUUXIIIIIIIIIAAAAAAAAAAAAAAARRRRRRRRRVVVVVVVVVVVVNNNNNGGGGGGGBBWWWDDDDPPPPPPPGGGGGGGGGGGGGGVV",
            "ZZBBZBBBZOOOOOOOOOOOOOAAAAAIIRROOOOUUUPUUUUUUUUUUUIIIIIIIIIIAAAAAAAAAAADDAARRRRRRRRRRSVVVVVVVVNNNNNNNGGGGGGGGGWWDDDDDPYPPPPPGGGGGGGGGGSGJXXV",
            "ZZZZZZZZZOOOOOOOOOOOOONNNAIIIIIIOOOPUUPPPUUUUUUPUIIIIIIIIIIIAAAAAAAAADADAAAAARRRRRRRRVVVVVVVVVNNNNNNNGGGGGGGWWWWDWDDDPPPPPPPPSSGGGGGGGGGXXXV",
            "ZZZZZZZZZOOZNNOONNNONNNNNAIIIIIIIITPBBPPPPUUUUUPPIIIIIIIIIIAAAAAAAAAADDDAAAAARRRRRRRVVVVVVGVVVNNNNNNNNGGGGGWWWWWWWWDDPPPPPPPPGGGGGGGGGGXXXXX",
            "ZZZZIZZIZZZZNNNNNNNOONNNNNZIIIIIIPPPPPPPPPPPPUPPIIIIIIIIIIIAAAAAAAAAADDDDAAARRRRRRRBVVVVVVGGVGGGNNNNNNGGGGWWWWWWWWWWWPPPPPPPPPPGGGGGGGXXXXXX",
            "IIIIIIIIZZZZNNNNNNNNNNNNNIIIIIIIIIPPPPPPPPPPPJPPPIIIIIIIIIIIAAAAAAATDDDDDAARRRRRRRBBNNNVVVGGGGGGNNNNNNNGGGGWWWWWWWWWWWPPPPPPPPGGGGGGGGXXXXXX",
            "IIIIIIIIIIZZNNNNNNNNNOONNNIIIIIIIIPPPPPPPPPPPPPPPIIIIIIIIIIIIIIICCCCDDDDDAARRRRRRBBBNNNNNVGGGGGGGGNNNRNGGGNNNWWWWWWWWWWWPPPPPPGGGGGGGXXXXXXX",
            "IIIIIIIIIIZZBBBBNNNNOOOOONIIIIIIIIPQPPPPPPPPPPCCPPEIIIIIIIITTIIICCCCCAAAAAARRRRRRRBNNNNNNGGGGGGGGNNNNRNNNNNNNWWWWWWWWWWWPPPPPGGGPPGGXXXXXXXX",
            "IIIIIIIIIZZZBBBBBNNNOOOOOIIIIIIIIIPPPPPPPPPPEPPPEEEIIIIIIIITTCCCCCCCCCACCCCRRRRAARBBANNNNGGGGGGGGRWNNNNNNNNNNWWWWWWWWWWWPPPPPPPPPPGGXXXXXXXX",
            "FIIIIIIIEBBBBBBBBNNNNOOOOOIIIIIIIIIIIPPPPPPRPPPEEEEIIIIIITTUTVCCCCCCCCACCCKKRAAAARBAANAANGGGGGGGRRRRNNNNNNNPWWWWWWWWWWWWWWPPPPPPPXXXXXXXXXXX",
            "FFFFFFIIIIIBBBBBNNNNNOOOOOIOOOIIIIIIIMMPPPPRRPPETTEEIIIITTTTTTCCCCCCCCCCCCKAAAAAAAAAAAAANGGGGRRRRRRRNNNNNNPPPWPWWWWWWWWUPPPPPPPPPXXXXXXXXXXX",
            "FFFFUUIIIIIBBBBBRRROTOOOOOOOOOWQQQIIMMMMPPJRJEEETEEEITTTTTTTTTTCCCCCCCCCCCCPPAAAAAAAAAAARRRGGRRRRRRNNNNNNNNPPPPWWWWWWWWPPPJJPPPPPXXXXXXXXXXX",
            "UUUUUUIIIBBBBBBBRROOOOOOOOOOOOQQQQQIMMMMPPJRJJEETEETTTTTTTTTTTTCCCCCCCCCCCCCAAAAAAAAAAAAAARRRRRRRRRNNNNNNNNPPPWWWWWWWPPPJJJJJPPPPPPPBXXXXXXX",
            "RUUUUUIUUBBBBBBBRROOOOOOOOOOVQQQQQMMMMMMJPJJJJEETTTTTTTTTTTTTTTCCCCCCCCCCCCEEAMAAAAAAAAAAARRQRRRRRRNNNNNNNNPPPWWWWWWPPPPPJJJJPPPPPPBBBXXXXXX",
            "UUUUUUUUUBBBBBBBRRRRORRRROOOQQQQQQMQQMJJJJJJJJEETTTTTTTTTTTTTTCCCCCCCCCCCEEEEAAAAAAAAAAAAARRRRRRRRRNNNNNNNNPPWWWWWPPPPPPJJJJPPPPPPPPPCXXXXXX",
            "UUUUUUUUUBBBBBBRRRRRRRRROOOPQQQQQQQQQJJJJJJJJJEETTTTTTTTTTTTTCCCCCCCCCCCCCEEEEEAAAAAAAAAAAARRRRRRRRRNNNNNNNPPWWWWWPPPPPPPPPJPPPPCCCCCCXXXXXX",
            "UUUUUUUUUUJBBJBRRRRRRRRXMMOPQQQQQQQQKJJJJJJJJJJJTTTTTTTTTTHHHCCCCCCCCCCCCHPEEEAAAAAAAAAAAAAARRRRRRRRNNNNNNNNBWWWWWPPPPPPPPPPPPPCCPCCCVVXXXXX",
            "UUUUUUUUUUJJJJRRRRRRXXXXMMOPQQQQQQQQJJJJJJJJJJJJTTTTTTTTTTTTHCCCCCCCCCCCCCPEEAAAAAAAAAAAAVVVVRRRRRRRRNNNNNNNBWWBWBBPPPPPPPPPPPPEPPCCCCXXXXWC",
            "UUUUUUUUUJJJJJRRRRRRXXXXXMQQQQQQQQQQQJJJJJJJJJJJTTTTTTTTTTTTHCCCCCCCCCCCCCPPEAAEAAASAAAAAVVVVVVVRRRRRNNVVNNNBBBBWBBBBPPPPPPPPPPPPPCCCCCXXWWW",
            "UUUUUUUJJJJJJRRRRRRRRXXXXQQQQQQQQQQQQJJJJJJJJJJTTTTTTTTTTTPTEOOCCCCCCCCCPPPPEEEEAAASVVVVVVVVVVRRRRRRRNVVVIUNNBBBBBBBBBPPPPPPPPPPQPPCCCCWWWWW",
            "UUUUUUUUUJJJJRRRRRRRRXXXXXIIQQQQQQQQQQJJJJJJJJJJJTTTTTTDDTPEEECCECSCCCCCPPPPEEEEAAAVVVVVVVVVVVVVVRRRRIIVIIUBBBBBBBBBPPPPPHPPPHPQQPCCCWWWWWWW",
            "UUUUUUUUUJJJJRRRRRRRRXXXXXXXQQQQOQQQQYYJJJJJFGJJJTTTTTTTDTEEEEEEEECCCCCPPPPPPEEEEAAVVVVVVVVVVVVVRRRIRIIIIMBBBBBBBBBBBPPPPHHPPHHHQQQQWWWWWWWW",
            "UUUUUUUUUUJJJJRRRRRRJJXXXXCXXQQQQYYQYYJJJJJJJGGGGGGTTTTTTEEEEEEEEECCCCPPPPPPPPEEEEEVVVVVVVVVVVVVRRIIIIIIIIIIIBBBBBBBBBBHHHHHHHDHQQWWQQWWWWWW",
            "UUUUUUUJUJJGGGJJJJJJJJXXXXCKXQQQQYYYYJJJJJJJGGGGGGGTEEEEEEEEEEEEEUCCPPPPPPPPPPEEEEEEEVVVVVVVVVVVVRIIIIIIIIIIBBBBBBBBBBOHHHIIHHHJHWWWWWWWWWWW",
            "UUUUUUJJJJJJGGJJJJJJJJJXMXKKKQDQQYYYYYYYYJJJJGGGGGGGEEEEEEEEEEEEEECCAPPPPPPPPPEEEEEEEVVVVVVLVLLLIIIIIIIIIIIIIBBBBBBPBOOHHHHHHHHHHWHWWWWWWWWW",
            "UUKUUUUUUJJJGGJJMMMJMMMMMXXKKKDKKKYYYYYYYYPEJMMGGGEEEEEEEEEEEEEEECCCAAAAPPPPPPEEEEEEEVVVRVVLLLPPIIIIIIIIIIIIIVVVOOBBOOHHHHHHHHHHHHWWWWWWWWWW",
            "KKKDUUUUUUJJGGJMMMPMMMMMMMKKKKKKKKYKYXYMMYPJJGGGGGGEEEEEEEEEEEEEECAAAAAPPPPPPPPEEEEEEEERRRVVLLPPFFIIIIIIIIIVVVVVOOOOOOOOHHHHHHHHHHHHHHWWWWWW",
            "KDDDJJJUJJJJJJJMMMMMMMMMMMKKKKKKKKKKYXMMPYPPPPGGGEEEEEEEEEEEEEEZEAAAAAAAPPPPPPPEEEEEEEERRRSLLPPFFIIQIIIYYYYYVVVJVOOOOOOHHHHHHHHHHHHHHWWWWWWW",
            "KDDDDDJJJJJJJGJMMMMMMMMMMMMKKKKKKKKXXXSMPPPPPPGGGEEEEEEEEEEEEEEZEAAAGGAAPPPAAAPEEEEEERRRRSSLPPPPPIIQIIIYYYYYYVVVVVOOOOOHHHHHHHHHHHHHWWWWWWWW",
            "DDDDDDJJGJGJGGJJMMMMMMMMMMMMKKKKKKKXXSMMPPPPPPPPGGPEEEEEEEEEJEEEEAAAGGAAAAAAAAPEERERRRIRSSSPPPPPPPQQQYYYYYYYYVVVVVVVOOOHOTTTHTTTTTZHWWWWWWWW",
            "DDDDDDDJGGGGGGJJMMMMMMMMMMMMKKKKXXXXXXMMMPPPPPPPPPPPEEEEEEEEJJJEEEAAGAAAAGGAAARRERRRRRRRSSSPPPPPPPPPPLYYYYYYVVVVVVVVDOOOOTTTTTTTTTZWWWWWWWWW",
            "DDDEDDDGGGGGGJJJMMMMMMMMMMMMMKKKKXXXXXMMMPPPPPPPPPPPPEEEEJEEJJJJPEEGGGAGGGGGAAARRRRRRRZZZZPPPPPPPPPPPPYYYYYYVVVYYVVDDDOOOOOTTTTTZZZZWWZZWTTT",
            "EEEEEEDGGGGGGGJJJMMMMMMMMMMOMKKKKKXXXXXLLPPPPPPPPPPPPEEJEJJJJJJJJGGGGGGGGGGGAARRRRRRRRRRPPPPPPPPPPPPPYYYYYYYGYYYDVDDDDDOOOOOTTTTOOOOWWZZZTTT",
            "EEEEEEDGGGGGGGGJJMMMMMMMMMMMMKKKKKKKKAAAAYPPPPPPPPPPPEJJJJJJJJJJJGGGGGGGJGGAARRRRRRRRRRXXXPPPPPPPPPPPYYYYYYYYYYYYYYYYYYYYOOOOOOOOOOOCCZZZTTT",
            "EEEEEEEGGGGGGGGMMMMMMMMMMRMMMKXKKAAAAAAAAPPPPPPAPPPQPPJJJJJJJJJJJGGGGGGGJJGGRRRRRRRRRRRXXPPPPPPPPPPPPYYYYYYYYYYYYYYYYYYYYYYOOOOOOOOCCCCZZZTT",
            "EEMEEEGGGGGGGGGMMMMMMMMMXXXMKKXXKKKAAAAAAAAGPPPAAPPVVVVJJJJJJJJJJJGGGGGGGGGGRRRRRRRRRRRRRRPPPPPPPPPPYYYYYYYYYYYYYYYYYYYYYYYOOOOOOOOOCCCZZZZZ",
            "EEMEEEEGGGGGGGMMMMMMMMMXXXXXXXXXKKKKAIAAAAAAPPAAAPAVVVVJJJJJJJJJJJJGGGGPGGMMMRRRRRRRRRRRRRRPPPPPPPYYYYYYYYYYYYYYYYDDDDOYYYYOOYYOOOZZCZCZZZZZ",
            "EEMMEMGGGGGGGGGEEMMMAALXXXXXXXXXKKKKIIAAAAAAAAAAAPAVVVVJJJJJJJJJJJJGGGGPPPPPRRRRRRRRRRRRRRPPPPPPPPYYYYYYYYYYYYCYYYDDDDOYYYYYYYYOZZZCCZZZZZZZ",
            "EEMMMMMGGGGGGGGEEEEEAAAGGGGGXXXXKIKIIIIIAAAAAAAAAAAVVVVJJJJJJJJJJGGGGGGPPPPPTTTRRRRRRRRRRRPPBBPPPPPYYYYYYYYYYYDDDZDDDDDYYYYYYYYZZZZZZZZZZZZZ",
            "EMMMMMMMMGGKGRGREEEEEAAGGGGGXXXXKIIIIIIIAAAAJAJJAAAVVVVJJJJJJJJJJJJJGGPPPPVVVVTVVRRRRRRRRRRRRBPPPPPYYYLYYYYYYCCDDDDDDDYYYYYYYYYZZZZZZZZZZZZZ",
            "MMMMMMMMMGKKKRRRREEEXAXGGGGGXXXXXXIIIIIIIAAJJJJJAAAAAAAAJJJJJJJJJJJJGPPPPPPVVVTVVRRRRRRRRRRRFBBPPPPQYYQQYYYYYYYBBDDDDYEYYYYYYYYZZZZZZZZZZZZZ",
            "MMMMMMMMMMKKKRRRREEEXXXGGGGGXXXXXXIIIIIIIIIJJJJAAAAAACCJJJLXJJJJQJJJPPPPPPPVVVVVVRRRRRRRRRRRPPPPPPPQQQQQQYYYYYYBDDDDYYYWYYYYYYYYYYZZZZZZZZZZ",
            "MMMMMMMMMKKKKRFRRRRXXXXGGGGGXXXXIIIIIIIIIIIIJJJJJAACCCCCAXXXXXJQQJXEXXPPPRPVVVVVRQQQQRRRRRRRRPPPUPBBQQQQQYYQQPPBBDDDYYYYYYYYYYYYYYZZZZZZZZZZ",
            "MMMMMMMMMKKRRRRRRRRLXXXGGGGGXXXXXIIIIIJJJIJJJJJJJJJCCCCCXXXXQQQQQXXXXXPPPRRRVRRRRQQQRRRRRRRRPPPPPPQQQQQQQQQQPPPBBBBBYYYYYYYYYYYYYYZZZLZZZZZX",
            "MMMMMMMMKKKKRRRRRRLLLXXGGGGGXXIIIIIIIIJJEIJJJJJJJJICCCCCCCXXQXQQQXXXTXPPPRRRRRRRRQQRRRRRRRRRRRRPPPBQQQQQQQQQPPPPPBBBBBYYYYYYYYYYFFZZZZZZXZXX",
            "MMMMMMMMKKKKYRRRRRRRLLLGGGGGXXIIIIIJJJJJJQJJJJJJJFCCCCCCCCXXXXXQQQTTTXXXXWWRRRRRJRRRRRRRRRRRRRBBBBQQQQQQQQPPPPPPPPPPYYYYYYYYYYYYYFFTXXXXXZXX",
            "MMMMMJMMKKKYYRRRRRRRRLLLLLXXXIIIIIIJJJJJJJJGGGGGGFFFCCCCCCXXXXXQQQTTTTXXXXRRRRRRJRRRRRRRRRRRRRBBBBQQQQQQQQQQPPPPPPPPPPYYYYYYYYYFFFFTXXXXXXXX",
            "MMTTTJMMKKKYYOORRRRRLLLLLLXXIIIIIIJJJJJJGJGGGGGMMIFFSSCCCXXXXXXQQTTTTTTTDDJJRJJJJJJJJJRRRRRRRRBBQQQQQQQQQQQQPPPPPPPPPZZYYYYYYYFFTTTTTTTTXXXX",
            "MMTTTMMMKKZZOOOORNLLLLLLLLLZZIZIZZEJJJJGGGGGGMMMMMMMSMMHHXXXXXXQQTTTTTTTTDJJJJJJJJJJJJJRRRRRRBBBQQQQQQQQQQQQPPPPPPPPPPZYYYYYYYYTTTTTTTTTXXXX",
            "MTTTTGMZZZZZOOONNNLLLLLLLLZZZZZIZZZZJJJGGGZZMMMMMMMMMMMHMXXXXXTQTTTTTTTTTDJJJJJJJJJJJJJRRRRRBBBBQQQQQQQQQQQQQPPPPPPPPPYYYYYYYYYTTTTTTTTXXXXX",
            "MMATTTZZZZZZYYYYYNLLLLLLLZZZZZZZZZZPPPZGGZZMMMZMMMMMMMMMMXXXXXTTTTTTTTTKKJJJJJJJJJJJJJRRBBBBBBBBBBEQQQQQQQHQMMPPPPPPUPTTTYTTYYYTTTTTTTTXXXXX",
            "MMTTTKZZZZZZZYYYNNLLLLLLLLZZZZZZZZZZZZZZZZZZZZZMMMMMMMMXXXXXXXXZZTTTTTTTJJJJJJJJJXXJJJRRDDDBBBEEEEEEEMQQQQQQMPPPPPPPTTTTTTTTTTTTTTTTTTTTXXXX",
            "MMMZZZZZZZZZZZZYNLLLLLLLDLLRRZZZZZZZZZZZZZZZZZMMMMMMMMXXXXXXXXXZZTTTTTTTJJJJJJJJXXXJJJXDDDDDDBEEEEEEEMQQMMMMMMPPPPBBUUTTTTTTTTTTTTTTTTTTTXXX",
            "MMMMMZZZZZZZZZZZLLLLLLLDDRRRDZZZZZZZZZZZZZZZZMMDMMMMMMMXXXXXXXXXXSMTTTJJJJJJJJJXXXXXXJXXDDDDDEEEEMEMMMMMMMMMMMPMPBBBBBBBBTTTTTTTTTBBBTTTXXXX",
            "MMMMMZZZZZZZZZZZLLLLLLLDDRDRDZZZZZZZZZMZZZZZMMZMMMMMMMWMXXXXXXXXXMMMMMJJJJJJJJJJXXXXXJXXDDDDDEEEEMMMMMMMMMMMMMMMMMBBBBBBBTTTTTTTBTTBBBTTXXXX",
            "MMMMMZZZZZZZZZZZLLLLLLLDDDDDDDZZZZZZZZZZZZZZZZZMMMMMMMMMMXXXXXXXXMMJJJJJJJJJJJJXXXXXXXXDDDDEEEEEEEEMMMMMMMMMMMMMMMBBBBBTTTTTTTTBBBBBBYTXXXXX",
            "MMMMZZZZZZZZZZZZLLLLNLDDDDDXDZZZZZZZZZIZZZZZZZZMMMMMMMMMMXXXXXXXMMMMBJJJJJJJJJJXXXXXXXXXDDDDDDDEEEMMMMMMMMMMMHMMMMMBBBBBTTTTTTBBBBBBBYBBXXXX",
            "MMMMZZZZZZZZZZZZNNNNNBBDDDDDDZZZZZZZZZZZZZZZZZZMMFFMMMMMXXXXXXXXMMMMBJBBJJJJJJJJXXXXXXXXXXXXDDDDEEMMMMMMMMMMMHMMMMMBBBBNNNNTTTTBBBBBBBBBXXXX",
            "MMOMMOOHZZZZUZZZZNNNBBBDDDDDDZZZZZZZZZGGGGGGZZZMFFFFFMMMXXXXRXOOMMMBBBBBJBBJJPJJXXXXXXXXXXXDDDDDEMMMMMMMMMMMMHHMMNNNBBBNNNXTTTTBBBBBBBBXXXXX",
            "MMOOOOOOOIZZIZZNNNNBBBBBDDDBBBZZZZZBBZGGGGGGZZZFFFFXXMMOOXXXXXXOOBBBBBBBBBBJJJJJEEXXXXXDDDDDDDDDDMMMMMMMMMMBHHHHMNNNNNBNNNXTTTTTBBBBBBBBBBXX",
            "OMOOOOOOOIIIIZZNNNNBBBBBDDBBBBZZZZZBZZGGGGGGZZZZFLFFMMOOOOOXXOOOOBBBBBBBBBBBJJEEEEEEXLLLDLDDZZDDDMMMMMMMMMHHHHHHHNNNNNNNNNXXXXBBBBBBBBBBBBXX",
            "OOOOOOOOOIIIIINNNNNBBBBBBDDDBBBBBBBBBZGGGGGGZZZZFFFFFFOOOOOXOOOOOBBBBBBBBBBBBEEEEELLLLLLLLLDZZZZMMMMMMMMMMMHHHHHHHHNNNNNNNNXXXXBBBBBBBBBBBNN",
            "OOOOOOOOOIIIINNNNBBBBBBBBBBBBBBBBBBBZZGGGGGGZZZFFFFFFFFOOOOOOOOOBBBBBBBBBBBBBBEEEEEELLLLLLDDZZZZMMMMMMMMMMHHHHHHHHHHNNNNNNNXXXXXXBBBBBBBBBNN",
            "OOOOOOOOOOIINNNNNNNBBBBBBBBBBBBBBGGGGGGGGGGGZZZFFFFFFFFOOOOOOOOOBBBBBBBBBBBBBBEEEEEELLLLLLDZZZZZZMMMMMMMMHHHHHHHHHHHHNNNNNNXXXXDDDBBBBBBBBNN",
            "OOOOOOOOIIINNNNNNNBBBBGGGGGBBBBZBGGGGGGGRRZLFFFFFFFFFFFFOOOOOOOOBBBIBBBBBBBDDBEEEEEEELLLLDDZZZZZZMMMMMMMMHXHHHHHHHHHHNNNNNNNXXXXXDGBBBNBBNNN",
            "OOOOOONNIIINNNNNNNNBBBRRRRGGGBBZZGGGGGGGRRZFFFFFFFFFFFFFFFOOOOOOOBBIBBBBBBDDDDDDEEEELLLLLDDZZZZZMMMMMMMMMPPHHHHHHHHQPNNNNNXXXXXXXDGBBBNNNNNN",
            "ZOOOOOONNIINNNKKKKBBBBZRRRRGGGBBZGGGGGGGRRFFFFFFFFFFFFFFFMFOOOOOIIIIIIBBBDDDDDDDDEEELLLLLZZZZZZZZZMMMMMPPPPHHHHHHHPPPPNNXXXXXDDDDDDDDNNNNNNN",
            "OOOOOOOONNIINNNKKKBBOOPPPPPPGBBBBGGGGGGGRRRFFFFFFFFFFFFFFFFOOOIIIIIIIIIIIGDDDDDDDDELLLLLEZZZZZZZZMMMMMMPPPPPPHHHPPPPPPNNPXXXXXDDDDDPDNNNNNNN",
            "AAOOOOOONNNNNNKKKKKKKZPPPPPPGBBZZGGGGGGGGRRFFFFFFFFFFFOFFFFOOOIIIIIIIIIIDDDDDDDDDDDLLLLLLOZZZZZZZMMMMMMMMMPPPPPPPPPPPPPPPXXPXXDDDDDNNNNNNNNN",
            "AAONNNNNNNNNNKKKKKKKKZPPPPPPGZZZZGGGGGGGGRRFFFFFFFFFFFOOFOFOOOOIIIIIIIVVVDDDDDDDDDDLLLLLLOOOOZZZZMMMMMMMMPPPPPPPPPPPPPPPPPPPPXDDDDDDDNNNNNNN",
            "AAAINNNNDNDNNNKKKZZKZZPPPPPPGGGZZGGGGGGGGZRFRFFFFFFFOFOOOOOOOOOIIIIIIIIVVDDDDDDDDDYLLLYLLOOOOZJZZMMMMMMMMMPPPPPPPPPPPPPPPPPIPXDDDDDNNNNNNNNN",
            "IIIIINNDDDDDNNNNNNZZPPPPPPPPGGGGZGGGGGGGGRRRRFFFFFFOOOOOOOOOOOOIIIIIIIIVVVDDDDDDDYYYYYYLLOOOOOOOOMMMMFFFMMPPPPPPPPPPPPPBPPIIIDDDDDNNNNNNNNNN",
            "IIIIIDDDDDDDNNNNNZZZPPPPPPPPGGGGZGGGGGGGGQQQRQFFFFQOOOOOOOOOOOOIIIIIIIVVVVVVDDDDDEYYYYLLOOOOOOOOOMMMMFFFFMFPPPPPPPPPIIPBPPIIIIIDDNNNNNNNNNNN",
            "IIIIIIIDDDDDNNNNNZZZPPPPPPPPGGGGLZZZZZGGGZQQQQFFFQQOQQOOOOOOOOOIIIIIIIVVVVVVVDDDEEEEYOOOOOOOOOOOOMMFFFFFFFFLFPPPPPPPPPPPIIIIDDIDDDNNNNNNNNNN",
            "IIIIIIDDDDDDDDZZZPPPPPPPPPPPPPGZZZZZZZGGGZQQQQQQQQQQQQOOOOOOOOIIIIIIIVVVVVVVVVVDEEMMOOOOOOOOOOOOOOFFFFFFFFFFFFFFVVVPPPPPPPDDDDDDDDGNNNNNNNNN",
            "IIIIIIDDDDDDDDZZZPPPPPPPPPPPPPGPZPPZZPGGGZQQQQQQQQOOOVOOOOOOOOOOIIIIIIIVVVVVVVVDMMMMOOOOOOOOOOOOODFFFFFFFFFFFFFFVVVPPPPPPPDDDDDDDDGGNGNNNNNN",
            "IIIIIIDDDDDDDDZZZPPPPPPPPPPPPPGPPPPPPPGGGPQQQQQQQQQOOOOOOOOOOOOQIIIIIIIVVVVVVVVVEMMMOOOOOOOOOOOOFFFFFFFFFFFFFFFFVVVVPVPPDDDDDDGGDGGGGGGGNNNN",
            "IIIDDIDDDDDDDDZZZPPPPPPPPPPPPPGPPPPPPPGGGQQQQQQQQOQOOOOOOOOOOOOQKIIIIZVVVVVVVVVEEEMMMMOOOOOOOOOFFFFFFFFFFFFFFFVVVVVVVVDDDDDDDDBGGGGGGGGGNNNN",
            "IDDDDDDDDDDDDDDTTPPPPPPPPPPPPPPPPPPPPQQQQQQQQQQQQOOOOOOOOOOQOOQQQQQIICCCCCRVVVEEEEMMMMMMOOOOOOOOOFFFFFFFFFFFFVVVVVVVVVDDDDDDDBBBGGGGHHHGNAAA",
            "DDDDDZDDDDDDDDTTTPPPPPPPPPPPPPPPVPVPPPPPPPQQQQQQQOOOOOOOOQQQOOQQQQQIICCCRRRREEEEEEEMMMMMMOOOOOOOOHFFFFFFFFFFFVVVVVVVVVVVDDDDDBBBGGGGHHHHAAAH",
            "DZDDDZDZDDDDDDDTTPPPPPPPPPPPPPKVVVVVPPPPPPPPQQQQJNOOOMOOOQQQOOQQQQQCCCCCRRREEEEEEEEMMMMMOOOOOOOOHHHFFFFFFFVFVVVVVVVVVVVDDDDDDBBBGGGHHHHHAAAH",
            "ZZZZZZZZDDDDDTTTTTTTZPPPPPPPPPVVVVVVVPPPPPPPJQQQJJJOOONNNQQQQQQQQCCCCCEECRREEEEEEEMMMMMMMMOOOOHHHHHFFFFFFFVVVVVVVVVVVVVDDDDDDBBBGBGHHHHFHHHH",
            "ZZZZZZZZDDDDTTTTTTTZZZZZZKKKKKVVVVVVVVPPPPPPJJQBJJJJJJNQQQQQQQQQQCCCCCCCCCRREEEEEMMMMMMMOOOOKOHFFFFFFFFFFFVVVVVVVVVVVVVDDDDDBBBBBBHHHHHHHHHH",
            "ZZZZZZZZDDDDDDDTOOOZZZZZZKKKKKVVVVVVVVPPPPPPJJJBJJJJJJNQQQQQQQQQQCCCCCCCRCRREEEMMMMMMMMMOMMMMMMMMDFFFFFFFFVVVVVVVVVVVVVDDDDDBBBBBBHHHHHHHHHH",
            "ZZZZZZZZZDDDDDDDOZZZZZZZZKKVKVVVVVVVVVPPPPPPJJJJJJJJJJNQQQQQQQQQQCCCCCRRRRREEXXHMVMMMMMMMMMMMMMMMDFFFFFFFFVVVVVVVVVVDDVDDDDDDDDDDBHHHHHHHHHH",
            "ZZZZZZZZZDDDDDDDOOZZZZZZZZVVVVVVVVVVVSPPPPPJJJJJJJJJJJQQQQQQQQQQQQQCCCRRRRREEXXXVVMMMMMMMMMMMMMMMMFFFZFFFFZVVVVVVVVVDDDDDDDDDDDDHHHHHHHHHHHH",
            "ZZZZZZZZZDZDZDDOOZZZZZZZZZVVVVVVVVVVVSPPPPPJJJJJJJJJJJJJQQQQQQQQQQQNCCRRRRRRXXXXVMMMMMMMMMMMMMMMMMMZZZZZZZZVVVVVNVVDDDDDDDDDDDDHHHHHHHHHHHHH",
            "ZZZZZZZZZZZZZDOOOOZZZZZZVVVVVVVVVVVVVPPPPPPJJJJJJJJJJJJJQQQQQQQQQQQCCCRRRRRXXXVVVMMBUUUUMMMMMMPMMZZZZZZZZZZZVVVVNVFDFFFDDDDDDDDDNHHHHHHHHHHH",
            "ZZZZZZZZZZZZZZZZOOOOOOZZTTVVVVVVVVVVVPPPPPPJJJJJJJJJJJJJQQQQQQQQQQQRCRRRRRRFXVVVVMMUUUUUMMMMPPPPPZZZZZZZZZZZZFFFFVFFFFFFTTTDTTDNNNNHNHHHHHHH",
            "ZZZZZZZZZZZZZZZZOOOOOOZTTTTVVVVVVVVVVJPPPPCJJJJJJJJJJJJJJQQQQQQQQQQRRRRRRFFFVVVVVMMUUUUUMMMMMPPPPZZPZPZZZZZFZFFFFFFFFFFFTTTTTTDNNNNNNHNHHHHH",
            "ZZZZZZZZZZZZZPPZOIIOOOOIITTTTVVVVVVVVJWPPPCCJJJJJJJJJJJJJQQQQQQQQQQRRRFFFFFFFVVVVVVUUUUMMMMPMPPPPPPPPPPZZZZFFFFYFFFFFFFFTTTQTJNNNNNNNNNHNNHH",
            "ZZZZZZZZZZZZZPPPPIIIOOOIIITTVVVVVVVVVWWWCCCCJJJJJJJJJJJJEENEQQQQRRRRRRFFFFFHFFFVVVUUUUUMMPMPPPPPPPPPPPZZZZZFFFFFFFFFFFFFFTTTNNNNNNNNNNNNNNHH",
            "ZZZZZZZZZZZZPPPPPIIIIIIIIITTVVVVVVVVVVWWWCCCCJJJJJJJJJJEOEEEQQRRRRRRRRFFFFFFFFFUUUUUUUUMMPPPPPPPPPPPPPZZZZZZFFFFFFFFFFFTTTTKNNNNNNNNNNNNNHHH",
            "ZZZZZZZZZZZPPPPPPIIIIIIIIIIVVVVVVVVVVVWWWWWWCJJJJJJJJJEEEEEEEQRRRRRRRRFFFFFFFFFFUUUUUUUUMPPPPPPPPPPPDPPZZZZZZFFFFFFFFFFFTTTNNNNNNNNNNNNNFHHH",
            "ZZZZZZZZZZZZPPPPPIIIIIIIIIIMMVVVVVNVWWWWWWWWWJJJJLLLEEEEEEEEEERRRRRRRRFFFFFFFFFCEUUUUUUMMPPPPPPPPPPPPPZZZZZZZFFFFFFFFFFFTTTNTNNNNNNNNNNNNDHH",
            "ZZZZZZZZZZZPPPPPPIPIIIIIIIIMMVPPVIWFWWWWWWWWWWLLLLLLLEEEEEEEEEERERRQQRFFFFFFFFFCEUEEEEUMPPPPPPPPPPPPPPPZZZZZZFFFFFFFFFFKTTTTTTNNNNNNNNNNNNHH",
            "ZZZZZZZZZZZPPPPPPPPIIIIIIIIIMPPPPWWWWWWWWWWWWWLLLLEEEEEEEEEEEEEEEQQQQQFFFFFFFFCCEUCCEEPMPPPPPPPPPPPPPPZZZZZZZFFFFFFFFKKKKTKTTTTTNNNNNNNNVVVH",
            "NNMZZZZZZPPPPPPPPPIIIIIIIIIIIPPPPWQQQQQWWWWWWLLLLLLLEEEEEEEEEEEEBBBQQQQFFFFFFPCCCCCCCCPPPQQQPKPPPPPPPPZZZZZZOFFKKFKKKKKKKKKTTTTTNNNNNNNNNVVV",
            "NNMZZZZZPPPPPPPPPPIRRRIUURPPPPPPPWQQQQQWWWWWWLLLLLLLEEEEEEEEEEEBBQQQQQQUFUUFFFCCCCCCCCPCPQCQPPPPPPPPPPPZZZOOOFFFKKKKKKKKNKKTTTTTNNNNNNNVVVVV",
            "NNMMMMZPPPPPPPPPPIIRRRRRRRPPPPPPPPQQQQQQQQWWWLLLLLLLEEEEEEEEEEEEEEEQQQQUUUUUUFCCCCCCCCCCCCCCCPZZZPPPZZZZZZOOOOOKKKKKKKKKKKKKTTTTTTTTVVVVVVVV",
            "MMMMMMZZPUUPPPPPPPPRRRRRRRRRPPPPPPQQQQQQQQWWWWLLLLLLEEEEEEEEEEEEQQQQQQQQQUUUUCCCCCCCCCCCCCCCCZZZPPZPZZZOOOOOOOOKKKKKKKKKKKIKTTTTTTTTVVVVVVVV",
            "MMMMMMMMUUPPPPPPPPPRRRRRRPPPPPPPPPQQQQQQQQQWQWLLLLLLEEEEEEEIEEEEQQQQQQQQUUUURRRRRRRRRRCCCCCCCZZZZZZZZZOOOOOOOOGKKKKKKKKKKIIKTTTTTTTVVVKKVEVV",
            "MMMMMLMUUPPPPPPPPPRRRRRRPPPPPPPPPPQQQQQQQQQQQQQQQQLLEEEEEEEEEEEEEQQQQQQQUUUURRRRRRRRRRCCCCCCKKKKKKKZZZOOOOOOOKKKKKKKKKKKKRIKTTTTTTTVVVKKKEVV",
            "MMMMMLMUUPPPPPPPPPPPRRRPPPPPPPPPOQQQQQQQQQQQQQQQQQLEEELEMMEEEQQQQQQQQQQIIIUURRRRRRRRRRCCCCHHKKKKKZZZOOOOOOOOOOKKKKKKKKKKKRRKTTTTTVVVEEEKEEEE",
            "MMMMMMMXXPPTPPPPPPPRRRRPPPPPPPPPPQQQQQQQQQQQQQQQQQLEEELLLLLQQQQQQQIQQQIIIIIIRRRRRRRRRRCCHHHHKKKZZZZZZOOOOOOOOOKKKKKKKKKKKRRTTTTTTTVVEEEEEEEE",
            "MMMMMXXXXXPTPPPPPPPPRRRPPPPPPPPPPQQSSSSSSSSQQQQQQLLLELLLLLLLGQQQQQIQIIIIIIIIRRRRRRRRRRCCHHHHKKKKKZAAAQQOOOOOOOKKKKKKKKKKRRRNRRLLRRVEEEEEEEEE",
            "MMMMMMMMXXPXXPPXXPXCRRRPPPPPPPPPSSSSSSSSSSSQQQLLLLLLLLLLLLLQGQQQIIIIIIIIRRRRRRRRRRRRRRCCHHHHQQQKZZAAAAQQOOOOOOOOKKKKKKKRRRRRVRRRRRREEEEEEEEE",
            "MMMMMMMXXXXXXXXXXXXRRRNPPPPPPPPPSSSSSSSSSSSQQQLLLLLLLLLLLLLLGQQIIIIIIIIIRRRRRRRRRRRRRRHHHHHHHHQQZZAAQQQQQOOOOOOOKKKKKKKRRRRRRRRRRRRREEEEEEEE",
            "MMMMMMMMXXXXXXXXXXXXRRRPPPPPPPPPSSSSSSSSSSSQQQQLLLLLLLLLLLLGGGQVIIIIIIIIRRRRRRRRRRRRHCHHHHHHHHQQQQQQQQQQQOOOOOOOKKKKKKKRRRRRRRRRRRREEEEEEEEE",
            "MMMMMMMXXXXXXXXXXXXXEEEEPPPPPPPPSSSSSSSSSSSQQQQLLLLLLLLLLLGGGGQVIILIIIIIRRRRRRRRRRRRHCHHHHHHHHHHHQQQQQQQQQYOOOOOOKKKKKKRRRRRRRRRRRCEEEEEEEEE",
            "MMMMMMMXXXXXXXXXXXXHEEEEPPCCCCPPSSSSSSSSSDDRQQQFFFFLLLLLLLGGGGGHIIIIIIIIRRRRRRRRRRRRHHHHHHHHGGHHHQQQQQQQQYYOOOOOOKKKKKRRRRRRRRRRRRRRREEEEEEE",
            "MMKKKMXXXXXXXXXXXXWHHHHHOPCCCCCCSSSSSSSSSDDDDDFFFFFLLLLLLLLGGGGHIHIIRRRRRRRRRRRRRRRRHHHHHHHGGGHHHQQQCQQQQYYYYOOHHKKKFKRRRRRRRRRRRRRRREEEEEEE",
            "MMKKKMXXXXXXXXXXHHHHHHHOOPCSSSSSSSSSSSSSSDDDDFFFFFFLFLLLLLLLLGGHHHIIRRRRRRRRRRRRRRRRHHHHGGGGGGGGHQQQCCQYYYYYROOHHKKKKHHHRRRRRRRRRRRRYEEEEEEE",
            "MMMKXXXXXXXXXXXXXHHHHHHHHCCSSSSSSSSSSSSSSDDDFFFFFFFFFLLLLLLLLLHHHIIIRRRRRRRRRRRRRRHHHHHGGGGGGGGCQQQCCQQYYYYYRYHHHHHHHHHHRRRRRRRRRRRRRREEEEEE",
            "KKKKKXXXXXXXXXXXHHHHHHHCCCCSSSSSSSSSSSSSSDDDFFFFFFFFFLLLLLLBBBBHHHHIRRRRRRRRRRRRRRHHHHHGGAAGGGGCCCCCCCCYYYYYYYHHHHHHHHHHHRRRRRRRRRRRRRREEEEE",
            "KXXXXXXXXXXXXSHHHHHHHHHHJJCSSSSSSSSSSSSDDDDDFFFTTTFFTLLMLLMMBBBBBBRRRRRRRRRRRRRRRRHHHHHHGGGGGGGCGCCCCCYYYYYYYYYHHHHHHHHHHRRRRRRRRRRRBEEEEEEE",
            "KXXXXXXXXXXXAHHHHHHHSSSSSSSSSSSSSCCDDDSDDDDDDFFTTTTFTTMMLMMPBBBBBBRRRRRRRRRRRRRRRREEPPPGGGGGGGGGGCCCCCYYYYYYYYHHHHHHHTTTHRRRBBBBBBRBBEEEEEEE",
            "KXXXXXXXDXXAAHHHHHHHSSSSSSSSSSSSSCCDDDDDDDDDTTTTTTTTTMMMMMMMTMBBBBRRRRRRRRRRRRRRRREHPPPGGGGGGGGGGGGCCYYYYYYYYYYHHHHHHTTHHHRRBBBBBBRBBEEEEEEE",
            "KKKXXXAXXXAAAHHHHHHHSSSSSSSSSSSSSCCDDDDDDDDDTTTTTTTTTTTMMMMMMMBBBBRRRRRRRRRRRRIEEEEHPPPGGGGGPGGGGGGGGGYYYYYYYYYHHHHTTTTTHBBBBBBBBBBBBEEEEEEE",
            "KKKKKXAAXAAHHHHHHHHHSSSSSSSSSSFCCCDDDDDDDDDTTTTTTTTTTMMMMMMMMMBBBBRRRRRRRRRRLEIEEEEEPPPAGGNNPPPDDGGCCCYYYYYCYYYHHHHHTTTTTBBBBBBBBBBBBBEEEEEE",
            "LLKLKXAAAAAAAAHHHHHHHHHJJJJJJJCCCDDDDDDDDDDTTTTTTTTTTMMMMMMMMMMBMBRRRRRRRRRREEEEEEEEPPPGGNNPPPPPGGGCCCCCCYYCYCHHGGHGTTTTBBBBBBBBBBBBBBBEEEEE",
            "LLLLLAAAAUUUUAAAHYHHHHHJJJJRJJJCDDDDDDDDDTTTTTTTTTTTTMMMMMMMMMMMMBRRRRRRRRRREEEEEEENPPPPPPPPPPKCCCCCCCCCCCCCYCHGGGGGTTTTVVBKBBBBBBBBBEEEEECC",
            "LLLLAAAUUUUUUAUAAHHHHJJJJJJOJGJCDDDDDDLDTTQTTTTTTTTTTMMMMMMMMMMMBBBYYYYHYYYYEEEEPPPPPPPPPPPPPPKCCCCCCCCCCCCCCCCGGGGGGTTTTTTBBFBBBBBBEEEEECCC",
            "LLLLLLUUUUUUUUUUAHHHJJJJJJJOGGGKKDKDDKLDDQQTTTTTTTTMMMMMMMMMMMMMYYYYYYYYYYYYYEEEPPPPPPPPPPPPPPKCCCCCCCCCCCCGGGGGGGGGGGTTTTFFBBBBBBBBEECCCCCC",
            "LLLLLLLUUUUUUUUAAAAAAJJJJJOOOOOOKKKKKKKKKTTTTTTTMMMMMMMMMMMMMMYYYYYYYYYYYYYYEEEEPPPPPPPPPCNNDNNOOCCCCCCCCCCCGGGGGGGGGGTTTFFFFBBBBBBBBECCCCCC",
            "LLLLLLUUUUUUUUUUUDAAJJJJOOOOOOOOOOKKKKKKKKTAMTMMMMMMMMMMMMMMMOYYYYYYYYYYYYYUEEEEPPPPPPPPPPPPPPPPPCCCCCCCCCCCCGGGGGGGGTTTTTTFBBBBBBBBHHCCCCCC",
            "LLLLLUUUUUUUUUUDDDDDPJJJJJOOOOOOOOKKKKKKKKMMMMMMMMMNNNMNMMMMOOOKKKYYYFYYYYYUEEEEPPPPPPPPPPPPPPPPPOCCCCCCCCCCCOGGGGGGGGFFTTFFBBXBXBBHHHOZCCCC",
            "LLLLLLUUUUUUUUUDUDPPPPJJJJOOOOOOOOKKKKKKKMMMMMMMMMMNNNNNNMMHOOKKYYYYYYOOYOOEEEEEPPPPPPPPPPPPPPPPPOCLLCCCCCCCCOOGGGGGGGFFTFFBBBXXXBHHHOOOCCCC",
            "LLLLLLUUUUUUUUUUUPPPPLPPJJJOOOOOOOKKKKKKKMMMMMMMSMMNNNNRNOOOOOOKYOYYOOOOOOOEEEEEEEEEPPPPPPPPPPPPPRLLLLCCCCCCCOGGGGGGGGFFFFFFFBBXXXOOOOCCCOCC",
            "LLLLUUUUUUUUUUUUUUPPPPPPJJOOOOOOOOKKKKKKMMMMMVMMMMMYNNNNNNQOOOOOOOYOOOOOOOOEEEEEEEEEPPPPFFFFFFFRRPLLLPPPPPCCPGGGGGPSSPPPFJJJJBBXOOOOOOOOOOOC",
            "LLLLLLLUUUUUUUUUUUPPPPPPJJJOOOOOTTTKKKKKMMMMMVMNWNNNNNNNNNNOOOOOOOYOOOOOOOOEEEOEEEEOPPPPFKFFFFRRPPLPLPPPPPCPPPPPPPPPPPPPFFJJJJJXXOEOOOOOOCCC",
            "LLLLLLUUUUUUUUUUUPPPPPPPJJOOOOOOTTTKKKCMMMMMMMMNNNNNNNNNNNNOOOOOOOOOOOOOOOOOOOOOOEDDPPPPDDDDRRRRRPPPPPPPPPPPPPPPPPPPPPPFFFFJJJJJXOOOOOOOCCCC",
            "LUULUUUUUUUUUUUUUUPPPPPPPPPPOOTTTTTTKKMMMMIMCCCNNNNNNNNNNNNNNOOOOOOOOOOOOOOOOOOOOODDPPPPDDDDDRRRRRPPPPPPPPPPPPPPPPPPPPPPFJJJJJJJJJJOOOCCCCCC",
            "DUUUUUUUUUUUUUUAPPPPPPPPPPTTTTTTTTTTKMMMMMMMCCCCNNNNNNNNNNNNOOOOOOOOOOOOOOOOOOOOOOODDDDDDDDDRRRRRRRPPPPPPPPPPPPPPPPPPPPPJJJJJJJJJJJOOCCCCCCC",
            "DDDUUUUUUUUUUCCPPPPPPPPPPPPTTTTTTTTTTMMWWWWMCCCCNNNNNNNNNKOOOOOOOOOOOOOOOOOOOOOOOOODDDDDDDDDDRRRRPPPPPPPPPPPPPPPPPPPPPPPAJJJJJJJJCCCCCCCCCCC"
        ];
     
        private static readonly (int colInc, int rowInc)[] Directions = [(0, -1), (1, 0), (0, +1), (-1, 0)];
        private static readonly (int colInc, int rowInc)[] Diags = [(1, -1), (1, 1), (-1, 1), (-1, -1)];

        private static List<(int col,int row)> DetermineRegion((int col, int row, char plant) startingLocation, List<(int col, int row, char plant)> plots, int width, int height)
        {
            List<(int col, int row)> retval = [(startingLocation.col, startingLocation.row)];

            plots.Remove((startingLocation.col, startingLocation.row, startingLocation.plant));

            retval.AddRange(Directions.Select(d => (col: startingLocation.col + d.colInc, row: startingLocation.row + d.rowInc))
                .Where(l => l.col >= 0 && l.col < width & l.row >= 0 && l.row < height && plots.Contains((l.col, l.row, startingLocation.plant)))
                .SelectMany(l => DetermineRegion((l.col, l.row, startingLocation.plant), plots, width, height)).ToList());

            return retval;
        }

        private static (int col, int row) LocationOffset((int col, int row) location, (int colInc, int rowInc) offset) => (location.col + offset.colInc, location.row + offset.rowInc);

        private static void Execute(string[] inputdata)
        {
            List<(int col, int row, char plant)> plots = inputdata.SelectMany((line, row) => line.Select((plant, col) => (col, row, plant))).ToList();

            List<List<(int, int)>> regions = [];

            // separate plots into regions
            while (plots.Count > 0)
            {
                (int col, int row, char plant) firstPlot = plots.First();

                regions.Add(DetermineRegion(firstPlot, plots, inputdata[0].Length, inputdata.Length));
            }

            int fencingPrice1 = regions.Select(region => region.Count * region.Select(plot => 
                Directions.Count(dir => !region.Contains(LocationOffset(plot, dir)))
            ).Sum()).Sum();

            int fencingPrice2 = regions.Select(region => region.Count * region.Select(plot =>
                Enumerable.Range(0, 4).Count(dir => //external corners
                    !region.Contains(LocationOffset(plot, Directions[dir])) &&
                    !region.Contains(LocationOffset(plot, Directions[(dir + 1) % 4]))) +
                Enumerable.Range(0, 4).Count(dir => //internal corners
                    region.Contains(LocationOffset(plot, Directions[dir])) &&
                    region.Contains(LocationOffset(plot, Directions[(dir + 1) % 4])) &&
                    !region.Contains(LocationOffset(plot, Diags[dir])))
            ).Sum()).Sum();

            Console.WriteLine($"Day 12 Part 1 Answer is Fencing Price {fencingPrice1}.");
            Console.WriteLine($"Day 12 Part 2 Answer is Fencing Price {fencingPrice2}.");
        }

        public static void Run() => Execute(Data);
    }
}
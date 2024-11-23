﻿
namespace AdventOfCode2016
{
    internal class Day6
    {
        private static readonly string[] Data =
        [
            "yvaywrul",
            "ujcsejwm",
            "ztyzonac",
            "yornafia",
            "ibmdppra",
            "owjqnqer",
            "ahkzywrp",
            "hdhgrcol",
            "nxbuzmki",
            "amwkhnhy",
            "znvuhmdq",
            "jlrukhss",
            "uvpzvtwf",
            "ttgizolw",
            "vghfbbiz",
            "iijrfsvb",
            "tnmqlfqy",
            "mslcjslh",
            "ezsumuxx",
            "xyhxqtme",
            "sfbsuhyh",
            "newysgfj",
            "kbkqkeuf",
            "hbtkmbuf",
            "jxxazxbp",
            "bpkrscwh",
            "jbzafmiq",
            "vrxgosxg",
            "qgjkpmrb",
            "kicyfqgl",
            "amxqsxsj",
            "dowuhqfv",
            "dyaexvdi",
            "pdnmixmo",
            "unlqxrgw",
            "gwcamnpd",
            "qcljehdz",
            "yndzaqwi",
            "erxgzbep",
            "bnvtmyud",
            "blxsijnd",
            "glefcenj",
            "ljaapkht",
            "nuygmaap",
            "clgtphyt",
            "evpuxtee",
            "kqsdjrrj",
            "cnpijuov",
            "wthtxtua",
            "yqjuiagg",
            "gzupqgvm",
            "gcgbyekg",
            "apoguipr",
            "hfbhzhpk",
            "phdzjvcw",
            "uxcxqnfe",
            "jqshvtus",
            "mcxaorkj",
            "ahvrqirw",
            "wmhcagaa",
            "nhmbkxxg",
            "dlgebehd",
            "rjkgbxrn",
            "kqsegzts",
            "zxllgdaq",
            "iarrmjpe",
            "qmabpovx",
            "dfttwkck",
            "hvlirmtd",
            "sieluyef",
            "gptbsufc",
            "lrectxly",
            "grfhjxtr",
            "fivfdmjy",
            "ibysxaed",
            "vavzcflk",
            "jtvaamhh",
            "xrkowbdd",
            "aalfiuqi",
            "jwfteoqi",
            "bmyrqted",
            "ruycdmhr",
            "ljzldtja",
            "nczypfst",
            "fxmuhmbi",
            "qsiflxnc",
            "tpuqukpz",
            "xnkerwbu",
            "qvokxtrf",
            "yzdbpfti",
            "psleiqfs",
            "pooladwj",
            "jzwxvcgn",
            "sstdytzo",
            "haxlzamb",
            "zepjnkza",
            "fgnongnc",
            "syrxrxos",
            "kxwvmwsv",
            "puupmjkg",
            "qoytrnin",
            "kgoaddsm",
            "apgmidlj",
            "flavdjcb",
            "gnuzxoth",
            "mnkjeosb",
            "ejqmykpz",
            "qiqebknx",
            "taujrjja",
            "aeeftwfd",
            "ldojryvq",
            "polbygse",
            "wosjxste",
            "ymhfooct",
            "jqmjkmid",
            "pmlgfejx",
            "noubmefy",
            "ffoqwtzy",
            "mjcnbgmu",
            "poiemkay",
            "zpwhzlmk",
            "tuqswxqu",
            "mrsnwydd",
            "ixixjmge",
            "mhbfrjuo",
            "exsgjblh",
            "avhrgjri",
            "gdxaezen",
            "yknniytq",
            "uwmpezpd",
            "lajwizne",
            "tykpurmk",
            "jnjwcloj",
            "tbntcuwe",
            "xusrgrsf",
            "pngkjyna",
            "wkrocije",
            "kkixtngw",
            "iekpbyrx",
            "qsodlzot",
            "grvdxrhq",
            "urynldsy",
            "efntvvvu",
            "shokzcmt",
            "eycychtm",
            "rikyjfpf",
            "utmhgfyu",
            "qgbrkwzd",
            "agjhhlvt",
            "mnounckl",
            "sclitqee",
            "oatoipaj",
            "kuqtydvx",
            "mvfwpgde",
            "otdxkifk",
            "jdxehrse",
            "rdfbtqov",
            "hhutipis",
            "gckzyoow",
            "vjphtldv",
            "ztkihzbt",
            "tcwdsxte",
            "lhtbtyuh",
            "yozkctlm",
            "muhblgzn",
            "fylsuubl",
            "mjrndjql",
            "vczrvvbq",
            "nmaqedor",
            "uhyaafyo",
            "wterctsa",
            "xhzvwohv",
            "xqvurvop",
            "riylylux",
            "aqhsovzj",
            "izpnawyp",
            "cpvjtlaq",
            "yrehnhlx",
            "rnuljggd",
            "gywmrqkm",
            "clduzuee",
            "tbikbrkg",
            "ggjeicab",
            "wberwbxw",
            "xgzuzdjg",
            "unumhkty",
            "ptpriseo",
            "jnfygpyr",
            "fsfovqjj",
            "fsvweaoz",
            "kyixynpr",
            "tkwsrict",
            "btkjqnsh",
            "oboynuim",
            "ojzfpfdu",
            "cygyjuoj",
            "guqwumzn",
            "wvrfsiyt",
            "xsqzzhls",
            "pavohgir",
            "ezinqtxl",
            "czezeswc",
            "bpcvcedi",
            "ixwwgmrf",
            "pisrvxqz",
            "jsspvtyj",
            "rtlfkrjs",
            "ubsslwgb",
            "zcxtpbkm",
            "svpmdtbx",
            "qinfjllv",
            "mtprpcxo",
            "gcgvyfwa",
            "uklnzzee",
            "sznoxgvo",
            "kizkvksv",
            "xwhkcltx",
            "ldjzomya",
            "uixumnen",
            "lbiwswhy",
            "dtfcohae",
            "hlmytext",
            "yuqxwyza",
            "plpockjx",
            "lkohqpip",
            "etifsdbi",
            "yegmhwgx",
            "ngbpplnm",
            "npzcdjxs",
            "fsjsxcbc",
            "bckgkisl",
            "fumkfeom",
            "iedhxuch",
            "uroewsgc",
            "ijrdrpif",
            "iwrpjnqc",
            "oysoiibn",
            "sxmoluyo",
            "ojshrdzm",
            "coixnbzm",
            "rahgbqbh",
            "swswubzu",
            "hrssfarw",
            "ieeychxh",
            "cjvrcrkr",
            "veiwtvrb",
            "brxgqbdp",
            "dudhknrd",
            "kyoypwyn",
            "rbcdyidk",
            "ikkanuec",
            "xnivkght",
            "wygdzmnl",
            "cvbqokzv",
            "xoxmywxn",
            "ethkplnv",
            "yfhwlxju",
            "raojzvpb",
            "yoottlhw",
            "rupwoevd",
            "ddwnaytb",
            "azvjrgdl",
            "lqyiwvna",
            "hkugydve",
            "fgsxjdns",
            "osipnrwq",
            "adcpkeox",
            "fayoghgq",
            "varmxqrq",
            "xlakadzd",
            "wddsqsop",
            "kqjfqbfd",
            "cdoabahh",
            "udulalxy",
            "icvoqdvv",
            "opwgwgyz",
            "klyiohwo",
            "edawoezx",
            "gkpoivei",
            "wcmllhln",
            "izsbdygi",
            "fhcqpopj",
            "cpfxhsgz",
            "hddesugm",
            "lctnczgs",
            "hipdojpa",
            "zwaynfmz",
            "glwfftsz",
            "oshbfgyp",
            "ywjicsba",
            "lucdcsup",
            "nqtllilg",
            "fgftgoxr",
            "vghucjjz",
            "vthnskcy",
            "zyvfqumb",
            "lypfdslc",
            "lmkggzbw",
            "sxqimuhf",
            "uxilvbwh",
            "exoauzjy",
            "jcipdhci",
            "sokqiypg",
            "ikobmgup",
            "pkxqcyid",
            "ktpyxysi",
            "jyagtehk",
            "qzkghqez",
            "awagoups",
            "jeuotogq",
            "wzqmdpou",
            "tjofgimo",
            "eystazux",
            "hntkjpzk",
            "wrykvfsh",
            "zsvcvvte",
            "deptmrwr",
            "mhfqtitw",
            "ahqyfhlw",
            "sxwzkoky",
            "dxlbcpzj",
            "ncqhdqsx",
            "qcbnlttb",
            "ecnibawi",
            "qqcwgxun",
            "kseizswa",
            "yarddiul",
            "hrqjqksf",
            "sgbhpbqm",
            "dxfxernk",
            "iavmtzql",
            "ekmhlgkt",
            "omdilugt",
            "ljqwvohg",
            "fmrakdjp",
            "vqanxphj",
            "uvbhhduh",
            "xbqjqymc",
            "dflehzea",
            "smgbvzzl",
            "vafsagbm",
            "fktglojj",
            "meyffxdv",
            "mcolnmts",
            "xhgepxgq",
            "rxlvweva",
            "xwcvtqxv",
            "dnvomckh",
            "tcrprafj",
            "lptvaoqv",
            "xvpvkffq",
            "vgnxvuod",
            "wifwjnch",
            "baaflxla",
            "mwctffod",
            "wvhupvky",
            "dlhrekcr",
            "dveanwuj",
            "qdtzafxp",
            "ypzmmwlu",
            "gslwkrnm",
            "pscqnadd",
            "ciahqdbc",
            "wtmmzaiz",
            "yjmelify",
            "kvnmpzab",
            "tbxeimao",
            "ddmxcvdv",
            "pmuqbpio",
            "qxjlswkb",
            "wweuuczq",
            "rycckvrk",
            "zedfuqmw",
            "sbknyoln",
            "nwrcieve",
            "wsgxawds",
            "zgricrdi",
            "nhuhflzi",
            "bdmlhqav",
            "ovqznifk",
            "hlwrpnep",
            "ezavuysi",
            "kjmpsuqf",
            "fetgdtdb",
            "qpuoqckn",
            "xugvazxp",
            "zktlactb",
            "dbopyqyz",
            "bonsxzil",
            "iqcjqaqt",
            "jnymuitf",
            "pckdhqak",
            "nhkivjnl",
            "bmpnjacv",
            "clknrccx",
            "aydltwjy",
            "tujsucks",
            "cwainpiv",
            "hyyvtnzi",
            "rgjvypev",
            "fiuvqrqb",
            "vhnpbdip",
            "kiyvwfvf",
            "vkzveiaf",
            "zjfrxfsq",
            "szwuxceu",
            "zazdbtam",
            "hhstxizc",
            "juotcvme",
            "zirhlbyy",
            "dpjmewwc",
            "myhwvwbv",
            "ezpesvlw",
            "gkwgocfq",
            "zsqoyvfe",
            "uexbupnl",
            "kglbsatp",
            "qlfcxyps",
            "bodyxccq",
            "swuxnfao",
            "zfevvcbo",
            "nlpanwdi",
            "yjoavnnt",
            "xgqbgsez",
            "ithqwwoc",
            "nzfnbtnw",
            "lrxwziue",
            "lmddnnmi",
            "foiqbray",
            "rkwunijn",
            "odcuuxqx",
            "ovuxbyga",
            "whnvmyqr",
            "unflbbms",
            "sgcgnxmr",
            "ldjqvayy",
            "hovigjig",
            "sditfypy",
            "sileoqfh",
            "eflcfjvj",
            "aimowvxm",
            "ldgaabqu",
            "cjndkicj",
            "oundpkxw",
            "sfbeerto",
            "bqioiavi",
            "aawkkmyz",
            "avdujvya",
            "ektrilke",
            "kpdkfzqj",
            "vfccaofu",
            "wueprjpg",
            "aodohgrb",
            "zmgzjxxx",
            "dfrxqspm",
            "vyqlvjuo",
            "tbagellj",
            "tiingjqk",
            "cqlzqcym",
            "dxezyqom",
            "xebyhxbc",
            "twfazwwu",
            "xrybgxuu",
            "ojyqvalg",
            "xlamezzg",
            "divculwc",
            "jleeahcw",
            "etdccjgj",
            "vwqfguwq",
            "rhqqorhl",
            "yzdbczxt",
            "agnmiibs",
            "wkjmwnyw",
            "esbrfzjf",
            "oziornmm",
            "sanheboy",
            "zbbcovqp",
            "iggvgbfc",
            "oqbrdqlz",
            "majzpyih",
            "wsyeusqh",
            "fbddsajg",
            "bpzzdbhp",
            "jwaifckr",
            "ifbrwphk",
            "pyzsowew",
            "quhmqhnt",
            "dfejtbct",
            "otevtaln",
            "bxzpydbi",
            "ewzlegng",
            "ghghlzos",
            "ulpskmjf",
            "ughqkpnv",
            "wafnwoho",
            "hwcmexio",
            "liryreus",
            "ujjsrakf",
            "zqwkmhxc",
            "cqffzkrz",
            "iumgsdvo",
            "fscgjpbx",
            "mfrroqfq",
            "ukiosfpo",
            "thlfmmxx",
            "mkexdlxv",
            "mbzespbp",
            "cqschicn",
            "bqrehhlz",
            "huawdjdg",
            "kqxvantv",
            "noubxycq",
            "ovamzoou",
            "fempltqr",
            "azjnwdfz",
            "bctzxppw",
            "dgearltb",
            "ehwujrdu",
            "xrujgyan",
            "otzivkvt",
            "hqtyvpok",
            "zrejukjq",
            "gvwzjspl",
            "ddtdstwg",
            "vsokesrc",
            "lrbjunkh",
            "qcfifdol",
            "hfqxdccp",
            "bvswbpkg",
            "btlrrimb",
            "cifmbvbl",
            "spmcnsva",
            "wjbwpgql",
            "pxbjtkur",
            "hlscoqck",
            "gytwpjwb",
            "bedebzhn",
            "jdhumkeb",
            "smtvkowh",
            "zmdphbcr",
            "cshizvqc",
            "nmwldxmc",
            "ioscnnic",
            "exxwsskg",
            "hkmptdai",
            "yotteevn",
            "phvtfmra",
            "freitcgb",
            "qbyxkzyw",
            "vuawzjry",
            "vuyckdaw",
            "ojlhhdyw",
            "jegayhky",
            "pkbautcf",
            "kpwkeear",
            "peggwlgs",
            "xngkymtl",
            "tfidfghf",
            "jfrlzqzw",
            "uxonsrju",
            "krchghzg",
            "ngastvbn",
            "jpwimnwf",
            "ilucyoda",
            "qmxqslfm",
            "vvxkbawg",
            "kzbvegkr",
            "nmfwqkvv",
            "yaihlssu",
            "ykqeqwxg",
            "uxsuakck",
            "ozydpnus",
            "xbukntpz",
            "qftbywyk",
            "bnzrouhp",
            "nbptgswf",
            "grivgntq",
            "lrznwphn",
            "pggjdgpv",
            "vedplgmz",
            "rrvddhrk",
            "oorxssrg",
            "rwxceuqg",
            "ffphaxam",
            "vuncoerp",
            "jftdwmrx",
            "qfqmbono",
            "gjnvfecq",
            "dmvldovn",
            "iwyuuexk",
            "ovnbkfxa",
            "ciqbrlhe",
            "mqcpuwdc",
            "kzfablph",
            "nkglhraz",
            "payjujas",
            "toexirfb",
            "tjxklauf",
            "madpfkan",
            "gtqcmjik",
            "wzkyzvto",
            "nmvlokmz",
            "lpncbbop",
            "rwjlbsjr",
            "hblomsdt",
            "miryjfjr",
            "zzmjfqwl",
            "ezpnamvh",
            "qfstlbdd",
            "clbtxrmk",
            "nauizuhr",
            "hxniwall",
            "tphbrpni",
            "clapconx",
            "bsxthfpo",
            "fynijbet",
            "rnusrpyf",
            "rnpywyej",
            "remfmjzr",
            "yecxabru",
            "yceqnemf",
            "mpbalkid",
            "tszdkfsw",
            "cvzqdfes",
            "qebpouuv",
            "zpvzgejt",
            "lfemvcku",
            "bmioeijz",
            "rebyitlk",
            "pdzeqeit",
            "yrtnxncc",
            "rqxjgmih",
            "vvgsmabl",
            "dyksiefo",
            "mtjsuvmu",
            "nbsdfhuq",
            "wmrzthvu",
            "ruuyhayy",
            "ulakolir",
            "apjjilmt",
            "gckusufb",
            "awrafegs",
            "xqfoscgx",
            "crzylcro",
            "jhnjifqu",
            "addsjzsm",
            "ufjsgyvu",
            "tonzyhgx",
            "betqoosk",
            "tngznlfd"
        ];

        public static void Run()
        {
            Dictionary<char, int>[]? counts = null;

            foreach (string line in Data)
            {
                counts ??= new Dictionary<char, int>[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
                    counts[i] ??= new Dictionary<char, int>();

                    if (!counts[i].ContainsKey(line[i]))
                    {
                        counts[i][line[i]] = 0;
                    }

                    counts[i][line[i]]++;
                }
            }

            Console.WriteLine($"Day 6 Part 1 Answer is {counts!.Select(count => count.MaxBy(kvp => kvp.Value)).Aggregate(string.Empty, (c, n) => c + n.Key)}.");
            Console.WriteLine($"Day 6 Part 2 Answer is {counts!.Select(count => count.MinBy(kvp => kvp.Value)).Aggregate(string.Empty, (c, n) => c + n.Key)}.");
        }
    }
}

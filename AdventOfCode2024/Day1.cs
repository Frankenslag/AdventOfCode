﻿
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    internal class Day1
    {
        private static readonly string[] Data =
        [
            "35039   67568",
            "61770   80134",
            "64079   34668",
            "61538   86348",
            "77448   73688",
            "56882   65376",
            "72415   66733",
            "11288   79847",
            "43897   20133",
            "56727   25055",
            "81287   24301",
            "66133   33989",
            "21274   84409",
            "65927   32516",
            "43275   24301",
            "29504   38180",
            "73071   74577",
            "25249   25055",
            "51211   25055",
            "19572   81012",
            "26142   24568",
            "25609   19866",
            "10036   18923",
            "97258   98885",
            "88301   43877",
            "89401   65376",
            "89964   88401",
            "26207   85319",
            "34775   97035",
            "55537   48593",
            "35189   46866",
            "74815   27672",
            "98408   81549",
            "66083   58944",
            "81768   50255",
            "86028   11898",
            "78015   70810",
            "26525   12863",
            "50652   11386",
            "46529   79454",
            "27670   30786",
            "20278   18592",
            "36953   18592",
            "98021   96012",
            "98347   60521",
            "39347   24301",
            "86168   39900",
            "82505   31605",
            "78290   92399",
            "12165   86348",
            "70134   35240",
            "60561   55192",
            "92644   92932",
            "70402   72092",
            "81492   82771",
            "67344   77389",
            "83806   50491",
            "46148   47616",
            "35372   63378",
            "70501   91984",
            "36437   44056",
            "13351   33618",
            "65114   71154",
            "67941   77586",
            "16939   24301",
            "43099   51685",
            "60351   38065",
            "92943   87339",
            "33652   15509",
            "73828   18923",
            "55163   65670",
            "57218   86022",
            "76645   24301",
            "36564   65376",
            "64261   15607",
            "67963   28041",
            "49372   30366",
            "69480   24952",
            "32198   55284",
            "38665   26207",
            "32951   50459",
            "53576   89578",
            "39656   26580",
            "71183   38180",
            "66472   46811",
            "24301   11898",
            "40984   25055",
            "65961   26207",
            "55309   36953",
            "20630   50491",
            "55278   62239",
            "58661   49521",
            "47209   39735",
            "30844   51389",
            "46280   11898",
            "73348   81012",
            "37023   44793",
            "43890   41616",
            "34095   35240",
            "60970   98021",
            "16343   24742",
            "41706   13472",
            "87020   46256",
            "46949   30366",
            "37286   56301",
            "54991   65376",
            "72476   58147",
            "96012   11747",
            "79020   26847",
            "11027   40409",
            "98640   47616",
            "78434   24301",
            "29492   18923",
            "45088   13012",
            "13223   91906",
            "17492   68439",
            "45464   91984",
            "94266   48022",
            "46126   52475",
            "80482   22341",
            "49680   66039",
            "15609   50491",
            "48176   14926",
            "74567   56332",
            "89131   14926",
            "42284   15607",
            "56347   43877",
            "87384   58198",
            "80786   27672",
            "15632   15059",
            "48967   24301",
            "80552   76081",
            "71754   27698",
            "71067   96012",
            "91984   31229",
            "77319   74172",
            "85675   39838",
            "54205   27186",
            "39928   81012",
            "13379   91984",
            "87496   27672",
            "32723   71218",
            "62186   22864",
            "78491   58198",
            "10168   10989",
            "24088   63750",
            "57858   88400",
            "10823   38180",
            "97894   24301",
            "70019   43544",
            "41477   24301",
            "15662   62524",
            "25093   43463",
            "29323   68118",
            "18936   14926",
            "17295   24996",
            "52810   26207",
            "13042   80773",
            "57453   87339",
            "45958   93542",
            "53286   82302",
            "65171   18711",
            "52645   18592",
            "89111   74154",
            "69190   65073",
            "34165   14035",
            "98963   87280",
            "13170   11898",
            "87920   99570",
            "22074   60255",
            "37187   10919",
            "20513   21640",
            "64242   40409",
            "81762   81683",
            "88574   24301",
            "63069   11898",
            "32411   36953",
            "13788   57579",
            "86602   30639",
            "53911   25055",
            "30069   28957",
            "98867   63750",
            "79357   89335",
            "29837   45181",
            "24479   65376",
            "46309   31558",
            "24235   83946",
            "50071   52395",
            "61057   55937",
            "95148   67530",
            "58070   56332",
            "16637   51656",
            "31912   68437",
            "38708   48382",
            "96787   11059",
            "75417   30401",
            "20360   81012",
            "17721   35393",
            "58217   15987",
            "49000   39785",
            "59036   31112",
            "77409   63750",
            "79817   91906",
            "30649   83513",
            "96917   38760",
            "95214   87339",
            "82654   50242",
            "88953   56447",
            "78903   36434",
            "21690   56874",
            "18483   32272",
            "29927   57208",
            "51783   96512",
            "55701   31292",
            "45673   30830",
            "73231   65376",
            "59005   59694",
            "91304   20527",
            "58464   35240",
            "78321   65376",
            "78012   94439",
            "83185   18923",
            "44548   53764",
            "71438   38847",
            "78713   97359",
            "71210   38895",
            "46581   33845",
            "62438   91906",
            "67039   63750",
            "16702   64076",
            "88676   15607",
            "73310   20399",
            "76088   24301",
            "87385   30775",
            "83592   25900",
            "58366   28870",
            "15476   93690",
            "26310   96738",
            "38036   64685",
            "60018   47223",
            "81012   37166",
            "38923   27672",
            "47082   73538",
            "89518   27672",
            "56737   85410",
            "51077   53083",
            "32515   11482",
            "18923   92879",
            "74717   54461",
            "13418   68933",
            "18592   50395",
            "25055   15496",
            "23882   27770",
            "95286   18923",
            "19221   15607",
            "60544   89335",
            "80751   73667",
            "34121   47616",
            "48090   78382",
            "84168   79627",
            "94488   11836",
            "80097   55090",
            "36689   65376",
            "79604   91566",
            "39541   26207",
            "30503   83946",
            "99952   92399",
            "85883   71286",
            "70810   35240",
            "98805   36248",
            "43305   51003",
            "82380   60967",
            "67400   63750",
            "62408   54292",
            "25541   14926",
            "65499   14611",
            "84214   35240",
            "70938   98496",
            "79681   10716",
            "73505   92399",
            "83713   96917",
            "84354   81012",
            "48548   18592",
            "12840   47616",
            "78716   82662",
            "45910   81012",
            "47560   96719",
            "47112   43877",
            "67023   88120",
            "20967   61095",
            "49248   65376",
            "87199   40221",
            "12263   50018",
            "57425   36953",
            "90601   98021",
            "15977   35240",
            "61849   65376",
            "32331   94453",
            "83097   89795",
            "12136   41894",
            "86788   10416",
            "28393   15607",
            "86736   34888",
            "61864   25055",
            "72683   39332",
            "54597   58675",
            "65421   38288",
            "17857   81012",
            "37720   33480",
            "68978   91984",
            "57267   88466",
            "18517   27672",
            "32657   11485",
            "21859   85410",
            "76476   70156",
            "53312   19427",
            "70428   35240",
            "49968   66978",
            "50579   91984",
            "50939   77399",
            "76445   92932",
            "53041   63750",
            "39271   39074",
            "72567   81120",
            "74117   11310",
            "25221   67033",
            "88816   91299",
            "60219   88487",
            "35361   38180",
            "92810   26207",
            "17644   56516",
            "46040   24301",
            "92989   43877",
            "17635   30990",
            "68783   37590",
            "20873   98021",
            "85545   52037",
            "21896   84232",
            "81831   62502",
            "57455   21094",
            "81437   56130",
            "13477   81012",
            "41826   24594",
            "91906   65576",
            "48905   25594",
            "19734   48335",
            "93363   82986",
            "15273   59774",
            "32150   57904",
            "88323   70156",
            "50438   30366",
            "77527   35846",
            "66427   18700",
            "41801   28247",
            "64461   81879",
            "53184   38180",
            "87733   67876",
            "97848   36634",
            "35602   33402",
            "82441   71912",
            "77772   80925",
            "36120   74492",
            "45634   18923",
            "24893   14926",
            "57112   85410",
            "40409   92399",
            "80879   75264",
            "92096   59223",
            "69320   43877",
            "78612   87552",
            "44562   51272",
            "77278   36322",
            "73599   15607",
            "16357   96012",
            "76061   86663",
            "29005   59024",
            "40702   68245",
            "70153   15607",
            "57420   75466",
            "86348   63766",
            "92063   30366",
            "47800   45272",
            "60458   46100",
            "15178   91984",
            "89187   18592",
            "73964   23709",
            "29307   18310",
            "96451   43665",
            "17193   47616",
            "79179   96012",
            "53513   32008",
            "40638   15884",
            "43355   53777",
            "40482   86348",
            "13852   66624",
            "35615   81012",
            "26073   88178",
            "23480   70156",
            "21199   50442",
            "67810   26207",
            "63103   43803",
            "19976   14574",
            "37087   63073",
            "34113   57605",
            "21162   31607",
            "57585   43679",
            "51300   42337",
            "98474   95224",
            "57264   91906",
            "34212   98763",
            "93328   21275",
            "75849   14926",
            "90445   97357",
            "93916   96467",
            "46798   41426",
            "82528   76844",
            "74563   74751",
            "67135   20376",
            "15607   83946",
            "66246   42725",
            "16903   14625",
            "45766   13145",
            "59997   50491",
            "81887   82899",
            "29485   14150",
            "80979   65376",
            "20258   81911",
            "70699   72454",
            "82045   24301",
            "45777   71343",
            "82525   16823",
            "92652   56332",
            "96844   19789",
            "28035   92093",
            "86365   13503",
            "78926   14227",
            "95946   96518",
            "43893   18592",
            "28609   26207",
            "87219   96012",
            "93438   25055",
            "97030   96012",
            "59943   46482",
            "29365   44009",
            "98717   39063",
            "64822   77298",
            "38180   97782",
            "37631   71831",
            "79526   20838",
            "96038   91984",
            "15216   27672",
            "91027   71842",
            "19057   59391",
            "77022   52566",
            "30822   44464",
            "99607   47776",
            "85679   65376",
            "62825   77572",
            "70683   81012",
            "38177   98021",
            "46156   63750",
            "92147   85410",
            "51291   29642",
            "46318   81012",
            "89248   63750",
            "90901   86348",
            "47593   18923",
            "59516   47616",
            "21660   82343",
            "95391   85410",
            "38263   63297",
            "70156   14926",
            "49825   27672",
            "21562   91984",
            "19126   91984",
            "27772   56019",
            "26534   21362",
            "12314   58104",
            "32251   32463",
            "20686   47616",
            "84143   76903",
            "38364   86348",
            "51507   72918",
            "67556   51842",
            "21631   19709",
            "64229   18923",
            "39986   83907",
            "47714   36953",
            "73986   93199",
            "69949   70518",
            "17270   27540",
            "99432   26207",
            "48531   52164",
            "46876   48879",
            "40461   63750",
            "20823   27672",
            "72811   58198",
            "98823   30862",
            "20633   27513",
            "42316   18592",
            "44514   29536",
            "42377   65985",
            "49072   26207",
            "69408   11898",
            "53679   60093",
            "52198   30366",
            "85786   26207",
            "30578   36953",
            "46225   36356",
            "45255   43020",
            "31920   15432",
            "90804   29097",
            "80275   47616",
            "68662   30366",
            "89110   69702",
            "42356   38439",
            "67432   56426",
            "84587   47154",
            "98965   97151",
            "39298   36452",
            "20305   58910",
            "72893   83506",
            "48498   52629",
            "56034   61450",
            "69371   98021",
            "75052   91906",
            "57465   25723",
            "97772   99510",
            "75434   61226",
            "18868   45072",
            "86813   71257",
            "43611   86348",
            "66792   74969",
            "69469   18707",
            "18458   47204",
            "38462   98021",
            "87928   83823",
            "96353   19691",
            "53118   11898",
            "74425   18923",
            "61527   30366",
            "72699   65376",
            "28361   89835",
            "65201   91984",
            "91574   38953",
            "37942   91906",
            "72588   24301",
            "71168   27672",
            "48459   89328",
            "31869   18923",
            "29588   18923",
            "97291   37295",
            "70794   36953",
            "22214   36953",
            "59680   73535",
            "32724   51828",
            "94621   92633",
            "21207   36621",
            "30806   41864",
            "97672   40409",
            "14543   93120",
            "39613   22746",
            "32528   22030",
            "83946   65339",
            "91301   54602",
            "80822   76443",
            "26200   73571",
            "73062   20377",
            "23869   15607",
            "92502   62049",
            "74516   92399",
            "27497   60849",
            "36478   35240",
            "92908   67257",
            "11876   86242",
            "26026   76500",
            "84224   98171",
            "13289   65376",
            "76102   37369",
            "74301   81012",
            "96021   87339",
            "40398   92399",
            "36289   81012",
            "39559   32845",
            "70127   15607",
            "61244   51380",
            "45691   91906",
            "16076   15607",
            "33843   62467",
            "18684   39937",
            "20708   67541",
            "42761   91906",
            "17831   86756",
            "24140   91906",
            "89681   44952",
            "83750   30366",
            "82004   98899",
            "27972   50893",
            "75904   59867",
            "99833   44885",
            "11155   47616",
            "66716   18923",
            "80735   96238",
            "85266   71723",
            "98337   99821",
            "92888   99950",
            "11445   98021",
            "79766   75273",
            "27583   74030",
            "70045   85429",
            "80793   95947",
            "33110   18425",
            "69622   68822",
            "90263   96033",
            "32835   40785",
            "13365   35240",
            "83143   72585",
            "64478   35240",
            "15324   76016",
            "50087   70156",
            "42350   36953",
            "71842   13181",
            "66498   14926",
            "13071   35240",
            "27992   14926",
            "57580   62903",
            "52296   96012",
            "96307   75995",
            "97907   12058",
            "73611   27672",
            "16524   77569",
            "83155   93991",
            "81077   69978",
            "90337   26207",
            "65045   91984",
            "73257   13393",
            "52515   17892",
            "62707   96917",
            "78188   92932",
            "67413   55783",
            "33346   63704",
            "76327   90249",
            "61151   71842",
            "89156   57778",
            "11898   30366",
            "69189   90111",
            "78225   93590",
            "60768   54781",
            "79015   45061",
            "42403   26330",
            "22916   59054",
            "31157   91906",
            "97212   27672",
            "88285   27672",
            "73376   35240",
            "62173   71842",
            "29269   96012",
            "79291   37786",
            "33370   37117",
            "25310   91906",
            "46324   22687",
            "92932   87339",
            "78964   81973",
            "67824   58586",
            "74235   35662",
            "66230   87195",
            "53615   23421",
            "26606   98021",
            "66102   89964",
            "71342   78685",
            "43935   28971",
            "48013   43877",
            "27841   65376",
            "12668   38654",
            "85915   25055",
            "88982   49297",
            "52956   24301",
            "16219   63750",
            "65720   91984",
            "65661   96012",
            "44967   23616",
            "65337   46633",
            "32906   22665",
            "60498   93894",
            "49603   70713",
            "91525   26207",
            "10320   39636",
            "36040   97075",
            "94564   47616",
            "13322   95892",
            "85023   63750",
            "48157   71842",
            "45995   39433",
            "98955   18592",
            "64728   37888",
            "15368   10049",
            "14567   58198",
            "65376   27235",
            "26937   95870",
            "75730   85289",
            "42888   35240",
            "92222   25055",
            "40465   90687",
            "37319   49808",
            "25266   63750",
            "91578   25055",
            "24497   84517",
            "34488   81012",
            "48385   91906",
            "36998   49180",
            "37862   40206",
            "42042   27672",
            "64800   79368",
            "58927   71842",
            "20943   76733",
            "80514   13893",
            "38460   92399",
            "97979   40409",
            "65486   15607",
            "66208   43877",
            "59095   49775",
            "24912   17215",
            "54521   76108",
            "41819   18592",
            "75618   26163",
            "14857   53151",
            "55033   59156",
            "11219   71842",
            "24108   74041",
            "72748   56218",
            "50491   73106",
            "56384   18592",
            "28634   15666",
            "23410   20042",
            "31083   24301",
            "71316   42619",
            "67358   93788",
            "55099   42797",
            "10599   47094",
            "27672   66687",
            "73375   36792",
            "92311   65920",
            "60872   72231",
            "71479   35240",
            "30419   38180",
            "78607   89172",
            "99993   86348",
            "22065   97784",
            "72059   78461",
            "45371   88210",
            "77264   96012",
            "95079   26207",
            "84890   91906",
            "64193   71842",
            "70500   54596",
            "67215   84958",
            "58345   75407",
            "20641   12224",
            "90141   15607",
            "18794   96012",
            "34989   27672",
            "88494   96012",
            "45338   92932",
            "49537   18239",
            "38474   92399",
            "62500   91083",
            "28881   16699",
            "47575   80033",
            "82557   91984",
            "15494   87216",
            "92399   37021",
            "47677   91527",
            "69368   78293",
            "50414   48322",
            "86571   83946",
            "81985   63750",
            "83036   49444",
            "27496   96012",
            "82780   24301",
            "41459   80706",
            "51973   96917",
            "22097   73702",
            "23186   58436",
            "87792   95578",
            "98725   92399",
            "60991   93326",
            "40941   35240",
            "38467   30366",
            "97787   35240",
            "61685   65376",
            "94917   73885",
            "91080   15464",
            "23026   13922",
            "21041   15607",
            "35643   96012",
            "47616   71640",
            "63750   43376",
            "55875   65376",
            "68900   50491",
            "39807   93669",
            "72815   81012",
            "58198   30366",
            "48829   64905",
            "86646   38180",
            "55697   65655",
            "69182   75133",
            "76647   86491",
            "98448   57039",
            "33099   27747",
            "23139   29704",
            "60836   38406",
            "85498   12228",
            "28998   91906",
            "51850   62160",
            "14028   30366",
            "62697   16252",
            "43849   27672",
            "76594   45618",
            "39877   65376",
            "31586   50491",
            "84342   33041",
            "50844   17316",
            "78138   93648",
            "79016   59231",
            "71282   84987",
            "17617   35251",
            "64712   18592",
            "15355   96808",
            "77589   83946",
            "77393   95802",
            "47388   27672",
            "72306   51892",
            "85251   71842",
            "16047   42023",
            "46217   81012",
            "41903   72862",
            "87596   18592",
            "28002   68144",
            "12253   27672",
            "18763   14926",
            "26931   86088",
            "42354   30366",
            "35240   24392",
            "70790   11436",
            "88687   36953",
            "45806   78289",
            "63080   30366",
            "10347   91634",
            "35973   97144",
            "12962   54401",
            "65157   34032",
            "80675   70442",
            "24466   87339",
            "76472   33729",
            "87390   31090",
            "67588   64702",
            "22469   14427",
            "43582   36953",
            "37926   47616",
            "29085   15607",
            "71468   71842",
            "44150   88463",
            "75227   59086",
            "27743   48950",
            "42285   13547",
            "28017   43877",
            "39155   18093",
            "24162   46889",
            "67045   72435",
            "43709   50140",
            "20627   24103",
            "87339   61159",
            "99967   49253",
            "84218   53382",
            "96982   27672",
            "71197   91984",
            "16340   47616",
            "61060   77734",
            "83449   73477",
            "95624   61592",
            "59665   43681",
            "73466   26207",
            "28105   72855",
            "30366   84388",
            "77149   22611",
            "33253   61407",
            "85410   98021",
            "58953   38292",
            "11507   82605",
            "84193   40409",
            "67318   72169",
            "40951   43032",
            "32631   78869",
            "25986   87905",
            "34783   33741",
            "64766   96420",
            "32044   62692",
            "81719   96066",
            "41173   57799",
            "46506   65753",
            "80973   10632",
            "37604   64315",
            "14926   15607",
            "46951   38764",
            "34190   87339",
            "72553   38180",
            "56856   87339",
            "73201   25230",
            "29912   43877",
            "49041   40409",
            "27259   27672",
            "54695   31632",
            "17378   61404",
            "97583   47616",
            "28779   15607",
            "95351   29186",
            "21760   77098",
            "42140   81012",
            "77824   88349",
            "45097   68764",
            "67886   81012",
            "50329   18923",
            "14225   87864",
            "99434   30366",
            "74789   30366",
            "78427   70515",
            "84093   89297",
            "54252   35240",
            "92354   47516",
            "46752   14507",
            "46079   49156",
            "65108   84142",
            "82936   41244",
            "96838   42417",
            "78614   24301",
            "82821   87339",
            "24203   93674",
            "30815   11898",
            "58616   64137",
            "49264   84748",
            "84899   57841",
            "13259   17449",
            "92682   16921",
            "96799   63750",
            "62014   96606",
            "58075   65376",
            "35814   19808",
            "34373   47077",
            "14478   27815",
            "86144   70902",
            "60533   25055",
            "81602   14417",
            "29901   40949",
            "85294   63750",
            "12993   35240",
            "27069   10274",
            "61603   71842",
            "97912   82234",
            "58222   73144",
            "58425   18923",
            "68953   29200",
            "45936   75561",
            "28974   36348",
            "12938   86894",
            "70553   94318",
            "15933   98220",
            "89459   59594",
            "16124   12118",
            "13563   69410",
            "47498   47919",
            "31933   78661",
            "31603   71247",
            "62333   91906",
            "87887   81059",
            "46728   66262",
            "96367   11898",
            "17032   33050",
            "74418   91906",
            "62556   60465",
            "88486   91906",
            "36317   80462",
            "43877   77404",
            "43569   87339",
            "16010   20368",
            "37165   53213",
            "45349   64028",
            "32335   63037",
            "39988   98690",
            "89335   83946",
            "30312   26207",
            "60169   43299",
            "91417   98021",
            "10429   98021",
            "42506   38381",
            "99591   73168",
            "57117   50960",
            "29801   26207",
            "43063   87339",
            "56332   26207",
            "45819   39519"
        ];

        public static void Run()
        {
            Regex rx = new(@"([0-9]*)\s*([0-9]*)");

            int[] left = Data.Select(s => rx.Match(s)).Where(mx => mx.Success).Select(mx => int.Parse(mx.Groups[1].Value)).OrderBy(v => v).ToArray();
            int[] right = Data.Select(s => rx.Match(s)).Where(mx => mx.Success).Select(mx => int.Parse(mx.Groups[2].Value)).OrderBy(v => v).ToArray();

            Console.WriteLine($"Day 1 Part 1 Answer is  {left.Select((v, i) => int.Abs(v - right[i])).Sum()}");

            Dictionary<int, int> rightGroup = right.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine($"Day 1 Part 2 Answer is {left.Select(v => { rightGroup.TryGetValue(v, out int m); return m * v; }).Sum()}.");
        }
    }
}
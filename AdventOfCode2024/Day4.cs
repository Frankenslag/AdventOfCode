﻿
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    internal class Day4
    {
        private static readonly string[] Data =
        [
            "MXMXMAMXAXMSMMMSSSXSSSMXXMSSXSMSASXSMXSAMXSMMMSMSMMSSXMSMSMSMMMSSMAAXSAMXSMSSMASAMMMSAMXSSSSSSSSXSAXMMMAXMMSSXMASXXSAXSXXAMXSSMSXMSAMXMAMAMX",
            "SMMAMXMSAMXAAAAAXMAMXAMAASAMSXXXAXAXAASAMAAAAAAXMAAAMAMXAAMAAAAAAMMXMSXMASAAAMXMAMAMSAMXXAMAAAAAXMAMSASMXSAASASAXMAMXMASMASASAMXASXMSMSMSSSM",
            "AMSMSMXXAAXXSMSSMMAMSXMASMASAMXMMMMMMMXAMASMMSSSSMMSSMMMSMSSSMMSSMXAASXMASMSMMASMMXXXMASMAMSMMMMMMXMSASMAMMSSXMSXMXMAMAMSAMXSAMSXMAMAAAAAAAA",
            "MMMAAAMMSSSMXAXMAXAMXMXSAMXMAMSAAAAASMSSMMAAAAAAAMAMAMAAAAXMAMAMXMSMXSASMXXMASASAMXMASASMSMMAXXXMASMMMMMAASAXXXXMSAMASAXMXSXMAXMASXXASMSMMMS",
            "XMMSMMAXAAAASAMASMMSMSMMMSSSXMAMXMMMSAAXAMXMMMSMMMASAMMMSSMXXMXXAXAMXSAMXXASAMXSAMAMMMMSAMASMMSMXMAXAAXMASMMMMSSMSASASMSMAMMAMMMAAMSMMAMXXXX",
            "MXMXMASMMSMMMAMAMAAXAAAMAAMXMSSSSXSAXMASXMAXXAXXXXXMMSSXMAXAASMSMSASAMAMAMXMMMXSXSAMMMAMAMAMMAAASMMSSSSMXMASMMAAXSAMXSAXMAMAAXSAMXAAXMAMXXMS",
            "AAMXMMXAXMAMSAMXSMMMSMSMMMSAMMXAAASAMXMMASXSMMSXASAMXAMASAMXMMAAXXMMXSAMXSAAASMMMSMMAMASMMASMSSSXAAAAAXMASAMAMSSMMXMXMXMMSSSSSMXSMSMMSAMMXMX",
            "SXSAMSSSMSXMSASAXAXXAXXXMASASXMSMXMAXXAXXMMSAASMMMSSMSXMMXMMMMSMSMSSMSASXSMSMSASMSMMMSAMAXAAXAMMXMMMMMMSAMXSXMMAXSAMXMASXMAXXXXAXXAMXSSXSAMA",
            "MAMMSAAMAXSAMXMASMXSAMXMMASMMMAMXSMSMSMMSAASMMMAXMAMXAMSASMSAAMAAMAAXMAMAMAMXSAMASAAXMXSAMMMMMSSSXXMASAXSSMMAMSAMXAMXSAMAMXMMSMSSSMMXMAMSASM",
            "XAMXMMSMSMXMASXAXXAMASXAXAXASMSMSAAAAXMASMMMXSSSMMASXMASAMASMSMXMMSSMMXMAMMXMMMMAMXMSAMXXSAXMAAAXMSXMAASASAXAMMASMMMMMMXXSAAAAAAMXSAAXSMSXMM",
            "XMXXXXAAXXXMAMMMSMXSAMASMMSASAMXSMXMXMSMMASXAMAMXSASMXAMAMXMXAXXMAMAXAXSSMSXAAAMXSXMMMMMASASAMMSMMMAXXMMASXMSXSAMAAXMASAAAMSSMSMMAMMSMXASAMX",
            "XSASMSMSMSMMAMAMXAAMASAMSXAXMAMAMXMAXXXMMAMMMSAMXMASMMXMMSSXSSSXMAMAMMMMAAXMMXXSAMASAMXSASAMMAXMXSAMMSXMAMAXXAMXSSMMSAMMSMXXMXMXMASAMAMXMAXX",
            "XAAMAAAAAXXMASMSMMMSAMASMMSXSAMAMAASXMAMMAMAXSMSXMXMMMMSAMXAXAMXSSXSASASMMMMSSMMASAMSXXMAMMMXSMSASASAXAMXSMMMXMAMASAMXSXXXMMAAMAXAMMXXAMSSMS",
            "SMSMSSSMSMSMASMAAAAMASXMMAMASASXXXMXASXMSAMSAMASMMMAAAXMAMMAXXMAXXAMXMASXAXMAAXSAMXXMSXMXMAMAMAMASXMXSXSMMXAAAMMSAMXSXSAMAMAMSSXMMSSSMSXMMAA",
            "XXXAAAMXMAAMSMMXMMXSMMAAMXSASMMMSSSSXMMXMAMMAMXXAASMMXSSXMAMAXMXSMMMAMXMMASMSSMXXMXAMXSAMSMSSMSMMMMMAMMMAXSMSXSAMMMXSMSAMAXSMAXAXSAAAAXAAMSM",
            "SSMMMMMAMMMMXAASAMXXXSMMMMMMSXXXAAXMAXMAXSMXSMXMMMSAAAMXMMSSMMXMAXXMAXMAMXAXMAMMSMMASAMXASXAMAMMAAAXAAAMSMSXMAXMXMSXMASAMXMXMASMMMMSMMMSXMMX",
            "SAMMSMSMSSSMMSMXMAAMXMSMAAMAMXMMMSMMMMSSSXSAXMMMAAMMMMXAXAAAAXMSAMMSASAXSSMXSMSAAXAMMMMXSXMXXAAXXXMSMSMMAAXAMMMSAMXAMXMXMXAXMASXSXXXAMAXAXMM",
            "SMMXAAAAXAASAMXASMSMMAASMSSSXAASAAMAAAXXAAMXMAASMMSAMSSMMMSSMMMMAMAMAXMAAAMMSAMMMSSXAMSMMSSXSSSSMMXAMXXXMXMXAAASASXXMXSAMXSAMXSAMXXSAMASMMSS",
            "MXSSMMMSMSMMXSSMSAAXMSMSXAAXMSSMMSSSSSMMMMMAMSMSAASAMXAXMXAAAAXSAMMSSMXMSXSAMMMMMSASXMAAMAMMAAAAASXMSXMASXMSSMMSAMXAAAXASAMASAMAMMMSAMMXMAAA",
            "XAXAAASXMXAMSAMXMMMMMAAXMMMMAMAXAMMAAAMMXAXAXXAMMMSAMXMMMMMSMMMSASAAAMXAMXMMMXAMXSASMSXSMASAMMMMMMAXSAMMMAAXXSAMXMXAMXXXMASAMMSSMMAXSMAXMMSS",
            "MASMMMSAMXAMMMSAMXXAMMMMXSAMXSAMSSMMSMMASMSSSMSMXXXMASXAMAAXASASXMMXSMASXSSSMSMMAMAMXSAAXXSMXXSSSSSMMSSMSMMMSMXXAXSSSMSSSMMMSXAAXMMSMMMMXMAX",
            "SASAMXSAMSSMAASAMSASXSMXAMXMXMMAAXMMMMMXMAAXMAXASXMMXXSSSMMSAMAMMASAXXAAASAAMASMMMMMAMAMAXSXSXSAMAMAMAXMASASAMMSSMAASMAAASXSSMXSXXXAXAAMXMMM",
            "MASXMASAMAMSMMSXMXAMASAMMMSMMMMMMMXAAAMAMMMMMSMAMAASXMAXAAAMXMAMMAMMSMXMXMSMMASXXAXMASASMMMAMSMAMXMAMSSSXXXMAXMAAMMMMMMSMMSAMXMMXMSXXSSXASAM",
            "MAMAMMSSMAMSMMXMMMSMAMMXMASAMXAASXSMSSSMXMXMMAMASMMMAAMSMMMMASMSMXSMXMAMSMXSMXSXSXMSXSAMAAMXMASXMXSXMXAMAMSSXMMSMMXXAXXAXMMXMAAMAXASMMMMAXAS",
            "MSXSMXMXSSMSAMSAXSAMXMXXMASAMSSXSAXAAMAXXAMXXXSXSAMXXSMAAMXSASMAMSXXAXAMXAAMMMMXXAMSAMXSSMSMXAXMAMAMXMAMXMMAXXAXMSSMSMSMSMMMSMSSMMASXAAAMSMM",
            "XMAMXSMAMXASAMSMMSASMXSXMASMMMMAMMMMMSXMASXXSASXMASMMMXSSMMAASXSMSASMSSMAMMSAASMMMMSAMXAMAMMMSSSMSMMXSMMXMXAMMSMAAAAAAAMAMAXAMMAAMSMXMSMMAAA",
            "XMAXAXMASMMMSMSSXSAMXXMAXAMMAXMXAXMSMAMAXMAAMAMAMAAAAAAMAMAMXSAMAMAMMAXXAMAXXMXAAXASAMXMXMXAMMAXASAMXSAXAMAXMXAMMMSSMSMXAMMMAXSSMMAAAXAAMSSM",
            "XMXMSMSMSAMAMXMXMSASMSSMMSSSMSMSMMMAXMASMMMMMMSAMSSSMSXXAXMXAMAMXMAXMAXSSSXSSSMXSMXSAMMXAMXSMMAMXMAXASASASMSSXXSAAXAMXXMSMMSMMXMMMMXMSSSMAAA",
            "XAMSAAAXSXMASAMAAMAMAMXXAAMAAAXAASXXSMMXAAXXMAMXXXMAXAMSMSMMASAMXMSSMMMAAMASAAMAMXMXAMAMASMAXMASXXXMXSAAAXMAXASXMMSMMASXMAAAASXMMMSAAXAMXMMM",
            "MSMXMMMXSMSASASAXMAMAMMMMMSMSMSSSMMSMAMSXMXAMXXSAMXXXMXAAAXAMMXSXAAAAXMMMMSMSMMAMASXMMMXAMMMMMSMMSMMMMMMMMMSSMMSAMMAMASASAMSSMASAAAMXMMMMXXX",
            "AMAMSASMXAMXXAMASXASASASMXAXAAXXAAMMMAMXAMXSSSMMASXMMXSMSMMMASAMMMSSMXXAXXXAMXMASMMAASXSMMSXMXAAMAAAXSAMXAAXXXAXMMXAMAMMMMAMXXAMMSMMAAAXXXMS",
            "SMMASASMMMMSMAMAMMMSXMXAXMAXMSMSSMMSSSSSSMAXAAASAMAAMXXAAAMMMMASAAMAMMSMSMMMMXSAXXMXMMXAAAMASMSSMSSMSMMSSMSASMMSASMMMXMASXMASMSAAMASXSXMASXS",
            "XAXMMXMASAAAAAMMSMAMMMMMMSSMXAAXAAXMAMAAXMMMXMMMASXSMMMMMXSAXSSMMSSSMAMMAAASAXMASXMSASXSMMMAMXAXXMAMXXAXXXMAAMAMMSAXAXMASXAMAMXMXSAAAMASXMAS",
            "SMMXXAMASXSSSMXAAMMSAXAXMAAXSXMSMMMMAMMMMAAAASASAMAAXAAXAAXMXXMSXXAXMASMSSMSXSMAMAASAMXMAMMSSSMSXSAXSMMSXXMMMAAXXSXMSMSMSAXSXSMSAMMSASMSAMAS",
            "XMAMMSMASMMAXAMSSSXSXSXMMSSMMMXSAMASXSAMSSXSASASMMSMMSSMMMSXMASMXXMSMMSAMMAMXMMSXMMMAMAMAMXAAAAAASMMMAMMMMMMXSMSAMXMAAAAMAMAAMASMSAXXSXSAMAS",
            "MMASAXMXSAMAMMXMAMAMASMXAXAAXMAMAAASXSAXXAAMAMXMAAXAAAXMAMXAXSAMMSXAMSMMMMSAMXAXAXXXXSMSSSMMSMXMXMMXXAMAAMMSMAMSASAMMMMMMAAXXMAMXMASAMASMMAS",
            "ASASMXXAMXMAMXXMXMSMAMAMXSXMMMXSMMMXMSMMSMXMAMAMMSSMMSMSSSSMMXMXAMMMXXAXAAAAMMASMMSMMAXXMAXXAMSMMAAASMSSXSAAXSAXAMXXMXSASMSSXMXXAMXMAMAMAMAS",
            "MMAXXXMMSMSMSMMXXXAMAXMAMMAXAAXAXXXAAMAAXXSMMXXXAMMAMAASXAAMXMXMMSAXMSSMMSSMMMAAAXAASMMMSMMSASMASMMMSAAAAMMSMMXMSMSMSASASAAAXXSSMSSSXMASXMAM",
            "XMASMMSXAXAMAAAMMMMSASMXAXAMXSAMXMSASXMMSMSAMASMMSXAMMSSMXMMXMASASMSXAAAXMAMXMXSAMSXMAAAAAAMXMMMMXXXMMMMMMXMAMXSAAAAMAMAMMMSMXAAAXXAMSXMXMAS",
            "XMMSAAAAMSMSSMMAAAXMXSASMSAMXAMSAAMAXAXXAAXAMAMAAXXMSXXMAXSAXSAMXSAMXXSMMXAMXMAXAMMMSSMSSSXMASAMMXAMXASMMSASMMXAMMMSMAMXMMAAMASMMMSSMSAMASAS",
            "XMAMMMMSXMMAMASXMSXMXMAMAAXMASAXAXSAXAMSXSMMMSMSMMASAXMMSMXAMMSSMMMMMXMASMASXMASAMXAAXMAXMAMAMAXMMMMSMSMASXXAMXXXAXAMXSAXMXMSAMXSAAAXSAMXXMS",
            "AMASAAXXAMAXMAMAAXMMSMSMMMSXXMXMSMMMXAAXXXASMMAMXAXSASMAMAMXMAXXASAAXAXAMSXMXMASAMMMSSMSMSXMSSSMMSAAAASMMMMXAMMMSAMXMMMMSMSMMASAMMSMMMAMXAXS",
            "MSXSMSXSAMMMMSSMMMAAAMAXXXMMXMXAAAAMSSSMMSAMAMAMXSXXAMMASAMMMXSAMSSXMAXSMMXSXMASMMMAMMAXMMXXXAAAASMSMXSAXAMXXSAAXMSXSAXXAAAXSAMXSXMASXSMSMMX",
            "MMAMXMASXMXAAAAAASMMXSMMXXSAAXAMSXMMAAAXAMMMAMAMMMAMMMXAXXXAMAXXXXAMMSMXAMMMAXAMXMMXSMAMASMMMSMMMSMXXSMXMMSAASMSMAAAXMXSMMMMXXMASAXXMAAMAMSM",
            "MMAMMMAMMXSMSSMMMXXAASXSAASMSXMMMXMMMMMMSSMSMSXSAMXXAAMXSSXSMSSMSMAMAMASMMSSMMXMAMSAMMXXAMAAXMSAMXMMMSMASAMMMMAXAMMMMXMXAAMAMXMMSAMSMSMMAAMA",
            "XMASAMAMMMMMMMMMMMMMMSAMMXMMMMSAAAMASAXMMAASAAAXAXSMSSSXAMAXAXAMASAMXSMXMAXAXMASMXASXASMMSSSMMXMXXMAAXXAMXMMASXXSXSMSSMSSXSAMXMMMMMSAMXSMSXS",
            "SSMSXSAXXAAXAAAMASAAAMAMMXXMAAMMSMSASXSXMMMMMMSSSMSAXAMMAMMMMMMXAMMSMMMAMSMXMSASXSMAMAXAAAAAASMSMASMSSMMXSASAXMAAMMMAAAAAMXAMXAAAAAMAMAXAMMM",
            "XAMMXSASMSMSMSMSASXMXSMSSMAMMMSAXXMMSAMXMSXSAXMAMAMMMAMSXSMXMASMMSAAAAMAMMXSXMAXAAXMAMXMMXMMMMAAAXXMAAAAAMXMXSMSMSAMSMMMSMSSMMMSSMSMSMSMMMMM",
            "SMMMAXMAMMMAXMAMMSXSASAAASXMAXMXMMMAMAMXMXAMAMMAMAXMSXMMMMMASXSAXMXSSMSSSMAMAMAMXMMXSAASMSSXXSSMMMMMMXMMSMXMAMAAXMXMAMXMAMAMXAAXXAXMMAMAXSAS",
            "AXXMAMAMASMMSMXMXMAAAXMSMMMMMMMXMASMSASAMMSMAMSXSXSMXMXMAAXMXMMMSMAMAAAAAMAMSMMSMASAAMMSAAXXXMAMXSXAMXSXXMAMASMSSSSSMMASMMSSSMXSMMMXMAMMASAS",
            "SMSMSMSMASAXMMMSAMXMMMXXAAAASASASXSXSASMSAMMAMXAXXSXAAASMSSSSXMAMMAMSMASXMASAAAAMAMXSXAMMMSXMSAMASMXSAMAMXAMXSXAAAAMMXAXAAAMXSASAMASMXSMMMAM",
            "XAXAAAAMSSMMXAAXAMXAXXAXSMSMSASASASXMAMXMASXMXXXAMMASMMXAXAMMAMSXSAXXXXAAXSAXMMSMMMAXAMXAXMAXSXMASMMMMSAXSXSXMMMMMMMMMSSMMMSAMXSXMASMAAXXMAM",
            "MAMMMSMSAMAMSMMSAMSSMMMXAMXMMMMMMAMAXASXMXMAMSAMXAAAMXMMSMSMSAMAAXMASXXSMMMMXXXXXMSSMMXXMMMSMMASMXXXAXMAMSAMXXAXAAMMMAMAAMAMASXSMSSXMSMMXMAS",
            "AAXAAMXMAMAMAAAMXXAAAAXXSMXAMXSMSSSMMAMXXMSAMXMMASMXSAMXMAMXSSSMMSXMMAAXMAAMXSMMMXXMASMASAMAAMAMXAMMSMMSSXAMMSXXSMSAMXSSMMASXMASAXMAXMXAXSMX",
            "SMXSSSMSAMSSMSMSMMSSMSXSASAMXAXMAAAAMAXSSMMAMMSMXMXASMXMMAMXMAXXASMSSMMMSSSMASAAMSASXMXAXASXMMASMAMAMXAXAMAMXSAAXASMSAMXMSMSAMAMAMSMMXMMMASX",
            "ASXXAXAMXMXAMXMAAAMXAAMSAMXXMXMMMXMXMMMXAMSSMAAXXMMASMSMMAMAMXMMMSAXAXAMAXAMASASXSMMAXMASMMMXSASMSMASMMMMSMXAMMMMAMXMASXMAASMMMSMXAMMAAXSAMS",
            "SXSMAMMXXMSMMMXMMSAMMMXMMMMMMAASAMXXMXSSMMAMMSMXAXMXMAAMSSSMSAXXXMMMSSXSSSMMMSXMXSASMMSMXXASXSAXAAMXMAXAXAXMSSMXMAMAXAMMSMXMMAAAXSASXXSXMAMX",
            "XAAMAMXSMMMMAMXSAMAXAXAAAAAAMXMMASMAXSMAXMASMAASMXMXMSMMAAAASMMAXAMXMSAXAXAAXMASASXMAMASAMXMMMAMSMSAMXAMSMSXMAMSSSSXSAMXSMSASMSAXSMSAAMASAMM",
            "MXMAXSAMAAAMASXMASMMMSMXSSSSMAXSAMMSMAXAMMAXXMAXAAMXMXXMMSMMXSSSSXSAAXMMMSSMSMMMMMMSMSMMXXSMXMSMMAXXXAMXAXAMSAMXAAAMSAMXSASXMAMMMMASMAMAMASA",
            "MAXXXMAXSXSSMSAMXMAXMAMAAXMAXMMXXMAMSMMMSXSSXSXXSSMMSSMXMAXAXMMAAASMMMXMXMAAAXXMAAAAXMXSMMMSAMXMMMMSXSXSMSMMXSMMSMXMSSMAMAMXSMXAXMAMMXMASXMM",
            "SSSMMMSMMAAMMMMMAXMXSASMSMSASMMXSASXSMAXXAMMAMMXMAAXAMMAXMMSMSAMMMMMAMAMASMMMMMSSMSXSMAAAMMAMXXAMXXXAMAAXAAMAMMAXXXXMAMXSXMAMXXMMMMSMSMMXXAA",
            "XAXMSAMAMMMSXMASMSXXMASAMAMASASMSAMMMMSSMAMMAMMAMSMMSSSMSSXMAXAMXXASMSMSASXMAXXAMXAASMSSSMMSSSMAMXAMAMSMMSSMAXMASXMAXMMMMAMXMAAXAMXAMAAMSMMM",
            "MXMAMASMMSAAASMMMSMXMAMXMAMASMAAMAMAMAAAMAMSAMSAXAXXAAAMAMMMSMAAXXXSXAAMASMSSSMMSMMSMAAAMAMMAMXAMMMSAMXAXAXXMMMASAAXXSASMSMMSSXSASMSSSXMAAAM",
            "MSMMXMMAAMMMXMMAAMXAMAMAMXMAXXMMSXMSMMSSMXXMAXSMMASXMSMMASAAAMMMSMSMMMMMMMXMAAXAAASXMMMMMAMMAMSASXAMXXAXMMSXMAMSSMSAMSASAXAXAAAMAMAXMAXSSSSS",
            "AAAXSXMMMMMMSASMMXMSMXMAMAMSSMXMSMAAMXAMMXMMSMMMSAMMMMXSASMMSSMAAXAASXXSASAMXMMSSMMAXXMSMMXSAMXXAMXMSAMXAXMASXMMSMMAAMAMAMSMMSMSSMXMMAMMAMAM",
            "SSSMAXXSXSXASAMXSSMMASXMMAMAAAXAMMSMSXSSXSAAMAAMMSMAXMASAXASXAMSSXXAMXASASAXSAMXMASMMMAMMMMMMSXASXSXAAAXAMXMXSAAXXXMMMXMAMXAXXAAXXXXMASMAMAM",
            "XAAXMXAXAAMMSMSAAAAMAMASXSMSSMMXSXMXAMXXAXMSSMMSAMMSMAMMSMXAMMMMAMXSAMMMXMAMMXMAMMASAMAXSXMAAXXMMAMXSMMXSMSXAXMMMMXMASMSMSXMMMMMSSMMMXXMXMAS",
            "SSSMXMSAMXMXMAMXSMMMAMAMXAAAAXAXSASXXMSMMMXXXAXMMMAAAXAAXXXMSXMSMSMXASXMSMAMXSMSMSASXMASXASMMSMMMSMMXMXAMXAMMSMSASXSMSAASXXAAXMSAXAAMSMXMAXX",
            "XMAXXAMASAAAMMMMXMMMSMSSSMMSMMXXMAMXMAAAXXSXMMSMSMSSSXMMMSXXAAMAAAAMXMAAASASXMAMAMAMAMXAXMMAASMAAMXSASMAXASAMAAMAMMAMXXXSXMSASXMASXMMSAXSAMX",
            "XSAMXMSAMXSASXSSXSAAMAAAXXAXXSXXMXMAAMSXSXMAMSAAAMAMXXMAMMMSSSMMSMSMXSMMMXXSAMXMAMMMSAMXSXSMMMMMMSASASMSAMXAXMSMMMSMMAMMMMAMAMXMXMMMXMAMAAMS",
            "MMXAMAMMMMXXXAMXAXMMMMMMMMXSAMASMMXMSXMAXMXAXXMMMSXMSMSASMAMAXMXMAXMXXMXXMXMXMAMXMAXMAMAMXSAMSMSAMASAXAMXMMSMXAAXAMXMAMAAAMMAMXXMAXSAMMMSMMX",
            "AAASXXXAAMMSMAMMMMSASXMSXSAMAMAAAXSXXAMAMMMMXXXSMMXAAAMASMSMAMMSMAMXSAMSSMMSMSSSMXMMSAMXSASAMAAMXSAMXMXMASAXXSMSMAXAMSSSSSXSSSXSXMXMXSXAXXXM",
            "XSXXAAMSMSAAMSMSXAMAMAAAXMASXMSSSMAAMMSMMXASAXAMAASXMSMSXMAMSSXMMSMXMASAAAAAMAMXAASXSSMAMASXMMSMAAAXMMXXXMASAXAXMMMMMMAXAMAXAMMXAMXSXXMSMMMS",
            "AXMMMMMAAMMSMMAMMSSSSMMMMXAMXXMAXAMXMAAAAXAMXXMSMMMASXXMAMXMAMXMAXXXSMMMSMMSMSXMXXSAMXXAMAMAXMAMSSMMASMSMSMSAMXMASASASAMMMMMAMAMAMXAAMAMASAS",
            "AMAAMASMSMAMMMAMXMAXAXXXAMSSMMMMXSXMMSSSMMMSMMXAMASMMXSSMMAMMSXMASMXMAAXXAXXAXMSXXMASMSXSASMMXMXMAMSXXAAXXASXAXSXMASAXXXXAAXSMSAXXXXMMASXMAS",
            "XSSMSASXAMASASAMAMXMSMMMMSXAXMAMMMSAAMAXXAAAAXSASXSXMAMAASXXXSXSXXAASMMMMSXMAMAAXMMMAMSXSMAMAASMSAMSMMMMSXAMMSMMAMMMMMMMMSMSAAMMSMSMXMXXXMAM",
            "XMXAMASMMMMSASMSAXAAASXAXMMMMSSMSAAMXMASXMSXXMMMMAMMMMXSMMXSASMSAXSAMXAXAMMAAMMMXSASAXMAXMAMSASASXMXMSAAAMMMXAASAMSAXXAAAMMAMXMAAAXAXMMMXAXM",
            "XSAMMMMMXSMMMMASASXSMAXSMMAXMXMAMXSSSMASXMXMSSSXMAMXAMXASAXMAMAXAMXSSXMMASXSXSMXSAASASXSSSSMMAMAMMSAASMSXMASXMXSMSMAMSSMSXSXXAMSMXSXMXAMMMSM",
            "MAMXASAMXAAAMMMMAMXAXMAMASASAAMXMAXAAMXMASXAAAMASXXSAMMAMMSMAMXMSMXXMXMSXMAMAMXXAMXMXMMAAAMAXXMXMXSMMMXAAXASASAXXXXAMXMAXXAAMAMAMXMASXMSAAAX",
            "MASXXSASXSMMSASMMMSXMXXSAMASXXMAMXMXMMMSMMMMMSMMXAMMMSMXMAMMMSMMXAMXMMXAMMMMAMSXMXSXAXMMMMMXMMSMSAXMAAMSSMASMMMXMMSASXSASXMSSSSSSXSAMAASMSMS",
            "SAMXXSAMAXAASXSAMASAMXMMAMXMAXMAMMSMAMAAASMMAAMXXMXAAXMSMMMAXSXAMAMAMXAMSAXXAMXAMASXMMAAMASXMXAAMXSSSSMAAMMMMAMXSASMMXMASAXAAXXAAAMXMMMXAMMS",
            "MMSMXMMMAMMMMMSXMASMSAMXSMMSAXMAMAAXMAXXXXAMSSSMSASMSSXMAASXMSMASAXXSXMMSXXSMMSAMASAXASMSASMSAMXMXXXMAMMSMAASXSAMXSAXSMASXMMSMMMMMMMXSMMXMAX",
            "MMAAAXAMAXXXAXXXMXSXSAXXAMXMAXSAMXMAXAMXSSMMAAAAAMXAAXAXMASAAXAAMXSSMMXMMSMAAXMMMSSMMXMXMASAMASAMMMMSSMMAMMXMMMAXMSAMXMASAXAAAMXAXSMAMAMMMXM",
            "SSSSMSMMSMMMMMMMMXMASAMSSMXMAMMXXMASMASAAAXMASMMXXMMMSSMSAMMMMSASMMAAAXAAAXXMMAXMXMAMSSSMMMXMASASXXAAAASMMSAAXSAMXMSSXMXSAMSMSSXMSMMASAMXXXX",
            "AXAAAXAAXASXSMSASAMXMAMAAMAMXSXMSMAMMAMMSMSAMXMSXMMSMAMAMASXMAMAAAMSXMSMSSMSASXMAASAMAXAXAAXMASAMMMMMSAMAASMSMMXSAAXMASMXXMAMMAMMAMSAMASAMMM",
            "MMSMMMMMSAMASASXSSSXSSMMMSAMAXAMAMAMMASXMMMMXAXMAMAAMAXMMXMXMASMSSMXAMMMAAASAMMMSMSXSMSMMMXSMXMAMXAAAMAMMMSXMXXASMSMSMMXMMSMSMAMSAMMMSMMAXMA",
            "XAMXXAAAMAMXMAMMMAMXMAAXASAXSSSSMSASXMSAAXAXXMSSMMSSSSSMASMMMAXXAAXSXMAMMSMMSMXAAXXMSXSMAXMMMSMMSSMSSSSMMXSAMXMMSAXAAXMAAXAXXXAMMXMMAAXSASAM",
            "MSSSMSMSSXMAMXMAMAMAMMMMMSAXMAAAAXXXAASXMMMSMAAAAAAMMAAXMSAAXASMSMMSMXXSAMMAMXMSSMSXSAMXXXAAAAAAXAAAXMAAAAMAMMASMAMXMSSMSSMSMMSSXSMMSSXMASMS",
            "AXAMAAAMXASXSASMMASMMSASMMMMMAMMMXSXMMMXSAAAMMMSMMSSMSMMXSXMSXSAMXSXSXXMASAXXMAMAASMMSMSSMSSSSMMSMMMSSSMMXSAMAMMMAMASXXXAAMAAXAMXMAAAXXMAMXA",
            "MMAMSMSMAMMMXASXSMSAASXSAASAMXMAXSMSMXMASMSSXSAMXMAMAAXMXMAXSXMAMMMAMMMMMMMXMXSMMMMAAAMAAMAMAXMXAAXSMMAAXXSMXSAMSSSXSASMSMSSSMASXSMMSMMMAXSX",
            "XMAMXXXMAMAXMXMAAXMMMMASMMMMXMXXSMAAXAXAXAAAMMMMSAMXSMSXASMMSMSAMAMXMASAXXMAMAMAXXSMMSSSMMMXSAMSAMXSASXMMXMMAXAAAMMMMXMAXAXAAMSMMXSAAXAMXXSM",
            "MSMSSMMSASXXXAMXMMMAAMAMASMSMSMMMMXMSMSSMMMMMAAXXSAMXAMXXXXXXXXASMSMSXSMSMSASMSMMMSAMXAXMAMXMAMAXXASAMMMSAMMMSAMXSASMAMSMSSSMSXSXMASMSXSSMSA",
            "MAMXAAASASXASMXXXASXMMASXMAAAAMSASAXAAAXAMXMSMMMXMXXAAXSXSSXMAMXMASASASAAASAXAAMAAXAMMXXSASXSXMMSMMMSMAASASAAAASAMMASASAAXAXMXAMMSMMMXMAMAXS",
            "MASXSMMSXXMASAASXMSAMSAMAMSMXMMSASMSMMMXSAMXSAXSAMSSSMAXSAMXMASAMXMAMAMXMXMAMSSSMSSMMSAASASAMSAMXMMAMSMXXAMMXSAMAXMMSXSMSMSMXMAXAAAMAMXMMMMM",
            "SMSMXXMXMXXMMMMMAAMAMMASMMMXSXAMAMXAMAAMMMAXMAXXAMAAAMAMMXMXMASMSMMSMXMAMAMXMAAAMAAMAMXMMAMAMXSAMXMAMMMSXAXXAXMSSMSXXAMMMAMXXXMXSXXMAXXXAXAS",
            "AXMMMASAMSAMXMASMMMSMSMMMAMMAMMXMAXXSMXSAMSXMSMSMMMSMMAXMASMMAMMAXMMASMMSAMSSMXMMMMMSSMXMXMXMAXXSASASAAMXMXMASAAAMXASXSASXSMSAAXAASXMMMSMSAS",
            "MAMAXMMASXASMMMXSXAAMAAAMSXMMAMAXAXXAMMSMSMXXAAAXAMAASXMSASMMSMSASMSAMAAXAMAXAASAMSAMXAAXMMAMXSXSASASMXSASXSAMMMSAMXMAAXSAAASXSXMXMAAXXAAMMM",
            "XASMSAMXMXXMAAMAMMSSMSSMXMAAXXSASMSMASAXMAMAMMSMSMXSXMMMMASAAAXMASASAMXMSXMXSMMXAAMXMASMSASAMMXAMXMAXMASASAMXSMSAASMMXMSMMMMMMMAXASMMMMMSMMS",
            "SMSASXSMMMSSSMMAXXAAAXXXAXAMXXMXSAAMAMMMMAXMAXAMXMAXMMAAMXXMASMMMMMMAMXXAASMSASMSMSAMMXXAMXMSSSMMAMXMMAMXMXMAMXMAMMASAXAXAMSAAXMMMSAXMAMXMAS",
            "AAMAMMXMAAAXAASXXMMXMMAMMSSMMAMAMMMMMAAAMASXMXAMXMASASMSXMASMXXSXAASAMMSMMSASAMAMXSASASMSMXSAMAASMSAXMAMSXMMSSMSSSSXMASXXSSSMSXSAAMMMSSSXSAS",
            "MAMMMMASXSMSSMMSSSMMSMXMAAAAXXMAMAXMSSSXSASMMSSMMMXSAMAMMMXMSMMMSXMMAXAMXXMXMSMXMASAMAMAAASMASXMMASMMSSMMAAAMAAAAXAMXXMMAXAMXMASMSXXXSAMAMXS",
            "XASMAMASXMXXMAMAXAAAMASMMSSMMMSMSMSMAAAAMXMAXAMAMSMMMMMMAMMAAXAMXMSSSMASXXSAXASAMXXMMAMXMSXSMMMAMAMMXMMASMMXSMMMSMMAMMAMXMAMAMMMAMAMXMAMSMAS",
            "MAMXAMXXAMAXXAMMSSMMSAMAAAAAXAAMAASMMSMSMMMMMXSAMAAAXAXXAMMSMSSSSXAAMXMXMASMSMSXSMSMSMSXMXMXMASAMXSXAASAMAXAMASXMAXXAMXMASXSASAMMMMMASAMXMAM",
            "MSMXMSMXXMASXMSXAXMXMMSXMSXMMSMSMAMAXMXXAASASASASMSXSAMMAXMXAXAAXMMSMASAMXMAAXXMMAAXAAMMMAAAMXMAAAMMSMMMSAMXSAMASMMMSSMSXSASASXSXMSSXSAMXMAS",
            "AAAXSAMXAMAXAAXMXMAMSASXMMASMMAMXMXSMXMMSMSASXSAMXMMSASXSMXMMMMMMMAAMASXSAMSMXSAMSMSSSMASASXSASXMMSAMMSMSMMMMAMMMAAAAAAMAMMMXMAXAXMAMXAMMMMA",
            "SMSMSAMMMMSMMMMMXSMAMASXMSASAMXMASAMXAXXXAMAMAMMMMMAMAMAMXMAMASAAMAMXXMAXAXXAASMMXAAAAXMMAMXXAMAMAMXSAAAMAXSSSMSSSMMSMMMMSXMAAAXMMMMAXAMXAAM",
            "XAAMMMMXSAMAXSXSAMAMMAMAXMASAMASAMXSSMMMMMMAMAMMAMXSMMMAMASMMAXMMMSSMSAXSXMMMMSMSMMMMMMSMXMMXMSSMMSASXMSMMMXAMAXAXMAMXAAAXASMMMXMAAXSASMSMSX",
            "MMMMASMXMASMMMAMMSSXMASMMMMMMMXMASAMXMASASMMSMMSASMXASXSSXSAMSSMSAMAAMAXSAXXSXSAXASXMSASMASAMMAXXXMMXAMXAXMMSMMMAMMSXMMMSMMMMAAAMSMMXAXAXAAA",
            "SAAMMSAAMAMXAMXMXXMASXXAXMAAAMMSMMMSAMMSASXMSAASASXSXMAAMXSAMXAXMAMMMMMMXAMAXAMAMXSMASAMSMSAXMAMSAMXMSMSMMSMMASMXMAAAMSMXMAASMSMXAMXMAMMMMMS",
            "SSMSXXMXMXSSXMXXMAMXMSSMSSSSMSAAAXAMAXAMAMAMMMMSAMAMXMSMSASAMMMMSMMASAXXXAMMMXMXMXXMAMXMAMMMMXSSXXXSXMAXMASASAMMAMMSSMAASAMXSXAMSMMAMAMMAMAM",
            "MXMSASXXXMXMAMXMMSAMXASXAAXAXMMMMMMSMMSSMSXMASXMMMAMAXAAMASAMXMAAASASAAMSXMAMMMSMXXMXSXSMSMAAXXMMXMXAMAMXXSXMAXSASXAXXMMMMXAMXMMXSSXSSSSSSSS",
            "AAXMASXMXAAMXSSMAXAAMASXMSMSMSSSMAXAMXXAXSAMASMMMSMSSXMXMXMAMXXSSMMXSMMXAAMMMSAAXXMMXMMSAAXASXSAAMAMXMSMXASXSSMSXSMMXXMMAXMSSSMAAMXAMAAXAAAM",
            "SSMMAMAMASMSAAAMAXMSAMMMXAAAAAAAAXSASMSMMSAMAXAAAAAMAMSXSXSXSMXXXMMMXAAXMMMSAMSSMSAMSAAMSMMMXAXXMASXMAXXXXMASXAXMXMAASMSXSXAAAMMSMXXMMMMMMMM",
            "XXASMSAMMMAMMMMMSMMAMAASMMSMMMSMMMMMXAAXASMMSMXMSSSMMMSAMAAAAXXSSMASXMMMXSXMAMXMAMAMMMMXAXXSMXMMMAMAMAMSXMMMMMSMMAMAMMAAAMMMAMXMAMSXMAMAAXXX",
            "MSMMAMMMAMSMSXSAAAMASXMSXAAAXAAMXAXAMSMMASAAMXMXAMAAXAMAMXMSMAMMASAMAAAAASXMXMAXSSSMMAMMXMSMAMSSMXSXMASMXMAMAAXASXSSSMSMSMSXAMAMAMSAMAMSMSAM",
            "AAMMSMASMSMAXAMMXMMXSXASMSMSMSSSSXSXXAAMAXMMSAMMASXMMMSAMXXAXMXSAMMSSMMMMSAASMSMAAAXMAMSAMAMMMAAXAXASXSAMMSMMMSAMAAAAAXAMASXASASXMSXMAXXAMAS",
            "SASAAMXMXAMSMMMSSMSMSMXSAXAMXXMAXASAMXXMMXSAMAMSMMAXAXSMMMMASXMMAMXAAXXMASMMXAMAMSMXSAMSASASAMSSMXSMMMSASAXASAMAMAMSMMMAMAMMAXXMAXMMSSSMASAM",
            "XXMXSXXXSMMXASAXMAAAXAMMAMXAAMMSMMMSAMXXSAMASMMXASXMSMMMAAMAMXMMMXMASASMAXAMMMMXMAXXMMMSAMXMMXMXMASXAASAMAXAMMSSMXAXAMXAMASXMMASXMAAXAAXXMXX",
            "XSSMMASMXMAMMMMSMSMSMAAMAMXMAMAXASAAMSAMMASAMXXSAMXMAMASMSMSXXAASAMMAMXMAMAMSXSXXXSMXMAMMXSXMAMAMXMXMXMXMXMSMMAMMSSSMMSXSAMAASAMASXSMSMMMMMS",
            "XXAAMAMAMSSMXAXMAXAMXXSXMMMSAMASAMSXXMAXSAMXXMAXMAXSASMSAMXAAXSMSASXAAXASXSASAXMSMMMSSSXSAMASXMXSAMXSAMXSAMAAMASAAXAMXSAMASXMMASAMXMAAAAAXAA",
            "XSMMMAMMMAAMSSSMMMMMAAMASAASXSAMXMXXMSMMMXSAASXXSMASASAMXMMMXMMASAMXXMXMMMMAMAMAAAXAAAXAMASMMSAMSASASAMXSASXSMAMMSXXMAMXMAMAASAMXSAMXSSMMMSS",
            "AAAXSMSMMMXMXAAMSAMXSMSAMMXMAMAMXXXMMAAMXAMXMMAASAMMAMXMXMASXMMAMAMXSMMMAXMXMSASMXMMMMMXMAXXAMMASXMASXMXSXMXAMASXMMMMSSMSAMMMMXSASMSAXAXXXAX",
            "SSMMXAAXMASXXSMMSASAMXMAMSAMXMAMXMSAMAMMMXMXSMMMMAMXXXAMXSASAAMXMXMAAAAMSXSAAXMXMXSMMMSAMXXMSMMMMXMXMMSAMXMXMSXSAMASAAAMSSMSSSXMMSXMXMAMMAMX",
            "XAMXMSMSMMXMAXAXSXMAMASAMXMXAAASAAASMSSSXSSXMASASXMAMSASAMASXMMSSMMSSSMMXASMSMAMXAAAAXSASMMMMASXMAXAAXAXXAMAMMMSMMMMMSMMXAXAAXAAXSXSSMAMXSXM",
            "XSMSAAMAXMAMXMMMSXMAMAMXXAXMASASMSMXXMAMAASASASMSAMXMAMAAMAMAXAXAXAXMAXAMAMMMAASMSSSMXMMAAXAXAMASAMSSMMMMXMASAAMASXAMMXSMMMMSMMSMMAAXMXMAMAM",
            "SMASMXSAXMASAMMXMASAMSSSSXSAMXAXAAAXAAAMMMSXMASMSMMMMASXMMSSSMSSMMSMSSMMSASXMSASAMAMXXSSMXMMSXSAMXMMAMAAXMSASXMMAMXXXAMMAAAAAAAAAMMMXMAMASAM",
            "AMAMMMMMXSASAMAASMMMSXAAXMAXMSMMAMMXMMXSMAXAMXMAXXAAAAXASXAAMAXAXAAMMMMXSASAMXMMXMASMXMASXAMAXSMSMXSASMXSAAXMMXMXSMSMMAMSMMSSXMMXXMSASASMSXS",
            "MMASAXAAMMXMXXSMMAAXXMMMMSMAMAAASXSXXSMMMMSSMSMMSSXSMMSAMXMMSSSSMSXSAAXAMXMMMAAXXMAMMMMAAMSMXXMASAMSAMASMXMASXMSXAAXAMSAMAXMAMSXSMMSASASASMS",
            "XSASMSMSSMMMSXMASXMXXXAAMAXMSSMMMAXMAMAASMAMMXAXXAMMAMMASXXXAXMAXAMSXMXAMXMXSXSMSMMMXXMXMSAMXXMAMAXMAMXASAXMXMAMMMMMXMAASAMMAMMAASAMXMXMAMAM",
            "XMAXAMAMAMAAAAMAMMAMSSSMSAMMAMAAMMMSSSMMXMAMSSXMMMASAXXAMAXMASMMMSMSAMMAMSAMXXMAAAAAMXSMMSASMMMSSMMSMMXMSMSMSMMSASMSSMMMMXXXXMMMMMMXAAXSAMMM",
            "SMSMSMAXMSMSSMMMSMAMXAMXMMMMASXMMSAAAMXSMMSSMMMMAMMSMSMASXMASAAMXMAMAMXSAXSAMXSSSMMSAMXAAXAMXAMMAMMASAMXSXAAAAMSMSAAAMXSASMSXMXSASXSXSASMSXX",
            "XAAAXXMMXXAAAAAAAXAMXAMXMMAMAMASMMMSSMXXAMMAAXAXASASAAXXMMMSMXXMAMAMXSMAAXAXSAMAXAAXMXSMMSMXSSSMAMMASXSAMSSSMSMMXMMMXSAMMSAAAMASXSAAAMXMAMMM",
            "MSMSMASMSMMMSSMSXSSSSXMSMSASASAMXAAAAXMAMSSSMSSSMSMMSMSXMASASASXMSXSAMXMMMMMMASAMMXMSMAMAAMXXMAMXSMMMMMAXAXAAXXMASAAAMASXXMSSMASAMXMXMSMSXAA",
            "AXSXXMAAMXSXXMAXASAMXAAXASASXSAXXMMSSSXSXMAMAAAAASXXAMAMSMSASMAAAXAMXXXMAXAAXAMXXXMMXSASMXSASMSMAMXMASXMMXSMXMASASMSSSSMMAMAXMXMAMAXAXAAXXSM",
            "XSAMXXMXMAAAMAAMXMASXXMMMMAMASXMSMAAAAAMMMAMXMXMMMXSAMXMAMMAMXSMMMXMSAMSASXMSAMAMSMMASXSAAXXAAAMASMSMSAAXMXXASMMAMXXAMXASXMASMSAMXMSXSAMXXMM",
            "MMMMMXXAMSSXAMXMSSSMMAAXXMXMAMXMAMMSSMXMASMSXXXSXSXSXMAXAXMXMAMMXSXAMMAAXMAMMXMAMAAMAMXMMMMSMXMXAMXAASMMMMMSASXSMSMMSASMMSMAXAMAMMMAXSAMSAMX",
            "SASASXMMXAXXMXSSMXMAXSAMXMXMAMMSAMXXXXXSAMAAAMXMASAXAXSSSXSAMXSXAMMMMXSXXMXMMSSSSXSMSSXXAAAXAASMSMSMXMMMXAAMXMAXAAAAAMXAASMMSSMMMAMMXSAMMAMM",
            "SASASMSSSMMSMMMAMMSAMAMSAMXSASAAASMMAXAMMSXMASAMAMMSSMMAAAMASAXMASAMSAMMSMMAAXAAAAXAMXMMSSSMXMSAAAXMXAAMSSXSSXAMSMMMSSSMMMMAAMASASMMAMSMXAMX",
            "MAMMMAAAAXAAAASAMAMSSXMAXXMSASXMSAASAMXMASAXXAAMXSAAAAMMMMSAMXSAXSASMAMSAASMMSMMMMMAMXAAXAAAXXMMMSMSSMMMAMXXAMMXAAMAAXAXMAMMMSAMAXAMXSAMSXSX",
            "MXMSMSMSMMSSSMSASAMXMASMXSXMAMXXMXXMXXMAMSAMXSMMMMMSSXMXXMAMXXSAMMMMMXMMSXMAMSXXMMSSMXSSMSMMXXSSXXAXAMXMASXMASXSSSMMSSSMSASAXMASXSSMMSXMSAMX"
        ];

        public static void Run()
        {
            int lineWidth = Data[0].Length;
            
            string strWordSearch = Data.Aggregate(new StringBuilder(), (c, n) => c.Append(" " + n), sb => sb.ToString());

            string strRegexPt1 = $"XMAS|SAMX|X.{{{lineWidth}}}M.{{{lineWidth}}}A.{{{lineWidth}}}S|S.{{{lineWidth}}}A.{{{lineWidth}}}M.{{{lineWidth}}}X|X.{{{lineWidth + 1}}}M.{{{lineWidth + 1}}}A.{{{lineWidth + 1}}}S|S.{{{lineWidth + 1}}}A.{{{lineWidth + 1}}}M.{{{lineWidth + 1}}}X|X.{{{lineWidth - 1}}}M.{{{lineWidth - 1}}}A.{{{lineWidth - 1}}}S|S.{{{lineWidth - 1}}}A.{{{lineWidth - 1}}}M.{{{lineWidth - 1}}}X";
            string strRegexPt2 = $"M.S.{{{lineWidth - 1}}}A.{{{lineWidth - 1}}}M.S|M.M.{{{lineWidth - 1}}}A.{{{lineWidth - 1}}}S.S|S.M.{{{lineWidth - 1}}}A.{{{lineWidth - 1}}}S.M|S.S.{{{lineWidth - 1}}}A.{{{lineWidth - 1}}}M.M";

            Console.WriteLine($"Day 4 Part 1 Answer is {strRegexPt1.Split('|').Select(rxstr => Regex.Matches(strWordSearch, $"(?=({rxstr}))").Count).Sum()}.");
            Console.WriteLine($"Day 4 Part 2 Answer is {strRegexPt2.Split('|').Select(rxstr => Regex.Matches(strWordSearch, $"(?=({rxstr}))").Count).Sum()}.");
        }
    }
}

using AoC2024_Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Day4Tests
    {
        [TestMethod]
        public void Part1_Test1()
        {
            string[] map =
            {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            };
            //string[] map =
            //{
            //    "--X---",
            //    "-SAMX-",
            //    "-A--A-",
            //    "XMAS-S",
            //    "-X----"
            //};
            var Day4 = new Day4();
            Day4.ProcessMap(map);
            Day4.PrintParsed();
            Console.WriteLine(Day4.count);
        }
    }
}

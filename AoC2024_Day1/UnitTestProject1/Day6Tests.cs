using AoC2024_Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void Part1_Test1()
        {
            string[] input =
            {
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#..."
            };
            var D6 = new Day6();
            D6.LoadMap(input);
            Assert.AreEqual("41",D6.GetAnswerPart1());
            D6.PrintMap();
        }
    }
}

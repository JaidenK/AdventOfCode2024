using AoC2024_Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Day6Tests
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

        [TestMethod]
        public void Part1_Test1()
        {
            var D6 = new Day6();
            D6.LoadMap(input);
            Assert.AreEqual("41", D6.GetAnswerPart1());
            D6.PrintMap();
        }

        [TestMethod]
        public void Part2_Test1()
        {
            var v1 = new Day6();
            v1.LoadMap(input);
            var v2 = new Day6(v1);
            v2.PlaceObstacleInFrontOf(6, 4);
            v1.PrintMap();
            v2.PrintMap();
        }

        [TestMethod]
        public void Part2_Test2()
        {
            var D6 = new Day6();
            D6.LoadMap(input);
            Assert.AreEqual("6", D6.GetAnswerPart2());
            D6.PrintMap();
        }
    }
}

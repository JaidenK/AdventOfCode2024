using AoC2024_Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Part1_TestMethod1()
        {
            var Day3 = new Day3();
            Day3.ParseLine("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");
            Assert.AreEqual("161", Day3.GetAnswerPart1());
        }
        [TestMethod]
        public void Part2_TestMethod1()
        {
            var Day3 = new Day3();
            Day3.ParseLine("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
            Assert.AreEqual("48", Day3.GetAnswerPart2());
        }
    }
}

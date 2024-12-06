using AoC2024_Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Part1_TestMethod1()
        {
            Assert.IsTrue(Day2.IsReportSafe(Day2.ParseLine("7 6 4 2 1")));
            Assert.IsFalse(Day2.IsReportSafe(Day2.ParseLine("1 2 7 8 9")));
            Assert.IsFalse(Day2.IsReportSafe(Day2.ParseLine("9 7 6 2 1")));
            Assert.IsFalse(Day2.IsReportSafe(Day2.ParseLine("1 3 2 4 5")));
            Assert.IsFalse(Day2.IsReportSafe(Day2.ParseLine("8 6 4 4 1")));
            Assert.IsTrue(Day2.IsReportSafe(Day2.ParseLine("1 3 6 7 9")));
        }

        [TestMethod]
        public void Part1_TestMethod2()
        {
            var d2 = new Day2();
            d2.ParseExampleInput();
            Assert.AreEqual("2",d2.GetAnswerPart1());
        }

        [TestMethod]
        public void Part2_TestMethod1()
        {
            Assert.IsTrue(Day2.IsReportSafe2(Day2.ParseLine("7 6 4 2 1")));
            Assert.IsFalse(Day2.IsReportSafe2(Day2.ParseLine("1 2 7 8 9")));
            Assert.IsFalse(Day2.IsReportSafe2(Day2.ParseLine("9 7 6 2 1")));
            Assert.IsTrue(Day2.IsReportSafe2(Day2.ParseLine("1 3 2 4 5")));
            Assert.IsTrue(Day2.IsReportSafe2(Day2.ParseLine("8 6 4 4 1")));
            Assert.IsTrue(Day2.IsReportSafe2(Day2.ParseLine("1 3 6 7 9")));
        }

        [TestMethod]
        public void Part2_TestMethod2()
        {
            var d2 = new Day2();
            d2.ParseExampleInput();
            Assert.AreEqual("4", d2.GetAnswerPart2());
        }
    }
}

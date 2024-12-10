using AoC2024_Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Day7Tests
    {
        [TestMethod]
        public void Part1_Test1()
        {
            var Eq = EquationD7.FromString("190: 10 19");
            Console.WriteLine(Eq.ToString());
        }

        [TestMethod]
        public void Part1_Test2()
        {
            Assert.IsTrue(EquationD7.FromString("190: 10 19").IsPossible());
            Assert.IsTrue(EquationD7.FromString("3267: 81 40 27").IsPossible());
            Assert.IsTrue(EquationD7.FromString("292: 11 6 16 20").IsPossible());
            Assert.IsFalse(EquationD7.FromString("83: 17 5").IsPossible());
            Assert.IsFalse(EquationD7.FromString("156: 15 6").IsPossible());
            Assert.IsTrue(EquationD7.FromString("156: 15 6").IsPossible(true));
            Assert.IsFalse(EquationD7.FromString("7290: 6 8 6 15").IsPossible());
            Assert.IsTrue(EquationD7.FromString("7290: 6 8 6 15").IsPossible(true));
            Assert.IsFalse(EquationD7.FromString("161011: 16 10 13").IsPossible());
            Assert.IsFalse(EquationD7.FromString("192: 17 8 14").IsPossible());
            Assert.IsTrue(EquationD7.FromString("192: 17 8 14").IsPossible(true));
            Assert.IsFalse(EquationD7.FromString("21037: 9 7 18 13").IsPossible());
        }

        [TestMethod]
        public void Part1_Test3()
        {
            string[] lines =
            {
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20"
            };
            var Day7 = new Day7();
            Day7.ParseLines(lines);
            Assert.AreEqual("3749", Day7.GetAnswerPart1());
        }

        [TestMethod]
        public void Part2_Test1()
        {
            string[] lines =
            {
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20"
            };
            var Day7 = new Day7();
            Day7.ParseLines(lines);
            Assert.AreEqual("11387", Day7.GetAnswerPart2());
        }
    }
}

using AoC2024_Day1.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void Part1_Test1()
        {
            var rule = Rule.FromString("12|34");
            Assert.AreEqual(12, rule.Page1);
            Assert.AreEqual(34, rule.Page2);
            rule = Rule.FromString("12,34");
            Assert.IsNull(rule);
        }
        [TestMethod]
        public void Part1_Test2()
        {
            var update = Update.FromString("12,34,56");
            Assert.AreEqual(12, update.Pages[0]);
            Assert.AreEqual(34, update.Pages[1]);
            Assert.AreEqual(56, update.Pages[2]);
        }
        [TestMethod]
        public void Part1_Test3()
        {
            var update = Update.FromString("12,34,56");
            var rule1 = Rule.FromString("12|34");
            var rule2 = Rule.FromString("34|12");
            var rule3 = Rule.FromString("12|78");
            Assert.IsTrue(rule1.AppliesTo(update));
            Assert.IsTrue(rule2.AppliesTo(update));
            Assert.IsFalse(rule3.AppliesTo(update));
            Assert.IsTrue(update.Satisfies(rule1));
            Assert.IsFalse(update.Satisfies(rule2));
            Assert.IsTrue(update.Satisfies(rule3));
        }
        [TestMethod]
        public void Part1_Test4()
        {
            string[] input = {
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
            };
            var Day5 = new Day5();
            Day5.ParseLines(input);
            Assert.AreEqual("143", Day5.GetAnswerPart1());
        }

        [TestMethod]
        public void Part2_Test1()
        {
            var update = Update.FromString("12,34,56");
            var rule1 = Rule.FromString("56|34");
            var sorted = update.GetSortedToSatisfy(new List<Rule> { rule1 });
            Assert.AreEqual(12, sorted.Pages[0]);
            Assert.AreEqual(56, sorted.Pages[1]);
            Assert.AreEqual(34, sorted.Pages[2]);
        }
        [TestMethod]
        public void Part2_Test2()
        {
            string[] input = {
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
            };
            var Day5 = new Day5();
            Day5.ParseLines(input);
            Assert.AreEqual("143", Day5.GetAnswerPart2());
        }
    }
}

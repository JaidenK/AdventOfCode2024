using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] input = {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            Regex regex = new Regex("(\\d+)\\s+(\\d+)");
            foreach(var line in input)
            {
                Match m = regex.Match(line);
                list1.Add(int.Parse(m.Groups[1].Value));
                list2.Add(int.Parse(m.Groups[2].Value));
            }
            list1.Sort();
            list2.Sort();
            int sum = 0;
            for(int i = 0; i < list1.Count; i++)
            {
                sum += Math.Abs(list1[i] - list2[i]);
            }
            Console.WriteLine(sum);
        }
    }
}

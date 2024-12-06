using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class Day1Tests
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
        [TestMethod]
        public void TestMethod2()
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
            foreach (var line in input)
            {
                Match m = regex.Match(line);
                list1.Add(int.Parse(m.Groups[1].Value));
                list2.Add(int.Parse(m.Groups[2].Value));
            }
            //list1.Sort();
            //list2.Sort();
            int sum = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                var needle = list1[i];
                var correspondence = list2.Where(x => (x == needle)).Count() * needle;
                Console.WriteLine(correspondence);
                sum += correspondence;
            }
            Console.WriteLine("Sum: "+sum);
        }
    }
}

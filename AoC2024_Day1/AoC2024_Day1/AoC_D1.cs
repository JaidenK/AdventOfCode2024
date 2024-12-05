using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class AoC_D1
    {

        public string GetAnswerPart1(string filename)
        {
            var input = File.ReadAllLines(filename);
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            Regex regex = new Regex("(\\d+)\\s+(\\d+)");
            foreach (var line in input)
            {
                Match m = regex.Match(line);
                list1.Add(int.Parse(m.Groups[1].Value));
                list2.Add(int.Parse(m.Groups[2].Value));
            }
            list1.Sort();
            list2.Sort();
            int sum = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                sum += Math.Abs(list1[i] - list2[i]);
            }
            return sum.ToString();
        }

        public string GetAnswerPart2(string filename)
        {
            var input = File.ReadAllLines(filename);
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
                //Console.WriteLine(correspondence);
                sum += correspondence;
            }
            return sum.ToString();
        }
    }
}

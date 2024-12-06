using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class Day3
    {
        List<(int, int)> Pairs = new List<(int, int)>();
        List<(int, int)> Part2Pairs = new List<(int, int)>();
        bool doFlag = true;
        Regex regex = new Regex(@"don't\(\)|do\(\)|mul\((\d+),(\d+)\)");
        public void ParseInputFile(string filename)
        {
            Pairs.Clear();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                ParseLine(line);
            }
        }
        public void ParseLine(string line)
        {
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                if(match.Value == "do()")
                {
                    doFlag = true;
                }
                else if(match.Value == "don't()")
                {
                    doFlag = false;
                }
                else
                {
                    var tuple = (int.Parse(match.Groups[1].Value),
                                 int.Parse(match.Groups[2].Value));
                    Pairs.Add(tuple);
                    if (doFlag)
                    {
                        Part2Pairs.Add(tuple);
                    }
                }
            }
        }

        public string GetAnswerPart1()
        {
            var sum = 0;
            foreach (var pair in Pairs)
            {
                sum += pair.Item1 * pair.Item2;
            }
            return sum.ToString();
        }

        public string GetAnswerPart2()
        {
            var sum = 0;
            foreach (var pair in Part2Pairs)
            {
                sum += pair.Item1 * pair.Item2;
            }
            return sum.ToString();
        }
    }
}

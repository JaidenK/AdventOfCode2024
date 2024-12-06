using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class Day2
    {
        public readonly string[] ExampleInput =
        {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        };

        List<List<int>> Reports;
        public void ParseInputFile(string filename)
        {
            Reports = new List<List<int>>();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                Reports.Add(ParseLine(line));
            }
        }
        public void ParseExampleInput()
        {
            Reports = new List<List<int>>();
            foreach (var line in ExampleInput)
            {
                Reports.Add(ParseLine(line));
            }
        }

        public string GetAnswerPart1()
        {
            if (Reports is null)
                return "Reports NULL";
            return Reports.Where(r => IsReportSafe(r)).Count().ToString();
        }

        public string GetAnswerPart2()
        {
            if (Reports is null)
                return "Reports NULL";
            return Reports.Where(r => IsReportSafe2(r)).Count().ToString();
        }

        public static List<int> ParseLine(string line)
        {
            var result = new List<int>();
            foreach (var num in line.Split(' '))
            {
                result.Add(int.Parse(num));
            }
            return result;
        }
        public static bool IsReportSafe(List<int> report)
        {
            bool isSafe = true;
            int direction = report[1] > report[0] ? 1 : -1;
            for (int i = 1; i < report.Count; i++)
            {
                int difference = report[i] - report[i - 1];
                difference *= direction;
                isSafe &= (difference >= 1 && difference <= 3);
            }
            return isSafe;
        }
        public static bool IsReportSafe2(List<int> report)
        {
            bool isSafe = true;
            int direction = report[1] > report[0] ? 1 : -1;
            for (int i = 1; i < report.Count; i++)
            {
                int difference = report[i] - report[i - 1];
                difference *= direction;
                isSafe &= (difference >= 1 && difference <= 3);
            }
            if (!isSafe)
            {
                // Brute force see if removing one of them makes it safe
                for (int i = 0; i < report.Count; i++)
                {
                    // New list omitting this element
                    var newReport = new List<int>();
                    for (int j = 0; j < report.Count; j++)
                    {
                        if (i != j)
                        {
                            newReport.Add(report[j]);
                        }
                    }
                    if (IsReportSafe(newReport))
                        return true;
                }
            }
            return isSafe;
        }
    }
}

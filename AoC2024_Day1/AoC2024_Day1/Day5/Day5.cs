using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1.Day5
{
    public class Day5
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();
        public List<Update> Updates { get; set; } = new List<Update>();
        public void ParseLines(string[] lines)
        {
            Rules.Clear();
            Updates.Clear();
            foreach (string line in lines)
            {
                var rule = Rule.FromString(line);
                if (rule is Rule)
                {
                    Rules.Add(rule);
                }
                else
                {
                    var update = Update.FromString(line);
                    if (update is Update)
                    {
                        Updates.Add(update);
                    }
                }
            }
        }
        public void ParseFile(string filename)
        {
            ParseLines(File.ReadAllLines(filename));
        }

        public string GetAnswerPart1()
        {
            int sum = 0;
            foreach(var update in Updates)
            {
                if (update.SatisfiesAllRules(Rules))
                    sum += update.GetMiddlePage();
            }
            return sum.ToString();
        }
    }
}

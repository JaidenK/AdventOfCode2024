using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2024_Day1.Day5
{
    public class Rule
    {
        public Rule(int page1, int page2)
        {
            Page1 = page1;
            Page2 = page2;
        }

        public int Page1 { get; private set; } = 0;
        public int Page2 { get; private set; } = 0;
        private static Regex regex = new Regex(@"(\d+)\|(\d+)");
        public static Rule FromString(string str)
        {
            Match match = regex.Match(str);
            if(match.Success)
            {
                return new Rule(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
            }
            return null;
        }

        public bool AppliesTo(Update update)
        {
            return (update.Pages.Contains(Page1))
                && (update.Pages.Contains(Page2));
        }
    }
}

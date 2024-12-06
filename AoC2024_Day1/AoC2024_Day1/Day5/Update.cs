using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2024_Day1.Day5
{
    public class Update
    {
        public List<int> Pages { get; set; } = new List<int>();
        public static Update FromString(string str)
        {
            if(str.Trim().Length == 0) return null;
            var nums = str.Trim().Split(',');
            if(nums is null || nums.Length == 0) return null;
            var update = new Update();
            foreach (var i in nums)
            {
                update.Pages.Add(int.Parse(i));
            }
            return update;
        }

        public bool Satisfies(Rule rule)
        {
            int i1 = Pages.IndexOf(rule.Page1);
            if (i1 == -1) return true; // Rule is satisfied if it does not apply
            int i2 = Pages.IndexOf(rule.Page2);
            if (i2 == -1) return true; // Rule is satisfied if it does not apply
            return i1 < i2;
        }

        public int GetMiddlePage()
        {
            return Pages[Pages.Count / 2];
        }

        internal bool SatisfiesAllRules(List<Rule> rules)
        {
            foreach (var rule in rules)
            {
                if(!Satisfies(rule)) return false;
            }
            return true;
        }
    }
}

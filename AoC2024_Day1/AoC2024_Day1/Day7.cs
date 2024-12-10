using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class Day7
    {
        public List<EquationD7> Equations { get; set; } = new List<EquationD7>();
        
        public void ParseFile(string file)
        {
            ParseLines(File.ReadAllLines(file));
        }
        
        public void ParseLines(string[] lines)
        {
            foreach (string line in lines)
            {
                Equations.Add(EquationD7.FromString(line));
            }
        }

        public string GetAnswerPart1()
        {
            ulong sum = 0;
            foreach(EquationD7 equation in Equations)
            {
                if(equation.IsPossible())
                {
                    sum += equation.Value;
                }
            }
            return sum.ToString();
        }
    }

    public enum Operator
    {
        NULL,
        ADD,
        SUB,
        MUL,
        DIV
    }

    public class EquationD7
    {
        public ulong Value { get; set; }
        public List<ulong> Operands { get; set; } = new List<ulong>();
        public List<Operator> Operators { get; set; } = new List<Operator>();


        public static EquationD7 FromString(string str)
        {
            var Eq = new EquationD7();
            var split1 = str.Split(':');
            Eq.Value = ulong.Parse(split1[0]);
            var split2 = split1[1].Split(' ');
            foreach(var s in split2)
            {
                if(s.Length > 0)
                    Eq.Operands.Add(ulong.Parse(s));
            }

            return Eq;
        }

        public bool IsPossible()
        {
            return CountPossibleEquations() > 0;
        }

        public int CountPossibleEquations()
        {
            if(Operators.Count == Operands.Count-1)
            {
                ulong littleSum = Operands[0];
                for(int i = 1; i < Operands.Count; i++)
                {
                    var num = Operands[i];
                    var opp = Operators[i - 1];
                    switch (opp)
                    {
                        case Operator.ADD:
                            littleSum = littleSum + num;
                            break;
                        case Operator.MUL:
                            littleSum = littleSum * num;
                            break;
                        default:
                            throw new NotImplementedException(Enum.GetNames(typeof(Operator))[(int)opp]);
                            break;
                    }
                }
                if (littleSum == Value)
                    return 1;
                return 0;
            }
            else
            {
                int nPossibilities = 0;

                Operators.Add(Operator.ADD);
                nPossibilities += CountPossibleEquations();
                Operators.RemoveAt(Operators.Count - 1);

                Operators.Add(Operator.MUL);
                nPossibilities += CountPossibleEquations();
                Operators.RemoveAt(Operators.Count - 1);

                return nPossibilities;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Value.ToString());
            sb.Append(':');
            foreach(var op in Operands)
            {
                sb.Append(' '+op.ToString());
            }
            return sb.ToString();
        }
    }
}

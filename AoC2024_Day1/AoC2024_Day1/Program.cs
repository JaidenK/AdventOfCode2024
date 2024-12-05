using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day1();
            Day2();
            Console.ReadKey();
        }

        static void Day1()
        {
            var Day1 = new AoC_D1();
            //Console.WriteLine(Day1.GetAnswerPart1("input.txt"));
            Console.WriteLine(Day1.GetAnswerPart2("input.txt"));
        }

        static void Day2()
        {
            var Day2 = new Day2();

            Console.WriteLine("Enter input filename:");
            var filename = Console.ReadLine().Trim();
            Day2.ParseInputFile(filename);
            Console.WriteLine(Day2.GetAnswerPart1());
        }
    }
}

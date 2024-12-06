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
            int day = 0;
            Console.WriteLine("Enter Day: ");
            while(!int.TryParse(Console.ReadLine(), out day))
            {
                Console.WriteLine("Day must be an integer.");
            }
            Console.WriteLine("Enter input filename: ");
            string filename = Console.ReadLine().Trim();
            switch(day)
            {
                case 1: Day1(filename); break;
                case 2: Day2(filename); break;
                case 3: Day3(filename); break;
                default:
                    Console.WriteLine($"Day {day} not implemented.");
                    break;
            }

            Console.ReadKey();
        }

        static void Day1(string filename)
        {
            var Day1 = new AoC_D1();
            Console.WriteLine(Day1.GetAnswerPart1(filename));
            Console.WriteLine(Day1.GetAnswerPart2(filename));
        }

        static void Day2(string filename)
        {
            var Day2 = new Day2();
            Day2.ParseInputFile(filename);
            Console.WriteLine("Part 1: " + Day2.GetAnswerPart1());
            Console.WriteLine("Part 2: " + Day2.GetAnswerPart2());
        }

        static void Day3(string filename)
        {
            var Day3 = new Day3();
            Day3.ParseInputFile(filename);
            Console.WriteLine("Part 1: " + Day3.GetAnswerPart1());
            //Console.WriteLine("Part 2: " + Day3.GetAnswerPart2());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class Day6
    {
        char[,] map;
        int rows, cols;

        public void LoadMap(string[] lines)
        {
            rows = lines.Length;
            cols = lines[0].Trim().Length;
            map = new char[rows, cols];
            for (int r = 0; r < lines.Length; r++)
            {
                for (int c = 0; c < lines[r].Length; c++)
                {
                    map[r, c] = lines[r][c];
                }
            }
        }

        public bool Step()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    char chr = map[r, c];
                    if (chr == '^')
                    {
                        map[r, c] = 'X';
                        if (r - 1 < 0)
                            return false;
                        if (map[r - 1, c] == '#')
                            map[r, c] = '>';
                        else
                            map[r - 1, c] = '^';
                    }
                    else if (chr == '>')
                    {
                        map[r, c] = 'X';
                        if (c + 1 >= cols)
                            return false;
                        if (map[r, c + 1] == '#')
                            map[r, c] = 'v';
                        else
                            map[r, c + 1] = '>';
                    }
                    else if (chr == 'v')
                    {
                        map[r, c] = 'X';
                        if (r + 1 >= rows)
                            return false;
                        if (map[r + 1, c] == '#')
                            map[r, c] = '<';
                        else
                            map[r + 1, c] = 'v';
                    }
                    else if (chr == '<')
                    {
                        map[r, c] = 'X';
                        if (c - 1 < 0)
                            return false;
                        if (map[r, c - 1] == '#')
                            map[r, c] = '^';
                        else
                            map[r, c - 1] = '<';
                    }
                }
            }
            return true;
        }

        public void PrintMap()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(map[r, c]);
                }
                Console.WriteLine();
            }
        }

        public int CountVisitedSquares()
        {
            while (Step())
                ;
            int sum = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (map[r, c] == 'X')
                        sum++;
                }
            }
            return sum;
        }

        public string GetAnswerPart1()
        {
            return CountVisitedSquares().ToString();
        }

        internal void ParseInputFile(string filename)
        {
            LoadMap(File.ReadAllLines(filename));
        }
    }
}

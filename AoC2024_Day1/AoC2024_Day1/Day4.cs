﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class Day4
    {
        string[] raw;
        char[,] parsed;
        public int count = 0;
        int rows = 0;
        int cols = 0;

        string filename = "";

        public void ProcessMap(string[] map)
        {
            raw = map;
            cols = raw[0].Trim().Length; 
            rows = raw.Length;
            parsed = new char[rows, cols];
            count = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    parsed[r, c] = '.';
                }
            }
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (raw[r][c] == 'X')
                    {
                        bool isPartOfValidString = false;
                        isPartOfValidString |= DepthFirst(r, c, - 1,   0, 1); // UP
                        isPartOfValidString |= DepthFirst(r, c, - 1, + 1, 1); // UP-RIGHT
                        isPartOfValidString |= DepthFirst(r, c, - 0, + 1, 1); // RIGHT
                        isPartOfValidString |= DepthFirst(r, c, + 1, + 1, 1); // DOWN-RIGHT
                        isPartOfValidString |= DepthFirst(r, c, + 1, + 0, 1); // DOWN
                        isPartOfValidString |= DepthFirst(r, c, + 1, - 1, 1); // DOWN-LEFT
                        isPartOfValidString |= DepthFirst(r, c, + 0, - 1, 1); // LEFT
                        isPartOfValidString |= DepthFirst(r, c, - 1, - 1, 1); // UP-LEFT
                        if (isPartOfValidString)
                            parsed[r, c] = raw[r][c];
                    }
                }
            }
        }
        private bool DepthFirst(int _r, int _c, int dr, int dc, int depth)
        {
            int r = _r + dr * depth;
            int c = _c + dc * depth;

            if (r < 0 || r >= rows || c < 0 || c >= cols)
                return false;

            bool isPartOfValidString = false;
            char needle = "XMAS"[depth];
            char here = raw[r][c];
            if(here != needle)
            {
                return false;
            }
            if(depth == 3) // needle == 'S'
            {
                count++;
                isPartOfValidString = true;
            }
            else
            {
                isPartOfValidString |= DepthFirst(_r, _c, dr, dc, depth + 1);
            }
            if(isPartOfValidString)
                parsed[r, c] = raw[r][c];
            return isPartOfValidString;
        }
        public void ProcessMap2(string[] map)
        {
            raw = map;
            cols = raw[0].Trim().Length;
            rows = raw.Length;
            parsed = new char[rows, cols];
            count = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    parsed[r, c] = '.';
                }
            }
            for (int r = 1; r < rows-1; r++)
            {
                for (int c = 1; c < cols-1; c++)
                {
                    if ((raw[r][c] == 'A')
                        && (raw[r - 1][c - 1] == 'M')
                        && (raw[r + 1][c - 1] == 'M')
                        && (raw[r - 1][c + 1] == 'S')
                        && (raw[r + 1][c + 1] == 'S'))
                    {
                        count++;
                    }
                    else if ((raw[r][c] == 'A')
                        && (raw[r - 1][c - 1] == 'M')
                        && (raw[r + 1][c - 1] == 'S')
                        && (raw[r - 1][c + 1] == 'M')
                        && (raw[r + 1][c + 1] == 'S'))
                    {
                        count++;
                    }
                    else if ((raw[r][c] == 'A')
                        && (raw[r - 1][c - 1] == 'S')
                        && (raw[r + 1][c - 1] == 'S')
                        && (raw[r - 1][c + 1] == 'M')
                        && (raw[r + 1][c + 1] == 'M'))
                    {
                        count++;
                    }
                    else if ((raw[r][c] == 'A')
                        && (raw[r - 1][c - 1] == 'S')
                        && (raw[r + 1][c - 1] == 'M')
                        && (raw[r - 1][c + 1] == 'S')
                        && (raw[r + 1][c + 1] == 'M'))
                    {
                        count++;
                    }
                }
            }
        }
        public void PrintParsed()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(parsed[r,c]);
                }
                Console.WriteLine();
            }
        }

        public string GetAnswerPart1()
        {
            ProcessMap(File.ReadAllLines(filename));
            return count.ToString();
        }
        public string GetAnswerPart2()
        {
            ProcessMap2(File.ReadAllLines(filename));
            return count.ToString();
        }

        internal void ParseInputFile(string filename)
        {
            this.filename = filename;
        }
    }
}

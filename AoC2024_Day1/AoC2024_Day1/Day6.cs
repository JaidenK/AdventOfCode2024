using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024_Day1
{
    public class LoopException : Exception
    {

    }

    public class Day6
    {
        char[,] map;
        int rows, cols;

        public Day6(Day6 day6)
        {
            rows = day6.rows; cols = day6.cols;
            map = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    map[r, c] = day6.map[r, c];
                }
            }
        }

        public Day6()
        {
        }

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
                        map[r, c] = (char)((ushort)map[r, c] | 128);
                        if (r - 1 < 0)
                            return false;
                        if ((map[r - 1, c] == '#') || (map[r - 1, c] == 'O'))
                        {
                            map[r, c] = '>';
                            r = rows; c = cols; // break;
                        }
                        else
                        {
                            if ((char)((ushort)map[r - 1, c] & 127) == '^')
                                throw new LoopException();
                            map[r - 1, c] = '^';
                            r = rows; c = cols; // break;
                        }
                    }
                    else if (chr == '>')
                    {
                        map[r, c] = (char)((ushort)map[r, c] | 128);
                        if (c + 1 >= cols)
                            return false;
                        if ((map[r, c + 1] == '#') || (map[r, c + 1] == 'O'))
                        {
                            map[r, c] = 'v';
                            r = rows; c = cols; // break;
                        }
                        else
                        {
                            if ((char)((ushort)map[r, c + 1] & 127) == '>')
                                throw new LoopException();
                            map[r, c + 1] = '>';
                            r = rows; c = cols; // break;
                        }
                    }
                    else if (chr == 'v')
                    {
                        map[r, c] = (char)((ushort)map[r, c] | 128);
                        if (r + 1 >= rows)
                            return false;
                        if ((map[r + 1, c] == '#') || (map[r + 1, c] == 'O'))
                        {
                            map[r, c] = '<';
                            r = rows; c = cols; // break;
                        }
                        else
                        {
                            if ((char)((ushort)map[r + 1, c] & 127) == 'v')
                                throw new LoopException();
                            map[r + 1, c] = 'v';
                            r = rows; c = cols; // break;
                        }
                    }
                    else if (chr == '<')
                    {
                        map[r, c] = (char)((ushort)map[r, c] | 128);
                        if (c - 1 < 0)
                            return false;
                        if ((map[r, c - 1] == '#') || (map[r, c - 1] == 'O'))
                        {
                            map[r, c] = '^';
                            r = rows; c = cols; // break;
                        }
                        else
                        {
                            if ((char)((ushort)map[r, c - 1] & 127) == '<')
                                throw new LoopException();
                            map[r, c - 1] = '<';
                            r = rows; c = cols; // break;
                        }
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
                    char chr = (char)((ushort)map[r, c] & 127);
                    Console.Write(chr);
                }
                Console.WriteLine();
            }
        }

        public void WriteMapToFile(string fileName)
        {
            using(var outFile = new StreamWriter(fileName, false))
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        char chr = (char)((ushort)map[r, c] & 127);
                        outFile.Write(chr);
                    }
                    outFile.WriteLine();
                }
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
                    if (((ushort)map[r, c] & 128) == 128)
                        sum++;
                }
            }
            return sum;
        }

        public string GetAnswerPart1()
        {
            return CountVisitedSquares().ToString();
        }

        public string GetAnswerPart2()
        {
            int loopSpots = 0;
            int loopSpotsTimeout = 0;
            int stepNo = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (Step())
            {
                stepNo++;
                Console.WriteLine($"Step {stepNo} {stopwatch.ElapsedMilliseconds}");
                var copy = new Day6(this);
                copy.PlaceObstacleInFrontOfCurrentPosition();
                try
                {
                    int i = 0;
                    while (copy.Step())
                    {
                        i++;
                        if(i > 4 * rows * cols)
                        {
                            loopSpots++;
                            loopSpotsTimeout++;
                            Console.WriteLine("StepCountLoopBreak");
                            copy.WriteMapToFile($"Map_2s{stepNo}.txt");
                            break;
                        }
                        //Console.WriteLine($"i: {i}");
                    }
                    //Console.WriteLine("No loop");
                }
                catch (LoopException e)
                {
                    //Console.WriteLine();
                    //Console.WriteLine($"Step {stepNo}");
                    //copy.PrintMap();
                    //Console.WriteLine();
                    Console.WriteLine($"Loop");
                    copy.WriteMapToFile($"Map_s{stepNo}.txt");
                    loopSpots++;
                }
            }
            Console.WriteLine($"LoopSpotsTimeout: {loopSpotsTimeout}");
            Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds}");
            return loopSpots.ToString();
        }

        private void PlaceObstacleInFrontOfCurrentPosition()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if ("^>v<".Contains(map[r, c]))
                    {
                        PlaceObstacleInFrontOf(r, c);
                    }
                }
            }
        }

        public void PlaceObstacleInFrontOf(int r, int c)
        {
            char chr = (char)((ushort)map[r, c] & 127);
            int dr = 0;
            int dc = 0;
            switch (chr)
            {
                case '^': dr = -1; break;
                case '>': dc = 1; break;
                case 'v': dr = 1; break;
                case '<': dc = -1; break;
            }
            map[r, c] = chr;
            r += dr;
            c += dc;
            if (r < 0 || r >= rows || c < 0 || c >= cols)
                return;
            if (map[r, c] != '.')
                return; // Do nothing unless it's open space and not an old path.
            map[r, c] = 'O';
        }

        internal void ParseInputFile(string filename)
        {
            LoadMap(File.ReadAllLines(filename));
        }
    }
}

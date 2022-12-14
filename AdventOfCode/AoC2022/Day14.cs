using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day14
    {
        public static void Part1()
        {
            string input;
            List<(int, int)> grid = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(" -> ");
                for (int i = 0; i < split.Length - 1; i++)
                {
                    var xy1 = split[i].Split(',');
                    int x1 = int.Parse(xy1[0]), y1 = int.Parse(xy1[1]);
                    var xy2 = split[i + 1].Split(',');
                    int x2 = int.Parse(xy2[0]), y2 = int.Parse(xy2[1]);

                    if (x1 < x2)
                        for (int j = x1; j <= x2; j++)
                            grid.Add((j, y1));
                    else if (x1 > x2)
                        for (int j = x2; j <= x1; j++)
                            grid.Add((j, y1));
                    else if (y1 < y2)
                        for (int j = y1; j <= y2; j++)
                            grid.Add((x1, j));
                    else if (y1 > y2)
                        for (int j = y2; j <= y1; j++)
                            grid.Add((x1, j));

                }
            }

            for (int j = 0; j <= grid.Max(c => c.Item2); j++)
            {
                for (int i = grid.Min(c => c.Item1) - 1; i <= grid.Max(c => c.Item1); i++)
                    Console.Write(grid.Contains((i, j)) ? "#" : ".");
                Console.WriteLine();
            }

            (int, int) origin = (500, 0);
            int highestY = grid.Max(c => c.Item2);
            bool settled = false;
            int sandUnits = 0;
            while(!settled)
            {
                bool stopped = false;
                (int, int) sandLoc = (500, 0);
                while (!stopped)
                {
                    if (sandLoc.Item2 > highestY)
                    {
                        settled = true;
                        break;
                    }
                    if (!grid.Contains((sandLoc.Item1, sandLoc.Item2 + 1)))
                        sandLoc = (sandLoc.Item1, sandLoc.Item2 + 1);
                    else if (!grid.Contains((sandLoc.Item1 - 1, sandLoc.Item2 + 1)))
                        sandLoc = (sandLoc.Item1 - 1, sandLoc.Item2 + 1);
                    else if (!grid.Contains((sandLoc.Item1 + 1, sandLoc.Item2 + 1)))
                        sandLoc = (sandLoc.Item1 + 1, sandLoc.Item2 + 1);
                    else stopped = true;
                }
                grid.Add(sandLoc);
                if (!settled)
                    sandUnits++;
            }

            Console.WriteLine(sandUnits);
        }

        public static void Part2()
        {
            string input;
            List<(int, int)> grid = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(" -> ");
                for (int i = 0; i < split.Length - 1; i++)
                {
                    var xy1 = split[i].Split(',');
                    int x1 = int.Parse(xy1[0]), y1 = int.Parse(xy1[1]);
                    var xy2 = split[i + 1].Split(',');
                    int x2 = int.Parse(xy2[0]), y2 = int.Parse(xy2[1]);

                    if (x1 < x2)
                        for (int j = x1; j <= x2; j++)
                            grid.Add((j, y1));
                    else if (x1 > x2)
                        for (int j = x2; j <= x1; j++)
                            grid.Add((j, y1));
                    else if (y1 < y2)
                        for (int j = y1; j <= y2; j++)
                            grid.Add((x1, j));
                    else if (y1 > y2)
                        for (int j = y2; j <= y1; j++)
                            grid.Add((x1, j));

                }
            }
            for (int j = 0; j <= grid.Max(c => c.Item2); j++)
            {
                for (int i = grid.Min(c => c.Item1) - 1; i <= grid.Max(c => c.Item1); i++)
                    Console.Write(grid.Contains((i, j)) ? "#" : ".");
                Console.WriteLine();
            }

            int highestY = grid.Max(c => c.Item2) + 2;
            bool settled = false;
            int sandUnits = 0;
            while (!settled)
            {
                bool stopped = false;
                (int, int) sandLoc = (500, 0);
                while (!stopped)
                {
                    if (sandLoc.Item2 == highestY)
                    {
                        stopped = true;
                        sandUnits--;
                        break;
                    }
                    if (!grid.Contains((sandLoc.Item1, sandLoc.Item2 + 1)))
                        sandLoc = (sandLoc.Item1, sandLoc.Item2 + 1);
                    else if (!grid.Contains((sandLoc.Item1 - 1, sandLoc.Item2 + 1)))
                        sandLoc = (sandLoc.Item1 - 1, sandLoc.Item2 + 1);
                    else if (!grid.Contains((sandLoc.Item1 + 1, sandLoc.Item2 + 1)))
                        sandLoc = (sandLoc.Item1 + 1, sandLoc.Item2 + 1);
                    else stopped = true;
                }
                if (sandLoc == (500, 0))
                    settled = true;
                grid.Add(sandLoc);
                    sandUnits++;
            }

            Console.WriteLine(sandUnits);
        }
    }
}
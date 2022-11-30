using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day05
    {
        public static void Part1()
        {
            string input;
            string[] splitInput;
            int[,] grid = new int[1000, 1000];

            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split(" -> ");
                AddLines(ref grid, splitInput, false);
            }

            int danger = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i, j] > 1)
                        danger++;
            Console.WriteLine(danger);
        }

        public static void Part2()
        {
            string input;
            string[] splitInput;
            int[,] grid = new int[1000, 1000];

            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split(" -> ");
                AddLines(ref grid, splitInput, true);
            }

            int danger = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i, j] > 1)
                        danger++;
            Console.WriteLine(danger);
        }

        private static void AddLines(ref int[,] grid, string[] input, bool diag)
        {

            (int, int) c1 = (int.Parse(input[0].Split(",")[0]), int.Parse(input[0].Split(",")[1]));
            (int, int) c2 = (int.Parse(input[1].Split(",")[0]), int.Parse(input[1].Split(",")[1]));
            
            if (c1.Item1 != c2.Item1 && c1.Item2 != c2.Item2)
            { 
                if (!diag)
                    return;

                if (c1.Item1 < c2.Item1 && c1.Item2 > c2.Item2)
                    for (int i = c1.Item1, j = c1.Item2; i <= c2.Item1; i++, j--)
                        grid[j, i]++;

                else if (c1.Item1 > c2.Item1 && c1.Item2 > c2.Item2)
                    for (int i = c2.Item1, j = c2.Item2; i <= c1.Item1; i++, j++)
                        grid[j, i]++;

                else if (c1.Item1 < c2.Item1 && c1.Item2 < c2.Item2)
                    for (int i = c1.Item1, j = c1.Item2; j <= c2.Item2; i++, j++)
                        grid[j, i]++;

                else
                    for (int i = c1.Item1, j = c1.Item2; j <= c2.Item2; i--, j++)
                        grid[j, i]++;
            }

            else if (c1.Item1 < c2.Item1)
            {
                for (int i = c1.Item1; i <= c2.Item1; i++)
                {
                    grid[c1.Item2, i]++;
                }
            }
            else if (c1.Item1 > c2.Item1)
            {
                for (int i = c2.Item1; i <= c1.Item1; i++)
                {
                    grid[c1.Item2, i]++;
                }
            }
            else if (c1.Item2 < c2.Item2)
            {
                for (int i = c1.Item2; i <= c2.Item2; i++)
                {
                    grid[i, c1.Item1]++;
                }
            }
            else
            {
                for (int i = c2.Item2; i <= c1.Item2; i++)
                {
                    grid[i, c1.Item1]++;
                }
            }

        }
    }
}
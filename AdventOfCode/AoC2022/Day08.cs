using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day08
    {
        private static int[,] Grid = new int[99, 99];
        public static void Part1()
        {
            int j = 0;
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                for (int i = 0; i < Grid.GetLength(0); i++)
                {
                    Grid[i, j] = int.Parse(input[i].ToString());
                }
                j++;
            }

            int higher = 0;
            for (int x = 0; x < Grid.GetLength(0); x++)
                for (int y = 0; y < Grid.GetLength(1); y++)
                    if (CalcLower(x, y))
                        higher++;

            Console.WriteLine(higher);
        }

        public static void Part2()
        {
            int j = 0;
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                for (int i = 0; i < Grid.GetLength(0); i++)
                {
                    Grid[i, j] = int.Parse(input[i].ToString());
                }
                j++;
            }

            int score = 0;
            for (int x = 0; x < Grid.GetLength(0); x++)
                for (int y = 0; y < Grid.GetLength(1); y++)
                {
                    var newScore = CalcScore(x, y);
                    if (newScore > score)
                        score = newScore;
                }

            Console.WriteLine(score);
        }

        private static bool CalcLower(int x, int y)
        {
            if (x == 0 || x == Grid.GetLength(0) - 1 || y == 0 || y == Grid.GetLength(1) - 1)
                return true;

            int height = Grid[x, y];

            // X-axis to the left
            for (int k = x - 1; k >= 0; k--)
                if (k == 0 && Grid[k, y] < height)
                    return true;
                else if (Grid[k, y] >= height)
                    break;

            // X-axis to the right
            for (int k = x + 1; k < Grid.GetLength(0); k++)
                if (k == Grid.GetLength(0) - 1 && Grid[k, y] < height)
                    return true;
                else if (Grid[k, y] >= height)
                    break;

            // Y-axis up
            for (int k = y - 1; k >= 0; k--)
                if (k == 0 && Grid[x, k] < height)
                    return true;
                else if (Grid[x, k] >= height)
                    break;

            // Y-axis down
            for (int k = y + 1; k < Grid.GetLength(1); k++)
                if (k == Grid.GetLength(1) - 1 && Grid[x, k] < height)
                    return true;
                else if (Grid[x, k] >= height)
                    break;

            return false;
        }

        private static int CalcScore(int x, int y)
        {

            int height = Grid[x, y];
            int score0 = 0, score1 = 0, score2 = 0, score3 = 0;

            // X-axis to the left
            for (int k = x - 1; k >= 0; k--)
            {
                score0++;
                if (Grid[k, y] >= height)
                    break;
            }

            // X-axis to the right
            for (int k = x + 1; k < Grid.GetLength(0); k++)
            {
                score1++;
                if (Grid[k, y] >= height)
                    break;
            }

            // Y-axis up
            for (int k = y - 1; k >= 0; k--)
            {
                score2++;
                if (Grid[x, k] >= height)
                    break;
            }

            // Y-axis down
            for (int k = y + 1; k < Grid.GetLength(1); k++)
            {
                score3++;
                if (Grid[x, k] >= height)
                    break;
            }
            return score0 * score1 * score2 * score3;
        }
    }
}
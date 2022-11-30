using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day25
    {
        public static int MaxX, MaxY;
        public static void Part1()
        {
            string input;
            int i = 0;
            List<SeaCucumber> rightCucumbers = new(), downCucumbers = new();
            while ((input = Console.ReadLine()) != "")
            {
                MaxX = input.Length;
                for (int j = 0; j < input.Length; j++)
                    if (input[j] == 'v')
                        downCucumbers.Add(new SeaCucumber(j, i));
                    else if (input[j] == '>')
                        rightCucumbers.Add(new SeaCucumber(j, i));
                i++;
            }
            MaxY = i;
            int moves = 1;
            while (Move(ref downCucumbers, ref rightCucumbers))
            {
                // Draw(downCucumbers, rightCucumbers);
                moves++;
            }
            Console.WriteLine(moves);
        }

        public static bool Move(ref List<SeaCucumber> downCucumbers, ref List<SeaCucumber> rightCucumbers)
        {
            // First right then down
            bool moved = false;
            var newRight = new List<SeaCucumber>();
            foreach (SeaCucumber cucumber in rightCucumbers)
            {
                int nextX = cucumber.x + 1 > MaxX - 1 ? 0 : cucumber.x + 1;
                if (!downCucumbers.Any(c => nextX == c.x && cucumber.y == c.y) && !rightCucumbers.Any(c => nextX == c.x && cucumber.y == c.y))
                {
                    newRight.Add(new SeaCucumber(nextX, cucumber.y));
                    moved = true;
                }
                else newRight.Add(new SeaCucumber(cucumber.x, cucumber.y));
            }
            rightCucumbers = newRight;

            var newDown = new List<SeaCucumber>();
            foreach (SeaCucumber cucumber in downCucumbers)
            {
                int nextY = cucumber.y + 1 > MaxY - 1 ? 0 : cucumber.y + 1;
                if (!downCucumbers.Any(c => nextY == c.y && cucumber.x == c.x) && !rightCucumbers.Any(c => nextY == c.y && cucumber.x == c.x))
                {
                    newDown.Add(new SeaCucumber(cucumber.x, nextY));
                    moved = true;
                }
                else newDown.Add(new SeaCucumber(cucumber.x, cucumber.y));
            }
            downCucumbers = newDown;

            return moved;
        }

        public static void Draw(List<SeaCucumber> downCucumbers, List<SeaCucumber> rightCucumbers)
        {
            Console.WriteLine();
            for (int j = 0; j < MaxY; j++)
            {
                for (int i = 0; i < MaxX; i++)
                {
                    if (downCucumbers.Any(c => c.x == i && c.y == j))
                        Console.Write("v");
                    else if (rightCucumbers.Any(c => c.x == i && c.y == j))
                        Console.Write(">");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        public struct SeaCucumber
        {
            public int x, y;
            public SeaCucumber(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
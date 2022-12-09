using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day09
    {
        public static void Part1()
        {
            string input;
            Pos head = new(), tail = new();
            List<Pos> tailPositions = new() { new Pos() };

            while ((input = Console.ReadLine()) != "")
            {
                string direction = input[0].ToString();
                int length = int.Parse(input.Split(' ')[1]);

                for (int i = 0; i < length; i++)
                {
                    switch (direction)
                    {
                        case "R":
                            head.x++;
                            if (Math.Abs(head.x - tail.x) > 1)
                            {
                                tail.x++;
                                if (head.y != tail.y)
                                    tail.y = head.y;
                                tailPositions.Add(tail);
                            }
                            break;
                        case "L":
                            head.x--;
                            if (Math.Abs(head.x - tail.x) > 1)
                            {
                                tail.x--;
                                if (head.y != tail.y)
                                    tail.y = head.y;
                                tailPositions.Add(tail);
                            }
                            break;
                        case "U":
                            head.y++;
                            if (Math.Abs(head.y - tail.y) > 1)
                            {
                                tail.y++;
                                if (head.x != tail.x)
                                    tail.x = head.x;
                                tailPositions.Add(tail);
                            }
                            break;
                        case "D":
                            head.y--;
                            if (Math.Abs(head.y - tail.y) > 1)
                            {
                                tail.y--;
                                if (head.x != tail.x)
                                    tail.x = head.x;
                                tailPositions.Add(tail);
                            }
                            break;
                    }
                }
            }
            Console.WriteLine(tailPositions.Distinct().Count());
        }

        public static void Part2()
        {
            string input;
            Pos[] knots = new Pos[10];
            for (int i = 0; i < knots.Length; i++)
                knots[i] = new();
            List<Pos> tailPositions = new() { new Pos() };

            while ((input = Console.ReadLine()) != "")
            {
                string direction = input[0].ToString();
                int length = int.Parse(input.Split(' ')[1]);

                for (int i = 0; i < length; i++)
                {
                    switch (direction)
                    {
                        case "R":
                            knots[0].x++;
                            for (int k = 1; k < knots.Length; k++)
                            {
                                int cur = k, prev = k - 1;
                                if (knots[prev].x - knots[cur].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y++;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y++;
                                }
                                else if (knots[prev].x - knots[cur].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y--;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y--;
                                }

                                if (knots[prev].x - knots[cur].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x++;
                                }
                                if (knots[cur].x - knots[prev].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x--;
                                }
                                if (knots[prev].y - knots[cur].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y++;
                                }
                                if (knots[cur].y - knots[prev].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y--;
                                }
                                tailPositions.Add(knots[9]);
                            }
                            break;
                        case "L":
                            knots[0].x--;
                            for (int k = 1; k < knots.Length; k++)
                            {
                                int cur = k, prev = k - 1;
                                if (knots[prev].x - knots[cur].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y++;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y++;
                                }
                                else if (knots[prev].x - knots[cur].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y--;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y--;
                                }

                                if (knots[prev].x - knots[cur].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x++;
                                }
                                if (knots[cur].x - knots[prev].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x--;
                                }
                                if (knots[prev].y - knots[cur].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y++;
                                }
                                if (knots[cur].y - knots[prev].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y--;
                                }
                                tailPositions.Add(knots[9]);
                            }
                            break;
                        case "U":
                            knots[0].y++;
                            for (int k = 1; k < knots.Length; k++)
                            {
                                int cur = k, prev = k - 1;
                                if (knots[prev].x - knots[cur].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y++;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y++;
                                }
                                else if (knots[prev].x - knots[cur].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y--;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y--;
                                }

                                if (knots[prev].x - knots[cur].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x++;
                                }
                                if (knots[cur].x - knots[prev].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x--;
                                }
                                
                                if (knots[prev].y - knots[cur].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y++;
                                }
                                if (knots[cur].y - knots[prev].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y--;
                                }
                                tailPositions.Add(knots[9]);
                            }
                            break;
                        case "D":
                            knots[0].y--;
                            for (int k = 1; k < knots.Length; k++)
                            {
                                int cur = k, prev = k - 1;
                                if (knots[prev].x - knots[cur].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y++;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[prev].y - knots[cur].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y++;
                                }
                                else if (knots[prev].x - knots[cur].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x++;
                                    knots[cur].y--;
                                }
                                else if (knots[cur].x - knots[prev].x == 2 && knots[cur].y - knots[prev].y == 2)
                                {
                                    knots[cur].x--;
                                    knots[cur].y--;
                                }

                                if (knots[prev].y - knots[cur].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y++;
                                }
                                if (knots[cur].y - knots[prev].y > 1)
                                {
                                    if (knots[cur].x != knots[prev].x)
                                        knots[cur].x = knots[prev].x;
                                    knots[cur].y--;
                                }
                                if (knots[prev].x - knots[cur].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x++;
                                }
                                if (knots[cur].x - knots[prev].x > 1)
                                {
                                    if (knots[cur].y != knots[prev].y)
                                        knots[cur].y = knots[prev].y;
                                    knots[cur].x--;
                                }
                                tailPositions.Add(knots[9]);
                            }
                            break;
                    }
                }
            }
            Console.WriteLine(tailPositions.Distinct().Count());
        }

        private struct Pos
        {
            public int x;
            public int y;

            public Pos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Pos()
            {
                this.x = 0;
                this.y = 0;
            }
        }
    }
}
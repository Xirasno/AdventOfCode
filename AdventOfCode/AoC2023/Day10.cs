﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2023Day10
    {
        public static void Part1()
        {
            string input;
            int y = 0;
            int dims = 140;
            Pipe[,] pipes = new Pipe[dims, dims];

            Pipe start = new Pipe();
            while ((input = Console.ReadLine()) != "")
            {
                for (int x = 0; x < input.Length; x++)
                {
                    if (input[x] != '.')
                    {
                        if (input[x] == 'S')
                        {
                            start = new Pipe(x, y, input[x]);
                        }
                        pipes[x, y] = new Pipe(x, y, input[x]);
                    }
                }
                y++;
            }
            if (start.x != 0 && (pipes[start.x - 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x - 1, start.y].Connection2 == (start.x, start.y)))
            {
                if (start.x != dims - 1 && pipes[start.x + 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x + 1, start.y].Connection2 == (start.x, start.y))
                { // -
                    start.Connection1 = (start.x - 1, start.y);
                    start.Connection2 = (start.x + 1, start.y);
                }
                if (start.y != 0 && pipes[start.x, start.y - 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y - 1].Connection2 == (start.x, start.y))
                { // J
                    start.Connection1 = (start.x - 1, start.y);
                    start.Connection2 = (start.x, start.y - 1);
                }
                if (start.y != dims - 1 && pipes[start.x, start.y + 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y + 1].Connection2 == (start.x, start.y))
                { // 7
                    start.Connection1 = (start.x - 1, start.y);
                    start.Connection2 = (start.x, start.y + 1);
                }
            }
            else if (start.y != 0 && pipes[start.x, start.y - 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y - 1].Connection2 == (start.x, start.y))
            {
                if (start.y != (dims - 1) && pipes[start.x, start.y + 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y + 1].Connection2 == (start.x, start.y))
                { // |
                    start.Connection1 = (start.x, start.y - 1);
                    start.Connection2 = (start.x, start.y + 1);
                }
                if (start.x != (dims - 1) && pipes[start.x + 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x + 1, start.y].Connection2 == (start.x, start.y))
                { // L
                    start.Connection1 = (start.x, start.y - 1);
                    start.Connection2 = (start.x + 1, start.y);
                }
            }
            else if (start.y != (dims - 1) && (pipes[start.x, start.y + 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y + 1].Connection2 == (start.x, start.y))
                && (start.x != (dims - 1) && pipes[start.x + 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x + 1, start.y].Connection2 == (start.x, start.y)))
            { // F
                start.Connection1 = (start.x, start.y + 1);
                start.Connection2 = (start.x + 1, start.y);
            }

            pipes[start.x, start.y] = start;

            Pipe newLoc = start;
            List<Pipe> loop = new();
            int length = 0;
            do
            {
                if (!loop.Contains(pipes[newLoc.Connection2.x, newLoc.Connection2.y]))
                    newLoc = pipes[newLoc.Connection2.x, newLoc.Connection2.y];
                else
                    newLoc = pipes[newLoc.Connection1.x, newLoc.Connection1.y];
                loop.Add(newLoc);
                length++;
            }
            while (newLoc.Type != start.Type);

            Console.WriteLine(length / 2);
        }

        public static void Part2()
        {
            string input;
            int y = 0;
            int dims = 500;
            Pipe[,] pipes = new Pipe[dims, dims];

            Pipe start = new Pipe();
            while ((input = Console.ReadLine()) != "")
            {
                for (int x = 0, xn = 0; x < input.Length; x++, xn += 3)
                {
                    if (input[x] != '.')
                    {
                        if (input[x] == 'S')
                            start = new Pipe(xn + 1, y + 1, input[x]);

                        if (input[x] == '|' || input[x] == 'J' || input[x] == 'L' || input[x] == 'S')
                            pipes[xn + 1, y] = new Pipe(xn + 1, y, '|');

                        if (input[x] == '-' || input[x] == 'J' || input[x] == '7' || (input[x] == 'S' && (input[x - 1] == '-' || input[x - 1] == 'F' || input[x - 1] == 'L')))
                            pipes[xn, y + 1] = new Pipe(xn, y + 1, '-');

                        pipes[xn + 1, y + 1] = new Pipe(xn + 1, y + 1, input[x]);

                        if (input[x] == '-' || input[x] == 'L' || input[x] == 'F' || (input[x] == 'S' && (input[x - 1] == '-' || input[x - 1] == '7' || input[x - 1] == 'J')))
                            pipes[xn + 2, y + 1] = new Pipe(xn + 2, y + 1, '-');

                        if (input[x] == '|' || input[x] == '7' || input[x] == 'F' || input[x] == 'S')
                            pipes[xn + 1, y + 2] = new Pipe(xn + 1, y + 2, '|');
                    }
                }
                y += 3;
            }

            if (start.x != 0 && (pipes[start.x - 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x - 1, start.y].Connection2 == (start.x, start.y)))
            {
                if (start.x != dims - 1 && pipes[start.x + 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x + 1, start.y].Connection2 == (start.x, start.y))
                { // -
                    start.Connection1 = (start.x - 1, start.y);
                    start.Connection2 = (start.x + 1, start.y);
                }
                if (start.y != 0 && pipes[start.x, start.y - 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y - 1].Connection2 == (start.x, start.y))
                { // J
                    start.Connection1 = (start.x - 1, start.y);
                    start.Connection2 = (start.x, start.y - 1);
                }
                if (start.y != dims - 1 && pipes[start.x, start.y + 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y + 1].Connection2 == (start.x, start.y))
                { // 7
                    start.Connection1 = (start.x - 1, start.y);
                    start.Connection2 = (start.x, start.y + 1);
                }
            }
            else if (start.y != (dims - 1) && (pipes[start.x, start.y + 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y + 1].Connection2 == (start.x, start.y))
                && (start.x != (dims - 1) && pipes[start.x + 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x + 1, start.y].Connection2 == (start.x, start.y)))
            { // F
                start.Connection1 = (start.x, start.y + 1);
                start.Connection2 = (start.x + 1, start.y);
            }
            else if (start.y != 0 && pipes[start.x, start.y - 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y - 1].Connection2 == (start.x, start.y))
            {
                if (start.x != (dims - 1) && pipes[start.x + 1, start.y].Connection1 == (start.x, start.y) || pipes[start.x + 1, start.y].Connection2 == (start.x, start.y))
                { // L
                    start.Connection1 = (start.x, start.y - 1);
                    start.Connection2 = (start.x + 1, start.y);
                }
                if (start.y != (dims - 1) && pipes[start.x, start.y + 1].Connection1 == (start.x, start.y) || pipes[start.x, start.y + 1].Connection2 == (start.x, start.y))
                { // |
                    start.Connection1 = (start.x, start.y - 1);
                    start.Connection2 = (start.x, start.y + 1);
                }
            }
            pipes[start.x, start.y] = start;

            Pipe newLoc = start;
            List<Pipe> loop = new();
            do
            {
                if (!loop.Contains(pipes[newLoc.Connection2.x, newLoc.Connection2.y]))
                    newLoc = pipes[newLoc.Connection2.x, newLoc.Connection2.y];
                else
                    newLoc = pipes[newLoc.Connection1.x, newLoc.Connection1.y];
                loop.Add(newLoc);
            }
            while (newLoc.Type != start.Type);

            List<(int x, int y)> unenclosed = new();
            for (int i = -1; i <= dims; i++)
            {
                unenclosed.Add((i, -1));
                unenclosed.Add((-1, i));
                unenclosed.Add((i, dims));
                unenclosed.Add((dims, i));
            }

            int enclosed = 0;

            for (int i = 0; i < dims; i++)
                for (int j = 0; j < dims; j++)
                    if (!loop.Contains(pipes[i, j]))
                    {
                        if (IsUnenclosed(pipes, loop, unenclosed, i, j))
                            unenclosed.Add((i, j));
                        else
                            enclosed++;
                    }


            Console.WriteLine(enclosed);
        }

        public static bool IsUnenclosed(Pipe[,] pipes, List<Pipe> loop, List<(int x, int y)> unenClosed, int x, int y)
        {
            bool[,] nodes = new bool[pipes.Length, pipes.Length];

            Queue<(int, int)> queue = new();

            queue.Enqueue((x, y));

            (int x, int y) curNode;

            while (queue.Any())
            {
                curNode = queue.Dequeue();
                if (nodes[curNode.x, curNode.y])
                    continue;
                nodes[curNode.x, curNode.y] = true;

                if (unenClosed.Contains(curNode) || curNode.x == 0 || curNode.x == pipes.GetLength(0) - 1 || curNode.y == 0 || curNode.y == pipes.GetLength(0) - 1)
                    return true;

                if (!loop.Contains(pipes[curNode.x - 1, curNode.y]))
                    queue.Enqueue((curNode.x - 1, curNode.y));
                if (!loop.Contains(pipes[curNode.x + 1, curNode.y]))
                    queue.Enqueue((curNode.x + 1, curNode.y));
                if (!loop.Contains(pipes[curNode.x, curNode.y - 1]))
                    queue.Enqueue((curNode.x, curNode.y - 1));
                if (!loop.Contains(pipes[curNode.x, curNode.y + 1]))
                    queue.Enqueue((curNode.x, curNode.y + 1));
            }

            return false;
        }

        public struct Pipe
        {
            public int x, y;
            public char Type;
            public (int x, int y) Connection1, Connection2;

            public Pipe(int x, int y, char c)
            {
                this.x = x;
                this.y = y;
                this.Type = c;
                switch (c)
                {
                    case 'L':
                        Connection1 = (x + 1, y);
                        Connection2 = (x, y - 1);
                        break;
                    case 'J':
                        Connection1 = (x, y - 1);
                        Connection2 = (x - 1, y);
                        break;
                    case 'F':
                        Connection1 = (x, y + 1);
                        Connection2 = (x + 1, y);
                        break;
                    case '7':
                        Connection1 = (x - 1, y);
                        Connection2 = (x, y + 1);
                        break;
                    case '|':
                        Connection1 = (x, y - 1);
                        Connection2 = (x, y + 1);
                        break;
                    case '-':
                        Connection1 = (x - 1, y);
                        Connection2 = (x + 1, y);
                        break;
                    case 'S':
                        Connection1 = (-1, -1);
                        Connection2 = (-1, -1);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }
}
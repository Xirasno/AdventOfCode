using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day24
    {
        public static void Part1()
        {
            string input;
            List<Blizzard> blizzards = new();
            (int, int) start;
            (int, int) end;
            int maxX;
            {
                int j = 0;
                maxX = Console.ReadLine().Length - 3;
                while ((input = Console.ReadLine()) != "")
                {
                    for (int i = 1; i < input.Length - 1; i++)
                        if (input[i] != '.' && input[i] != '#')
                            blizzards.Add(new Blizzard(input[i].ToString(), i - 1, j));
                    j++;
                }
                start = (0, -1);
                end = (maxX, j - 1);
            }
            int minX = 0;
            int minY = 0, maxY = end.Item2 - 1;

            List<List<Blizzard>> BlizzardsOverTime = new();
            BlizzardsOverTime.Add(new List<Blizzard>(blizzards));
            for (int i = 1; i < 500; i++)
            {
                List<Blizzard> newBlizzards = new();
                foreach (var blizzard in BlizzardsOverTime[i - 1])
                    switch (blizzard.direction)
                    {
                        case ">":
                            if (blizzard.X == maxX)
                                newBlizzards.Add(new Blizzard(">", minX, blizzard.Y));
                            else
                                newBlizzards.Add(new Blizzard(">", blizzard.X + 1, blizzard.Y));
                            break;
                        case "v":
                        case "V":
                            if (blizzard.Y == maxY)
                                newBlizzards.Add(new Blizzard("V", blizzard.X, minY));
                            else
                                newBlizzards.Add(new Blizzard("V", blizzard.X, blizzard.Y + 1));
                            break;
                        case "<":
                            if (blizzard.X == minX)
                                newBlizzards.Add(new Blizzard("<", maxX, blizzard.Y));
                            else
                                newBlizzards.Add(new Blizzard("<", blizzard.X - 1, blizzard.Y));
                            break;
                        case "^":
                            if (blizzard.Y == minY)
                                newBlizzards.Add(new Blizzard("^", blizzard.X, maxY));
                            else
                                newBlizzards.Add(new Blizzard("^", blizzard.X, blizzard.Y - 1));
                            break;
                        default:
                            Console.WriteLine(blizzard.direction);
                            break;
                    }
                BlizzardsOverTime.Add(new List<Blizzard>(newBlizzards));
                newBlizzards.Clear();
            }

            Queue<(int, int, int)> Queue = new();
            Queue.Enqueue((0, -1, 0));
            HashSet<(int, int, int)> visited = new();

            while (Queue.Count > 0)
            {
                var curItem = Queue.Dequeue();
                if ((curItem.Item1, curItem.Item2) == end)
                {
                    Console.WriteLine(curItem.Item3);
                    break;
                }
                int curX = curItem.Item1, curY = curItem.Item2;
                visited.Add(curItem);

                (int, int)[] positions = new[] {
                    (curX + 1, curY),
                    (curX, curY - 1),
                    (curX - 1, curY),
                    (curX, curY + 1),
                    (curX, curY),};

                for (int i = 0; i < positions.Length; i++)
                {
                    if (!BlizzardsOverTime[curItem.Item3 + 1].Any(b => b.X == positions[i].Item1 && b.Y == positions[i].Item2)
                        && positions[i].Item1 >= minX
                        && positions[i].Item1 <= maxX
                        && positions[i].Item2 >= minY
                        && !visited.Any(v => v.Item1 == positions[i].Item1 && v.Item2 == positions[i].Item2 && v.Item3 == curItem.Item3 + 1))
                    {
                        // This is for making sure we can get to the end
                        if (positions[i].Item1 != maxX && positions[i].Item2 > maxY)
                            continue;

                        var newLoc = (positions[i].Item1, positions[i].Item2, curItem.Item3 + 1);
                        visited.Add(newLoc);
                        Queue.Enqueue(newLoc);
                    }
                }
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        public static void Part2()
        {
            string input;
            List<Blizzard> blizzards = new();
            (int, int) start;
            (int, int) end;
            int maxX;
            {
                int j = 0;
                maxX = Console.ReadLine().Length - 3;
                while ((input = Console.ReadLine()) != "")
                {
                    for (int i = 1; i < input.Length - 1; i++)
                        if (input[i] != '.' && input[i] != '#')
                            blizzards.Add(new Blizzard(input[i].ToString(), i - 1, j));
                    j++;
                }
                start = (0, -1);
                end = (maxX, j - 1);
            }
            int minX = 0;
            int minY = 0, maxY = end.Item2 - 1;

            List<List<Blizzard>> BlizzardsOverTime = new();
            BlizzardsOverTime.Add(new List<Blizzard>(blizzards));
            for (int i = 1; i < 5000; i++)
            {
                List<Blizzard> newBlizzards = new();
                foreach (var blizzard in BlizzardsOverTime[i - 1])
                    switch (blizzard.direction)
                    {
                        case ">":
                            if (blizzard.X == maxX)
                                newBlizzards.Add(new Blizzard(">", minX, blizzard.Y));
                            else
                                newBlizzards.Add(new Blizzard(">", blizzard.X + 1, blizzard.Y));
                            break;
                        case "v":
                        case "V":
                            if (blizzard.Y == maxY)
                                newBlizzards.Add(new Blizzard("V", blizzard.X, minY));
                            else
                                newBlizzards.Add(new Blizzard("V", blizzard.X, blizzard.Y + 1));
                            break;
                        case "<":
                            if (blizzard.X == minX)
                                newBlizzards.Add(new Blizzard("<", maxX, blizzard.Y));
                            else
                                newBlizzards.Add(new Blizzard("<", blizzard.X - 1, blizzard.Y));
                            break;
                        case "^":
                            if (blizzard.Y == minY)
                                newBlizzards.Add(new Blizzard("^", blizzard.X, maxY));
                            else
                                newBlizzards.Add(new Blizzard("^", blizzard.X, blizzard.Y - 1));
                            break;
                        default:
                            Console.WriteLine(blizzard.direction);
                            break;
                    }
                BlizzardsOverTime.Add(new List<Blizzard>(newBlizzards));
                newBlizzards.Clear();
            }

            Queue<(int, int, int)> Queue = new();
            Queue.Enqueue((0, -1, 0));
            HashSet<(int, int, int)> visited = new();
            int time1 = 334, time2 = 643, time3 = 934;
            
            while (Queue.Count > 0)
            {
                var curItem = Queue.Dequeue();
                if ((curItem.Item1, curItem.Item2) == end)
                {
                    time1 = curItem.Item3;
                    break;
                }
                int curX = curItem.Item1, curY = curItem.Item2;
                visited.Add(curItem);

                (int, int)[] positions = new[] {
                    (curX + 1, curY),
                    (curX, curY - 1),
                    (curX - 1, curY),
                    (curX, curY + 1),
                    (curX, curY),};

                for (int i = 0; i < positions.Length; i++)
                {
                    if (!BlizzardsOverTime[curItem.Item3 + 1].Any(b => b.X == positions[i].Item1 && b.Y == positions[i].Item2)
                        && positions[i].Item1 >= minX
                        && positions[i].Item1 <= maxX
                        && positions[i].Item2 >= minY
                        && !visited.Any(v => v.Item1 == positions[i].Item1 && v.Item2 == positions[i].Item2 && v.Item3 == curItem.Item3 + 1))
                    {
                        // This is for making sure we can get to the end
                        if (positions[i].Item1 != maxX && positions[i].Item2 > maxY)
                            continue;

                        var newLoc = (positions[i].Item1, positions[i].Item2, curItem.Item3 + 1);
                        visited.Add(newLoc);
                        Queue.Enqueue(newLoc);
                    }
                }
            }

            Console.WriteLine(time1);
            Queue.Clear();
            Queue.Enqueue((end.Item1, end.Item2, time1));
            while (Queue.Count > 0)
            {
                var curItem = Queue.Dequeue();
                if ((curItem.Item1, curItem.Item2) == start)
                {
                    time2 = curItem.Item3;
                    break;
                }
                int curX = curItem.Item1, curY = curItem.Item2;
                visited.Add(curItem);

                (int, int)[] positions = new[] {
                    (curX, curY + 1),
                    (curX - 1, curY),
                    (curX, curY - 1),
                    (curX + 1, curY),
                    (curX, curY),};

                for (int i = 0; i < positions.Length; i++)
                {
                    if (i == positions.Length - 1 
                        && ((curX == end.Item1 && curY == end.Item2) || (curX == start.Item1 && curY == start.Item2)))
                    {
                        if (!BlizzardsOverTime[curItem.Item3 + 1].Any(b => b.X == positions[i].Item1 && b.Y == positions[i].Item2)
                            && !visited.Any(v => v.Item1 == positions[i].Item1 && v.Item2 == positions[i].Item2 && v.Item3 == curItem.Item3 + 1))
                        {
                            var newLoc = (positions[i].Item1, positions[i].Item2, curItem.Item3 + 1);
                            visited.Add(newLoc);
                            Queue.Enqueue(newLoc);
                        }
                    }
                    if (!BlizzardsOverTime[curItem.Item3 + 1].Any(b => b.X == positions[i].Item1 && b.Y == positions[i].Item2)
                        && positions[i].Item1 >= minX
                        && positions[i].Item1 <= maxX
                        && positions[i].Item2 <= maxY
                        && !visited.Any(v => v.Item1 == positions[i].Item1 && v.Item2 == positions[i].Item2 && v.Item3 == curItem.Item3 + 1))
                    {
                        // This is for making sure we can get to the start
                        if (positions[i].Item1 != minX && positions[i].Item2 < minY)
                            continue;

                        var newLoc = (positions[i].Item1, positions[i].Item2, curItem.Item3 + 1);
                        visited.Add(newLoc);
                        Queue.Enqueue(newLoc);
                    }
                }
            }

            if (time2 < 0)
                Console.WriteLine("Help");
            Console.WriteLine(time2);

            Queue.Clear();
            Queue.Enqueue((start.Item1, start.Item2, time2));
            while (Queue.Count > 0)
            {
                var curItem = Queue.Dequeue();
                if ((curItem.Item1, curItem.Item2) == end)
                {
                    time3 = curItem.Item3;
                    break;
                }
                int curX = curItem.Item1, curY = curItem.Item2;
                visited.Add(curItem);

                (int, int)[] positions = new[] {
                    (curX + 1, curY),
                    (curX, curY - 1),
                    (curX - 1, curY),
                    (curX, curY + 1),
                    (curX, curY),};

                for (int i = 0; i < positions.Length; i++)
                {
                    if (i == positions.Length - 1
                        && ((curX == end.Item1 && curY == end.Item2) || (curX == start.Item1 && curY == start.Item2)))
                    {
                        if (!BlizzardsOverTime[curItem.Item3 + 1].Any(b => b.X == positions[i].Item1 && b.Y == positions[i].Item2)
                            && !visited.Any(v => v.Item1 == positions[i].Item1 && v.Item2 == positions[i].Item2 && v.Item3 == curItem.Item3 + 1))
                        {
                            var newLoc = (positions[i].Item1, positions[i].Item2, curItem.Item3 + 1);
                            visited.Add(newLoc);
                            Queue.Enqueue(newLoc);
                        }
                    }
                    if (!BlizzardsOverTime[curItem.Item3 + 1].Any(b => b.X == positions[i].Item1 && b.Y == positions[i].Item2)
                        && positions[i].Item1 >= minX
                        && positions[i].Item1 <= maxX
                        && positions[i].Item2 >= minY
                        && !visited.Any(v => v.Item1 == positions[i].Item1 && v.Item2 == positions[i].Item2 && v.Item3 == curItem.Item3 + 1))
                    {
                        // This is for making sure we can get to the end
                        if (positions[i].Item1 != maxX && positions[i].Item2 > maxY)
                            continue;

                        var newLoc = (positions[i].Item1, positions[i].Item2, curItem.Item3 + 1);
                        visited.Add(newLoc);
                        Queue.Enqueue(newLoc);
                    }
                }
            }

            Console.WriteLine(time3);
            Console.ReadLine();
        }

        public struct Blizzard
        {
            public string direction;
            public int X;
            public int Y;

            public Blizzard(string direction, int X, int Y)
            {
                this.X = X;
                this.Y = Y;
                this.direction = direction;
            }
        }
    }
}
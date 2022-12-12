using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day12
    {
        private readonly static Dictionary<char, int> Prio = new Dictionary<char, int>()
        {
            {'a', 1  },
            {'b', 2  },
            {'c', 3  },
            {'d', 4  },
            {'e', 5  },
            {'f', 6  },
            {'g', 7  },
            {'h', 8  },
            {'i', 9  },
            {'j', 10 },
            {'k', 11 },
            {'l', 12 },
            {'m', 13 },
            {'n', 14 },
            {'o', 15 },
            {'p', 16 },
            {'q', 17 },
            {'r', 18 },
            {'s', 19 },
            {'t', 20 },
            {'u', 21 },
            {'v', 22 },
            {'w', 23 },
            {'x', 24 },
            {'y', 25 },
            {'z', 26 },
            {'S', 0 },
            {'E', 26 },
        };
        // x, y, letter, distance
        private static Dictionary<(int, int), (int, int)> Grid = new();
        private static Dictionary<(int, int), bool> BoolGrid = new();
        private static Queue<((int, int), (int, int))> Queue = new();
        public static void Part1()
        {
            string input;
            List<List<char>> grid = new();
            while ((input = Console.ReadLine()) != "")
                grid.Add(new List<char>(input.ToList()));

            ((int, int), (int, int)) start = new();
            (int, int) end = new();
            for (int i = 0; i < grid.Count; i++)
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] == 'S')
                        start = ((i, j), (0, 0));
                    if (grid[i][j] == 'E')
                        end = (i, j);
                    Grid.Add((i, j), (Prio[grid[i][j]], 0));
                    BoolGrid.Add((i, j), false);
                }

            Queue.Enqueue(start);

            while (Queue.Count > 0)
            {
                var curItem = Queue.Dequeue();
                if (curItem.Item1 == end)
                {
                    Console.WriteLine(curItem.Item2.Item2);
                    break;
                }
                int curX = curItem.Item1.Item1, curY = curItem.Item1.Item2;
                BoolGrid[(curX, curY)] = true;

                (int, int)[] positions = new[] { (curX - 1, curY),
                    (curX, curY - 1),
                    (curX + 1, curY),
                    (curX, curY + 1) };

                for (int i = 0; i < positions.Length; i++)
                {
                    try
                    {
                        if (Grid[positions[i]].Item1 - curItem.Item2.Item1 <= 1 && !BoolGrid[positions[i]])
                        {
                            BoolGrid[positions[i]] = true;
                            var newLoc = Grid[positions[i]];
                            Queue.Enqueue((positions[i], (newLoc.Item1, curItem.Item2.Item2 + 1)));
                        }
                    }
                    catch { }
                }
            }
        }

        public static void Part2()
        {
            string input;
            List<List<char>> grid = new();
            while ((input = Console.ReadLine()) != "")
                grid.Add(new List<char>(input.ToList()));

            List<((int, int), (int, int))> start = new();
            (int, int) end = new();
            for (int i = 0; i < grid.Count; i++)
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] == 'S' || grid[i][j] == 'a')
                        start.Add(((i, j), (1, 0)));
                    if (grid[i][j] == 'E')
                        end = (i, j);
                    Grid.Add((i, j), (Prio[grid[i][j]], 0));
                }

            List<int> steps = new();
            foreach (var s in start)
            {
                BoolGrid.Clear();
                Queue.Clear();
                for (int i = 0; i < grid.Count; i++)
                    for (int j = 0; j < grid[i].Count; j++)
                        BoolGrid.Add((i, j), false);
                Queue.Enqueue(s);

                while (Queue.Count > 0)
                {
                    var curItem = Queue.Dequeue();
                    if (curItem.Item1 == end)
                    {
                        steps.Add(curItem.Item2.Item2);
                        break;
                    }
                    int curX = curItem.Item1.Item1, curY = curItem.Item1.Item2;
                    BoolGrid[(curX, curY)] = true;

                    (int, int)[] positions = new[] { (curX - 1, curY),
                    (curX, curY - 1),
                    (curX + 1, curY),
                    (curX, curY + 1) };

                    for (int i = 0; i < positions.Length; i++)
                    {
                        try
                        {
                            if (Grid[positions[i]].Item1 - curItem.Item2.Item1 <= 1 && !BoolGrid[positions[i]])
                            {
                                BoolGrid[positions[i]] = true;
                                var newLoc = Grid[positions[i]];
                                Queue.Enqueue((positions[i], (newLoc.Item1, curItem.Item2.Item2 + 1)));
                            }
                        }
                        catch { }
                    }
                }
            }
            Console.WriteLine(steps.OrderBy(s => s).First());
        }
    }
}
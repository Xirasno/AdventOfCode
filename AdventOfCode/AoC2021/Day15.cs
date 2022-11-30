using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day15
    {
        // x, y, cost, distance
        private static Dictionary<(int, int), (long, long)> Grid = new();
        private static Dictionary<(int, int), (long, long)> Unvisited;
        private static Dictionary<(int, int), (long, long)> Visited = new();
        public static void Part1()
        {
            string input;
            List<List<int>> grid = new();
            while ((input = Console.ReadLine()) != "")
            {
                grid.Add(new List<int>(input.ToList().Select(c => int.Parse(c.ToString()))));
            }
            for (int i = 0; i < grid.Count; i++)
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if(i == 0 && j == 0)
                        Grid.Add((i, j), (0, 0));
                    else 
                    Grid.Add((i, j), (grid[i][j], int.MaxValue));
                }

            Unvisited = new Dictionary<(int, int), (long, long)>(Grid);

            long cost = 0;
            while (Unvisited.Count > 0)
            {
                KeyValuePair<(int, int), (long, long)> curNode = Unvisited.OrderBy(n => n.Value.Item2).First();

                (int, int)[] positions = new[] { (curNode.Key.Item1 - 1, curNode.Key.Item2), 
                    (curNode.Key.Item1, curNode.Key.Item2 - 1), 
                    (curNode.Key.Item1 + 1, curNode.Key.Item2), 
                    (curNode.Key.Item1, curNode.Key.Item2 + 1) };

                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i].Item1 < 0 || positions[i].Item2 < 0 || positions[i].Item1 >= grid.Count || positions[i].Item2 >= grid.Last().Count)
                        continue;
                    (long, long) nextNode = Grid[positions[i]];
                    if (!Visited.Values.Any(n => n.Item1 == nextNode.Item1 && n.Item2 == nextNode.Item2))
                    {
                        cost = curNode.Value.Item2 + nextNode.Item1;
                        if (cost <= nextNode.Item2)
                        {
                            Unvisited[positions[i]] = (Unvisited[positions[i]].Item1, cost);
                            Grid[positions[i]] = (Unvisited[positions[i]].Item1, cost);
                        }
                    }
                }
                Visited.Add(curNode.Key, curNode.Value);
                Unvisited.Remove(curNode.Key);
            }

            Console.WriteLine(Visited[(grid.Count - 1, grid[0].Count - 1)].Item2);
        }

        public static void Part2()
        {
            string input;
            List<List<int>> grid = new();
            while ((input = Console.ReadLine()) != "")
            {
                grid.Add(new List<int>(input.ToList().Select(c => int.Parse(c.ToString()))));
            }
            int[,] largeGrid = new int[grid.Count * 5, grid[0].Count * 5];
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                    for (int i = 0; i < grid.Count; i++)
                        for (int j = 0; j < grid[i].Count; j++)
                        {
                            if (x == 0 && y == 0)
                                largeGrid[i, j] = grid[i][j];
                            else
                                largeGrid[i + (x * grid.Count), j + (y * grid[0].Count)] = grid[i][j] + x + y > 9 ? grid[i][j] + x + y - 9 : grid[i][j] + x + y;
                        }

            for (int i = 0; i < largeGrid.GetLength(0); i++)
                for (int j = 0; j < largeGrid.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                        Grid.Add((i, j), (0, 0));
                    else
                        Grid.Add((i, j), (largeGrid[i,j], int.MaxValue));
                }

            Unvisited = new Dictionary<(int, int), (long, long)>(Grid);

            long cost = 0;
            while (Unvisited.Count > 0)
            {
                KeyValuePair<(int, int), (long, long)> curNode = Unvisited.OrderBy(n => n.Value.Item2).First();

                (int, int)[] positions = new[] { (curNode.Key.Item1 - 1, curNode.Key.Item2),
                    (curNode.Key.Item1, curNode.Key.Item2 - 1),
                    (curNode.Key.Item1 + 1, curNode.Key.Item2),
                    (curNode.Key.Item1, curNode.Key.Item2 + 1) };

                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i].Item1 < 0 || positions[i].Item2 < 0 || positions[i].Item1 >= largeGrid.GetLength(0) || positions[i].Item2 >= largeGrid.GetLength(1))
                        continue;
                    (long, long) nextNode = Grid[positions[i]];
                    if (!Visited.Values.Any(n => n.Item1 == nextNode.Item1 && n.Item2 == nextNode.Item2))
                    {
                        cost = curNode.Value.Item2 + nextNode.Item1;
                        if (cost <= nextNode.Item2)
                        {
                            Unvisited[positions[i]] = (Unvisited[positions[i]].Item1, cost);
                            Grid[positions[i]] = (Unvisited[positions[i]].Item1, cost);
                        }
                    }
                }
                Visited.Add(curNode.Key, curNode.Value);
                Unvisited.Remove(curNode.Key);
            }

            Console.WriteLine(Visited[(largeGrid.GetLength(0) - 1, largeGrid.GetLength(1) - 1)].Item2);
        }
    }
}
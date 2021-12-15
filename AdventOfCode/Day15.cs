using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day15
    {
        public static void Part1()
        {
            string input;
            List<List<int>> grid = new();
            while ((input = Console.ReadLine()) != "")
            {
                grid.Add(new List<int>(input.ToList().Select(c => int.Parse(c.ToString()))));
            }
            long risk = 0;
            List<long> risks = new();
            Stack<(int, int)> path = new();
            path.Push((0, 0));
            var h = FindPath(grid, (0, 0), path);

            foreach ((int x, int y) in path)
                risk += grid[x][y];
            Console.WriteLine(risk);
        }

        /*public static void Part2()
        {

        }*/

        private static int FindPath(List<List<int>> grid, (int, int) curPos, Stack<(int, int)> curPath)
        {
            int paths = 0;
            curPath.Push(curPos);

            (int, int)[] positions = new[] { (curPos.Item1 - 1, curPos.Item2), (curPos.Item1, curPos.Item2 - 1), (curPos.Item1 + 1, curPos.Item2), (curPos.Item1, curPos.Item2 + 1) };
            for (int i = 0; i < positions.Length; i++)
            {
                if (curPath.Contains(positions[i]))
                    continue;
                if (positions[i] == (grid.Count, grid[0].Count))
                {
                    paths++;
                    continue;
                }
                paths += FindPath(grid, positions[i], curPath);
            }

            curPath.Pop();
            return paths;
        }

        /*private static List<long> FindPath(List<List<int>> grid, (int, int) curPos, int risk, List<(int, int)> path)
        {
            List<long> paths = new();
            if (curPos == (grid.Count, grid[0].Count))
                return new List<long>(risk + grid.Last().Last());

            (int, int)[] positions = new[] { (curPos.Item1 - 1, curPos.Item2), (curPos.Item1, curPos.Item2 - 1), (curPos.Item1 + 1, curPos.Item2), (curPos.Item1, curPos.Item2 + 1) };
            for (int i = 0; i < positions.Length; i++)
            {
                if (!path.Contains(positions[i]))
                {
                    try
                    {
                        var loc = grid[positions[i].Item1][positions[i].Item2];
                        path.Add(positions[i]);
                        paths = paths.Concat(FindPath(grid, positions[i], risk + loc, path)).ToList();
                    }
                    catch { continue; };
                }
            }

            return paths;
        }*/

        //private static List<(int, int)> FindPath(List<List<int>> grid, (int, int) curPos, List<(int, int)> path)
        //{
        //    if (curPos == (grid.Count, grid[0].Count))
        //        return path;

        //    List<(int, int)> lowestNs = new();
        //    int cur = grid[curPos.Item1][curPos.Item2];
        //    (int, int)[] positions = new[] { (curPos.Item1 - 1, curPos.Item2), (curPos.Item1, curPos.Item2 - 1), (curPos.Item1 + 1, curPos.Item2), (curPos.Item1, curPos.Item2 + 1) };
        //    for (int i = 0; i < positions.Length; i++)
        //    {
        //        try
        //        {
        //            var n = grid[positions[i].Item1][positions[i].Item2];
        //            if (n <= cur && !path.Contains(positions[i]))
        //            {
        //                if (n < grid[lowestNs[0].Item1][lowestNs[0].Item2])
        //                    lowestNs.Clear();
        //                lowestNs.Add(positions[i]);
        //            }

        //        }
        //        catch { continue; };
        //    }

        //    foreach (var n in lowestNs)
        //    {
        //        var newPath = FindPath(grid, n, path);
        //        if (newPath == null)
        //            continue;
        //        path = path.Concat(newPath).ToList();
        //    }

        //    return path;
        //}
    }
}
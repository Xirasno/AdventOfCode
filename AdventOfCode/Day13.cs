using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day13
    {
        public static void Part1()
        {
            string input;
            HashSet<(int, int)> coords = new();
            int maxX = int.MinValue, maxY = int.MinValue;

            while ((input = Console.ReadLine()) != "")
            {
                var s = input.Split(',').Select(s => int.Parse(s)).ToArray();
                if (s[0] + 1 > maxX)
                    maxX = s[0] + 1;
                if (s[1] + 1> maxY)
                    maxY = s[1] + 1;
                coords.Add((s[0], s[1]));
            }

            List<int> foldsX = new();

            while ((input= Console.ReadLine()) != "")
            {
                if (input.Contains("x"))
                    foldsX.Add(int.Parse(input.Split('=').Last()));
            }

            bool[,] graph = new bool[maxX, maxY];
            bool[,] newGraph = new bool[1,1];

            foreach ((int x, int y) in coords)
                graph[x, y] = true;

            newGraph = FoldGraphX(graph, foldsX[0]);

            int dots = 0;
            foreach(bool d in newGraph)
                if (d)
                    dots++;
            Console.WriteLine(dots);
        }

        public static void Part2()
        {
            string input;
            HashSet<(int, int)> coords = new();
            int maxX = int.MinValue, maxY = int.MinValue;

            while ((input = Console.ReadLine()) != "")
            {
                var s = input.Split(',').Select(s => int.Parse(s)).ToArray();
                if (s[0] + 1 > maxX)
                    maxX = s[0] + 1;
                if (s[1] + 1 > maxY)
                    maxY = s[1] + 1;
                coords.Add((s[0], s[1]));
            }

            List<int> foldsY = new();
            List<int> foldsX = new();


            bool[,] graph = new bool[maxX, maxY];
            bool[,] newGraph = graph;

            foreach ((int x, int y) in coords)
                graph[x, y] = true;

            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains("x"))
                    newGraph = FoldGraphX(newGraph, (int.Parse(input.Split('=').Last())));
                if (input.Contains("y"))
                    newGraph = FoldGraphY(newGraph, (int.Parse(input.Split('=').Last())));
            }

            for (int j = 0; j < newGraph.GetLength(1); j++)
            {
                for (int i = 0; i < newGraph.GetLength(0); i++)
                    if (newGraph[i, j])
                        Console.Write("#");
                    else Console.Write(" ");
                Console.WriteLine();
            }
        }

        private static bool[,] FoldGraphX(bool [,] graph, int x)
        {
            bool[,] newGraph = new bool[Math.Min(x, graph.GetLength(0)), graph.GetLength(1)];
            for (int j = 0; j < newGraph.GetLength(1); j++)
                for (int i = 0, k = x; i < newGraph.GetLength(0); i++, k--)
                {
                        newGraph[i, j] = graph[i, j];
                    if (x + k < graph.GetLength(0))
                        newGraph[i, j] |= graph[x + k, j];
                }

            return newGraph;
        }

        private static bool[,] FoldGraphY(bool [,] graph, int y)
        {
            bool[,] newGraph = new bool[graph.GetLength(0), Math.Min(y, graph.GetLength(1))];
            for (int i = 0; i < newGraph.GetLength(0); i++)
                for (int j = 0, k = y; j < newGraph.GetLength(1); j++, k--)
                {
                    newGraph[i, j] = graph[i, j];
                    if (y + k < graph.GetLength(1))
                        newGraph[i, j] |= graph[i, y + k];
                }

            return newGraph;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day15
    {
        private static List<Node> Grid = new();
        private static List<Node> Unvisited;
        private static List<Node> Close = new();
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
                        Grid.Add(new Node(i, j, 0));
                    else 
                    Grid.Add(new Node(i, j, grid[i][j]));
                }

            Unvisited = new List<Node>(Grid);
            Unvisited.Sort(new NodeComparer());

            bool finished = false;
            while (Unvisited.Count > 0 && !finished)
            {
                Node curNode =
            }
            
            //var h = FindPath((0, 0), path);
            Console.WriteLine(risk);
        }

        /*public static void Part2()
        {

        }*/

        private static int FindPath((int, int) curPos, Stack<(int, int)> curPath)
        {

        }

        /*private static int FindPath((int, int) curPos, Stack<(int, int)> curPath)
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
        }*/


    }
    
    public class Node
    {
        public int x, y, cost, distance = int.MaxValue;
        public Node previous = null;
        public bool visited = false;
        public Node(int x, int y, int cost)
        {
            this.x = x;
            this.y = y;
            this.cost = cost;
        }
    }

    class NodeComparer : IComparer<Node>
    {
        public int Compare(Node n1, Node n2)
        {
            return n1.cost.CompareTo(n2.cost);
        }
    }
}
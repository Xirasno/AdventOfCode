using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day12
    {
        private static HashSet<Cave> Caves = new();
        private static int SmallCaves;

        public static void Part1()
        {
            string input;
            string[] splitInput;
            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split("-");
                if (!Caves.Any(c => c.Name == splitInput[0]))
                {
                    Caves.Add(new Cave()
                    {
                        Name = splitInput[0],
                        Small = splitInput[0].IsLower(),
                        Caves = new HashSet<Cave>()
                    });
                }
                if (!Caves.Any(c => c.Name == splitInput[1]))
                {
                    Caves.Add(new Cave()
                    {
                        Name = splitInput[1],
                        Small = splitInput[1].IsLower(),
                        Caves = new HashSet<Cave>()
                    });
                }
                Cave cave1 = Caves.First(c => c.Name == splitInput[0]);
                Cave cave2 = Caves.First(c => c.Name == splitInput[1]);
                cave1.Caves.Add(cave2);
                cave2.Caves.Add(cave1);
            }
            SmallCaves = 1;
            Console.WriteLine(FindPath(Caves.First(c => c.Name == "start"), new Stack<Cave>()));            
        }

        public static void Part2()
        {
            string input;
            string[] splitInput;
            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split("-");
                if (!Caves.Any(c => c.Name == splitInput[0]))
                {
                    Caves.Add(new Cave()
                    {
                        Name = splitInput[0],
                        Small = splitInput[0].IsLower(),
                        Caves = new HashSet<Cave>()
                    });
                }
                if (!Caves.Any(c => c.Name == splitInput[1]))
                {
                    Caves.Add(new Cave()
                    {
                        Name = splitInput[1],
                        Small = splitInput[1].IsLower(),
                        Caves = new HashSet<Cave>()
                    });
                }
                Cave cave1 = Caves.First(c => c.Name == splitInput[0]);
                Cave cave2 = Caves.First(c => c.Name == splitInput[1]);
                cave1.Caves.Add(cave2);
                cave2.Caves.Add(cave1);
            }
            SmallCaves = 2;
            Console.WriteLine(FindPath(Caves.First(c => c.Name == "start"), new Stack<Cave>()));
        }

        private static int FindPath(Cave curCave, Stack<Cave> curPath)
        {
            int paths = 0;
            curPath.Push(curCave);

            foreach (Cave c in curCave.Caves)
            {
                if (c.Name == "start")
                    continue;
                if (c.Name == "end")
                {
                    paths++;
                    continue;
                }
                if (c.Small && ((curPath.Where(x => x.Small).GroupBy(x => x.Name).Any(x => x.Count() > 1) && curPath.Contains(c)) || curPath.Where(cave => c.Name == cave.Name).Count() == SmallCaves))
                    continue;
                paths += FindPath(c, curPath);
            }

            curPath.Pop();
            return paths;
        }

        private static bool IsLower(this string s)
        {
            if (s == null)
                return false;

            foreach (char c in s)
                if (char.IsUpper(c))
                    return false;

            return true;
        }
    }

    public class Cave
    {
        public string Name { get; set; }
        public bool Small { get; set; }
        public HashSet<Cave> Caves { get; set; }
    }
}
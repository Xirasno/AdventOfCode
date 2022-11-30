using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day09
    {
        private static List<(int, int)> CheckedCoords = new();
        public static void Part1()
        {
            string input;
            List<List<int>> coords = new();
            while ((input = Console.ReadLine()) != "")
            {
                coords.Add(new List<int>());
                for (int i = 0; i < input.Length; i++)
                    coords.Last().Add(int.Parse(input[i].ToString()));
            }

            int riskLevel = 0;
            for (int i = 0; i < coords.Count; i++)
                for (int j = 0; j < coords.ElementAt(i).Count; j++)
                {
                    var elem = coords.ElementAt(i).ElementAt(j);
                    var neighbour = new List<int>();
                    try { neighbour.Add(coords.ElementAt(i - 1).ElementAt(j)); } catch {}
                    try { neighbour.Add(coords.ElementAt(i + 1).ElementAt(j)); } catch {}
                    try { neighbour.Add(coords.ElementAt(i).ElementAt(j - 1)); } catch {}
                    try { neighbour.Add(coords.ElementAt(i).ElementAt(j + 1)); } catch {}
                    if (elem < neighbour.Min())
                        riskLevel += elem + 1;
                }

            Console.WriteLine(riskLevel);
        }

        public static void Part2()
        {
            string input;
            List<List<int>> coords = new();
            while ((input = Console.ReadLine()) != "")
            {
                coords.Add(new List<int>());
                for (int i = 0; i < input.Length; i++)
                    coords.Last().Add(int.Parse(input[i].ToString()));
            }

            List<int> riskLevel = new();

            for (int i = 0; i < coords.Count; i++)
                for (int j = 0; j < coords.ElementAt(i).Count; j++)
                {
                    var elem = coords.ElementAt(i).ElementAt(j);
                    if (elem == 9 || CheckedCoords.Contains((i, j)))
                        continue;
                    riskLevel.Add(FindBasin(coords, (i, j)));
                }

            List<int> top3 = new();
            for (int i = 0; i < 3; i++)
            {
                var max = riskLevel.Max();
                top3.Add(max);
                riskLevel.Remove(max);
            }
            Console.WriteLine(top3.Aggregate((e1, e2) => e1 * e2));
        }

        private static int FindBasin(List<List<int>> coords, (int, int) loc)
        {
            int elem;
            try { elem = coords.ElementAt(loc.Item1).ElementAt(loc.Item2); }
            catch { return 0; }

            if (CheckedCoords.Contains(loc) || elem == 9)
                return 0;

            CheckedCoords.Add(loc);
            var riskLevel = 0;

            riskLevel += FindBasin(coords, (loc.Item1 - 1, loc.Item2));
            riskLevel += FindBasin(coords, (loc.Item1 + 1, loc.Item2));
            riskLevel += FindBasin(coords, (loc.Item1, loc.Item2 - 1));
            riskLevel += FindBasin(coords, (loc.Item1, loc.Item2 + 1)); 
            return riskLevel + 1;
        }
    }
}
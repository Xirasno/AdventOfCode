﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day09
    {
        public static List<(int, int)> CheckedCoords;
        public static void Part1()
        {
            string input;
            List<List<int>> coords = new List<List<int>>();
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
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            if (elem < coords.ElementAt(i).ElementAt(j + 1) && elem < coords.ElementAt(i + 1).ElementAt(j))
                            {
                                riskLevel += elem + 1;
                            }
                        }

                        else if (j == coords.ElementAt(i).Count - 1)
                        {
                            if (elem < coords.ElementAt(i).ElementAt(j - 1) && elem < coords.ElementAt(i + 1).ElementAt(j))
                            {
                                riskLevel += elem + 1;
                            }
                        }

                        else if (elem < coords.ElementAt(i).ElementAt(j + 1) && elem < coords.ElementAt(i + 1).ElementAt(j) && elem < coords.ElementAt(i).ElementAt(j - 1))
                        {
                            riskLevel += elem + 1;
                        }
                    }

                    else if (i == coords.Count - 1)
                    {
                        if (j == 0)
                        {
                            if (elem < coords.ElementAt(i).ElementAt(j + 1) && elem < coords.ElementAt(i - 1).ElementAt(j))
                            {
                                riskLevel += elem + 1;
                            }
                        }

                        else if (j == coords.ElementAt(i).Count - 1)
                        {
                            if (elem < coords.ElementAt(i).ElementAt(j - 1) && elem < coords.ElementAt(i - 1).ElementAt(j))
                            {
                                riskLevel += elem + 1;
                            }
                        }

                        else if (elem < coords.ElementAt(i).ElementAt(j + 1) && elem < coords.ElementAt(i - 1).ElementAt(j) && elem < coords.ElementAt(i).ElementAt(j - 1))
                        {
                            riskLevel += elem + 1;
                        }
                    }

                    else if (j == 0)
                    {
                        if (elem < coords.ElementAt(i).ElementAt(j + 1) && elem < coords.ElementAt(i + 1).ElementAt(j) && elem < coords.ElementAt(i - 1).ElementAt(j))
                        {
                            riskLevel += elem + 1;
                        }
                    }

                    else if (j == coords.ElementAt(i).Count - 1)
                    {
                        if (elem < coords.ElementAt(i).ElementAt(j - 1) && elem < coords.ElementAt(i + 1).ElementAt(j) && elem < coords.ElementAt(i - 1).ElementAt(j))
                        {
                            riskLevel += elem + 1;
                        }
                    }

                    else if (elem < coords.ElementAt(i).ElementAt(j + 1) && elem < coords.ElementAt(i + 1).ElementAt(j) && elem < coords.ElementAt(i).ElementAt(j - 1) && elem < coords.ElementAt(i - 1).ElementAt(j))
                    {
                        riskLevel += elem + 1;
                    }
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

            CheckedCoords = new List<(int, int)>();
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
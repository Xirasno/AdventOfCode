using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day23
    {
        readonly static Dictionary<char, int> Costs = new() { {'A', 1}, {'B', 10}, {'C', 100}, {'D', 1000} };
        static Dictionary<int, char> Corridor = new();
        static Dictionary<int, (char, char)> Hallways = new()
        {
            { 0, ('B', 'A') },
            { 1, ('C', 'D') },
            { 2, ('B', 'C') },
            { 3, ('D', 'A') },
            /*
            { 0, ('C', 'B') },
            { 1, ('B', 'D') },
            { 2, ('D', 'A') },
            { 3, ('A', 'C') },
                */
        };
        public static void Part1()
        {
            
        }

        public static bool Complete (this Dictionary<int, (char, char)> hallways)
        {
            return hallways.Values.All(h => h.Item1 == h.Item2);
        }

        public static bool Complete (this (char, char) hallway)
        {
            return hallway.Item1 == hallway.Item2;
        }

        /*public static void Part2()
        {

        }*/
    }
}
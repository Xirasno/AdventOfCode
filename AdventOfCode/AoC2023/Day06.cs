using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class AoC2023Day06
    {
        public static void Part1()
        {
            Regex nrs = new(@"\d+");
            List<int> times = nrs.Matches(Console.ReadLine()).Select(m => int.Parse(m.Value)).ToList();
            List<int> distances = nrs.Matches(Console.ReadLine()).Select(m => int.Parse(m.Value)).ToList();

            int product = 1, possibleWays;
            for (int i = 0; i < times.Count; i++)
            {
                possibleWays = 0;

                for (int x = 0; x < times[i]; x++)
                {
                    if (x * (times[i] - x) > distances[i])
                    {
                        possibleWays++;
                    }

                }

                product *= possibleWays;
            }

            Console.WriteLine(product);
        }

        public static void Part2()
        {
            Regex nrs = new(@"\d+");
            long times = long.Parse(nrs.Matches(Console.ReadLine()).Select(m => m.Value).Aggregate((a, b) => a + b));
            long distances = long.Parse(nrs.Matches(Console.ReadLine()).Select(m => m.Value).Aggregate((a, b) => a + b));

            long possibleWays = 0;

            for (long x = 0; x < times; x++)
            {
                if (x * (times - x) > distances)
                {
                    possibleWays++;
                }

            }

            Console.WriteLine(possibleWays);
        }
    }
}
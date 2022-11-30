using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day07
    {
        public static void Part1()
        {
            int[] crabs = Console.ReadLine().Split(',').Select(c => int.Parse(c)).ToArray();
            int lowestPos = crabs.Min(), highestPos = crabs.Max();
            int lowestDist = int.MaxValue, curDist;

            for (int i = lowestPos; i < highestPos; i++)
            {
                curDist = 0;
                for (int j = 0; j < crabs.Length; j++)
                {
                    curDist += Math.Abs(crabs[j] - i);
                    if (curDist >= lowestDist)
                        break;
                }
                if (curDist < lowestDist)
                    lowestDist = curDist;
            }
            Console.WriteLine(lowestDist);
        }

        public static void Part2()
        {
            int[] crabs = Console.ReadLine().Split(',').Select(c => int.Parse(c)).ToArray();
            int lowestPos = crabs.Min(), highestPos = crabs.Max();
            int lowestDist = int.MaxValue, curDist;

            for (int i = lowestPos; i < highestPos; i++)
            {
                curDist = 0;
                for (int j = 0; j < crabs.Length; j++)
                {
                    curDist += calcFuel(Math.Abs(crabs[j] - i));
                    if (curDist >= lowestDist)
                        break;
                }
                if (curDist < lowestDist)
                    lowestDist = curDist;
            }
            Console.WriteLine(lowestDist);
        }

        private static int calcFuel(int dist)
        {
            int fuel = 0;
            for (int i = 0; i <= dist; i++)
            {
                fuel += i;
            }
            return fuel;
        }
    }
}
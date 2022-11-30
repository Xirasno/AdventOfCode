using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day17
    {
        public static void Part1()
        {
            string[] input = Console.ReadLine()[15..].Split(", y=");
            int[] xRange = input[0].Split("..").Select(s => int.Parse(s)).ToArray();
            int[] yRange = input[1].Split("..").Select(s => int.Parse(s)).ToArray();
            int minX = xRange[0], maxX = xRange[1], minY = yRange[0], maxY = yRange[1];
            int highest = 0;
            for (int i = 1; i <= maxX; i++)
            {
                for (int j = minY; j < 100; j++)
                {
                    int maxHeight = int.MinValue;
                    for (int x = 0, y = 0, xVel = i, yVel = j; ; x += xVel, y += yVel, xVel = xVel > 0 ? xVel - 1 : (xVel < 0 ? xVel + 1 : xVel), yVel--)
                    {
                        if (y > maxHeight)
                            maxHeight = y;
                        if (x > maxX || (xVel == 0 && x < minX) || (yVel < 0 && y < minY))
                            break;

                        if (x >= minX && x <= maxX && y >= minY && y <= maxY)
                        {
                            if (maxHeight > highest)
                                highest = maxHeight;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(highest);
        }

        public static void Part2()
        {
                    string[] input = Console.ReadLine()[15..].Split(", y=");
            int[] xRange = input[0].Split("..").Select(s => int.Parse(s)).ToArray();
            int[] yRange = input[1].Split("..").Select(s => int.Parse(s)).ToArray();
            int minX = xRange[0], maxX = xRange[1], minY = yRange[0], maxY = yRange[1];
            int hits = 0;
            for (int i = 0; i <= maxX; i++)
                for (int j = minY; j < 10000; j++)
                {
                    for (int x = 0, y = 0, xVel = i, yVel = j; ; x += xVel, y += yVel, xVel = xVel > 0 ? xVel - 1 : (xVel < 0 ? xVel + 1 : xVel), yVel--)
                    {
                        if (x > maxX || (xVel == 0 && x < minX) || (yVel < 0 && y < minY))
                            break;

                        if (x >= minX && x <= maxX && y >= minY && y <= maxY)
                        {
                            hits++;
                            break;
                        }
                    }
                }
            Console.WriteLine(hits);
        }
    }
}
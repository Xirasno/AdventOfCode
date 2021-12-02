using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day2
    {
        public static void Part1()
        {
            int depth = 0, dist = 0;
            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "stop")
            {
                switch (input[0])
                {
                    case "forward":
                        dist += int.Parse(input[1]);
                        break;

                    case "down":
                        depth += int.Parse(input[1]);
                        break;

                    case "up":
                        depth -= int.Parse(input[1]);
                        break;
                }
                input = Console.ReadLine().Split(' ');
            }
            Console.WriteLine($"depth = {depth}; dist = {dist}; total = {depth * dist}");
        }

        public static void Part2()
        {
            int depth = 0, dist = 0, aim = 0;
            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "stop")
            {
                switch (input[0])
                {
                    case "forward":
                        dist += int.Parse(input[1]);
                        depth += aim * int.Parse(input[1]);
                        break;

                    case "down":
                        aim += int.Parse(input[1]);
                        break;

                    case "up":
                        aim -= int.Parse(input[1]);
                        break;
                }
                input = Console.ReadLine().Split(' ');
            }
            Console.WriteLine($"depth = {depth}; dist = {dist}; total = {depth * dist}");
        }
    }
}

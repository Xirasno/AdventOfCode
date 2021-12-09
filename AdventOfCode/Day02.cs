using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day02
    {
        public static void Part1()
        {
            int depth = 0, dist = 0;
            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "")
            {
                int val = int.Parse(input[1]);
                switch (input[0])
                {
                    case "forward":
                        dist += val;
                        break;

                    case "down":
                        depth += val;
                        break;

                    case "up":
                        depth -= val;
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

            while (input[0] != "")
            {
                int val = int.Parse(input[1]);
                switch (input[0])
                {
                    case "forward":
                        dist += val;
                        depth += aim * val;
                        break;

                    case "down":
                        aim += val;
                        break;

                    case "up":
                        aim -= val;
                        break;
                }
                input = Console.ReadLine().Split(' ');
            }
            Console.WriteLine($"depth = {depth}; dist = {dist}; total = {depth * dist}");
        }
    }
}

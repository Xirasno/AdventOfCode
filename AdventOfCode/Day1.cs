using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day1
    {
        public static void Part1(string firstLine = "")
        {
            int incr = 0, prev = int.Parse(Console.ReadLine());
            string input;

            while ((input = Console.ReadLine())!= "")
            {
                if (int.Parse(input) > prev)
                    incr++;

                prev = int.Parse(input);
            }
            Console.WriteLine(incr);
        }
        public static void Part2(string firstLine = "")
        {
            int incr = 0, a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine()), c = int.Parse(Console.ReadLine());
            string input;

            while ((input = Console.ReadLine()) != "")
            {
                if (b + c + int.Parse(input) > a + b + c)
                    incr++;

                a = b; b = c; c = int.Parse(input);
            }
            Console.WriteLine(incr);
        }
    }
}

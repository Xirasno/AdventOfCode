using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day06
    {
        public static void Part1()
        {
            string input = Console.ReadLine(), buffer = "";
            for(int i = 0; i < input.Length; i++)
            {
                if (!buffer.Contains(input[i]))
                    buffer += input[i];
                else
                {
                    buffer = buffer.Replace(input[i], ' ');
                    buffer = buffer.Split(' ')[1] + input[i];
                }
                if (buffer.Length == 4)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        public static void Part2()
        {
            string input = Console.ReadLine(), buffer = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (!buffer.Contains(input[i]))
                    buffer += input[i];
                else
                {
                    buffer = buffer.Replace(input[i], ' ');
                    buffer = buffer.Split(' ')[1] + input[i];
                }
                if (buffer.Length == 14)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
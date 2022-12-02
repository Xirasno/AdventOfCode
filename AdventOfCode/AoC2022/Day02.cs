using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day2
    {
        public static void Part1()
        {
            string input;
            int score = 0;
            while ((input = Console.ReadLine()) != "") {
                score += RPS(input[2], input[0]);
            }
            Console.WriteLine(score);
        }

        public static void Part2()
        {
            string input;
            int score = 0;
            while ((input = Console.ReadLine()) != "") {
                score += RPS2(input[2], input[0]);
            }
            Console.WriteLine(score);
        }

        private static int RPS(char X, char Y)
        {
            if (X == 'X')
            {
                if (Y == 'A')
                    return 4;
                if (Y == 'B')
                    return 1;
                if (Y == 'C')
                    return 7;
            }
            if (X == 'Y')
            {
                if (Y == 'A')
                    return 8;
                if (Y == 'B')
                    return 5;
                if (Y == 'C')
                    return 2;
            }
            if (X == 'Z')
            {
                if (Y == 'A')
                    return 3;
                if (Y == 'B')
                    return 9;
                if (Y == 'C')
                    return 6;
            }
            return -1;
        }

        private static int RPS2(char X, char Y)
        {
            if (X == 'X')
            {
                if (Y == 'A')
                    return 3;
                if (Y == 'B')
                    return 1;
                if (Y == 'C')
                    return 2;
            }
            if (X == 'Y')
            {
                if (Y == 'A')
                    return 4;
                if (Y == 'B')
                    return 5;
                if (Y == 'C')
                    return 6;
            }
            if (X == 'Z')
            {
                if (Y == 'A')
                    return 8;
                if (Y == 'B')
                    return 9;
                if (Y == 'C')
                    return 7;
            }
            return -1;
        }
    }
}
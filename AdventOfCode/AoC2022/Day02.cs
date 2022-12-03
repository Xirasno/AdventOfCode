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
            switch (X)
            {
                case 'X':
                    switch (Y)
                    {
                        case 'A':
                            return 4;
                        case 'B':
                            return 1;
                        case 'C':
                            return 7;
                    }
                    break;
                case 'Y':
                    switch (Y)
                    {
                        case 'A':
                            return 8;
                        case 'B':
                            return 5;
                        case 'C':
                            return 2;
                    }
                    break;
                case 'Z':
                    switch (Y)
                    {
                        case 'A':
                            return 3;
                        case 'B':
                            return 9;
                        case 'C':
                            return 6;
                    }
                    break;
            }
            return -1;
        }

        private static int RPS2(char X, char Y)
        {
            switch (X)
            {
                case 'X':
                    switch (Y)
                    {
                        case 'A':
                            return 3;
                        case 'B':
                            return 1;
                        case 'C':
                            return 2;
                    }
                    break;
                case 'Y':
                    switch (Y)
                    {
                        case 'A':
                            return 4;
                        case 'B':
                            return 5;
                        case 'C':
                            return 6;
                    }
                    break;
                case 'Z':
                    switch (Y)
                    {
                        case 'A':
                            return 8;
                        case 'B':
                            return 9;
                        case 'C':
                            return 7;
                    }
                    break;
            }
            return -1;
        }
    }
}
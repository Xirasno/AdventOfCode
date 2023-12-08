using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class AoC2023Day08
    {
        public static void Part1()
        {
            string instructions =  Console.ReadLine();
            Console.ReadLine();

            Dictionary<string, Node> nodes = new();
            Regex lettersRgx = new Regex(@"\w+");
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                List<string> letters = lettersRgx.Matches(input).Select(m => m.Value).ToList();
                nodes.Add(letters[0], new(letters[1], letters[2]));
            }

            string curNode = "AAA";
            int steps = 0, moveIndex = 0;

            while (curNode != "ZZZ")
            {
                switch (instructions[moveIndex])
                {
                    case 'R':
                        curNode = nodes[curNode].Rigth;
                        break;
                    case 'L':
                        curNode = nodes[curNode].Left;
                        break;   
                    default:
                        break;
                }
                steps++;
                moveIndex = moveIndex == instructions.Length - 1 ? 0 : moveIndex + 1;
            }
            Console.WriteLine(steps);
        }

        public static void Part2()
        {
            string instructions = Console.ReadLine();
            Console.ReadLine();

            Dictionary<string, Node> nodes = new();
            Regex lettersRgx = new Regex(@"\w+");
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                List<string> letters = lettersRgx.Matches(input).Select(m => m.Value).ToList();
                nodes.Add(letters[0], new(letters[1], letters[2]));
            }

            List<string> curNodes = nodes.Where(n => n.Key[^1] == 'A').Select(n => n.Key).ToList();
            List<long> neededSteps = new();

            for (int i = 0; i < curNodes.Count; i++)
            {
                long steps = 0;
                int moveIndex = 0;
                while (curNodes[i][^1] != 'Z')
                {
                    switch (instructions[moveIndex])
                    {
                        case 'R':
                            curNodes[i] = nodes[curNodes[i]].Rigth;
                            break;
                        case 'L':
                            curNodes[i] = nodes[curNodes[i]].Left;
                            break;
                        default:
                            break;
                    }
                    steps++;
                    moveIndex = moveIndex == instructions.Length - 1 ? 0 : moveIndex + 1;
                }
                neededSteps.Add(steps);
            }
            Console.WriteLine(neededSteps.Aggregate((a, b) => FindLCM(a, b)));
        }

        public static long FindLCM(long a, long b)
        {
            long num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (long i = 1; i < num2; i++)
            {
                long mult = num1 * i;
                if (mult % num2 == 0)
                {
                    return mult;
                }
            }
            return num1 * num2;
        }
    }

    public struct Node
    {
        public string Left;
        public string Rigth;

        public Node(string Left, string Right)
        {
            this.Left = Left;
            this.Rigth = Right;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day10
    {
        private static Dictionary<char, char> Braces = new() { {')', '(' }, { ']', '[' }, { '}', '{' }, { '>', '<' } };
        private static Dictionary<char, int> CorruptScore = new() { {')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
        private static Dictionary<char, int> IncompleteScore = new() { {'(', 1 }, { '[', 2 }, { '{', 3 }, { '<', 4 } };
        public static void Part1()
        {
            string input;
            int errorScore = 0;
            while ((input = Console.ReadLine()) != "")
            {
                errorScore += MatchingPairs(input, 0);
            }

            Console.WriteLine(errorScore);
        }

        public static void Part2()
        {
            List<string> debug = new();
            string input, openers;
            List<long> errorScores = new();
            while ((input = Console.ReadLine()) != "")
            {
                long errorScore = 0;
                openers = RemoveCorruption(input, 0);
                debug.Add(openers);
                if (openers == "")
                    continue;
                for (int i = openers.Length - 1; i >= 0; i--)
                {
                    errorScore *= 5;
                    errorScore += IncompleteScore[openers[i]];
                }
                errorScores.Add(errorScore);
            }
            errorScores.Sort();
            Console.WriteLine(errorScores.ElementAt(errorScores.Count / 2));
        }

        private static int MatchingPairs(string input, int index)
        {
            if (index == input.Length)
                return 0;

            if (Braces.Keys.Contains(input[index]))
                if (Braces[input[index]] != input[index - 1])
                    return CorruptScore[input[index]];
                else
                    return MatchingPairs(input.Remove(index - 1, 2), index - 1);
            else
                return MatchingPairs(input, index + 1);
        }

        private static string RemoveCorruption(string input, int index)
        {
            if (index == input.Length)
                return input;

            if (Braces.Keys.Contains(input[index]))
                if (Braces[input[index]] != input[index - 1])
                    return "";
                else
                    return RemoveCorruption(input.Remove(index - 1, 2), index - 1);
            else
                return RemoveCorruption(input, index + 1);
        }
    }
}
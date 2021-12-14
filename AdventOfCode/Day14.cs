using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day14
    {
        private static Dictionary<(char, char), long> Template;
        public static void Part1()
        {
            string polymer = Console.ReadLine();
            Console.ReadLine();
            Dictionary<(char, char), string> map = new();
            string input = "";
            string[] splitInput;
            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split(" -> ");
                map.Add((splitInput[0][0], splitInput[0][1]), splitInput[1]);
            }

            for (int i = 0; i < 10; i++)
            {
                polymer = polymer.AddLetters(map);
            }

            var occurence = polymer
                .GroupBy(x => x)
                .Select(x => x.Count())
                .ToList();
            occurence.Sort();
            Console.WriteLine(occurence.Last() - occurence.First());
        }

        public static void Part2()
        {
            string input = Console.ReadLine();
            char lastChar = input[^1];
            Console.ReadLine();

            Dictionary<(char, char), long> polymer = new();
            for (int i = 0; i < input.Length - 1; i++)
            {
                var c = (input[i], input[i + 1]);
                if (!polymer.Any(ch => ch.Key == c))
                    polymer.Add(c, 0);

                polymer[c]++;
            }

            Dictionary<(char, char), (char, char, char)> map = new();
            string[] splitInput;
            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split(" -> ");
                map.Add((splitInput[0][0], splitInput[0][1]), (splitInput[0][0], splitInput[1][0], splitInput[0][1]));

                if (!polymer.Any(c => c.Key == (splitInput[0][0], splitInput[1][0])))
                    polymer.Add((splitInput[0][0], splitInput[1][0]), 0);

                if (!polymer.Any(c => c.Key == (splitInput[1][0], splitInput[0][1])))
                    polymer.Add((splitInput[1][0], splitInput[0][1]), 0);
            }

            Template = new(polymer);
            Template.Keys.ToList().ForEach(d => Template[d] = 0);

            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(i);
                polymer = polymer.AddLetters(map);
            }

            polymer.Add((lastChar, ' '), 1);
            var occurence = polymer
                .GroupBy(x => x.Key.Item1)
                .Select(x => x.Select(y => y.Value).Aggregate((a, b) => a + b))
                .ToList();

            occurence.Sort();
            Console.WriteLine(occurence.Last() - occurence.First());
        }

        private static string AddLetters(this string polymer, Dictionary<(char, char), string> map)
        {
            string newTemplate = "";
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                newTemplate += polymer[i];
                newTemplate += map[(polymer[i], polymer[i + 1])];
            }
            newTemplate += polymer.Last();
            return newTemplate;
        }

        private static Dictionary<(char, char), long> AddLetters(this Dictionary<(char, char), long> polymer, Dictionary<(char, char), (char, char, char)> map)
        {
            Dictionary <(char, char), long> newPolymer = new(Template);

            foreach (var c in polymer.Where(x => x.Value > 0))
            {
                var x = map[c.Key];
                newPolymer[(x.Item1, x.Item2)] += c.Value;
                newPolymer[(x.Item2, x.Item3)] += c.Value;
            }

            return newPolymer;
        }
    }
}
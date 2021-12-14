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
            string template = Console.ReadLine();
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
                template = template.AddLetters(map);
            }

            var occurence = template
                .GroupBy(x => x)
                .Select(x => x.Count())
                .ToList();
            occurence.Sort();
            Console.WriteLine(occurence.Last() - occurence.First());
        }

        public static void Part2()
        {
            string input = Console.ReadLine();
            Console.ReadLine();

            List<(char, char)> templ = new();
            for (int i = 0; i < input.Length - 1; i++)
                templ.Add((input[i], input[i + 1]));
            char lastChar = input[input.Length - 1];

            Template = new();
            Dictionary<(char, char), long> template = new();
            foreach ((char, char) c in templ)
            {
                if (!Template.Any(ch => ch.Key == c))
                {
                    Template.Add(c, 0);
                    template.Add(c, 0);
                }
                template[c]++;
            }

            Dictionary<(char, char), (char, char, char)> map = new();
            string[] splitInput;
            while ((input = Console.ReadLine()) != "")
            {
                splitInput = input.Split(" -> ");
                map.Add((splitInput[0][0], splitInput[0][1]), (splitInput[0][0], splitInput[1][0], splitInput[0][1]));

                if (!Template.Any(c => c.Key == (splitInput[0][0], splitInput[1][0])))
                {
                    Template.Add((splitInput[0][0], splitInput[1][0]), 0);
                    template.Add((splitInput[0][0], splitInput[1][0]), 0);
                }
                if (!Template.Any(c => c.Key == (splitInput[1][0], splitInput[0][1])))
                {
                    Template.Add((splitInput[1][0], splitInput[0][1]), 0);
                    template.Add((splitInput[1][0], splitInput[0][1]), 0);
                }
            }

            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(i);
                template = template.AddLetters(map);
            }
            template.Add((lastChar, ' '), 1);
            var occurence = template
                .GroupBy(x => x.Key.Item1)
                .ToList();

            List<long> occs = new();
            foreach(var occ in occurence)
            {
                long oc = 0;
                for(int j = 0; j < occ.Count(); j++)
                    oc += occ.ElementAt(j).Value;
                occs.Add(oc);
                Console.WriteLine($"{occ.Key} {oc}");
            }
            occs.Sort();
            Console.WriteLine(occs.Last() - occs.First());
        }

        private static string AddLetters(this string template, Dictionary<(char, char), string> map)
        {
            string newTemplate = "";
            for (int i = 0; i < template.Length - 1; i++)
            {
                newTemplate += template[i];
                newTemplate += map[(template[i], template[i + 1])];
            }
            newTemplate += template.Last();
            return newTemplate;
        }

        private static Dictionary<(char, char), long> AddLetters(this Dictionary<(char, char), long> template, Dictionary<(char, char), (char, char, char)> map)
        {
            Dictionary <(char, char), long> newTemplate = new Dictionary<(char, char), long>(Template);

            foreach (var c in template.Where(x => x.Value > 0))
            {
                var x = map[c.Key];
                newTemplate[(x.Item1, x.Item2)] += c.Value;
                newTemplate[(x.Item2, x.Item3)] += c.Value;
            }

            return newTemplate;
        }
    }
}
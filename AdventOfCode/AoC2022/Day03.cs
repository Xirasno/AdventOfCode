using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day03
    {
        private readonly static Dictionary<char, int> Prio = new Dictionary<char, int>()
        {
            {'a', 1  },
            {'b', 2  },
            {'c', 3  },
            {'d', 4  },
            {'e', 5  },
            {'f', 6  },
            {'g', 7  },
            {'h', 8  },
            {'i', 9  },
            {'j', 10 },
            {'k', 11 },
            {'l', 12 },
            {'m', 13 },
            {'n', 14 },
            {'o', 15 },
            {'p', 16 },
            {'q', 17 },
            {'r', 18 },
            {'s', 19 },
            {'t', 20 },
            {'u', 21 },
            {'v', 22 },
            {'w', 23 },
            {'x', 24 },
            {'y', 25 },
            {'z', 26 },
            {'A', 27 },
            {'B', 28 },
            {'C', 29 },
            {'D', 30 },
            {'E', 31 },
            {'F', 32 },
            {'G', 33 },
            {'H', 34 },
            {'I', 35 },
            {'J', 36 },
            {'K', 37 },
            {'L', 38 },
            {'M', 39 },
            {'N', 40 },
            {'O', 41 },
            {'P', 42 },
            {'Q', 43 },
            {'R', 44 },
            {'S', 45 },
            {'T', 46 },
            {'U', 47 },
            {'V', 48 },
            {'W', 49 },
            {'X', 50 },
            {'Y', 51 },
            {'Z', 52 }
        };
        public static void Part1()
        {
            string input;
            int priority = 0;
            while ((input = Console.ReadLine()) != "")
            {
                string half1 = input[0..(input.Length / 2)];    
                string half2 = input[(input.Length / 2) .. input.Length];
                foreach (var c in half1)
                    if (half2.Contains(c))
                    {
                        priority += Prio[c];
                        break;
                    }
            }
            Console.WriteLine(priority);
        }

        public static void Part2()
        {
            string elf1, elf2, elf3;
            int priority = 0;
            while ((elf1 = Console.ReadLine()) != "")
            {
                elf2 = Console.ReadLine();
                elf3 = Console.ReadLine();
                foreach (var c in elf1)
                    if (elf2.Contains(c) && elf3.Contains(c))
                    {
                        priority += Prio[c];
                        break;
                    }
            }
            Console.WriteLine(priority);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day04
    {
        public static void Part1()
        {
            string input;
            int elf1S, elf1E, elf2S, elf2E, overlap = 0;
            while ((input = Console.ReadLine()) != "")
            {
                elf1S = int.Parse(input.Split(',')[0].Split('-')[0]);
                elf1E = int.Parse(input.Split(',')[0].Split('-')[1]);
                elf2S = int.Parse(input.Split(',')[1].Split('-')[0]);
                elf2E = int.Parse(input.Split(',')[1].Split('-')[1]);
                if ((elf2S >= elf1S && elf2E <= elf1E) || (elf1S >= elf2S && elf1E <= elf2E))
                        overlap++;
            }
            Console.WriteLine(overlap);
        }

        public static void Part2()
        {
            string input;
            int elf1S, elf1E, elf2S, elf2E, overlap = 0;
            while ((input = Console.ReadLine()) != "")
            {
                elf1S = int.Parse(input.Split(',')[0].Split('-')[0]);
                elf1E = int.Parse(input.Split(',')[0].Split('-')[1]);
                elf2S = int.Parse(input.Split(',')[1].Split('-')[0]);
                elf2E = int.Parse(input.Split(',')[1].Split('-')[1]);
                if ((elf2S >= elf1S && elf2S <= elf1E) || (elf2E <= elf1E && elf2E >= elf1S) || (elf1S >= elf2S && elf1S <= elf2E) || (elf1E <= elf2E && elf1E >= elf2S))
                    overlap++;
            }
            Console.WriteLine(overlap);

        }
    }
}
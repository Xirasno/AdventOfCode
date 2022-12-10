using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day10
    {
        private static int Register = 1;

        public static void Part1()
        {
            string input;
            List<Command> commands = new();
            int i = 0, strength = 0;

            while ((input = Console.ReadLine()) != "")
            {
                if (input[0..4] == "addx")
                {
                    i += 2;
                    commands.Add(new Command(i, int.Parse(input.Split(' ')[1])));
                }
                else
                    commands.Add(new Command(++i, 0));
            }
            int l = 0;
            for(int k = 0; k < commands.Max(c => c.cycles) + 1; k++)
            {
                if (k == 20 + (40 * l))
                {
                    strength += k * Register;
                    l++;
                }
                Register += commands.FirstOrDefault(c => c.cycles == k, new Command(k, 0)).effect;
            }
            Console.WriteLine(strength);
        }

        public static void Part2()
        {
            string input;
            List<Command> commands = new();
            int i = 0, spritePos = 0;

            while ((input = Console.ReadLine()) != "")
            {
                if (input[0..4] == "addx")
                {
                    i += 2;
                    commands.Add(new Command(i, int.Parse(input.Split(' ')[1])));
                }
                else
                    commands.Add(new Command(++i, 0));
            }

            int pos = 0;
            for (int k = 0; k < commands.Max(c => c.cycles) + 1; k++, pos++)
            {
                Register += commands.FirstOrDefault(c => c.cycles == k, new Command(k, 0)).effect;

                if (pos >= Register - 1 && pos <= Register + 1)
                    Console.Write('#');
                else
                    Console.Write(' ');

                if (pos > 0 && pos == 39)
                {
                    Console.WriteLine();
                    pos = -1;
                }

            }
            Console.WriteLine(spritePos);
        }

        public struct Command
        {
            public int cycles;
            public int effect;
            
            public Command(int cycles, int effect)
            {
                this.cycles = cycles;
                this.effect = effect;
            }
        }
    }
}
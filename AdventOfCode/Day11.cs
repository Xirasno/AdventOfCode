using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day11
    {
        private static int Flashes = 0;
        private static HashSet<(int, int)> HasFlashed = new();

        public static void Part1()
        {
            int[,] octopusses = new int[10,10];
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                octopusses[i, j] = int.Parse(input[j].ToString());
            }
            for (int i = 0; i < 100;i++)
            {
                octopusses.Advance();
                foreach ((int x, int y) in HasFlashed)
                    octopusses.Flash(x, y);
                
                octopusses.Reset();
                //octopusses.Write();
            }
            Console.WriteLine(Flashes);
        }

        public static void Part2()
        {
            int[,] octopusses = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                    octopusses[i, j] = int.Parse(input[j].ToString());
            }
            for (int i = 0; i < 500; i++)
            {
                octopusses.Advance();
                foreach ((int x, int y) in HasFlashed)
                    octopusses.Flash(x, y);

                octopusses.Reset();
                if(octopusses.AllFlash())
                {
                    Console.WriteLine(i + 1);
                    break;
                }
                //octopusses.Write();
            }
        }

        private static int[,] Advance(this int[,] octopusses)
        {
            HasFlashed.Clear();
            int[,] octoRef = octopusses;
            for (var i = 0;i < octoRef.GetLength(0);i++)
                for (var j = 0;j < octoRef.GetLength(1);j++)
                {
                    if (++octoRef[i, j] > 9)
                        HasFlashed.Add((i, j));
                }
            return octoRef;
        }

        private static int[,] Reset(this int[,] octopusses)
        {
            int[,] octoRef = octopusses;
            for (var i = 0; i < octoRef.GetLength(0); i++)
                for (var j = 0; j < octoRef.GetLength(1); j++)
                {
                    if (octoRef[i, j] < 0)
                        octoRef[i, j] = 0;
                }
            return octoRef;
        }

        private static int[,] Flash(this int[,] octopusses, int x, int y)
        {
            int[,] octoRef = octopusses;

            try { int energy = octopusses[x, y]; }
            catch { return octopusses; }

            if (++octoRef[x, y] > 9)
            {
                octoRef[x, y] = int.MinValue;
                Flashes++;
                octoRef = Flash(octoRef, x + 1, y);
                octoRef = Flash(octoRef, x + 1, y + 1);
                octoRef = Flash(octoRef, x, y + 1);
                octoRef = Flash(octoRef, x - 1, y);
                octoRef = Flash(octoRef, x - 1, y - 1);
                octoRef = Flash(octoRef, x, y - 1);
                octoRef = Flash(octoRef, x + 1, y - 1);
                octoRef = Flash(octoRef, x - 1, y + 1);
            }
            return octoRef;
        }

        private static bool AllFlash(this int[,] octopusses)
        {
            foreach(int octo in octopusses)
            {
                if (octo != 0)
                    return false;
            }
            return true;
        }

        private static void Write(this int[,] octopusses)
        {
            Console.WriteLine();
            for (int i = 0; i < octopusses.GetLength(0); i++)
            {
                for (int j = 0; j < octopusses.GetLength(1); j++)
                {
                    Console.Write(octopusses[i, j]);
                    if (octopusses[i, j] < 10)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day22
    {
        public static void Part1()
        {
            HashSet<Instruction> instructions = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(' ');
                bool onOff = splitInput[0].ToLower() == "on";
                splitInput = splitInput[1].Split(',');
                string[] x = splitInput[0][2..].Split("..");
                string[] y = splitInput[1][2..].Split("..");
                string[] z = splitInput[2][2..].Split("..");
                instructions.Add(new Instruction(onOff, int.Parse(x[0]), int.Parse(x[1]), int.Parse(y[0]), int.Parse(y[1]), int.Parse(z[0]), int.Parse(z[1])));
            }

            bool[,,] reactors = new bool[101, 101, 101];
            foreach(Instruction instruction in instructions)
            {
                for (int i = Math.Max(instruction.xMin, -50); i <= Math.Min(instruction.xMax, 50); i++)
                    for (int j = Math.Max(instruction.yMin, -50); j <= Math.Min(instruction.yMax, 50); j++)
                        for (int k = Math.Max(instruction.zMin, -50); k <= Math.Min(instruction.zMax, 50); k++)
                        {
                            reactors[i + 50, j + 50, k + 50] = instruction.onOff;
                        }

            }
            int r = 0;
            foreach (bool onOff in reactors)
                if (onOff)
                    r++;
            Console.WriteLine(r);

        }

        public static void Part2()
        {
            string input;
            HashSet<(int, int, int)> instructions = new();
            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(' ');
                bool onOff = splitInput[0].ToLower() == "on";
                splitInput = splitInput[1].Split(',');
                string[] x = splitInput[0][2..].Split("..");
                string[] y = splitInput[1][2..].Split("..");
                string[] z = splitInput[2][2..].Split("..");
                for (int i = int.Parse(x[0]); i <= int.Parse(x[1]); i++)
                    for (int j = int.Parse(y[0]); j <= int.Parse(y[1]); j++)
                        for (int k = int.Parse(z[1]); k <= int.Parse(z[1]); k++)
                        {
                            if (instructions.Contains((i, j, k)))
                            {
                                if (!onOff)
                                    instructions.Remove((i, j, k));
                            }
                            else instructions.Add((i, j, k));
                        }
            }
            Console.WriteLine(instructions.Count());
        }
    }

    public struct Instruction
    {
        public bool onOff;
        public int xMin, xMax, yMin, yMax, zMin, zMax;

        public Instruction(bool onOff, int xMin, int xMax, int yMin, int yMax, int zMin, int zMax)
        {
            this.onOff = onOff;
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            this.zMin = zMin;
            this.zMax = zMax;
        }
    }
}

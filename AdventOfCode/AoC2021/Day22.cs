using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day22
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
            var instructions = Enumerable.Empty<IEnumerable<int>>();

            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(' ');
                bool onOff = splitInput[0].ToLower() == "on";
                splitInput = splitInput[1].Split(',');
                string[] x = splitInput[0][2..].Split("..");
                string[] y = splitInput[1][2..].Split("..");
                string[] z = splitInput[2][2..].Split("..");
                int xMin = int.Parse(x[0]), xMax = int.Parse(x[1]);
                int yMin = int.Parse(y[0]), yMax = int.Parse(y[1]);
                int zMin = int.Parse(z[0]), zMax = int.Parse(z[1]);
                var xRange = Enumerable.Range(xMin, xMax - xMin + 1);
                var yRange = Enumerable.Range(yMin, yMax - yMin + 1);
                var zRange = Enumerable.Range(zMin, zMax - zMin + 1);
                var xyzRange = new[] {xRange, yRange, zRange};
                var fullRange = xyzRange.CartesianProduct();

                if (!onOff)
                    instructions = instructions.Where(x => !fullRange.Contains(x));
                else
                    instructions = instructions.Concat(fullRange).Distinct();
            }

            Console.WriteLine(instructions.Count());
        }

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };
            foreach (var sequence in sequences)
            {
                var localSequence = sequence;
                result = result.SelectMany(
                  _ => localSequence,
                  (seq, item) => seq.Concat(new[] { item })
                );
            }
            return result;
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

/*
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
            var instructions = Enumerable.Empty<IEnumerable<int>>();
            HashSet<Cube> cubes = new();

            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(' ');
                bool onOff = splitInput[0].ToLower() == "on";
                splitInput = splitInput[1].Split(',');
                string[] x = splitInput[0][2..].Split("..");
                string[] y = splitInput[1][2..].Split("..");
                string[] z = splitInput[2][2..].Split("..");
                int xMin = int.Parse(x[0]), xMax = int.Parse(x[1]);
                int yMin = int.Parse(y[0]), yMax = int.Parse(y[1]);
                int zMin = int.Parse(z[0]), zMax = int.Parse(z[1]);
                cubes = cubes.AddCube(xMin, xMax, yMin, yMax, zMin, zMax);
            }

            Console.WriteLine(instructions.Count());
        }

        public static HashSet<Cube> AddCube(this HashSet<Cube> cubes, int xMin, int xMax, int yMin, int yMax, int zMin, int zMax)
        {
            var cube = new Cube(xMin, xMax, yMin, yMax, zMin, zMax);
            Cube? overlap = null;
            if (cubes.Any(c => c.Overlap(cube, ref overlap)))
            {
                cubes = cubes.Concat(cube.Slice(overlap.Value)).ToHashSet();
            }
            else
                cubes.Add(new Cube(xMin, xMax, yMin, yMax, zMin, zMax));
            return cubes;

        }
        public static bool Overlap(this Cube c1, Cube c2, ref Cube? overlap)
        {
            if (c1.xMin <= c2.xMin && c2.xMin < c1.xMax
            || c1.xMin <= c2.xMax && c2.xMax < c1.xMax
            || c1.yMin <= c2.yMin && c2.yMin < c1.yMax
            || c1.yMin <= c2.yMax && c2.yMax < c1.yMax
            || c1.zMin <= c2.zMin && c2.zMin < c1.zMax
            || c1.zMin <= c2.zMax && c2.zMax < c1.zMax)
            {
                overlap = c1;
                return true;
            }
            else return false;
        }

        public HashSet<Cube> Slice(this Cube c1, Cube c2)
        {
            HashSet<Cube> newCubes = new();
            newCubes.Add(c1);
            newCubes.Add();
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

    public struct Cube
    {
        public int xMin, xMax, yMin, yMax, zMin, zMax;

        public Instruction(int xMin, int xMax, int yMin, int yMax, int zMin, int zMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            this.zMin = zMin;
            this.zMax = zMax;
        }
    }
}

 */

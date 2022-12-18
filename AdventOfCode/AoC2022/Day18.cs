using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day18
    {
        public static void Part1()
        {
            string input;
            HashSet<Cube> cubes = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(',');
                cubes.Add(new Cube(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
            }

            int exposed = 0;
            foreach (var c in cubes)
            {
                exposed += c.Exposed(cubes);
            }

            Console.WriteLine(exposed);
        }

        public static void Part2()
        {
            string input;
            HashSet<Cube> cubes = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(',');
                cubes.Add(new Cube(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
            }

            int exposed = 0;
            foreach (var c in cubes)
            {
                exposed += c.Exposed(cubes);
            }

            var airPockets = FindAirPockets(cubes);
            int airEdges = 0;
            foreach (var air in airPockets)
            {
                airEdges += air.Exposed(airPockets);
            }
            int leftOver = exposed - airEdges;
            Console.WriteLine(leftOver);
            Console.ReadLine();
        }

        public static HashSet<Cube> FindAirPockets(HashSet<Cube> cubes)
        {
            HashSet<Cube> airpockets = new();
            int minX, maxX, minY, maxY, minZ, maxZ;
            minX = cubes.Min(c => c.x);
            maxX = cubes.Max(c => c.x);
            minY = cubes.Min(c => c.y);
            maxY = cubes.Max(c => c.y);
            minZ = cubes.Min(c => c.z);
            maxZ = cubes.Max(c => c.z);

            var edges = new (int, int)[3] {
                (minX - 1, maxX + 1),
                (minY - 1, maxY + 1),
                (minZ - 1, maxZ + 1)
            };

            HashSet<Cube> grid = new();
            for (int x = minX - 1; x <= maxX + 1; x++)
                for (int y = minY - 1; y <= maxY + 1; y++)
                    for (int z = minZ - 1; z <= maxZ + 1; z++)
                        grid.Add(new Cube(x, y, z));

            for (int x = minX; x <= maxX; x++)
                for (int y = minY; y <= maxY; y++)
                    for (int z = minZ; z <= maxZ; z++)
                    {
                        if (!cubes.Any(c => c.x == x && c.y == y && c.z == z))
                        {
                                if (!PathFound(x, y, z, cubes, edges))
                                { 
                                    airpockets.Add(new Cube(x, y, z));
                                }

                        }
                    }

            return airpockets;
        }

        public static bool PathFound(int x, int y, int z, HashSet<Cube> cube, (int, int)[] edges)
        {
            var queue = new Queue<Cube>();
            HashSet<Cube> blocked = new(cube);
            queue.Enqueue(new Cube(x, y, z));

            while (queue.Count > 0)
            {
                var curItem = queue.Dequeue();
                if (curItem.x == edges[0].Item1 || curItem.x == edges[0].Item2
                    || curItem.y == edges[1].Item1 || curItem.y == edges[1].Item2
                    || curItem.z == edges[2].Item1 || curItem.z == edges[2].Item2)
                    return true;
                
                int curX = curItem.x, curY = curItem.y, curZ = curItem.z;
                blocked.Add(curItem);

                (int, int, int)[] positions = new[] { (curX - 1, curY, curZ),
                    (curX, curY - 1, curZ),
                    (curX + 1, curY, curZ),
                    (curX, curY + 1, curZ),
                    (curX, curY, curZ - 1),
                    (curX, curY, curZ + 1) };

                for (int i = 0; i < positions.Length; i++)
                {
                    try
                    {
                        if (!blocked.Any(b => b.x == positions[i].Item1 && b.y == positions[i].Item2 && b.z == positions[i].Item3))
                        {
                            blocked.Add(new Cube(positions[i]));
                            var newLoc = positions[i];
                            queue.Enqueue(new Cube(positions[i]));
                        }
                    }
                    catch { }
                }
            }
            return false;
        }

        public class Cube
        {
            public int x;
            public int y;
            public int z;

            public Cube (int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Cube ((int, int, int) coords)
            {
                this.x = coords.Item1;
                this.y = coords.Item2;
                this.z = coords.Item3;
            }

            public int Exposed(HashSet<Cube> cubes)
            {
                int exposed = 6;
                foreach (var c in cubes)
                {
                    if ((c.x == this.x + 1 || c.x == this.x - 1) && c.y == this.y && c.z == this.z)
                    {
                        exposed--;
                    }
                    if ((c.y == this.y + 1 || c.y == this.y - 1) && c.x == this.x && c.z == this.z)
                    {
                        exposed--;
                    }
                    if ((c.z == this.z + 1 || c.z == this.z - 1) && c.y == this.y && c.x == this.x)
                    {
                        exposed--;
                    }
                }
                return exposed;
            }
        }
    }
}
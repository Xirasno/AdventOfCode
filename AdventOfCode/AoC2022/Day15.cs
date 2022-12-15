using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class AoC2022Day15
    {
        public static void Part1()
        {
            string input;
            List<Sensor> sensors = new List<Sensor>();
            int noBeacon = 0;
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                var xL = int.Parse(split[2].Split('=')[1].Split(',')[0].ToString());
                var yL = int.Parse(split[3].Split('=')[1].Split(':')[0].ToString());
                var xB = int.Parse(split[8].Split('=')[1].Split(',')[0].ToString());
                var yB = int.Parse(split[9].Split('=')[1].ToString());
                sensors.Add(new Sensor(xL, yL, xB, yB));
            }

            const int checkY = 2000000;

            foreach (var s in sensors)
            {
                if (s.location.Item2 - s.distance > checkY || s.location.Item2 + s.distance < checkY)
                    continue;
                for(int i = s.location.Item1 - s.distance; i <= s.location.Item1 + s.distance; i++)
                    if ((i,checkY) != s.beacon && ManhattanDist(s.location, (i, checkY)) <= s.distance)
                    {
                        noBeacon++;
                    }
            }

            Console.WriteLine(noBeacon);
        }

        public static void Part2()
        {
            int minXY = 0; //3687000
            int maxXY = 4000000;// 4000000;

            string input;
            List<Sensor> sensors = new List<Sensor>();
            HashSet<(int, int, int)> noBeacon = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                var xL = int.Parse(split[2].Split('=')[1].Split(',')[0].ToString());
                var yL = int.Parse(split[3].Split('=')[1].Split(':')[0].ToString());
                var xB = int.Parse(split[8].Split('=')[1].Split(',')[0].ToString());
                var yB = int.Parse(split[9].Split('=')[1].ToString());
                var dist = ManhattanDist((xL, yL), (xB, yB));
                if (xL - dist > maxXY || xL + dist < minXY || yL - dist > maxXY || yL + dist < minXY)
                    continue;
                //sensors.Add(new Sensor(xL, yL, xB, yB, dist));
                noBeacon.Add((xL, yL, dist));
            }

            bool inArea = false;
            for (int j = minXY; j <= maxXY; j++)
            {
                for (int i = minXY; i <= maxXY;)
                {
                    foreach (var area in noBeacon)
                    {
                        inArea = InArea((i, j), area);
                        if (inArea)
                        {
                            i = area.Item1;
                            i += Math.Abs(area.Item3 - Math.Abs(area.Item2 - j)) + 1;
                            break;
                        }
                    }
                    if (!inArea)
                    {
                        Console.WriteLine($"{i}, {j}");
                        Console.WriteLine((long)((long)i * (long)4000000 + (long)j));
                        Console.ReadLine();
                        return;
                    }
                }
            }
        }

        public static bool InArea((int, int) loc, (int, int, int) area)
        {
            return ManhattanDist(loc, (area.Item1, area.Item2)) <= area.Item3;
        }

        public static int ManhattanDist((int, int) l1, (int, int) l2)
        {
            return Math.Abs(l1.Item1 - l2.Item1) + Math.Abs(l1.Item2 - l2.Item2);
        }

        public struct Sensor
        {
            public (int, int) location;
            public (int, int) beacon;
            public int distance;

            public Sensor(int xL, int yL, int xB, int yB)
            {
                location = (xL, yL);
                beacon = (xB, yB);
                distance = Math.Abs(xL - xB) + Math.Abs(yL - yB);
            }

            public Sensor(int xL, int yL, int xB, int yB, int dist)
            {
                location = (xL, yL);
                beacon = (xB, yB);
                distance = dist;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day19
    {
        public static void Part1()
        {
            string input = "";
            string[] splitInput;
            HashSet<Scanner> scanners = new();
            while ((input = Console.ReadLine()) != "")
            {
                Scanner scanner = new(int.Parse(input[12..^4].ToString()));
                while ((input = Console.ReadLine()) != "")
                {
                    splitInput = input.Split(',');
                    scanner.probes.Add(new Probe(int.Parse(splitInput[0]), int.Parse(splitInput[1]), int.Parse(splitInput[2])));
                }
                scanners.Add(scanner);
            }
            scanners.First(s => s.Nr == 0).ChangeLoc(0, 0, 0);

            for(int i = 0; i < scanners.Count - 1; i++)
            {
                Scanner curScanner = scanners.First(s => s.Nr == i);
                foreach (Scanner s2 in scanners.Where(s => s != curScanner))
                {
                    foreach (Probe p1 in curScanner.probes)
                    {
                        for (int k = 0; k < 24; k++)
                        {
                            foreach (Probe p2 in s2.probes)
                            {
                                for (int l = 0; l < 24; l++)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }

        /*public static void Part2()
        {

        }*/
    }

    public class Scanner
    {
        public List<Probe> probes = new();
        public int Nr, x, y, z;

        public Scanner(int Nr)
        {
            this.Nr = Nr;
        }

        public void ChangeLoc(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public struct Probe
    {
        public int x, y, z;
        public Probe(int x, int y, int z)
        {
            this.x = x;
            this.y = y; 
            this.z = z;
        }
    }
}

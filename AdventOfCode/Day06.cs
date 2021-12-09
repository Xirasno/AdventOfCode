using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day06
    {
        public static void Part1()
        {
            List<int> fishes = new List<int>(), newFishes = new List<int>();
            fishes = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToList();

            for (int d = 0; d < 80; d++)
            {
                Console.WriteLine(d);
                for (int i = 0; i < fishes.Count; i++)
                {
                    int fish = fishes.ElementAt(i);
                    if (fish == 0)
                    {
                        newFishes.Add(6);
                        newFishes.Add(8);
                    }
                    else
                    {
                        newFishes.Add(fish - 1);
                    }
                }
                fishes = new List<int>(newFishes);
                newFishes.Clear();
            }

            Console.WriteLine(fishes.Count);
        }

        public static void Part2()
        {
            List<int> fishes = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToList();
            long fishNr = fishes.Count;
            long[] offsprings = new long[5];

            for (int i = 0; i < offsprings.Length; i++)
            {
                offsprings[i] = CountOffspring(i + 1, 255);
            }

            for (int i = 0; i < fishes.Count; i++)
            {
                fishNr += offsprings[fishes[i] - 1];
            }

            Console.WriteLine(fishNr);
        }

        private static long CountOffspring(int age, int days)
        {
            if (days - age < 0)
                return 0;

            long fish = (days - age) / 7 + 1;

            long offspring = fish;
            for (int f = 0; f < fish; f++)
            {
                offspring += CountOffspring(9, days - age - (f * 7));
            }
            return offspring;
        }
    }
}
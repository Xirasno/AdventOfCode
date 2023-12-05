using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using static AdventOfCode.AoC2023Day05;

namespace AdventOfCode
{
    public static class AoC2023Day05
    {
        public static void Part1()
        {
            string input = Console.ReadLine();
            Regex numbers = new(@"\d+");
            Dictionary<long,Seed> seeds = numbers.Matches(input).Select(m => long.Parse(m.Value)).ToDictionary(m => m, m => new Seed(m, false));
            string prevLine = Console.ReadLine();
            while (input != "" || prevLine != "")
            {
                prevLine = input;
                input = Console.ReadLine();
                if (input.Contains("map"))
                {
                    foreach (var seed in seeds)
                    {
                        seeds[seed.Key] = new(seed.Value.Number, false);
                    }
                    continue;
                }
                if (input == "")
                    continue;

                var ranges = numbers.Matches(input).Select(m => long.Parse(m.Value)).ToList();
                long destinationRange = ranges[0], sourceRange = ranges[1], rangeLength = ranges[2];

                foreach (var seed in seeds)
                {
                    if (!seed.Value.Edited && seed.Value.Number >= sourceRange && seed.Value.Number < sourceRange + rangeLength)
                    {
                        seeds[seed.Key] = new (destinationRange + (seed.Value.Number - sourceRange), true);
                    }
                }
            }
            Console.WriteLine(seeds.Select(s => s.Value.Number).Min());
        }

        public static void Part2()
        {
            string input = Console.ReadLine();
            Regex numbers = new(@"\d+");
            List<long> seedsInput = numbers.Matches(input).Select(m => long.Parse(m.Value)).ToList();

            List<Seed2> seeds = new();
            for (int i = 0; i < seedsInput.Count - 1; i += 2)
            {
                seeds.Add(new(seedsInput[i], seedsInput[i] + seedsInput[i + 1], false));
            }
            string prevLine = Console.ReadLine();

            long seedCount = 0;
            List<long> seedCounts = new();
            seeds.ForEach(s =>
            {
                seedCount += s.End - s.Start;
            });
            seedCounts.Add(seedCount);
            while (input != "" || prevLine != "")
            {
                prevLine = input;
                input = Console.ReadLine();
                if (input.Contains("map"))
                {
                    for (int i = 0; i < seeds.Count; i++)
                    {
                        seeds[i] = new(seeds[i].Start, seeds[i].End, false);
                    }

                    seeds = seeds.OrderBy(s => s.Start).ToList();
                    continue;
                }
                    
                if (input == "")
                    continue;

                var ranges = numbers.Matches(input).Select(m => long.Parse(m.Value)).ToList();
                long destinationRange = ranges[0], sourceRange = ranges[1], rangeLength = ranges[2];

                List<Seed2> newSeeds = new();
                foreach (var seed in seeds)
                {
                    if (!seed.Edited && sourceRange + rangeLength >= seed.Start && sourceRange <= seed.End)
                    {
                        // Starts outside the range <----|-->---|
                        if (seed.Start < sourceRange && seed.End <= sourceRange + rangeLength)
                        {
                            newSeeds.Add(new(seed.Start, sourceRange, true));
                            newSeeds.Add(new(destinationRange, destinationRange + (seed.End - sourceRange), true));
                        }
                        // Ends outside the range |---<----|-->
                        if (seed.Start >= sourceRange && seed.End > sourceRange + rangeLength)
                        {
                            newSeeds.Add(new(destinationRange + (seed.Start - sourceRange), destinationRange + rangeLength, true));
                            newSeeds.Add(new(sourceRange + rangeLength, seed.End, true));
                        }
                        // Fully within the range |---<------>---|
                        if (sourceRange <= seed.Start && seed.End <= sourceRange + rangeLength)
                        {
                            newSeeds.Add(new(destinationRange + (seed.Start - sourceRange), destinationRange + (seed.End - sourceRange), true));
                        }
                        // Range fully inside seeds <---|------|--->
                        if (seed.Start < sourceRange && seed.End > sourceRange + rangeLength)
                        {
                            newSeeds.Add(new(seed.Start, sourceRange, true));
                            newSeeds.Add(new(destinationRange, destinationRange + rangeLength, true));
                            newSeeds.Add(new(sourceRange + rangeLength, seed.End, true));
                        }
                    }
                    else
                    {
                        newSeeds.Add(new(seed.Start, seed.End, false));
                    }
                }
                seeds = new(newSeeds);

                seedCount = 0;
                seeds.ForEach(s =>
                {
                    seedCount += s.End - s.Start;
                });
                seedCounts.Add(seedCount);
                seedCounts = seedCounts.Distinct().ToList();
                if (seedCounts.Count > 1)
                {
                    Console.WriteLine("Help");
                }

            }
            var t = seeds.Select(s => s.Start).ToList();
            t.Sort();
            Console.WriteLine(seeds.Select(s => s.Start).Min());

            // 10954309
        }

        public struct Seed
        {
            public long Number;
            public bool Edited;

            public Seed(long Number, bool Edited)
            {
                this.Number = Number;
                this.Edited = Edited;
            }
        }
        public struct Seed2
        {
            public long Start;
            public long End;
            public bool Edited;

            public Seed2(long Start, long End, bool Edited)
            {
                this.Start = Start;
                this.End = End;
                this.Edited = Edited;
            }
        }
    }
}
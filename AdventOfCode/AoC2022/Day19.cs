using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day19
    {
        public static void Part1()
        {
            string input;
            List<Blueprint> blueprints = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                blueprints.Add(new Blueprint(int.Parse(split[1].Split(':')[0]), int.Parse(split[6]), int.Parse(split[12]), int.Parse(split[18]), int.Parse(split[21]), int.Parse(split[27]), int.Parse(split[30])));
            }

            int qualityLevel = 0;
            const int Time = 24;
            var rand = new Random();
            for (int i = 0; i < blueprints.Count; i++)
            {
                var curBlueprint = blueprints[i];

                var bestGeodes = 0;
                var count = 0;
                List<string> steps = new();

                while (true) 
                {
                    var oreRobots = 1;
                    var clayRobots = 0;
                    var obsidianRobots = 0;
                    var geodeRobots = 0;

                    var ore = 0;
                    var clay = 0;
                    var obsidian = 0;
                    var geodes = 0;

                    for (int t = 1; t <= Time; t++)
                    {
                        /*steps.Add($"=========== {t} =============\n" +
                            $"Start: \n" +
                            $"OreBot = {oreRobots}\n" +
                            $"ClayBot = {clayRobots}\n" +
                            $"ObsidianBot = {obsidianRobots}\n" +
                            $"GeodeBot = {geodeRobots}\n\n" +
                            $"Ore = {ore}\n" +
                            $"Clay = {clay}\n" +
                            $"Obsidian = {obsidian}\n" +
                            $"Geode = {geodes}\n");*/


                        ore += oreRobots;
                        clay += clayRobots;
                        obsidian += obsidianRobots;
                        geodes += geodeRobots;

                        if (ore - oreRobots >= curBlueprint.GeodeRobotCost.Ore && obsidian - obsidianRobots >= curBlueprint.GeodeRobotCost.Obsidian && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.GeodeRobotCost.Ore;
                            obsidian -= curBlueprint.GeodeRobotCost.Obsidian;
                            geodeRobots++;
                        }

                        else if (ore - oreRobots >= curBlueprint.ObsidianRobotCost.Ore && clay - clayRobots >= curBlueprint.ObsidianRobotCost.Clay && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.ObsidianRobotCost.Ore;
                            clay -= curBlueprint.ObsidianRobotCost.Clay;
                            obsidianRobots++;
                        }

                        else if (ore - oreRobots >= curBlueprint.ClayRobotCost && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.ClayRobotCost;
                            clayRobots++;
                        }

                        else if (ore - oreRobots >= curBlueprint.OreRobotCost && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.OreRobotCost;
                            oreRobots++;
                        }

                        /*Console.WriteLine($"\n" +
                            $"End: \n" +
                            $"Ore = {ore}\n" +
                            $"Clay = {clay}\n" +
                            $"Obsidian = {obsidian}\n" +
                            $"Geode = {geodes}\n");*/
                    }
                    if (geodes > bestGeodes)
                    {
                        bestGeodes = geodes;
                        /*for (int f = 0; f < steps.Count; f++)
                            Console.WriteLine(steps[f]);*/
                        count = 0;
                    }
                    else
                    {
                        count++;
                        //steps.Clear();
                    }

                    if (count > 10_000_000)
                        break;
                }
                Console.WriteLine($"Blueprint: {i}: Geodes: {bestGeodes}");
                qualityLevel += curBlueprint.Index * bestGeodes;
            }

            Console.WriteLine("\n Best Quality Level " + qualityLevel);
            Console.ReadLine();
        }

        public static void Part2()
        {
            string input;
            List<Blueprint> blueprints = new();
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                blueprints.Add(new Blueprint(int.Parse(split[1].Split(':')[0]), int.Parse(split[6]), int.Parse(split[12]), int.Parse(split[18]), int.Parse(split[21]), int.Parse(split[27]), int.Parse(split[30])));
            }

            int qualityLevel = 1;
            const int Time = 32;
            var rand = new Random();
            for (int i = 0; i < blueprints.Count; i++)
            {
                var curBlueprint = blueprints[i];

                var bestGeodes = 0;
                var count = 0;
                List<string> steps = new();

                while (true)
                {
                    var oreRobots = 1;
                    var clayRobots = 0;
                    var obsidianRobots = 0;
                    var geodeRobots = 0;

                    var ore = 0;
                    var clay = 0;
                    var obsidian = 0;
                    var geodes = 0;

                    for (int t = 1; t <= Time; t++)
                    {
                        /*steps.Add($"=========== {t} =============\n" +
                            $"Start: \n" +
                            $"OreBot = {oreRobots}\n" +
                            $"ClayBot = {clayRobots}\n" +
                            $"ObsidianBot = {obsidianRobots}\n" +
                            $"GeodeBot = {geodeRobots}\n\n" +
                            $"Ore = {ore}\n" +
                            $"Clay = {clay}\n" +
                            $"Obsidian = {obsidian}\n" +
                            $"Geode = {geodes}\n");*/


                        ore += oreRobots;
                        clay += clayRobots;
                        obsidian += obsidianRobots;
                        geodes += geodeRobots;

                        if (ore - oreRobots >= curBlueprint.GeodeRobotCost.Ore && obsidian - obsidianRobots >= curBlueprint.GeodeRobotCost.Obsidian && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.GeodeRobotCost.Ore;
                            obsidian -= curBlueprint.GeodeRobotCost.Obsidian;
                            geodeRobots++;
                        }

                        else if (ore - oreRobots >= curBlueprint.ObsidianRobotCost.Ore && clay - clayRobots >= curBlueprint.ObsidianRobotCost.Clay && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.ObsidianRobotCost.Ore;
                            clay -= curBlueprint.ObsidianRobotCost.Clay;
                            obsidianRobots++;
                        }

                        else if (ore - oreRobots >= curBlueprint.ClayRobotCost && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.ClayRobotCost;
                            clayRobots++;
                        }

                        else if (ore - oreRobots >= curBlueprint.OreRobotCost && rand.Next(0, 2) == 0)
                        {
                            ore -= curBlueprint.OreRobotCost;
                            oreRobots++;
                        }

                        /*Console.WriteLine($"\n" +
                            $"End: \n" +
                            $"Ore = {ore}\n" +
                            $"Clay = {clay}\n" +
                            $"Obsidian = {obsidian}\n" +
                            $"Geode = {geodes}\n");*/
                    }
                    if (geodes > bestGeodes)
                    {
                        bestGeodes = geodes;
                        /*for (int f = 0; f < steps.Count; f++)
                            Console.WriteLine(steps[f]);*/
                        count = 0;
                    }
                    else
                    {
                        count++;
                        //steps.Clear();
                    }

                    if (count > 25_000_000)
                        break;
                }
                Console.WriteLine($"Blueprint: {i}: Geodes: {bestGeodes}");
                qualityLevel *= bestGeodes;
            }

            Console.WriteLine("\n Best Quality Level " + qualityLevel);
            Console.ReadLine();
        }

        public struct Blueprint
        {
            public int Index;
            public int OreRobotCost;
            public int ClayRobotCost;
            public ObsidianCost ObsidianRobotCost;
            public GeodeCost GeodeRobotCost;

            public Blueprint(int Index, int Ore, int Clay, int ObsidianOre, int ObsidianClay, int GeodeOre, int GeodeObsidian)
            {
                this.Index = Index;
                this.OreRobotCost = Ore;
                this.ClayRobotCost = Clay;
                this.ObsidianRobotCost = new ObsidianCost(ObsidianOre, ObsidianClay);
                this.GeodeRobotCost = new GeodeCost(GeodeOre, GeodeObsidian);
            }
        }

        public struct ObsidianCost
        {
            public int Ore;
            public int Clay;

            public ObsidianCost(int Ore, int Clay)
            {
                this.Ore = Ore;
                this.Clay = Clay;
            }
        }

        public struct GeodeCost
        {
            public int Ore;
            public int Obsidian;

            public GeodeCost(int Orse, int Obsidian)
            {
                this.Ore = Orse;
                this.Obsidian = Obsidian;
            }
        }
    }
}
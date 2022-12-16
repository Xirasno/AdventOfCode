using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day16
    {
        public static List<Valve> Valves = new();
        public static void Part1()
        {
            string input;
            int time = 30;
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                var name = split[1];
                int flowRate = int.Parse(split[4].Split('=')[1][0..^1]);
                List<string> tunnels;
                try
                {
                    tunnels = input.Split("to valves ")[1].Split(", ").ToList();
                }
                catch
                {
                    tunnels = input.Split("to valve ")[1].Split(", ").ToList();
                }
                Valves.Add(new Valve(name, tunnels, flowRate));
            }

            foreach(var v in Valves)
                foreach(var v2 in Valves)
                    if (!v.Tunnels.ContainsKey(v2.Name))
                        v.Tunnels.Add(v2.Name, int.MaxValue);

            foreach(var v in Valves)
                v.CalcDist(Valves);

            var curValve = Valves.First(v => v.Name == "AA");
            int curPressure, bestPressure = 1869;// int.MinValue;
            string path = "AA";
            string times = "30";
            Random rand = new();
            int n = 0;
            while (true)
            {
                curValve = Valves.First(v => v.Name == "AA");
                path = "AA";
                times = "30";
                List<Valve> unvisitedValves = Valves.Where(v => v.Name != "AA").ToList();
                curPressure = 0;
                for (int i = 30; i > 0;)
                {
                    if (unvisitedValves.Select(v => i - (curValve.Tunnels[v.Name] + 1)).Where(t => t > 0).ToList().Count == 0)
                        break;
                    var option = unvisitedValves[rand.Next(0, unvisitedValves.Count)];
                    
                    i -= (curValve.Tunnels[option.Name] + 1);
                    if (i <= 0)
                        break;
                    curValve = option;
                    curPressure += i * curValve.FlowRate;
                    unvisitedValves.Remove(curValve);
                    path += " -> " + option.Name;
                    times += " -> " + i;
                    /*Console.WriteLine($"Moving to {option.Name}");
                    Console.WriteLine($"Opening {option.Name}, releasing {i} * {option.FlowRate} = {i * option.FlowRate} gas");
                    Console.WriteLine($"Total = {curPressure}");*/
                }
                n++;

                if (curPressure > bestPressure)
                {
                    Console.WriteLine($"\nCurrent path: {path}");
                    Console.WriteLine($"Current times: {times}");
                    Console.WriteLine($"Current pressure: {curPressure}");
                    bestPressure = curPressure;
                    n = 0;
                }
                if (n > 1 && n % 1_000_000 == 0)
                    Console.WriteLine(n);
                if (n == 50_000_000)
                    break;
            }

            Console.WriteLine("\n\n " + bestPressure);
            Console.ReadLine();
            Console.ReadLine();
        }

        /*public static void Part2()
        {
        }*/

        public class Valve
        {
            public string Name;
            public Dictionary<string, int> Tunnels;
            public int FlowRate;


            public Valve (string name, List<string> tunnels, int flowRate)
            {
                this.Name = name;
                this.Tunnels = tunnels.Select(t => new { id = t, dist = 1 }).ToDictionary(x => x.id, x => x.dist);
                this.FlowRate = flowRate;
            }

            public void CalcDist(List<Valve> valves)
            {                    
                    Dictionary<string, bool> spSet = new();
                    foreach (var v in valves)
                        spSet.Add(v.Name, false);

                    Tunnels[Name] = 0;

                    for (int i = 0; i < valves.Count; i++)
                    {
                        var u = Tunnels.OrderBy(v => v.Value).Where(valve => !spSet[valve.Key]).First();

                        spSet[u.Key] = true;

                        foreach (var valve in Tunnels)
                        {
                            if (!spSet[valve.Key] 
                                && valves.First(v => v.Name == u.Key).Tunnels[valve.Key] == 1
                                && Tunnels[u.Key] != int.MaxValue
                                && Tunnels[u.Key] + valves.First(v => v.Name == u.Key).Tunnels[valve.Key] < Tunnels[valve.Key])
                            Tunnels[valve.Key] = Tunnels[u.Key] + valves.First(v => v.Name == u.Key).Tunnels[valve.Key];
                        }
                    }
            }

            public Valve FindBestOption(List<Valve> valves, int time)
            {
                int score = -1;
                Valve curValve = this;
                Valve bestValve = this;
                foreach (var v in valves)
                {
                    var curScore = (time - curValve.Tunnels[v.Name] - 1) * v.FlowRate;
                    if (curScore > score)
                    {
                        score = curScore;
                        bestValve = v;
                    }
                }
                return bestValve;
            }

        }
    }
}
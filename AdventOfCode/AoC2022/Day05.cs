using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day05
    {
        private readonly static string[] stacks = new string[9] {
                "NSDCVQT",
                "MFV",
                "FQWDPNHM",
                "DQRTF",
                "RFMNQHVB",
                "CFGNPWQ",
                "WFRLCT",
                "TZNS",
                "MSDJRQHN" };

        // TestInput
        /*private readonly static string[] stacks = new string[3] {
            "ZN",
            "MCD",
            "P" };*/

        public static void Part1()
        {
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                int amnt = int.Parse(input.Split(' ')[1]);
                int from = int.Parse(input.Split(' ')[3]) - 1;
                int to   = int.Parse(input.Split(' ')[5]) - 1;
                for (int i = 0; i < amnt; i++)
                {
                    stacks[to] += stacks[from][^1];
                    stacks[from] = stacks[from].Remove(stacks[from].Length - 1);
                }
            }
            foreach(var c in stacks)
            {
                Console.Write(c.Last());
            }
        }

        public static void Part2()
        {
            string input, temp = "";
            while ((input = Console.ReadLine()) != "")
            {
                int amnt = int.Parse(input.Split(' ')[1]);
                int from = int.Parse(input.Split(' ')[3]) - 1;
                int to   = int.Parse(input.Split(' ')[5]) - 1;
                for (int i = 0; i < amnt; i++)
                {
                    temp += stacks[from][^1];
                    stacks[from] = stacks[from].Remove(stacks[from].Length - 1);
                }
                for (int i = 0; i < amnt; i++)
                {
                    stacks[to] += temp[^1];
                    temp = temp.Remove(temp.Length - 1);
                }
            }
            foreach(var c in stacks)
            {
                Console.Write(c.Last());
            }
        }
    }
}
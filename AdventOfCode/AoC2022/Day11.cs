using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day11
    {
        private static List<Monkey> Monkeys;
        public static void Part1()
        {
            string input;
            Monkeys = new();
            while ((input = Console.ReadLine()) != "")
            {
                int number = int.Parse(input[7].ToString());
                input = Console.ReadLine();
                var split = input.Split(' ');
                List<long> items = new();
                for (int i = 4; i < split.Length; i++)
                    items.Add(int.Parse(split[i].Split(',')[0].ToString()));
                Console.ReadLine(); 
                input = Console.ReadLine();
                split = input.Split(' ');
                var test = int.Parse(split[5].ToString());
                input = Console.ReadLine();
                int monkeyTrue; 
                split = input.Split(' ');
                monkeyTrue = int.Parse(split[9].ToString());
                input = Console.ReadLine();
                split = input.Split(' ');
                int monkeyFalse = int.Parse(split[9].ToString());
                Monkeys.Add(new Monkey(number, items, test, monkeyTrue, monkeyFalse));
                Console.ReadLine();
            }

            for (int i = 0; i < 20; i++)
                for (int j = 0; j < Monkeys.Count; j++)
                    Monkeys[j].InspectItems(Monkeys, false);

            var action = Monkeys.Select(m => m.action).OrderByDescending(a => a).ToList();
            Console.WriteLine(action[0] * action[1]);
        }

        public static void Part2()
        {
            string input;
            Monkeys = new();
            while ((input = Console.ReadLine()) != "")
            {
                int number = int.Parse(input[7].ToString());
                input = Console.ReadLine();
                var split = input.Split(' ');
                List<long> items = new();
                for (int i = 4; i < split.Length; i++)
                    items.Add(int.Parse(split[i].Split(',')[0].ToString()));
                Console.ReadLine();
                input = Console.ReadLine();
                split = input.Split(' ');
                var test = int.Parse(split[5].ToString());
                input = Console.ReadLine();
                int monkeyTrue;
                split = input.Split(' ');
                monkeyTrue = int.Parse(split[9].ToString());
                input = Console.ReadLine();
                split = input.Split(' ');
                int monkeyFalse = int.Parse(split[9].ToString());
                Monkeys.Add(new Monkey(number, items, test, monkeyTrue, monkeyFalse));
                Console.ReadLine();
            }

            var moduloSum = Monkeys.Select(m => m.test).Aggregate((m1, m2) => m1 * m2);
            for (int i = 0; i < 10_000; i++)
            {
                for (int j = 0; j < Monkeys.Count; j++)
                    Monkeys[j].InspectItems(Monkeys, true);
            }

            var action = Monkeys.Select(m => m.action).OrderByDescending(a => a).ToList();
            Console.WriteLine(action[0] * action[1]);
        }
    }

    public class Monkey
    {
        readonly int number;
        readonly List<long> items, toDelete;
        public int test, monkeyTrue, monkeyFalse;
        public long action;

        public Monkey(int number, List<long> items, int test, int monkeyTrue, int monkeyFalse)
        {
            this.number = number;
            this.items = items;
            this.test = test;
            this.monkeyTrue = monkeyTrue;
            this.monkeyFalse = monkeyFalse;
            this.toDelete = new();
            this.action = 0;
        }

        public void InspectItems(List<Monkey> monkeys, bool part2)
        {
            for (int i = 0; i < items.Count; i++)
            {
                action++;
                toDelete.Add(items[i]);
                var newItem = Operation(items[i]);
                if (!part2)
                    newItem /= 3;
                Test(monkeys, newItem);
            }
            Cleanup();
        }

        public void Cleanup()
        {
            foreach (var item in toDelete)
            {
                items.Remove(item);
            }
            toDelete.Clear();
        }

        public void Test(List<Monkey> monkeys, long item)
        {
            if (item % test == 0)
                monkeys[monkeyTrue].items.Add(item % 9699690); // TestInput: 96577
            else
                monkeys[monkeyFalse].items.Add(item % 9699690); // TestInput: 96577
        }

        public long Operation(long item)
        {
            long newItem = number switch
            {
                0 => item * 7,
                1 => item + 4,
                2 => item * 5,
                3 => item * item,
                4 => item + 1,
                5 => item + 8,
                6 => item + 2,
                7 => item + 5,
                _ => throw new Exception("Monkey does not exist")
            };

            return newItem;
        }

        public long Operation2(long item)
        {
            long newItem = number switch
            {
                0 => item * 19,
                1 => item + 6,
                2 => item * item,
                3 => item + 3,
                _ => throw new Exception("Monkey does not exist")
            };

            return newItem;
        }
    }
}
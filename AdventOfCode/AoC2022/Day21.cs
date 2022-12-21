using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day21
    {
        public static void Part1()
        {
            List<Monkey> Monkeys = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                var name = split[0][..^1];
                if (split.Length == 2)
                    Monkeys.Add(new Monkey(name, int.Parse(split[1])));
                else Monkeys.Add(new Monkey(name, split[1], split[3], split[2]));
            }

            var Root = Monkeys.First(m => m.Name == "root");

            Root.FindNumber(Monkeys);

            Console.WriteLine(Root.Number);
            Console.ReadLine();
        }

        public static void Part2()
        {
            List<Monkey> Monkeys = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                var split = input.Split(' ');
                var name = split[0][..^1];
                if (name == "humn")
                {
                    Monkeys.Add(new Monkey(name, null));
                    continue;
                }
                if (name == "root")
                {
                    Monkeys.Add(new Monkey(name, split[1], split[3], "="));
                    continue;
                }
                if (split.Length == 2)
                    Monkeys.Add(new Monkey(name, int.Parse(split[1])));
                else Monkeys.Add(new Monkey(name, split[1], split[3], split[2]));
            }
            var Root = Monkeys.First(m => m.Name == "root");
            var Human = Monkeys.First(m => m.Name == "humn");
            Console.WriteLine(Root.FindOperation(Monkeys));

            for (long i = 3509819803064; ; i++)
            {
                if (i % 10_000_000 == 0)
                    Console.WriteLine(i);
                var correct = (((702) + ((3) * ((73621039497353) - ((((2) * ((372) + ((((((52) * ((((667) + (((((((2) * ((122) + (((((8) + ((2) * ((((498) + ((((2) * ((((10) + ((32) * ((((((673) + ((9) * ((((((467) + (((((2) * ((364) + (((((((((477) + ((47) * ((65) + (((i) - (273)) / (2))))) * (2)) - (376)) / (8)) + (533)) / (4)) - (699)) * (12)))) - (625)) + (67)) / (2))) / (10)) - (828)) * (2)) - (712)))) / (7)) + (242)) / (9)) - (724)))) / (2)) - (23))) - (228)) / (3))) * (3)) - (150)))) / (4)) - (275)) / (9)))) - (116)) * (3)) + (314)) / (2)) + (427))) / (4)) - (704))) + (424)) * (2)) - (988)) / (4)))) - (423)) / (3))))) / (2)) == (49160133593649);
                if (correct)
                {
                    Console.WriteLine("Correct answer: " + i);
                    break;
                }
            }

            // Test input
            /*for (long i = 0; ; i++)
            {
                var correct = (((4) + ((2) * ((i) - (3)))) / (4)) == 150;
                if (correct)
                {
                    Console.WriteLine("Correct answer: " + i);
                    break;
                }
            }*/

             Console.ReadLine();
        }

        public class Monkey
        {
            public string Name;
            public long? Number;
            public string Monkey1;
            public string Monkey2;
            public string Operation;
            public bool Correct = false;

            public Monkey(string Name, int? Number)
            {
                this.Name = Name;
                this.Number = Number;
                this.Monkey1 = null;
                this.Monkey2 = null;
                this.Operation = null;
            }

            public Monkey(string Name, string Monkey1, string Monkey2, string Operation)
            {
                this.Name = Name;
                this.Monkey1 = Monkey1;
                this.Monkey2 = Monkey2;
                this.Operation = Operation;
                this.Number = null;
            }

            public long FindNumber(List<Monkey> monkeys)
            {
                if (Number != null)
                    return Number.Value;

                var monkey1Nr = monkeys.First(m => m.Name == this.Monkey1).FindNumber(monkeys);
                var monkey2Nr = monkeys.First(m => m.Name == this.Monkey2).FindNumber(monkeys);
                long result;
                switch (Operation)
                {
                    case "+":
                        result = monkey1Nr + monkey2Nr;
                        return result;
                    case "-":
                        result = monkey1Nr - monkey2Nr;
                        return result;
                    case "*":
                        result = monkey1Nr * monkey2Nr;
                        return result;
                    case "/":
                        result = monkey1Nr / monkey2Nr;
                        return result;
                    case "=":
                        Correct = monkey1Nr == monkey2Nr;
                        return 0;
                    default:
                        throw new ArgumentException($"Operator unknown: {this.Operation}; Monkey: {this.Name}");
                }
            }

            public string FindOperation(List<Monkey> monkeys)
            {
                string result = "";
                if (Name == "humn")
                    return "x";
                if (Number != null)
                    return Number.Value.ToString();

                var monkey1Nr = monkeys.First(m => m.Name == this.Monkey1).FindOperation(monkeys);
                var monkey2Nr = monkeys.First(m => m.Name == this.Monkey2).FindOperation(monkeys);
                if (long.TryParse(monkey1Nr, out long x) && long.TryParse(monkey2Nr, out long y))
                {
                    switch (Operation)
                    {
                        case "+":
                            result += x + y;
                            return result;
                        case "-":
                            result += x - y;
                            return result;
                        case "*":
                            result += x * y;
                            return result;
                        case "/":
                            result += x / y;
                            return result;
                        case "=":
                            result += monkey1Nr == monkey2Nr;
                            return result;
                        default:
                            throw new ArgumentException($"Operator unknown: {this.Operation}; Monkey: {this.Name}");
                    }
                }
                else
                {
                    switch (Operation)
                    {
                        case "+":
                            result += $"({monkey1Nr}) + ({monkey2Nr})";
                            return result;
                        case "-":
                            result += $"({monkey1Nr}) - ({monkey2Nr})";
                            return result;
                        case "*":
                            result += $"({monkey1Nr}) * ({monkey2Nr})";
                            return result;
                        case "/":
                            result += $"({monkey1Nr}) / ({monkey2Nr})";
                            return result;
                        case "=":
                            result += $"({monkey1Nr}) == ({monkey2Nr})";
                            return result;
                        default:
                            throw new ArgumentException($"Operator unknown: {this.Operation}; Monkey: {this.Name}");
                    }
                }
            }

            public long FindNumber(List<Monkey> monkeys, string lr)
            {
                if (Name == "humn")
                    Console.WriteLine(lr);
                if (Number != null)
                    return Number.Value;

                long monkey1Nr;
                long monkey2Nr;

                if (Name == "root")
                {
                    monkey1Nr = monkeys.First(m => m.Name == this.Monkey1).FindNumber(monkeys, "left");
                    monkey2Nr = monkeys.First(m => m.Name == this.Monkey2).FindNumber(monkeys, "right");                
                }

                monkey1Nr = monkeys.First(m => m.Name == this.Monkey1).FindNumber(monkeys, lr);
                monkey2Nr = monkeys.First(m => m.Name == this.Monkey2).FindNumber(monkeys, lr);

                long result;
                switch (Operation)
                {
                    case "+":
                        result = monkey1Nr + monkey2Nr;
                        this.Number = result;
                        return result;
                    case "-":
                        result = monkey1Nr - monkey2Nr;
                        this.Number = result;
                        return result;
                    case "*":
                        result = monkey1Nr * monkey2Nr;
                        this.Number = result;
                        return result;
                    case "/":
                        result = monkey1Nr / monkey2Nr;
                        this.Number = result;
                        return result;
                        
                    default:
                        throw new ArgumentException($"Operator unknown: {this.Operation}; Monkey: {this.Name}");
                }
            }
        }
    }
}
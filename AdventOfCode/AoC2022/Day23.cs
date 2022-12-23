using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day23
    {
        public static void Part1()
        {
            List<Elf> elves = new();
            string input;
            int j = 5;
            while ((input = Console.ReadLine()) != "")
            {
                for (int i = 0; i < input.Length; i++) 
                    if (input[i] == '#')
                        elves.Add(new Elf(i+5, j));
                j++;
            }

            var OrderOfOperations = new List<string>()
            {
                "North",
                "South",    
                "West",
                "East",
            };

            bool done = false;
            for (int t = 0; t < 10 && !done; t++)
            {
                done = true;
                foreach (var elf in elves)
                {
                    if (!elf.AdjacentElf(elves))
                        continue;
                    done = false;
                    for (int l = 0; l < OrderOfOperations.Count; l++)
                    {
                        if (elf.ValidMove(elves, OrderOfOperations[l], out var suggestedMove))
                        {
                            elf.suggestedMove = suggestedMove.Value;
                            break;
                        }
                    }
                }

                foreach (var elf in elves)
                {
                    if (elf.suggestedMove != null && elves.Where(e => e.suggestedMove == elf.suggestedMove).Count() == 1)
                    {
                        elf.X = elf.suggestedMove.Value.Item1;
                        elf.Y = elf.suggestedMove.Value.Item2;
                    }
                }

                foreach (var elf in elves)
                    elf.suggestedMove = null;
                OrderOfOperations.Add(OrderOfOperations.First());
                OrderOfOperations.RemoveAt(0);

                /*var minX2 = elves.Select(e => e.X).Min();
                var maxX2 = elves.Select(e => e.X).Max();
                var minY2 = elves.Select(e => e.Y).Min();
                var maxY2 = elves.Select(e => e.Y).Max();
                for (int y = minY2; y <= maxY2; y++)
                {
                    for (int x = minX2; x <= maxX2; x++)
                        if (!elves.Any(e => e.X == x && e.Y == y))
                            Console.Write(".");
                        else
                            Console.Write("#");
                    Console.WriteLine("");
                }
                Console.WriteLine();*/
            }
            var minX = elves.Select(e => e.X).Min();
            var maxX = elves.Select(e => e.X).Max();
            var minY = elves.Select(e => e.Y).Min();
            var maxY = elves.Select(e => e.Y).Max();
            var emptySpaces = 0;
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                    if (!elves.Any(e => e.X == x && e.Y == y))
                    {
                        emptySpaces++;
                        //Console.Write(".");
                    }
                    /*else 
                        Console.Write("#");
                Console.WriteLine();*/
            }
            Console.WriteLine($"Smallest rectangle: X: {minX}->{maxX}; Y: {minY}->{maxY}");
            Console.WriteLine(emptySpaces);
            Console.ReadLine();
        }

        public static void Part2()
        {
                List<Elf> elves = new();
                string input;
                int j = 5;
                while ((input = Console.ReadLine()) != "")
                {
                    for (int i = 0; i < input.Length; i++)
                        if (input[i] == '#')
                            elves.Add(new Elf(i + 5, j));
                    j++;
                }

                var OrderOfOperations = new List<string>()
            {
                "North",
                "South",
                "West",
                "East",
            };

                bool done = false;
                int t = 0;
                for (; !done; t++)
                {
                    if (t % 100 == 0)
                        Console.WriteLine(t);
                    done = true;
                    foreach (var elf in elves)
                    {
                        if (!elf.AdjacentElf(elves))
                            continue;
                        done = false;
                        for (int l = 0; l < OrderOfOperations.Count; l++)
                        {
                            if (elf.ValidMove(elves, OrderOfOperations[l], out var suggestedMove))
                            {
                                elf.suggestedMove = suggestedMove.Value;
                                break;
                            }
                        }
                    }

                    foreach (var elf in elves)
                    {
                        if (elf.suggestedMove != null && elves.Where(e => e.suggestedMove == elf.suggestedMove).Count() == 1)
                        {
                            elf.X = elf.suggestedMove.Value.Item1;
                            elf.Y = elf.suggestedMove.Value.Item2;
                        }
                    }

                    foreach (var elf in elves)
                        elf.suggestedMove = null;
                    OrderOfOperations.Add(OrderOfOperations.First());
                    OrderOfOperations.RemoveAt(0);

                    /*var minX2 = elves.Select(e => e.X).Min();
                    var maxX2 = elves.Select(e => e.X).Max();
                    var minY2 = elves.Select(e => e.Y).Min();
                    var maxY2 = elves.Select(e => e.Y).Max();
                    for (int y = minY2; y <= maxY2; y++)
                    {
                        for (int x = minX2; x <= maxX2; x++)
                            if (!elves.Any(e => e.X == x && e.Y == y))
                                Console.Write(".");
                            else
                                Console.Write("#");
                        Console.WriteLine("");
                    }
                    Console.WriteLine();*/
                }
                /*var minX = elves.Select(e => e.X).Min();
                var maxX = elves.Select(e => e.X).Max();
                var minY = elves.Select(e => e.Y).Min();
                var maxY = elves.Select(e => e.Y).Max();
                var emptySpaces = 0;
                for (int y = minY; y <= maxY; y++)
                {
                    for (int x = minX; x <= maxX; x++)
                        if (!elves.Any(e => e.X == x && e.Y == y))
                        {
                            emptySpaces++;
                            //Console.Write(".");
                        }
                    else 
                        Console.Write("#");
                Console.WriteLine();
                }
                Console.WriteLine($"Smallest rectangle: X: {minX}->{maxX}; Y: {minY}->{maxY}");*/
                Console.WriteLine(t);
                Console.ReadLine();
        }

        private static bool AdjacentElf(this Elf elf, List<Elf> elves)
        {
            for (int x = elf.X - 1; x <= elf.X + 1; x++)
                for (int y = elf.Y - 1; y <= elf.Y + 1; y++)
                {
                    if (x == elf.X && y == elf.Y)
                        continue;
                    if (elves.Any(e => e.X == x && e.Y == y))
                        return true;
                }
            return false;
        }

        private static bool ValidMove(this Elf elf, List<Elf> elves, string move, out (int, int)? suggestedMove)
        {
            suggestedMove = null;
            switch (move)
            {
                case "North":
                    if (!elves.Any(e => e.X == elf.X && e.Y == elf.Y - 1)
                    && !elves.Any(e => e.X == elf.X + 1 && e.Y == elf.Y - 1)
                    && !elves.Any(e => e.X == elf.X - 1 && e.Y == elf.Y - 1))
                    {
                        suggestedMove = (elf.X, elf.Y - 1);
                        return true;
                    }
                    break;
                case "South":
                    if (!elves.Any(e => e.X == elf.X && e.Y == elf.Y + 1)
                    && !elves.Any(e => e.X == elf.X + 1 && e.Y == elf.Y + 1)
                    && !elves.Any(e => e.X == elf.X - 1 && e.Y == elf.Y + 1))
                    {
                        suggestedMove = (elf.X, elf.Y + 1);
                        return true;
                    }
                    break;
                case "West":
                    if (!elves.Any(e => e.X == elf.X - 1 && e.Y == elf.Y - 1)
                    && !elves.Any(e => e.X == elf.X - 1 && e.Y == elf.Y)
                    && !elves.Any(e => e.X == elf.X - 1 && e.Y == elf.Y + 1))
                    {
                        suggestedMove = (elf.X - 1, elf.Y);
                        return true;
                    }
                    break;
                case "East":
                    if (!elves.Any(e => e.X == elf.X + 1 && e.Y == elf.Y - 1)
                    && !elves.Any(e => e.X == elf.X + 1 && e.Y == elf.Y)
                    && !elves.Any(e => e.X == elf.X + 1 && e.Y == elf.Y + 1))
                    {
                        suggestedMove = (elf.X + 1, elf.Y);
                        return true;
                    }
                    break;
            }
            return false;
        }

        public class Elf
        {
            public (int, int)? suggestedMove;
            public int X;
            public int Y;

            public Elf(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
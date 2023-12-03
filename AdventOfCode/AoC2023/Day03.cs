using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class AoC2023Day03
    {
        public static void Part1()
        {
            List<gridElement> gridElements = new();

            string input;
            int y = 0;
            while ((input = Console.ReadLine()) != "")
            {
                int x1 = -1;
                string value = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        if (x1 == -1)
                        {
                            x1 = i;
                        }
                        value += input[i];
                    }
                    else if (input[i] == '.')
                    {
                        if (x1 != -1)
                        {
                            gridElements.Add(new(x1, i - 1, y, false, value));
                            x1 = -1;
                            value = "";
                        }
                    }
                    else
                    {
                        if (x1 != -1)
                        {
                            gridElements.Add(new(x1, i - 1, y, false, value));
                            x1 = -1;
                            value = "";
                        }
                        gridElements.Add(new(i, i, y, true, input[i].ToString()));
                    }
                }
                if (x1 != -1)
                {
                    gridElements.Add(new(x1, input.Length - 1, y, false, value));
                    x1 = -1;
                    value = "";
                }
                y++;
            }

            int sum = 0;
            gridElements.ForEach(e =>
            {
                if (!e.symbol)
                {
                    var sublist = gridElements.Where(g =>
                        g.symbol
                        && (g.y >= e.y - 1 && g.y <= e.y + 1)
                        && (g.x1 >= e.x1 - 1 && g.x2 <= e.x2 + 1)).ToList();
                    if (sublist.Any())
                    {
                        sum += int.Parse(e.value);
                    }
                }
            });

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            List<gridElement> gridElements = new();

            string input;
            int y = 0;
            while ((input = Console.ReadLine()) != "")
            {
                int x1 = -1;
                string value = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        if (x1 == -1)
                        {
                            x1 = i;
                        }
                        value += input[i];
                    }
                    else if (input[i] == '.')
                    {
                        if (x1 != -1)
                        {
                            gridElements.Add(new(x1, i - 1, y, false, value));
                            x1 = -1;
                            value = "";
                        }
                    }
                    else
                    {
                        if (x1 != -1)
                        {
                            gridElements.Add(new(x1, i - 1, y, false, value));
                            x1 = -1;
                            value = "";
                        }
                        gridElements.Add(new(i, i, y, true, input[i].ToString()));
                    }
                }
                if (x1 != -1)
                {
                    gridElements.Add(new(x1, input.Length - 1, y, false, value));
                    x1 = -1;
                    value = "";
                }
                y++;
            }

            int sum = 0;
            gridElements.ForEach(e =>
            {
                if (e.value == "*")
                {
                    var sublist = gridElements.Where(g =>
                        !g.symbol
                        && (g.y >= e.y - 1 && g.y <= e.y + 1)
                        && (g.x2 >= e.x1 - 1 && g.x1 <= e.x1 + 1)).ToList();
                    if (sublist.Count == 2)
                    {
                        sum += int.Parse(sublist[0].value) * int.Parse(sublist[1].value);
                    }
                }
            });

            Console.WriteLine(sum);
        }
    }

    public struct gridElement
    {
        public int x1, x2, y;
        public bool symbol;
        public string value;

        public gridElement(int x1, int x2, int y, bool symbol, string value)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
            this.symbol = symbol;
            this.value = value;
        }
    }
}
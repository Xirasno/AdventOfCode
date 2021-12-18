using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day18
    {
        public static void Part1()
        {
            string input;
            SnailNumber snailNr = new SnailNumber(Console.ReadLine()[1..^1], null);
            while ((input = Console.ReadLine()) != "")
            {
                snailNr = new SnailNumber(snailNr, new SnailNumber(input[1..^1], null));
                //Console.WriteLine("-----------------START-----------------"); Console.WriteLine(snailNr.Write()); Console.WriteLine("----------------REDUCED-----------------");

                bool reduced = false;
                while (!reduced)
                {
                    snailNr.FixDepth();
                    reduced = snailNr.ReduceExplode();
                    if (!reduced)
                        continue;
                    reduced = snailNr.ReduceSplit();
                }
                //Console.WriteLine(snailNr.Write());
                //Console.WriteLine("-----------------END------------------");
            }
            Console.WriteLine(snailNr.Magnitude());
        }

        public static void Part2()
        {
            string input;
            List<SnailNumber> numbers = new();
            while ((input = Console.ReadLine()) != "")
            {
                numbers.Add(new SnailNumber(input[1..^1], null));
            }

            List<long> magnitudes = new();
            foreach (SnailNumber number1 in numbers)
            {
                //Console.WriteLine("-----------------NR.01-----------------"); 
                //Console.WriteLine(number1.Write());
                foreach (SnailNumber number2 in numbers)
                {
                    if (number1 == number2)
                        continue;
                    SnailNumber snailNr = new SnailNumber(new SnailNumber(number1.Write()[1..^1], null), new SnailNumber(number2.Write()[1..^1], null));
                    bool reduced = false;
                    while (!reduced)
                    {
                        snailNr.FixDepth();
                        reduced = snailNr.ReduceExplode();
                        if (!reduced)
                            continue;
                        reduced = snailNr.ReduceSplit();
                    }
                    long magnitude = snailNr.Magnitude();
                    /*Console.WriteLine("-----------------NR.02-----------------"); 
                    Console.WriteLine(number2.Write());
                    Console.WriteLine("----------------REDUCED-----------------");
                    Console.WriteLine(snailNr.Write());
                    Console.WriteLine("---------------MAGNITUDE----------------");
                    Console.WriteLine(magnitude);*/
                    magnitudes.Add(magnitude);
                }
            }
            Console.WriteLine(magnitudes.Max());
        }
    }

    public class SnailNumber
    {
        SnailNumber x, y, parent;
        int value = -1;
        int depth;

        public SnailNumber(SnailNumber x, SnailNumber y)
        {
            x.parent = this;
            y.parent = this;
            this.x = x;
            this.y = y;
        }

        public SnailNumber(string s, SnailNumber parent)
        {
            this.parent = parent;
            this.depth = this.parent != null ? parent.depth : 0;
            if (s.Length == 1)
            {
                this.value = int.Parse(s);
                return;
            }

            if (s.Length == 3)
            {
                this.x = new SnailNumber(s[0].ToString(), this);
                this.y = new SnailNumber(s[2].ToString(), this);
                return;
            }

            string newS1 = "", newS2 = "";
            int braces = 0, i = 0;
            for(; i < s.Length; i++)
            {
                newS1 += s[i];
                if (s[i] == '[')
                    braces++;
                if (s[i] == ']')
                    braces--;
                if (braces == 0)
                {
                    i += 2;
                    break;
                }
            }
            for (; i < s.Length; i++)
            {
                newS2 += s[i];
                if (s[i] == '[')
                    braces++;
                if (s[i] == ']')
                    braces--;
                if (braces == 0)
                    break;
            }

            newS1 = newS1.Length > 1 ? newS1[1..^1] : newS1;
            newS2 = newS2.Length > 1 ? newS2[1..^1] : newS2;

            this.x = new SnailNumber(newS1, this);
            this.y = new SnailNumber(newS2, this);
           
        }

        public SnailNumber(int value, SnailNumber parent)
        {
            this.value = value;
            this.parent = parent;
            this.depth = this.parent != null ? parent.depth : 0;
        }

        public void FixDepth()
        {
            if (this.parent == null)
                this.depth = 0;
            else
                this.depth = parent.depth + 1;

            if (x != null) x.FixDepth();
            if (y != null) y.FixDepth();
        }

        public bool ReduceExplode()
        {
            if (this.x != null && this.y != null)
            {
                if (depth >= 4 && this.x.value != -1 && this.y.value != -1)
                {
                    parent = parent.Explode(this);
                    this.x = null;
                    this.y = null;
                    this.value = 0;
                    return false;
                }
                else
                {
                    bool reduced = this.x.ReduceExplode();
                    if (!reduced)
                        return false;
                    return this.y.ReduceExplode();
                }
            }
            return true;
        }

        public bool ReduceSplit()
        {
            if (this.x != null && this.y != null)
            {
                bool reduced = this.x.ReduceSplit();
                if (!reduced)
                    return false;
                return this.y.ReduceSplit();
            }
                if (value >= 10)
            {
                this.x = new SnailNumber(value / 2, this);
                this.y = new SnailNumber(value % 2 == 0 ? value / 2 : (value / 2) + 1, this);
                value = -1;
                return false;
            }
            return true;
        }

        public SnailNumber Explode(SnailNumber s)
        {
            if (s == x)
            {
                y.Add(this.x.y.value, s, 0);
                if (this.parent.x != null)
                    this.parent.x.Add(s.x.value, s, 1);
                x = new SnailNumber(0, this);
            }
            else if (s == y)
            {
                x.Add(this.y.x.value, s, 1);
                if (this.parent.y != null)
                    this.parent.y.Add(s.y.value, s, 0);
            }
            return this;
        }

        public void Add(int v, SnailNumber s, int lr)
        {
            if (x == null && y == null)
            {
                value += v;
            }
            else if (lr == 1)
            {
                if (this.x == s)
                    try { this.parent.parent.x.Add(v, this, lr); } catch { }
                else y.Add(v, this, 1);
            }
            else
            {
                if (this.y == s)
                    try { this.parent.parent.y.Add(v, this, lr); } catch { }
                else x.Add(v, this, 0);
            }
        }

        public long Magnitude()
        {
            if (x == null && y == null)
                return value;
            else 
                return (3 * x.Magnitude()) + (2 * y.Magnitude());
        }

        public string Write()
        {
            if (x != null && y != null)
                return $"[{x.Write()},{y.Write()}]";
            else return this.value.ToString();
        }
    }
}

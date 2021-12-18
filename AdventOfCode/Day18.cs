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
            while ((input = Console.ReadLine()) != "")
            {
                SnailNumber sn = new SnailNumber(input[1..^1], 1, null);
                bool reduced = false;
                while (!reduced)
                {
                    sn.Reduce();
                }
                Console.WriteLine(sn.ToString());
            }

        }

        /*public static void Part2()
        {

        }*/
    }

    public class SnailNumber
    {
        SnailNumber x, y, parent;
        int value = -1;
        int depth;

        public SnailNumber(string s, int depth, SnailNumber parent)
        {
            this.depth = depth;
            this.parent = parent;
            if (s.Length == 1)
            {
                this.depth--;
                this.value = int.Parse(s);
                return;
            }

            if (s.Length == 3)
            {
                this.x = new SnailNumber(s[0].ToString(), depth, this);
                this.y = new SnailNumber(s[2].ToString(), depth, this);
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

            this.x = new SnailNumber(newS1, depth + 1, this);
            this.y = new SnailNumber(newS2, depth + 1, this);
           
        }

        public SnailNumber(int value, int depth, SnailNumber parent)
        {
            this.value = value;
            this.depth = depth;
            this.parent = parent;
        }

        public bool Reduce()
        {
            if (this.x != null && this.y != null)
            {
                if (depth == 4)
                {
                    parent.Explode(this);
                    return false;
                }
                else
                {
                    this.x.Reduce();
                    this.y.Reduce();
                    return false;
                }
            }
            else if (value >= 10)
            {
                this.x = new SnailNumber(value / 2, depth, this);
                this.y = new SnailNumber(value % 2 == 0 ? value / 2 : (value / 2) + 1, depth, this);
                return false;
            }
            return true;
        }

        public void Explode(SnailNumber s)
        {
            if (s == x)
            {
                y.Add(s.y.value, 0);
                try { this.parent.parent.x.Add(s.x.value, 1); } catch { }
            }
            else if (s == y)
            {
                x.Add(s.x.value, 1);
                try { this.parent.parent.y.Add(s.x.value, 1); } catch { }
            }
        }

        public void Add(int v, int lr)
        {
            if (x == null && y == null)
                value += v;
            else if (lr == 0)
             x.Add(v, lr);
            else y.Add(v, lr);
        }
    }
}

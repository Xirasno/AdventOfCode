using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day08
    {
        public static void Part1()
        {
            List<string> numbers = new();
            string input;
            int count = 0;
            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(" | ");

                numbers = numbers.Concat(splitInput[1].Split(' ')).ToList();
            }

            count += numbers.Count(n => n.Length == 2);
            count += numbers.Count(n => n.Length == 4);
            count += numbers.Count(n => n.Length == 3);
            count += numbers.Count(n => n.Length == 7);
            Console.WriteLine(count);
        }

        public static void Part2()
        {
            List<(string[], string[])> numbers = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(" | ");
                numbers.Add((splitInput[0].Split(' '), splitInput[1].Split(' ')));
            }

            int count = 0;
            string zero, one, two, three, four, five, six, seven, eight, nine;
            string a, b, c, d, e, f, g;

            foreach ((string[] nrs, string[] digits) in numbers)
            {
                one = nrs.First(s => s.Length == 2);
                four = nrs.First(s => s.Length == 4);
                six = nrs.First(s => s.Length == 6 && !one.All(o => s.Contains(o)));
                seven = nrs.First(s => s.Length == 3);
                eight = nrs.First(s => s.Length == 7);
                nine = nrs.First(s => s.Length == 6 && four.All(f => s.Contains(f)));
                zero = nrs.First(s => s.Length == 6 && s != nine && s != six);

                c = (six.Contains(one[0]) ? one[1] : one[0]).ToString();
                f = one.Difference(c);
                three = nrs.First(s => s.Length == 5 && s.Contains(one[0]) && s.Contains(one[1]));
                two = nrs.First(s => s.Length == 5 && s.Contains(c) && !s.Contains(f));
                five = nrs.First(s => s.Length == 5 && s != three && s != two);

                a = seven.Difference(one);
                b = eight.Difference(two).Difference(f);
                d = eight.Difference(zero);
                e = eight.Difference(nine);
                g = "abcdefg".Difference(a+b+c+d+e+f);

                int number = 0;
                for(int i = 0; i < digits.Length; i++)
                {
                    if (!digits[i].Contains(a) && !digits[i].Contains(b) && digits[i].Contains(c) && !digits[i].Contains(d) && !digits[i].Contains(e) && digits[i].Contains(f) && !digits[i].Contains(g))
                        number += int.Parse("1" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && !digits[i].Contains(b) && digits[i].Contains(c) && digits[i].Contains(d) && digits[i].Contains(e) && !digits[i].Contains(f) && digits[i].Contains(g))
                        number += int.Parse("2" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && !digits[i].Contains(b) && digits[i].Contains(c) && digits[i].Contains(d) && !digits[i].Contains(e) && digits[i].Contains(f) && digits[i].Contains(g))
                        number += int.Parse("3" + new string('0', 3 - i));

                    else if (!digits[i].Contains(a) && digits[i].Contains(b) && digits[i].Contains(c) && digits[i].Contains(d) && !digits[i].Contains(e) && digits[i].Contains(f) && !digits[i].Contains(g))
                        number += int.Parse("4" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && digits[i].Contains(b) && !digits[i].Contains(c) && digits[i].Contains(d) && !digits[i].Contains(e) && digits[i].Contains(f) && digits[i].Contains(g))
                        number += int.Parse("5" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && digits[i].Contains(b) && !digits[i].Contains(c) && digits[i].Contains(d) && digits[i].Contains(e) && digits[i].Contains(f) && digits[i].Contains(g))
                        number += int.Parse("6" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && !digits[i].Contains(b) && digits[i].Contains(c) && !digits[i].Contains(d) && !digits[i].Contains(e) && digits[i].Contains(f) && !digits[i].Contains(g))
                        number += int.Parse("7" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && digits[i].Contains(b) && digits[i].Contains(c) && digits[i].Contains(d) && digits[i].Contains(e) && digits[i].Contains(f) && digits[i].Contains(g))
                        number += int.Parse("8" + new string('0', 3 - i));

                    else if (digits[i].Contains(a) && digits[i].Contains(b) && digits[i].Contains(c) && digits[i].Contains(d) && !digits[i].Contains(e) && digits[i].Contains(f) && digits[i].Contains(g))
                        number += int.Parse("9" + new string('0', 3 - i));
                }
                count += number;
            }

            Console.WriteLine(count);
        }

        private static string Difference(this string s1, string s2)
        {
            string result = "";
            foreach(char c in s1)
            {
                if (!s2.Contains(c))
                    result += c.ToString();
            }
            return result;
        }
    }
}
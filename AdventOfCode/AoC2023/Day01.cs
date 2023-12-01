using System;
using System.Collections.Generic;

namespace AdventOfCode.AoC2023
{
    public static class AoC2023Day01
    {
        public static void Part1()
        {
            string input;
            List<string> digits = new();
            while ((input = Console.ReadLine()) != "")
            {
                string newDigit = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (int.TryParse(input[i].ToString(), out _))
                    {
                        newDigit += input[i];
                    }
                }

                if (newDigit.Length > 2)
                {
                    newDigit = newDigit[0].ToString() + newDigit[^1].ToString();
                }
                if (newDigit.Length == 1)
                {
                    newDigit += newDigit;
                }
                digits.Add(newDigit);
            }
            int total = 0;
            foreach (string digit in digits)
            {
                total += int.Parse(digit);
            }
            Console.WriteLine(total);
        }

        public static void Part2()
        {
            string input;
            List<string> digits = new();
            while ((input = Console.ReadLine()) != "")
            {
                string newDigit = "";
                input = input.Replace("one", "one1one");
                input = input.Replace("two", "two2two");
                input = input.Replace("three", "three3three");
                input = input.Replace("four", "four4four");
                input = input.Replace("five", "five5five");
                input = input.Replace("six", "six6six");
                input = input.Replace("seven", "seven7seven");
                input = input.Replace("eight", "eight8eight");
                input = input.Replace("nine", "nine9nine");

                for (int i = 0; i < input.Length; i++)
                {
                    if (int.TryParse(input[i].ToString(), out _))
                    {
                        newDigit += input[i];
                    }
                }

                if (newDigit.Length > 2)
                {
                    newDigit = newDigit[0].ToString() + newDigit[^1].ToString();
                }
                if (newDigit.Length == 1)
                {
                    newDigit += newDigit;
                }
                digits.Add(newDigit);
            }
            int total = 0;
            foreach (string digit in digits)
            {
                total += int.Parse(digit);
            }
            Console.WriteLine(total);
        }
    }
}

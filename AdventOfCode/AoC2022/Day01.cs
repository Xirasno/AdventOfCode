using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day01
    {
        public static void Part1()
        {
            Console.WriteLine(CalcCalories().Max());
        }

        public static void Part2()
        {
            Console.WriteLine(CalcCalories().OrderByDescending(n => n).Take(3).Sum());
        }

        public static List<int> CalcCalories()
        {
            List<int> calories = new();
            string input;
            int calorie = 0;
            while ((input = Console.ReadLine()) != ".")
            {
                if (input != "")
                    calorie += Convert.ToInt32(input);
                else
                    calories.Add(calorie.Reset());
            }
            return calories;
        }

        public static int Reset(this ref int i)
        {
            var old = i;
            i = 0;
            return old;
        }

        /* The version where I don't have to end with a "."
        public static List<int> calcCalories()
        {
            List<int> calories = new();
            string input = Console.ReadLine();
            int calorie = 0;
            do
            {
                do
                    calorie += Convert.ToInt32(input);
                while ((input = Console.ReadLine()) != "");
                calories.Add(calorie.Reset());
            }
            while ((input = Console.ReadLine()) != "");
            return calories;
        }
         */
    }
}

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
            List<int> calories = new();
            string input = Console.ReadLine();
            int calorie = 0;
            do
            {
                do
                    calorie += Convert.ToInt32(input);
                while ((input = Console.ReadLine()) != "");

                calories.Add(calorie);
                calorie = 0;

            }
            while ((input = Console.ReadLine()) != "");
            Console.WriteLine(calories.Max());
        }

        public static void Part2()
        {
            List<int> calories = new();
            string input = Console.ReadLine();
            int calorie = 0;
            do
            {
                do
                    calorie += Convert.ToInt32(input);
                while ((input = Console.ReadLine()) != "");

                calories.Add(calorie);
                calorie = 0;

            }
            while ((input = Console.ReadLine()) != "");
            var newCalories = calories.OrderByDescending(n => n).ToArray();
            Console.WriteLine(newCalories[0]+ newCalories[1]+ newCalories[2]);
        }
    }
}

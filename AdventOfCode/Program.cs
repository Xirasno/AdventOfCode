using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "11":
                    Day1.Part1();
                    break;

                case "12":
                    Day1.Part2();
                    break;

                case "21":
                    Day2.Part1();
                    break;
                case "22":
                    Day2.Part2();
                    break;

                case "31":
                    Day3.Part1();
                    break;

                case "32":
                    Day3.Part2();
                    break;

                default:
                    break;
            }
        }
    }
}

#region DayTemplate 
/*
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class DayX
    {
        public static void Part1()
        {

        }

        public static void Part2()
        {

        }
    }
}
 */
#endregion

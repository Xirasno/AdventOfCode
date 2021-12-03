using System;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input.Length != 2)
            {
                input = Console.ReadLine();
            }
            var assembly = Assembly.LoadFrom("./AdventOfCode.dll");
            var type = assembly.GetType($"AdventOfCode.Day{input[0]}");
            type.GetMethod($"Part{input[1]}").Invoke(null, null);
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

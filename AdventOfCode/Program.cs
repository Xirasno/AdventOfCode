using System;
using System.Reflection;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitInput = input.Split(' ');
            var assembly = Assembly.LoadFrom("./AdventOfCode.dll");

            if (splitInput.Length == 2)
            {
                var type = assembly.GetType($"AdventOfCode.Day{splitInput[0]}");
                type.GetMethod($"Part{splitInput[1]}").Invoke(null, null);
            }
            else
            {
                var type = assembly.DefinedTypes.Where(t => t.Name.StartsWith("Day")).Last();
                type.DeclaredMethods.Last().Invoke(null, new[] { input });
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
        public static void Part1(string firstLine = "")
        {

        }

        public static void Part2(string firstLine = "")
        {

        }
    }
}
 */
#endregion

using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("./AdventOfCode.dll");
            TypeInfo type = assembly.DefinedTypes
                .Where(t => t.Name.ToUpper().StartsWith("AOC"))
                .OrderByDescending(t => t.Name)
                .FirstOrDefault();
            _ = type.DeclaredMethods
                .Where(t => t.Name.ToUpper().StartsWith("PART"))
                .OrderByDescending(m => m.Name.Last())
                .FirstOrDefault()
                .Invoke(null, null);
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
    public static class AoC2023DayX
    {
        public static void Part1()
        {
            string input;
            while ((input = Console.ReadLine()) != "")
            {

            }
            Console.WriteLine(input);
        }

        /*public static void Part2()
        {

        }
    }
}
 */
#endregion

using System;
using System.Reflection;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            var assembly = Assembly.LoadFrom("./AdventOfCode.dll");

            if (input.Length == 2)
            {
                var type = assembly.GetType($"AdventOfCode.Day{input[0]}");
                type.GetMethod($"Part{input[1]}").Invoke(null, null);
            }
            else
            {
                var type = assembly.DefinedTypes.Where(t => t.Name.StartsWith("Day")).Last();
                type.DeclaredMethods.Last().Invoke(null, null);
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

using System;
using System.Reflection;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom("./AdventOfCode.dll");
            TypeInfo type = assembly.DefinedTypes
                .Where(t => t.Name.ToUpper().StartsWith("AOC"))
                .OrderByDescending(t => t.Name)
                .FirstOrDefault();
            type.DeclaredMethods
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
    public static class AoC2022DayX
    {
        public static void Part1()
        {

        }

        /*public static void Part2()
        {

        }
    }
}
 */
#endregion

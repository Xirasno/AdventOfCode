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
                .Where(t => t.Name.StartsWith("Day"))
                .OrderByDescending(t => t.Name.Remove(0, 3))
                .FirstOrDefault();
            type.DeclaredMethods
                .Where(t => t.Name.StartsWith("Part"))
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

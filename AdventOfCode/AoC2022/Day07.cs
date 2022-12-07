using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2022Day17
    {
        public static void Part1()
        {
            string input;
            Directory curDir = new Directory(null, "/");
            List<Directory> dirs = new() { curDir };
            while ((input = Console.ReadLine()) != "")
            {
                var splitInput = input.Split(' ');
                if (splitInput[0] == "$" && splitInput[1] == "cd")
                {
                    switch (splitInput[2])
                    {
                        case "/":
                            curDir = dirs.FirstOrDefault(curDir => curDir.Name == "/");
                            break;
                        case "..":
                            curDir = curDir.Parent;
                            break;
                        default:
                            curDir = new Directory(curDir, splitInput[2]);
                            dirs.Add(curDir);
                        break;
                    }
                }
                else if (int.TryParse(splitInput[0], out var size))
                    curDir.AddSize(size);
            }
            long totalSize = 0;
            
            foreach (var dir in dirs.Where(d => d.Size <= 100_000))
            {
                totalSize += dir.Size;
            }
            Console.WriteLine(totalSize);
        }

        public static void Part2()
        {
            string input;
            Directory curDir = new Directory(null, "/");
            List<Directory> dirs = new() { curDir };
            while ((input = Console.ReadLine()) != "")
            {
                var splitInput = input.Split(' ');
                if (splitInput[0] == "$" && splitInput[1] == "cd")
                {
                    switch (splitInput[2])
                    {
                        case "/":
                            curDir = dirs.FirstOrDefault(curDir => curDir.Name == "/");
                            break;
                        case "..":
                            curDir = curDir.Parent;
                            break;
                        default:
                            curDir = new Directory(curDir, splitInput[2]);
                            dirs.Add(curDir);
                            break;
                    }
                }
                else if (int.TryParse(splitInput[0], out var size))
                    curDir.AddSize(size);
            }
            long totalSize = dirs.FirstOrDefault(curDir => curDir.Name == "/").Size;
            Console.WriteLine(dirs.Where(d => (70_000_000 - totalSize) + d.Size >= 30_000_000).OrderBy(d => d.Size).FirstOrDefault().Size);
        }

        private class Directory
        {
            private long size;
            public long Size { get { return size; } }
            public string Name;
            public Directory Parent;
            
            public Directory(Directory parent, string name)
            {
                this.Name = name;
                this.Parent = parent;
            }

            public void AddSize(int size)
            {
                this.size += size;
                if (Parent != null)
                    this.Parent.AddSize(size);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode
{
    public static class AoC2022Day20
    {
        public static void Part1()
        {
            string input;
            List<Number> numbers = new();
            int index = 0;
            while ((input = Console.ReadLine()) != "")
            {
                numbers.Add(new Number(index, int.Parse(input)));
                index++;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].Value == 0)
                    continue;
                var oldIndex = numbers[i].Index;
                long newIndex = numbers[i].Index + numbers[i].Value;

                while (newIndex <= 0)
                    newIndex += index - 1;

                while (newIndex > index)
                    newIndex -= (index - 1);

                if (newIndex > oldIndex)
                    numbers = numbers.Select(n => (n.Index > oldIndex && n.Index <= newIndex) ? new Number(n.Index - 1, n.Value) : new Number(n.Index, n.Value)).ToList();
                else
                    numbers = numbers.Select(n => (n.Index >= newIndex && n.Index < oldIndex) ? new Number(n.Index + 1, n.Value) : new Number(n.Index, n.Value)).ToList();

                numbers[i].Index = (int)newIndex;
                /*var sorted = numbers.OrderBy(n => n.Index).ToList();
                if (sorted.Select(n => n.Index).Distinct().Count() != index)
                {
                    foreach (var n in numbers.OrderBy(n => n.Index))
                        Console.Write($"{n.Value}, ");
                    Console.WriteLine("\n");
                }*/
            }
            numbers = numbers.OrderBy(n => n.Index).ToList();
                foreach(var n in numbers.OrderBy(n => n.Index))
                    Console.Write($"{n.Value}, ");
                Console.WriteLine();
            numbers = numbers.OrderBy(n => n.Index).ToList();
                foreach(var n in numbers.OrderBy(n => n.Index))
                    Console.Write($"{n.Index}, ");
                Console.WriteLine();

            long sum = 0;
            var nextIndex = numbers.FindIndex(n => n.Value == 0);
            for(int i = 0; i < 3; i++)
            {
                for (int n = 0; n < 1000; n++)
                {
                    nextIndex++;
                    if (nextIndex == numbers.Count)
                        nextIndex = 0;
                }
                sum += numbers[nextIndex].Value;

            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }

        public static void Part2()
        {
            const long DecryptionKey = 811589153;
            string input;
            List<Number> numbers = new();
            int index = 0;
            while ((input = Console.ReadLine()) != "")
            {
                numbers.Add(new Number(index, int.Parse(input) * DecryptionKey));
                index++;
            }

            for (int t = 0; t < 10; t++)
            {
                Console.WriteLine("New loop: " + t);
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i].Value == 0)
                        continue;
                    var oldIndex = numbers[i].Index;
                    long newIndex = numbers[i].Index + numbers[i].Value;

                    if (newIndex <= 0)
                        newIndex += ((index - 1) * ((newIndex * -1) / (index - 1) + 1));

                    if (newIndex >= index)
                        newIndex -= ((index - 1) * (newIndex / (index - 1)));

                    if (newIndex > oldIndex)
                        numbers = numbers.Select(n => (n.Index > oldIndex && n.Index <= newIndex) ? new Number(n.Index - 1, n.Value) : new Number(n.Index, n.Value)).ToList();
                    else
                        numbers = numbers.Select(n => (n.Index >= newIndex && n.Index < oldIndex) ? new Number(n.Index + 1, n.Value) : new Number(n.Index, n.Value)).ToList();

                    numbers[i].Index = (int)newIndex;
                }
            }
            numbers = numbers.OrderBy(n => n.Index).ToList();

            long sum = 0;
            var nextIndex = numbers.FindIndex(n => n.Value == 0);
            for (int i = 0; i < 3; i++)
            {
                for (int n = 0; n < 1000; n++)
                {
                    nextIndex++;
                    if (nextIndex == numbers.Count)
                        nextIndex = 0;
                }
                sum += numbers[nextIndex].Value;

            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }

        public class Number
        {
            public int Index;
            public long Value;

            public Number(int Index, long Value)
            {
                this.Index = Index;
                this.Value = Value;
            }
        }
    }
}
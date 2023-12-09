using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class AoC2023Day09
    {
        public static void Part1()
        {
            List<List<int>> sequences = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                sequences.Add(input.Split(' ').Select(m => int.Parse(m)).ToList());
            }

            long sum = 0, n = 0;
            foreach (var sequence in sequences)
            {
                List<int> sequenceSums = new() { sequence[^1] };
                List<int> sequenceSum = new(sequence), newSequenceSum = new(sequence);

                while (newSequenceSum.Any(m => m != 0))
                {
                    sequenceSum = new(newSequenceSum);
                    newSequenceSum.Clear();

                    if (sequenceSum.Count == 1)
                    {
                        newSequenceSum.Add(0);
                    }

                    for (int i = 0; i < sequenceSum.Count - 1; i++)
                    {
                        newSequenceSum.Add(sequenceSum[i + 1] - sequenceSum[i]);
                    }
                    sequenceSums.Add(newSequenceSum[^1]);
                }

                sum += sequenceSums.Sum();
                n++;
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            List<List<int>> sequences = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                sequences.Add(input.Split(' ').Select(m => int.Parse(m)).ToList());
            }

            long sum = 0, n = 0;
            foreach (var sequence in sequences)
            {
                List<int> sequenceSums = new() { sequence[0] };
                List<int> sequenceSum = new(sequence), newSequenceSum = new(sequence);

                while (newSequenceSum.Any(m => m != 0))
                {
                    sequenceSum = new(newSequenceSum);
                    newSequenceSum.Clear();

                    if (sequenceSum.Count == 1)
                    {
                        newSequenceSum.Add(0);
                    }

                    for (int i = 0; i < sequenceSum.Count - 1; i++)
                    {
                        newSequenceSum.Add(sequenceSum[i + 1] - sequenceSum[i]);
                    }
                    sequenceSums.Add(newSequenceSum[0]);
                }

                long prev = 0;
                for (int i = sequenceSums.Count - 1; i > 0; i--)
                {
                    prev = sequenceSums[i - 1] - prev;
                }
                sum += prev;
            }

            Console.WriteLine(sum);
        }
    }
}
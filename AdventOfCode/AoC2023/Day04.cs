using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode
{
    public static class AoC2023Day04
    {
        public static void Part1()
        {
            string input;
            List<int> myNumbers = new(), winningNumbers = new();
            Regex nrs = new(@"\d+");
            int sum = 0;
            while ((input = Console.ReadLine()) != "")
            {
                int score = 0;
                string[] splitInput = input.Split('|');
                winningNumbers = nrs.Matches(splitInput[1]).Select(m => int.Parse(m.Value)).ToList();
                myNumbers = nrs.Matches(splitInput[0].Split(": ")[1]).Select(m => int.Parse(m.Value)).ToList();

                myNumbers.ForEach(n =>
                {
                    if (winningNumbers.Contains(n))
                    {
                        if (score == 0)
                            score = 1;
                        else 
                        score <<= 1;
                    }
                });
                sum += score;
            }

            Console.WriteLine(sum);
        }

        public static void Part2()
        {
            string input;
            List<int> myNumbers = new(), winningNumbers = new();
            Regex nrs = new(@"\d+");
            int sum = 0;
            List<ScratchCard> scratchCards= new();
            while ((input = Console.ReadLine()) != "")
            {
                scratchCards.Add(new(input, 1));
            }
            for (int i = 0; i < scratchCards.Count; i++)
            {
                int score = 0;
                string[] splitInput = scratchCards[i].Card.Split('|');
                winningNumbers = nrs.Matches(splitInput[1]).Select(m => int.Parse(m.Value)).ToList();
                myNumbers = nrs.Matches(splitInput[0].Split(": ")[1]).Select(m => int.Parse(m.Value)).ToList();

                myNumbers.ForEach(n =>
                {
                    if (winningNumbers.Contains(n))
                    {
                        score++;
                    }
                });
                for (int n = 1; n <= score; n++)
                {
                    scratchCards[i + n] = new (scratchCards[i + n].Card, scratchCards[i + n].Count + scratchCards[i].Count);
                }
            }

            Console.WriteLine(scratchCards.Sum(c => c.Count));
        }

        public struct ScratchCard
        {
            public string Card;
            public int Count;

            public ScratchCard(string card, int count)
            {
                Card = card;
                Count = count;
            }
        }
    }
}
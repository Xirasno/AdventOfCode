using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.AoC2023
{
    public static class AoC2023Day02
    {
        public static void Part1()
        {
            string input;
            int possibleGamesCount = 0;
            int gameId = 1;

            int maxRed = 12, maxGreen = 13, maxBlue = 14;
            Regex redRx = new(@"\d+ red"), greenRx = new(@"\d+ green"), blueRx = new(@"\d+ blue");

            while ((input = Console.ReadLine()) != "")
            {
                bool possible = true;
                string game = input.Split(": ")[1];
                string[] games = game.Split("; ");
                for (int i = 0; i < games.Length; i++)
                {
                    string red = redRx.Match(games[i]).Value;
                    string green = greenRx.Match(games[i]).Value;
                    string blue = blueRx.Match(games[i]).Value;
                    if ((red != "" && int.Parse(red.Split(' ')[0]) > maxRed) || (green != "" && int.Parse(green.Split(' ')[0]) > maxGreen) || (blue != "" && int.Parse(blue.Split(' ')[0]) > maxBlue))
                    {
                        possible = false;
                        break;
                    }
                }
                if (possible)
                {
                    possibleGamesCount += gameId;
                }

                gameId++;
            }
            Console.WriteLine(possibleGamesCount);
        }

        public static void Part2()
        {
            string input;
            int sumOfPower = 0;
            Regex redRx = new(@"\d+ red"), greenRx = new(@"\d+ green"), blueRx = new(@"\d+ blue");

            while ((input = Console.ReadLine()) != "")
            {
                string game = input.Split(": ")[1];
                string[] games = game.Split("; ");
                int minRed = 0, minGreen = 0, minBlue = 0;
                for (int i = 0; i < games.Length; i++)
                {
                    string red = redRx.Match(games[i]).Value;
                    string green = greenRx.Match(games[i]).Value;
                    string blue = blueRx.Match(games[i]).Value;
                    if (red != "" && int.Parse(red.Split(' ')[0]) > minRed)
                    {
                        minRed = int.Parse(red.Split(' ')[0]);
                    }
                    if (green != "" && int.Parse(green.Split(' ')[0]) > minGreen)
                    {
                        minGreen = int.Parse(green.Split(' ')[0]);
                    }
                    if (blue != "" && int.Parse(blue.Split(' ')[0]) > minBlue)
                    {
                        minBlue = int.Parse(blue.Split(' ')[0]);
                    }
                }
                sumOfPower += minRed * minGreen * minBlue;
            }
            Console.WriteLine(sumOfPower);
        }
    }
}

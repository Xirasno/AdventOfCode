using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day04
    {
        public static void Part1()
        {
            int[] numbers = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();
            string[] splitInput;
            string input = "";
            List<Dictionary<(int, int), (int, bool)>> boards = new List<Dictionary<(int, int), (int, bool)>>();
            List<(int, int)> numbersToWin = new List<(int, int)>();

            Console.ReadLine();

            while ((input = Console.ReadLine()) != "")
            {
                var board = new Dictionary<(int, int), (int, bool)>();
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                        splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    else 
                        splitInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < splitInput.Length; j++)
                    {
                        board.Add((i, j), (int.Parse(splitInput[j]), false));
                    }
                }
                boards.Add(board);
                Console.ReadLine();
            }

            for (int i = 0; i < boards.Count; i++)
            {
                numbersToWin.Add(CheckNumbersToWin(boards.ElementAt(i), numbers));
            }

            int boardNr = numbersToWin.FindIndex(n => n.Item1 == numbersToWin.Min(n => n.Item1));
            int highestScore = CalcScore(boards.ElementAt(boardNr), numbersToWin.ElementAt(boardNr).Item2);
            Console.WriteLine($"Board Nr = {boardNr}; Score = {highestScore}");
        }

        public static void Part2()
        {
            int[] numbers = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();
            string[] splitInput;
            string input = "";
            List<Dictionary<(int, int), (int, bool)>> boards = new List<Dictionary<(int, int), (int, bool)>>();
            List<(int, int)> numbersToWin = new List<(int, int)>();

            Console.ReadLine();

            while ((input = Console.ReadLine()) != "")
            {
                var board = new Dictionary<(int, int), (int, bool)>();
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                        splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    else
                        splitInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < splitInput.Length; j++)
                    {
                        board.Add((i, j), (int.Parse(splitInput[j]), false));
                    }
                }
                boards.Add(board);
                Console.ReadLine();
            }

            for (int i = 0; i < boards.Count; i++)
            {
                numbersToWin.Add(CheckNumbersToWin(boards.ElementAt(i), numbers));
            }

            int boardNr = numbersToWin.FindIndex(n => n.Item1 == numbersToWin.Max(n => n.Item1));
            int highestScore = CalcScore(boards.ElementAt(boardNr), numbersToWin.ElementAt(boardNr).Item2);
            Console.WriteLine($"Board Nr = {boardNr}; Score = {highestScore}");
        }

        private static (int, int) CheckNumbersToWin(Dictionary<(int, int),(int, bool)> board, int[] numbers)
        {
            int nrsToWin = 1;
            for(int i = 0; i < numbers.Length; i++, nrsToWin++)
            {
                var cell = board.FirstOrDefault(v => v.Value.Item1 == numbers[i]);
                if (cell.Key != (0, 0) || cell.Value != (0, false))
                    board[cell.Key] = (cell.Value.Item1, true);
                if (CheckWon(board))
                    return (nrsToWin, numbers[i]);
            }

            return (-1, -1);
        }

        private static bool CheckWon(Dictionary<(int, int), (int, bool)> board)
        {
            for (int i = 0; i < 5; i++)
            {
                // Check columns
                if (board.Where(b => b.Key.Item1 == i).All(b => b.Value.Item2))
                    return true;

                // Check rows
                if (board.Where(b => b.Key.Item2 == i).All(b => b.Value.Item2))
                    return true;
            }
            return false;
        }

        private static int CalcScore(Dictionary<(int, int), (int, bool)> board, int winningNr)
        {
            return board.Where(b => !b.Value.Item2).Sum(b => b.Value.Item1) * winningNr;
        }
    }
}
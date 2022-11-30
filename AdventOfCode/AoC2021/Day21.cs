using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class AoC2021Day21
    {
        public static void Part1()
        {
            string[] input = Console.ReadLine().Split(' ');
            int player1 = int.Parse(input[0]), player2 = int.Parse(input[1]);

            int score1 = 0, score2 = 0, rolls = 1;
            for (; score1 < 1000 && score2 < 1000; rolls += 3)
            {
                int roll = (3 * rolls) + 3;
                if (rolls % 2 == 1)
                {
                    roll += player1;
                    while (roll > 10)
                        roll -= 10;
                    player1 = roll;
                    score1 += roll;
                }
                else 
                {
                    roll += player2;
                    while (roll > 10)
                        roll -= 10;
                    player2 = roll;
                    score2 += roll;
                }
            }
            if (score1 > score2)
            Console.WriteLine(score2 * (rolls - 1));
            else Console.WriteLine(score1 * (rolls - 1));
        }

        public static void Part2()
        {
            string[] input = Console.ReadLine().Split(' ');
            int player1 = int.Parse(input[0]), player2 = int.Parse(input[1]);

            (long, long) playerWins = RollDice((player1, 0), (player2, 0), 1);

            if (playerWins.Item1 > playerWins.Item2)
                Console.WriteLine(playerWins.Item1); 
            else Console.WriteLine(playerWins.Item2);
        }




        //                                           (Position, Score)
        public static (long, long) RollDice((int, int) player1, (int, int) player2, int nextPlayer)
        {
            (long, long) playerWins = (0, 0);

            if (player1.Item2 >= 21)
                return (1, 0);
            if (player2.Item2 >= 21)
                return (0, 1);

            if (nextPlayer == 1)
                for (int i = 3; i <= 9; i++)
                {
                    int prevPos = player1.Item1;
                    int roll = i + player1.Item1;
                    while (roll > 10)
                        roll -= 10;
                    player1.Item1 = roll;
                    player1.Item2 += roll;
                    playerWins = i switch
                    {
                        3 => playerWins.Add(RollDice(player1, player2, 2)),
                        4 => playerWins.Add(RollDice(player1, player2, 2).Times(3)),
                        5 => playerWins.Add(RollDice(player1, player2, 2).Times(6)),
                        6 => playerWins.Add(RollDice(player1, player2, 2).Times(7)),
                        7 => playerWins.Add(RollDice(player1, player2, 2).Times(6)),
                        8 => playerWins.Add(RollDice(player1, player2, 2).Times(3)),
                        9 => playerWins.Add(RollDice(player1, player2, 2)),
                    };
                    player1.Item1 = prevPos;
                    player1.Item2 -= roll;
                }
            else
                for (int i = 3; i <= 9; i++)
                {
                    int prevPos = player2.Item1;
                    int roll = i + player2.Item1;
                    while (roll > 10)
                        roll -= 10;
                    player2.Item1 = roll;
                    player2.Item2 += roll;
                    playerWins = i switch
                    {
                        3 => playerWins.Add(RollDice(player1, player2, 1)),
                        4 => playerWins.Add(RollDice(player1, player2, 1).Times(3)),
                        5 => playerWins.Add(RollDice(player1, player2, 1).Times(6)),
                        6 => playerWins.Add(RollDice(player1, player2, 1).Times(7)),
                        7 => playerWins.Add(RollDice(player1, player2, 1).Times(6)),
                        8 => playerWins.Add(RollDice(player1, player2, 1).Times(3)),
                        9 => playerWins.Add(RollDice(player1, player2, 1)),
                    };
                    player2.Item1 = prevPos;
                    player2.Item2 -= roll;
                }
            return playerWins;
        }

        public static (long, long) Add(this (long, long) a, (long, long) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2);
        public static (long, long) Times(this (long, long) a, int x) => (a.Item1 * x, a.Item2 * x);
    }
}
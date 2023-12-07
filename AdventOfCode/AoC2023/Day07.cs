using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class AoC2023Day07
    {
        public static void Part1()
        {
            string input;
            List<Hand> hands = new();
            while ((input = Console.ReadLine()) != "")
            {
                hands.Add(new(input.Split(' ')[0], int.Parse(input.Split(' ')[1])));
            }
            for (int i = 0; i < hands.Count; i++)
            {
                List<char> distinctCards = hands[i].Cards.Distinct().ToList();
                int distinctCardsCount = hands[i].Cards.Distinct().Count();
                if (distinctCardsCount == 1) // five of a kind
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 7);
                }
                else if (distinctCardsCount == 2 && distinctCards.Any(c => hands[i].Cards.Count(c2 => c2 == c) == 4)) // four of a kind
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 6);
                }
                else if (distinctCardsCount == 2 
                    && ((hands[i].Cards.Count(c => c == distinctCards[0]) == 2 && hands[i].Cards.Count(c => c == distinctCards[1]) == 3) 
                        || (hands[i].Cards.Count(c => c == distinctCards[0]) == 3 && hands[i].Cards.Count(c => c == distinctCards[1]) == 2))) // full house
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 5);
                }
                else if (distinctCardsCount == 3 && distinctCards.Any(c => hands[i].Cards.Count(c2 => c2 == c) == 3)) // three of a kind
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 4);
                }
                else if (distinctCardsCount == 3 && distinctCards.Count(c => hands[i].Cards.Count(c2 => c2 == c) == 2) == 2) // two pair
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 3);
                }
                else if (distinctCardsCount == 4 && distinctCards.Count(c => hands[i].Cards.Count(c2 => c2 == c) == 2) == 1) // one pair
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 2);
                }
                else // high card
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 1);
                }
            }

            int curMaxRank = hands.Count;
            for (int n = 7; n > 0; n--)
            {
                List<Hand> rankHands = hands.Where(h => h.Type == n).ToList().OrderByDescending(h => h.Cards).ToList();
                for (int i = 0; i < rankHands.Count; i++, curMaxRank--)
                {
                    int index = hands.FindIndex(h => h.Cards == rankHands[i].Cards);
                    hands[index] = new(hands[index].Cards, hands[index].Bid, hands[index].Type, curMaxRank);
                }

            }

            long score = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                score += hands[i].Bid * hands[i].Rank;
            }
            Console.WriteLine(score);
        }

        public static void Part2()
        {
            string input;
            List<Hand> hands = new();
            while ((input = Console.ReadLine()) != "")
            {
                hands.Add(new(input.Split(' ')[0], int.Parse(input.Split(' ')[1]), true));
            }
            for (int i = 0; i < hands.Count; i++)
            {
                List<char> distinctCards = hands[i].Cards.Distinct().ToList();
                int distinctCardsCount = hands[i].Cards.Distinct().Count();
                if (distinctCardsCount == 1 || (distinctCardsCount == 2 && distinctCards.Contains('a'))) // five of a kind
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 7);
                }
                else if ((distinctCardsCount == 2 || (distinctCardsCount == 3 && distinctCards.Contains('a'))) 
                    && distinctCards.Any(c => hands[i].Cards.Count(c2 => c == c2) + (c != 'a' ? hands[i].Cards.Count(c2 => c2 == 'a') : 0) == 4)) // four of a kind
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 6);
                }
                else if ((distinctCardsCount == 2 || (distinctCardsCount == 3 && distinctCards.Contains('a')))
                    && (distinctCards.Contains('a') 
                        ? (hands[i].Cards.Count(c => c == distinctCards.Where(c2 => c2 != 'a').ToList()[0]) == 2 && hands[i].Cards.Count(c => c == distinctCards.Where(c2 => c2 != 'a').ToList()[1]) == 2)
                        : ((hands[i].Cards.Count(c => c == distinctCards[0]) == 2 && hands[i].Cards.Count(c => c == distinctCards[1]) == 3)
                            || (hands[i].Cards.Count(c => c == distinctCards[0]) == 3 && hands[i].Cards.Count(c => c == distinctCards[1]) == 2)))) // full house
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 5);
                }
                else if ((distinctCardsCount == 3 || (distinctCardsCount == 4 && distinctCards.Contains('a'))) 
                    && distinctCards.Any(c => hands[i].Cards.Count(c2 => c == c2) + (c != 'a' ? hands[i].Cards.Count(c2 => c2 == 'a') : 0) == 3)) // three of a kind
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 4);
                }
                else if ((distinctCardsCount == 3 || (distinctCardsCount == 4 && distinctCards.Contains('a')))
                    && distinctCards.Count(c => hands[i].Cards.Count(c2 => c == c2) + (c != 'a' ? hands[i].Cards.Count(c => c == 'a') : 0) == 2) == 2) // two pair
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 3);
                }
                else if (distinctCards.Contains('a') || distinctCardsCount == 4 && distinctCards.Count(c => hands[i].Cards.Count(c2 => c2 == c) == 2) == 1) // one pair
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 2);
                }
                else // High Card
                {
                    hands[i] = new(hands[i].Cards, hands[i].Bid, 1);
                }

            }
            int curMaxRank = hands.Count;
            for (int n = 7; n > 0; n--)
            {
                List<Hand> rankHands = hands.Where(h => h.Type == n).ToList().OrderByDescending(h => h.Cards).ToList();
                for (int i = 0; i < rankHands.Count; i++, curMaxRank--)
                {
                    int index = hands.FindIndex(h => h.Cards == rankHands[i].Cards);
                    hands[index] = new(hands[index].Cards, hands[index].Bid, hands[index].Type, curMaxRank);
                }

            }

            long score = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                score += hands[i].Bid * hands[i].Rank;
            }
            Console.WriteLine(score);

            // 251081177
        }

        public struct Hand
        {
            public string Cards;
            public int Bid;
            public int Type = 0;
            public int Rank = 0;

            public Hand(string Cards, int Bid, bool Part2 = false)
            {
                this.Cards = !Part2 
                    ? Cards
                    .Replace('A', 'm')
                    .Replace('K', 'l')
                    .Replace('Q', 'k')
                    .Replace('J', 'j')
                    .Replace('T', 'i')
                    .Replace('9', 'h')
                    .Replace('8', 'g')
                    .Replace('7', 'f')
                    .Replace('6', 'e')
                    .Replace('5', 'd')
                    .Replace('4', 'c')
                    .Replace('3', 'b')
                    .Replace('2', 'a')
                    : Cards
                    .Replace('A', 'm')
                    .Replace('K', 'l')
                    .Replace('Q', 'k')
                    .Replace('T', 'j')
                    .Replace('9', 'i')
                    .Replace('8', 'h')
                    .Replace('7', 'g')
                    .Replace('6', 'f')
                    .Replace('5', 'e')
                    .Replace('4', 'd')
                    .Replace('3', 'c')
                    .Replace('2', 'b')
                    .Replace('J', 'a');
                this.Bid = Bid;
            }

            public Hand(string Cards, int Bid, int Type)
            {
                this.Cards = Cards;
                this.Bid = Bid;
                this.Type = Type;
            }

            public Hand(string Cards, int Bid, int Type, int Rank)
            {
                this.Cards = Cards;
                this.Bid = Bid;
                this.Type = Type;
                this.Rank = Rank;
            }
        }
    }
}
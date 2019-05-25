using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_NumberWars
{
    class NumberWars
    {
        private static List<string> result;
        static void Main(string[] args)
        {
            var playerOne = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var playerTwo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            int round = 0;
            var firstPlayerCards = new Queue<string>(playerOne);
            var secondPlayerCards = new Queue<string>(playerTwo);

            while (round < 1000000)
            {
                round++;
                var cardOne = string.Empty;
                var cardTwo = string.Empty;

                cardOne = firstPlayerCards.Dequeue();
                cardTwo = secondPlayerCards.Dequeue();

                var cardOneNumber = long.Parse(cardOne.Substring(0, cardOne.Length - 1));
                var cardTwoNumber = long.Parse(cardTwo.Substring(0, cardTwo.Length - 1));

                if (cardOneNumber>cardTwoNumber)
                {
                    firstPlayerCards.Enqueue(cardOne);
                    firstPlayerCards.Enqueue(cardTwo);
                }
                else if (cardOneNumber < cardTwoNumber)
                {
                    secondPlayerCards.Enqueue(cardTwo);
                    secondPlayerCards.Enqueue(cardOne);
                }
                else
                {
                    result = new List<string>();
                    result.Add(cardOne);
                    result.Add(cardTwo);

                    War(firstPlayerCards, secondPlayerCards, round);
                }
                CardsMoreThanZero(firstPlayerCards, secondPlayerCards, round);
            }
            var winner = firstPlayerCards.Count > secondPlayerCards.Count ? "First" : "Second";
            GameOver(winner, round);
        }

        private static void GameOver(string winner, int round)
        {
            Console.WriteLine($"{winner} player wins after {round} turns");
            Environment.Exit(0);
        }

        static void CardsMoreThanZero(Queue<string> firstPlayerCards, Queue<string> secondPlayerCards, int round)
        {
            if (firstPlayerCards.Count==0 && secondPlayerCards.Count==0)
            {
                Console.WriteLine($"Draw after {round} turns");
                Environment.Exit(0);
            }
            else if (firstPlayerCards.Count<=0)
            {
                GameOver("Second", round);
            }
            else if (secondPlayerCards.Count<=0)
            {
                GameOver("First", round);
            }

        }

        static void War(Queue<string> firstPlayerCards, Queue<string> secondPlayerCards, int round)
        {
            CardsMoreThanZero(firstPlayerCards, secondPlayerCards, round);

            if (firstPlayerCards.Count<3)
            {
                GameOver("Second", round);
            }
            else if (secondPlayerCards.Count<3)
            {
                GameOver("First", round);
            }
            else
            {
                var card1 = firstPlayerCards.Dequeue();
                var card2 = firstPlayerCards.Dequeue();
                var card3 = firstPlayerCards.Dequeue();
                result.AddRange(new List<string> { card1, card2, card3 });

                var playerOneStrength = card1[card1.Length-1]+ card2[card2.Length - 1] + card3[card3.Length - 1];

                var card4 = secondPlayerCards.Dequeue();
                var card5 = secondPlayerCards.Dequeue();
                var card6 = secondPlayerCards.Dequeue();
                result.AddRange(new List<string> { card4, card5, card6 });

                var playerTwoStrength = card4[card4.Length - 1] + card5[card5.Length - 1] + card6[card6.Length - 1];

                if (playerOneStrength == playerTwoStrength)
                {
                    War(firstPlayerCards, secondPlayerCards, round);
                }
                else if (playerOneStrength > playerTwoStrength)
                {
                    result = result
                            .OrderByDescending(x => long.Parse(x.Substring(0, x.Length - 1)))
                            .ThenByDescending(x => x[x.Length - 1] - 96)
                            .ToList();

                    foreach (var item in result)
                    {
                        firstPlayerCards.Enqueue(item);
                    }
                }
                else if (playerTwoStrength > playerOneStrength)
                {
                    result = result
                            .OrderByDescending(x => long.Parse(x.Substring(0, x.Length - 1)))
                            .ThenByDescending(x => x[x.Length - 1] - 96)
                            .ToList();

                    foreach (var item in result)
                    {
                        secondPlayerCards.Enqueue(item);
                    }
                }
            }
        }
    }
}

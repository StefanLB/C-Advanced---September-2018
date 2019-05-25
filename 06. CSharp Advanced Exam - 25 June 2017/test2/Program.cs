using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_NumberWars
{
    class NumberWars
    {
        static void Main(string[] args)
        {
            string[] player1Cards = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] player2Cards = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<KeyValuePair<long, char>> player1Deck = new Queue<KeyValuePair<long, char>>();

            for (long i = 0; i < player1Cards.Length; i++)
            {
                char suit = player1Cards[i][player1Cards[i].Length - 1];
                long power = long.Parse(player1Cards[i].Substring(0, player1Cards[i].Length - 1).ToString());

                player1Deck.Enqueue(new KeyValuePair<long, char>(power, suit));
            }

            Queue<KeyValuePair<long, char>> player2Deck = new Queue<KeyValuePair<long, char>>();

            for (long i = 0; i < player2Cards.Length; i++)
            {
                char suit = player2Cards[i][player2Cards[i].Length - 1];
                long power = long.Parse(player2Cards[i].Substring(0, player2Cards[i].Length - 1).ToString());

                player2Deck.Enqueue(new KeyValuePair<long, char>(power, suit));
            }

            long turns = 0;

            while (player1Deck.Count > 0 && player2Deck.Count > 0 && turns < 1000000)
            {
                turns++;
                long player1Strength = player1Deck.Peek().Key;
                long player2Strength = player2Deck.Peek().Key;

                if (player1Strength > player2Strength)
                {
                    player1Deck.Enqueue(player1Deck.Dequeue());
                    player1Deck.Enqueue(player2Deck.Dequeue());
                }
                else if (player1Strength < player2Strength)
                {
                    player2Deck.Enqueue(player2Deck.Dequeue());
                    player2Deck.Enqueue(player1Deck.Dequeue());
                }
                else //equal cards
                {
                    //if (player1Deck.Count<3 && player2Deck.Count>=3)
                    //{
                    //    Console.WriteLine($"Second player wins after {turns} turns");
                    //    return;
                    //}
                    //else if (player1Deck.Count >= 3 && player2Deck.Count < 3)
                    //{
                    //    Console.WriteLine($"First player wins after {turns} turns");
                    //    return;
                    //}

                    List<KeyValuePair<long, char>> currentStakes = new List<KeyValuePair<long, char>>();
                    currentStakes.Add(player1Deck.Dequeue());
                    currentStakes.Add(player2Deck.Dequeue());

                    while (true) // ne sledi dali ima 3 ili poveche ostavashti karti
                    {
                        long player1cardsStrength = 0;
                        long player2cardsStrength = 0;

                        for (long i = 0; i < 3; i++) // ne sledi dali ima ostavashti karti
                        {
                            if (player1Deck.Count == 0 && player2Deck.Count > 0)
                            {
                                break;
                                //Console.WriteLine($"Second player wins after {turns} turns");
                                //return;
                            }
                            else if (player1Deck.Count > 0 && player2Deck.Count == 0)
                            {
                                break;
                                //Console.WriteLine($"First player wins after {turns} turns");
                                //return;
                            }
                            else if (player1Deck.Count == 0 && player2Deck.Count == 0 && (player2cardsStrength == player1cardsStrength))
                            {
                                Console.WriteLine($"Draw after {turns} turns");
                                return;
                            }
                            else if (player1Deck.Count == 0 && player2Deck.Count == 0)
                            {
                                break;
                            }

                            player1cardsStrength = player1Deck.Peek().Value - 96;
                            player2cardsStrength = player2Deck.Peek().Value - 96;

                            currentStakes.Add(player1Deck.Dequeue());
                            currentStakes.Add(player2Deck.Dequeue());
                        }

                        if (player1cardsStrength > player2cardsStrength)
                        {
                            currentStakes = currentStakes.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value).ToList();

                            foreach (var kvp in currentStakes)
                            {
                                player1Deck.Enqueue(kvp);
                            }
                            break;
                        }
                        else if (player2cardsStrength > player1cardsStrength)
                        {
                            currentStakes = currentStakes.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value).ToList();

                            foreach (var kvp in currentStakes)
                            {
                                player2Deck.Enqueue(kvp);
                            }
                            break;
                        }
                    }
                }
            }

            if (player1Deck.Count == 0)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else if (player2Deck.Count == 0)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }

        }
    }
}

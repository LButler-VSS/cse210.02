using System;
using System.Collections.Generic;
using System.Linq;

namespace Prove02
{
    public class Deck
    {
        List<Card> deck = new List<Card>();
        private static Random rng = new Random();

        public Deck()
        {
            for (int j = 0; j < 5; j++)
            {
                switch (j)
                {
                    case 1:
                        {
                            int cardValue = 0;
                            for (int i = 0; i < 13; i++)
                            {
                                Card card = new Card();
                                cardValue++;
                                if (cardValue == 1)
                                {
                                    card.Symbol = "Ace";
                                    card.Value = 11;
                                    card.AceValue = 1;
                                }
                                else if (cardValue == 11)
                                {
                                    card.Symbol = "Jack";
                                    card.Value = 10;
                                }
                                else if (cardValue == 12)
                                {
                                    card.Symbol = "Queen";
                                    card.Value = 10;
                                }
                                else if (cardValue == 13)
                                {
                                    card.Symbol = "King";
                                    card.Value = 10;
                                }
                                else
                                {
                                    card.Symbol = Convert.ToString(cardValue);
                                    card.Value = cardValue;
                                }
                                card.Suit = "Hearts";
                                deck.Add(card);
                            }
                            break;
                        }
                    case 2:
                        {

                            int cardValue = 0;
                            for (int i = 0; i < 13; i++)
                            {
                                Card card = new Card();
                                cardValue++;
                                if (cardValue == 1)
                                {
                                    card.Symbol = "Ace";
                                    card.Value = 11;
                                    card.AceValue = 1;
                                }
                                else if (cardValue == 11)
                                {
                                    card.Symbol = "Jack";
                                    card.Value = 10;
                                }
                                else if (cardValue == 12)
                                {
                                    card.Symbol = "Queen";
                                    card.Value = 10;
                                }
                                else if (cardValue == 13)
                                {
                                    card.Symbol = "King";
                                    card.Value = 10;
                                }
                                else
                                {
                                    card.Symbol = Convert.ToString(cardValue);
                                    card.Value = cardValue;
                                }
                                card.Suit = "Spades";
                                deck.Add(card);
                            }
                            break;
                        }
                    case 3:
                        {
                            int cardValue = 0;
                            for (int i = 0; i < 13; i++)
                            {
                                Card card = new Card();
                                cardValue++;
                                if (cardValue == 1)
                                {
                                    card.Symbol = "Ace";
                                    card.Value = 11;
                                    card.AceValue = 1;
                                }
                                else if (cardValue == 11)
                                {
                                    card.Symbol = "Jack";
                                    card.Value = 10;
                                }
                                else if (cardValue == 12)
                                {
                                    card.Symbol = "Queen";
                                    card.Value = 10;
                                }
                                else if (cardValue == 13)
                                {
                                    card.Symbol = "King";
                                    card.Value = 10;
                                }
                                else
                                {
                                    card.Symbol = Convert.ToString(cardValue);
                                    card.Value = cardValue;
                                }
                                card.Suit = "Diamonds";
                                deck.Add(card);
                            }
                            break;
                        }
                    case 4:
                        {
                            int cardValue = 0;
                            for (int i = 0; i < 13; i++)
                            {
                                Card card = new Card();
                                cardValue++;
                                if (cardValue == 1)
                                {
                                    card.Symbol = "Ace";
                                    card.Value = 11;
                                    card.AceValue = 1;
                                }
                                else if (cardValue == 11)
                                {
                                    card.Symbol = "Jack";
                                    card.Value = 10;
                                }
                                else if (cardValue == 12)
                                {
                                    card.Symbol = "Queen";
                                    card.Value = 10;
                                }
                                else if (cardValue == 13)
                                {
                                    card.Symbol = "King";
                                    card.Value = 10;
                                }
                                else
                                {
                                    card.Symbol = Convert.ToString(cardValue);
                                    card.Value = cardValue;
                                }
                                card.Suit = "Clubs";
                                deck.Add(card);
                            }
                            break;
                        }
                    default:
                        break;
                };
            }
        }


        public void Shuffle()
        {
            int n = deck.Count;
            List<Card> list = new List<Card>();

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                list.Add(deck[k]);
                deck[k] = deck[n];
                deck[n] = list[0];
                list.RemoveAt(0);
            }
            /*
            foreach (var value in deck)
            {
                Console.WriteLine($"{value.Symbol} of {value.Suit}");
            }
            */
        }

        public List<Card> Deal(int i)
        {
            List<Card> dealtCards = new List<Card>();
            for (int j = 0; j < i; j++)
            {
                dealtCards.Add(deck[0]);
                deck.RemoveAt(0);
            }
            return dealtCards;
        }
    }

}

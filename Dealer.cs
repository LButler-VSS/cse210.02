using System;
using System.Collections.Generic;

namespace Prove02
{
    public class Dealer
    {
        List<Card> dealerHand = new List<Card>();
        List<Card> playerHand = new List<Card>();
        bool isPlaying = true, resetDeck = true, validResponse;
        int points, wagerdPoints;
        public Dealer()
        {

        }




        public void StartGame()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            while (isPlaying)
            {
                points = 1000;
                do
                {
                    deck = new Deck();
                    deck.Shuffle();
                    resetDeck = false;
                } while (resetDeck);

                do
                {
                Console.WriteLine($"You have {points} points. How many would you like to wager?");
                string wageredPointsStr = Console.ReadLine();
                try
                {
                    int wageredPoints = Int32.Parse(wageredPointsStr);
                    validResponse = true;
                }
                catch
                {
                    Console.WriteLine($"Your wager was not valid, please enter a new wager.\n");
                    validResponse = false;
                }
                } while (!validResponse);

                
                dealerHand = deck.Deal();
                playerHand = deck.Deal();
                Console.WriteLine($"The dealer is showing a(n) {dealerHand[0].Value} of {dealerHand[0].Suit}.");
                Console.WriteLine($"Your cards are a(n) {playerHand[0].Value} of {playerHand[0].Suit} and a(n) {playerHand[1].Value} of {playerHand[1].Suit}.");
                isPlaying = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Prove02
{
    public class Dealer
    {
        Deck deck = new Deck(); 
        List<Card> dealerHand = new List<Card>();
        List<Card> playerHand = new List<Card>();
        bool isPlaying = true;
        public Dealer()
        {

        }
        
        


        public void StartGame()
        {
            while(isPlaying)
            {
                deck.Shuffle();
                dealerHand = deck.Deal();
                playerHand = deck.Deal();
                Console.WriteLine($"The dealer is showing a(n) {dealerHand[0].Value} of {dealerHand[0].Suit}.");
                Console.WriteLine($"Your cards are a(n) {playerHand[0].Value} of {playerHand[0].Suit} and a(n) {playerHand[1].Value} of {playerHand[1].Suit}.");
                isPlaying = false;
            }
        }
    }
}

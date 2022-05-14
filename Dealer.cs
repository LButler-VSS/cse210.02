using System;
using System.Collections.Generic;

namespace Prove02
{
    public class Dealer
    {
        List<Card> dealerHand = new List<Card>();
        List<Card> playerHand = new List<Card>();
        bool isPlaying = true, resetDeck = true, validResponse, bust;
        int points, wageredPoints, handValue;
        string hitOrStand;

        public Dealer()
        {

        }

        public void StartGame()
        {
            Deck deck = new Deck();
            points = 1000;
            while (isPlaying)
            {
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
                        wageredPoints = Int32.Parse(wageredPointsStr);
                        validResponse = true;
                    }
                    catch
                    {
                        Console.WriteLine($"Your entry was not valid, please enter a new wager.\n");
                        validResponse = false;
                    }
                    if (wageredPoints > points)
                    {
                        Console.WriteLine($"Your wager was larger than your available points, please enter a new wager.\n");
                        validResponse = false;
                    }
                } while (!validResponse);


                dealerHand = deck.Deal(2);
                playerHand = deck.Deal(2);
                Console.WriteLine($"The dealer is showing a(n) {dealerHand[0].Value} of {dealerHand[0].Suit}.");
                Console.WriteLine($"Your cards are a(n) {playerHand[0].Value} of {playerHand[0].Suit} and a(n) {playerHand[1].Value} of {playerHand[1].Suit}.");

                if (checkBlackjack("player"))
                {
                    Console.WriteLine("You have blackjack!");
                    if (checkBlackjack("dealer"))
                    {
                        Console.WriteLine($"The dealer has blackjack as well with a(n) {dealerHand[0].Value} of {dealerHand[0].Suit} and a(n) {dealerHand[1].Value} of {dealerHand[1].Suit}.");
                        Console.WriteLine($"The hand is a tie.");
                        checkPlaying();
                    }
                    else
                    {
                        points += wageredPoints * 2;
                        Console.WriteLine($"You win {(wageredPoints * 2)}. Your new point total is {points}.");
                        checkPlaying();
                    }
                }

                else if (checkBlackjack("dealer"))
                {
                    Console.WriteLine($"The dealer has blackjack with a(n) {dealerHand[0].Value} of {dealerHand[0].Suit} and a(n) {dealerHand[1].Value} of {dealerHand[1].Suit}.");
                    Console.WriteLine($"You lose your wagered {points} points.");
                    points -= wageredPoints;
                    if (points == 0)
                        isPlaying = false;
                    else
                        checkPlaying();
                }

                else
                {
                    do
                    {
                        if (bust)
                        {
                            hitOrStand = "s";
                        }
                        else
                        {
                            Console.WriteLine("Would you like to hit or stand? (h/s)");
                            hitOrStand = Console.ReadLine();
                            if (hitOrStand == "h")
                            {
                                List<Card> hitCard = new List<Card>();
                                hitCard = (deck.Deal(1));
                                playerHand.Add(hitCard[0]);
                                Console.WriteLine($"Your cards are:");
                                foreach (Card card in playerHand)
                                {
                                    Console.WriteLine($"{card.Value} of {card.Suit}");
                                }
                                checkBust();
                                validResponse = true;
                            }
                            else if (hitOrStand == "s")
                            {
                                validResponse = true;
                            }
                            else
                            {
                                Console.WriteLine($"Your answer {hitOrStand} is invalid. Please enter a valid response.");
                                validResponse = false;
                            }
                        }
                    } while (hitOrStand == "h" || !validResponse);
                    
                    Console.WriteLine($"Your hand has a value of {handTotal("player")}.");
                }

                //placeholder while testing
                isPlaying = false;
            }
        }

        public bool checkBlackjack(string player)
        {
            if (player == "dealer")
            {
                if ((dealerHand[0].Value == 10 & dealerHand[1].Value == 11) | (dealerHand[0].Value == 11 & dealerHand[1].Value == 10))
                    return true;
                else
                    return false;
            }
            if (player == "player")
            {
                if ((playerHand[0].Value == 10 & playerHand[1].Value == 11) | (playerHand[0].Value == 11 & playerHand[1].Value == 10))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public void checkPlaying()
        {
            do
            {
                Console.WriteLine($"Would you like to play another hand? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    isPlaying = true;
                    validResponse = true;
                }
                else if (playAgain == "n")
                {
                    isPlaying = false;
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine($"Your entry {playAgain} is invalid. Please enter a valid answer.");
                    validResponse = false;
                }
            } while (!validResponse);
        }

        public bool checkBust()
        {
            return false;
        }

        public int handTotal(string player)
        {
            handValue = 0;
            if (player == "player")
            {
                foreach (Card card in playerHand)
                {
                    handValue += card.Value;
                }
            }
            else
            {
                foreach (Card card in dealerHand)
                {
                    handValue += card.Value;
                }
            }
            return handValue;
        }
    }
}

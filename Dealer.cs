using System;
using System.Collections.Generic;

namespace Prove02
{
    public class Dealer
    {
        List<Card> dealerHand = new List<Card>();
        List<Card> playerHand = new List<Card>();
        bool isPlaying = true, validResponse, bust = false, /*playerAces = false, dealerAces = false,*/ dealerFin;
        int points, wageredPoints, handValue;
        string hitOrStand;

        public Dealer()
        {

        }

        public void StartGame()
        {
            Console.WriteLine("This blackjack game treats Aces only as an 11.");
            Deck deck = new Deck();
            points = 1000;
            while (isPlaying)
            {
                deck = new Deck();
                deck.Shuffle();
                bust = false;

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

                dealerHand.RemoveAll(dealerHand => dealerHand.Value == 0);
                playerHand.RemoveAll(playerHand => playerHand.Value == 0);
                dealerHand = deck.Deal(2);
                playerHand = deck.Deal(2);
                Console.WriteLine($"\nThe dealer is showing a(n) {dealerHand[0].Value} of {dealerHand[0].Suit}.");
                Console.WriteLine($"Your cards are a(n) {playerHand[0].Value} of {playerHand[0].Suit} and a(n) {playerHand[1].Value} of {playerHand[1].Suit}.");

                if (checkBlackjack("player"))
                {
                    Console.WriteLine("\nYou have blackjack!");
                    if (checkBlackjack("dealer"))
                    {
                        Console.WriteLine($"The dealer has blackjack as well with a(n) {dealerHand[0].Value} of {dealerHand[0].Suit} and a(n) {dealerHand[1].Value} of {dealerHand[1].Suit}.");
                        Console.WriteLine($"The hand is a tie.");
                        checkPlaying();
                    }
                    else
                    {
                        points += wageredPoints * 2;
                        Console.WriteLine($"\nYou win {(wageredPoints * 2)}. Your new point total is {points}.");
                        checkPlaying();
                    }
                }

                else if (checkBlackjack("dealer"))
                {
                    Console.WriteLine($"The dealer has blackjack with a(n) {dealerHand[0].Value} of {dealerHand[0].Suit} and a(n) {dealerHand[1].Value} of {dealerHand[1].Suit}.");
                    changePointTotal(false);
                }

                else
                {
                    do
                    {
                        {
                            Console.WriteLine("\nWould you like to hit or stand? (h/s)");
                            hitOrStand = Console.ReadLine();
                            if (hitOrStand == "h")
                            {
                                List<Card> hitCard = new List<Card>();
                                hitCard = (deck.Deal(1));
                                playerHand.Add(hitCard[0]);
                                Console.WriteLine($"\nYour cards are:");
                                foreach (Card card in playerHand)
                                {
                                    Console.WriteLine($"{card.Value} of {card.Suit}");
                                }
                                checkBust("player");
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

                    Console.WriteLine($"Your hand has a value of {handTotal("player", false)}.");
                    
                    if (bust)
                    {
                        Console.WriteLine($"\nThe dealer's cards are:");
                                foreach (Card card in dealerHand)
                                {
                                    Console.WriteLine($"{card.Value} of {card.Suit}");
                                }
                        changePointTotal(false);
                    }
                    else
                    {
                        dealerFin = false;
                        bust = false;
                        Console.WriteLine($"\nThe dealer's cards are:");
                                foreach (Card card in dealerHand)
                                {
                                    Console.WriteLine($"{card.Value} of {card.Suit}");
                                }
                        while (!bust & !dealerFin)
                        {
                            //checkAces("dealer");
                            
                            if (handTotal("dealer", false) < 17)
                            {
                                List<Card> hitCard = new List<Card>();
                                hitCard = (deck.Deal(1));
                                Console.WriteLine($"{hitCard[0].Value} of {hitCard[0].Suit}");
                                dealerHand.Add(hitCard[0]);
                            }
                            else
                            {
                                dealerFin = true;
                                checkBust("dealer");
                            }
                        }
                        Console.WriteLine($"The dealer's hand has a value of {handTotal("dealer", false)}.");

                        if ((handTotal("player", false) > handTotal("dealer", false)) | bust)
                        {
                            changePointTotal(true);
                        }
                        else if (!bust && (handTotal("player", false) < handTotal("dealer", false)))
                        {
                            changePointTotal(false);
                        }
                        else
                        {
                            Console.WriteLine($"The hand is a tie.");
                            checkPlaying();
                        }
                    }
                }
            }

            if (!isPlaying)
            {
                Console.WriteLine("Thanks for playing!");
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

        public void checkBust(string player)
        {
            if (handTotal(player, false) > 21)
            {
                Console.WriteLine("Busted!");
                hitOrStand = "s";
                bust = true;
            }
            else
                bust = false;
        }

        public int handTotal(string player, bool Ace)
        {
            handValue = 0;
            if (Ace)
            {
                if (player == "player")
                {
                    foreach (Card card in playerHand)
                    {
                        if (card.Value == 11)
                            handValue += card.AceValue;
                        else
                            handValue += card.Value;
                    }
                }
                else
                {
                    foreach (Card card in dealerHand)
                    {
                        if (card.Value == 11)
                            handValue = +card.AceValue;
                        handValue += card.Value;
                    }
                }
                return handValue;
            }
            else
            {
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

        public void changePointTotal(bool change)
        {
            if (change)
            {
                points += wageredPoints;
                Console.WriteLine($"\nYou won {wageredPoints} point(s). Your new total is {points}.");
                checkPlaying();
            }
            else if (!change)
            {
                points -= wageredPoints;
                Console.WriteLine($"\nYou lost {wageredPoints} point(s). Your new total is {points}.");
                if (points == 0)
                    isPlaying = false;
                else
                    checkPlaying();
            }
        }
/*
        public void checkAces(string player)
        {
            if (player == "player")
            {
                foreach (Card card in playerHand)
                {
                    if (card.Value == 11)
                        playerAces = true;
                }
            }
            else
            {
                foreach (Card card in dealerHand)
                {
                    if (card.Value == 11)
                        dealerAces = true;
                }
            }
        }*/
    }
}

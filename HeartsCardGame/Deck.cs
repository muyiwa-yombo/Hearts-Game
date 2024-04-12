/* Program Name: Hearts Game
   Program Description: This is the Deck Class for this Hearts Game
   File Name: Deck.cs
   Program Authors: Group 5 
   Program Date: April 1st, 2024
*/

using HeartsCardGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartsCardGame
{
    internal class Deck
    {
        // List to hold the cards in the deck
        public List<Card> cardDeck = new List<Card>();

        // Method to build a standard deck of cards
        public virtual void BuildDeck()
        {
            // Standard suits and values for a deck of cards
            string[] standardSuits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            int[] standardValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            int points;

            // Loop through each suit and value to create cards
            foreach (var suit in standardSuits)
            {
                foreach (var value in standardValues)
                {
                    points = 0;
                    // Assign point values based on suit and value
                    if (suit == "Hearts")
                    {
                        points = 1;
                    }
                    else if (suit == "Spades" && value == 12)
                    {
                        points = 13;
                    }
                    // Add the card to the deck
                    cardDeck.Add(new Card(suit, value, points));
                }
            }
            // Shuffle the deck 
            Shuffle();
        }

        // Method to shuffle the deck
        public void Shuffle()
        {
            Random randomShuffle = new Random();
            int n = cardDeck.Count;
            // using Fisher-Yates shuffle algorithm
            while (n > 1)
            {
                // decrement 
                n--;
                int k = randomShuffle.Next(n + 1);
                Card value = cardDeck[k];
                cardDeck[k] = cardDeck[n];
                cardDeck[n] = value;
            }
        }

        // Method to deal a card from the deck
        public Card Deal()
        {
            Card card = cardDeck.Last();
            cardDeck.Remove(card);
            return card;
        }
    }
}

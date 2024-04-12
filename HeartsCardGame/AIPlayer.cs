/* Program Name: Hearts Game
   Program Description: This is the AIPlayer Class for this Hearts Game
   File Name: AIPlayer.cs
   Program Authors: Group 5
   Program Date: April 1st, 2024
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartsCardGame
{
    internal class AIPlayer : Player
    {
        // Random number generator for AI decisions
        private Random AIRandom;

        // Constructor for AI player, initializes player name and random number generator
        public AIPlayer(string newPlayerName) : base(newPlayerName)
        {
            AIRandom = new Random();
        }

        // Method for AI player to select a card to play
        public override Card PlayCard(List<Card> currentTrick, bool heartsBroken)
        {
            // Check if the AI player holds the Two of Clubs
            Card twoOfClubs = playerHand.Find(card => card.Value == 2 && card.Suit == "Clubs");

            // If it's the first card of the trick
            if (currentTrick.Count == 0)
            {
                // Play the Two of Clubs if available, otherwise lead with a card
                if (twoOfClubs != null)
                {
                    return twoOfClubs;
                }
                else
                {
                    return LeadCard();
                }
            }
            // If it's not the first card of the trick
            else
            {
                // Determine the leading suit of the trick
                string leadingSuit = currentTrick[0].Suit;
                // Get playable cards based on the leading suit
                var playableCards = GetPlayableCards(leadingSuit);
                // If no playable cards are available
                if (playableCards.Count == 0)
                {
                    // If hearts are not broken or the player has non-heart cards, play a random non-heart card
                    var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
                    if (!heartsBroken || nonHeartCards.Count > 0)
                    {
                        return RandomCardWOHearts();
                    }
                    // If hearts are broken and the player has only hearts, play a random card
                    else
                    {
                        return RandomCard();
                    }
                }
                // If playable cards are available, play the lowest valued playable card
                else
                {
                    return playableCards.OrderBy(card => card.Value).First();
                }
            }
        }

        // Method to select a card to lead with
        private Card LeadCard()
        {
            // Get non-heart cards from the player's hand
            var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
            // If non-heart cards are available, play the lowest valued non-heart card
            if (nonHeartCards.Count > 0)
            {
                return nonHeartCards.OrderBy(card => card.Value).First();
            }
            // If the player only has hearts, play the lowest valued heart card
            else
            {
                return playerHand.OrderBy(card => card.Value).First();
            }
        }

        // Method to get playable cards based on the leading suit
        private List<Card> GetPlayableCards(string suit)
        {
            // Get cards from the player's hand that match the leading suit
            var matchingSuitCards = playerHand.Where(card => card.Suit == suit).ToList();
            // If no cards match the leading suit, return an empty list
            if (matchingSuitCards.Count == 0)
            {
                return new List<Card>();
            }
            // Get non-heart cards among the matching suit cards
            var nonHeartCards = matchingSuitCards.Where(card => card.Suit != "Hearts").ToList();
            // If non-heart cards are available, return them
            if (nonHeartCards.Count > 0)
            {
                return nonHeartCards;
            }
            // If only heart cards match the leading suit, return all matching suit cards
            else
            {
                return matchingSuitCards;
            }
        }

        // Method to select a random card from the player's hand
        private Card RandomCard()
        {
            return playerHand[AIRandom.Next(playerHand.Count)];
        }

        // Method to select a random non-heart card from the player's hand
        private Card RandomCardWOHearts()
        {
            return playerHand[AIRandom.Next(playerHand.Count)];
        }
    }
}
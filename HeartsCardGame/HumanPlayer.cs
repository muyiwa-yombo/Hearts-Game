/* Program Name: Hearts Game
   Program Description: This is the HumanPlayer Class for this Hearts Game
   File Name: HumanPlayer.cs
   Program Authors: Group 5 
   Program Date: April 1st, 2024
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HeartsCardGame
{
    // HumanPlayer class inherits the Player Class 

    internal class HumanPlayer : Player
    {
        // Field to store the card currently in play
        private Card cardInPlay = null;

        // Constructor for human player, initializes player name and current card in play
        public HumanPlayer(string newPlayerName) : base(newPlayerName)
        {
            cardInPlay = null;
        }

        // Property for accessing and modifying the current card in play
        protected internal Card CardInPlay
        {
            get { return cardInPlay; }
            set { cardInPlay = value; }
        }

        // Method for human player to play a card
        public override Card PlayCard(List<Card> currentRound, bool heartsBroken)
        {
            // This method should not be called for human player
            throw new NotImplementedException(); 
        }

        // Method for human player to play a card based on user input
        public Card PlayCard(Control control, List<Button> cardButtons, List<Card> currentTrick, bool heartsBroken)
        {
            // Get non-heart cards from the player's hand
            var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
            // Disable all card buttons initially
            DisableCards(control, cardButtons);

            // If the first card of the trick
            if (currentTrick.Count == 0)
            {
                // Check if the player has the Two of Clubs
                Card twoOfClubs = playerHand.Find(card => card.Value == 2 && card.Suit == "Clubs");
                // If the player has the Two of Clubs, enable only the Two of Clubs button
                if (twoOfClubs != null)
                {
                    EnableCards(control, cardButtons, ForceTwoOfClubs(playerHand));
                    return cardInPlay;
                }
                // If hearts are not broken or the player has non-heart cards, enable all non-heart cards
                else if (!heartsBroken || nonHeartCards.Count > 0)
                {
                    EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                    return cardInPlay;
                }
                // If hearts are broken and the player has only heart cards, enable all cards
                else
                {
                    EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                    return cardInPlay;
                }
            }
            // else if not the first card of the trick
            else
            {
                // Determine the leading suit of the trick
                string leadingSuit = currentTrick[0].Suit;
                // Get cards from the player's hand that match the leading suit
                List<Card> matchingSuits = playerHand.Where(card => card.Suit == leadingSuit).ToList();
                // If the player has no cards matching the leading suit
                if (matchingSuits.Count == 0)
                {
                    // If hearts are not broken or the player has non-heart cards, enable all cards
                    if (!heartsBroken || nonHeartCards.Count > 0)
                    {
                        EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                        return cardInPlay;
                    }
                    // If hearts are broken and the player has only heart cards, enable all cards
                    else
                    {
                        EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                        return cardInPlay;
                    }
                }
                // If the player has cards matching the leading suit, enable those cards
                else
                {
                    EnableCards(control, cardButtons, ValidateCards(playerHand, leadingSuit));
                    return cardInPlay;
                }
            }
        }

        // Method to validate cards based on suit
        private List<Card> ValidateCards(List<Card> hand, string suit)
        {
            return hand.Where(card => card.Suit == suit).ToList();
        }

        // Method to validate cards based on whether hearts are broken
        private List<Card> ValidateCards(List<Card> hand, bool hearts)
        {
            if (hearts)
            {
                return hand;
            }
            else
            {
                return hand.Where(card => card.Suit != "Hearts").ToList();
            }
        }

        // Method to force selection of the Two of Clubs
        private List<Card> ForceTwoOfClubs(List<Card> hand)
        {
            return hand.Where(card => card.Value == 2 && card.Suit == "Clubs").ToList();
        }

        // Method to disable all card buttons
        public void DisableCards(Control control, List<Button> cardButtons)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => DisableCards(control, cardButtons)));
                return;
            }
            foreach (var button in cardButtons)
            {
                button.Enabled = false;
            }
        }

        // Method to enable valid card buttons
        private void EnableCards(Control control, List<Button> cardButtons, List<Card> validHand)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => EnableCards(control, cardButtons, validHand)));
                return;
            }
            // Enable buttons corresponding to valid cards
            for (var i = 0; i < validHand.Count; i++)
            {
                foreach (var button in cardButtons)
                {
                    if (button.Name == validHand[i].NameButton())
                    {
                        button.Enabled = true;
                    }
                }
            }
        }
    }
}

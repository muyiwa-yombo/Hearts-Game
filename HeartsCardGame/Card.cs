/* Program Name: Hearts Game
   Program Description: This is the Card Class for this Hearts Game
   File Name: Card.cs
   Program Authors: Group 5
   Program Date: April 1st, 2024
*/

using System;

namespace HeartsCardGame
{
    internal class Card
    {
        // Fields to store card suit, value, and point value
        private string cardSuit;
        private int cardValue;
        private int pointValue;

        // Default constructor
        public Card()
        {
        }

        // Constructor with parameters to initialize card properties
        public Card(string assignedSuit, int assignedValue, int cardPointValue)
        {
            cardSuit = assignedSuit;
            cardValue = assignedValue;
            pointValue = cardPointValue;
        }

        // Property for accessing and modifying card suit
        protected internal string Suit
        {
            get { return cardSuit; }
            set { cardSuit = value; }
        }

        // Property for accessing and modifying card value
        protected internal int Value
        {
            get { return cardValue; }
            set { cardValue = value; }
        }

        // Property for accessing and modifying card point value
        protected internal int PointValue
        {
            get { return pointValue; }
            set { pointValue = value; }
        }

        // Override of ToString method to display card details
        public override string ToString()
        {
            string cardString;
            string cardValueString;
            // Convert numeric card values to corresponding strings
            switch (Value)
            {
                case 11:
                    cardValueString = "Jack";
                    break;
                case 12:
                    cardValueString = "Queen";
                    break;
                case 13:
                    cardValueString = "King";
                    break;
                case 14:
                    cardValueString = "Ace";
                    break;
                default:
                    cardValueString = Value.ToString();
                    break;
            }
            // Construct card representation string
            cardString = cardValueString + " of " + Suit;
            return cardString;
        }

        // Method to generate a name for a button based on card suit and value
        public string NameButton()
        {
            string buttonName = Suit + Value.ToString() + "Button";
            return buttonName;
        }
    }
}

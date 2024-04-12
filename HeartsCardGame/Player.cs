/* Program Name: Hearts Game
   Program Description: This is the Player Class for this Hearts Game
   File Name: Player.cs
   Program Authors: Group 5 
   Program Date: April 1st, 2024
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HeartsCardGame
{
    // abstract class player 
    internal abstract class Player
    {
        // Fields to store player information
        protected string playerName;
        protected List<Card> playerHand;
        protected int playerPoints;

        // Setting a default constructor
        public Player()
        {
        }

        // Constructor to initialize player with a name
        public Player(string newPlayerName)
        {
            playerName = newPlayerName;
            playerHand = new List<Card>();
            playerPoints = 0;
        }

        // Constructor to initialize player with a name, hand, and points
        public Player(string newPlayerName, List<Card> newPlayerHand, int newPlayerPoints)
        {
            playerName = newPlayerName;
            playerHand = newPlayerHand;
            playerPoints = newPlayerPoints;
        }

        // Property for accessing and modifying player name
        protected internal string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        // Property for accessing and modifying player hand
        protected internal List<Card> PlayerHand
        {
            get { return playerHand; }
            set { playerHand = value; }
        }

        // Property for accessing and modifying player points
        protected internal int PlayerPoints
        {
            get { return playerPoints; }
            set { playerPoints = value; }
        }

        // Method to add a card to the player's hand
        public void AddCard(Card card)
        {
            playerHand.Add(card);
        }

        // Method to remove a card from the player's hand
        public void RemoveCard(Card card)
        {
            playerHand.Remove(card);
        }

        // Abstract method for playing a card
        public abstract Card PlayCard(List<Card> currentRound, bool heartsBroken);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Hearts
{
    public class Trick
    {
        public List<Card> CardsPlayed { get; set; }
        public Player Winner { get; set; }
        public Suit LeadingSuit { get; set; }
        public bool HeartsBroken { get; set; }

        public Trick()
        {
            CardsPlayed = new List<Card>();
            Winner = null;
            HeartsBroken = false;
           
        }

        public void AddCard(Card card, Player player)
        {
            if (CardsPlayed.Count == 0)
            {
                LeadingSuit = card.Suit;
            }

            if (card.Suit == Suit.Hearts || (card.Suit == Suit.Spades && card.Value == 12)) // Queen of Spades is value 12
            {
                HeartsBroken = true;
            }

        }

        public void DetermineWinner(List<Player> players)
        {
            if (CardsPlayed.Count == players.Count) // Ensure all players have played
            {
                Card winningCard = CardsPlayed
                    .Where(card => card.Suit == LeadingSuit)
                    .OrderByDescending(card => card.Value)
                    .FirstOrDefault();

                if (winningCard != null)
                {
                    int winningIndex = CardsPlayed.IndexOf(winningCard);
                    Winner = players[winningIndex];
                }
            }
        }
    }
}

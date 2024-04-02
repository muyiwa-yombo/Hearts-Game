using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    public class Trick
    {
        public List<Card> CardsPlayed { get; private set; }
        public Player Winner { get; private set; }
        public Suit LeadingSuit { get; private set; }
        public bool HeartsBroken { get; private set; }

        public Trick()
        {
            CardsPlayed = new List<Card>();
            HeartsBroken = false;
        }

        public void AddCard(Card card, Player player)
        {
            if (CardsPlayed.Count == 0)
            {
                LeadingSuit = card.Suit;
            }

            if (card.Suit == Suit.Hearts)
            {
                HeartsBroken = true;
            }

            CardsPlayed.Add(card);
        }

        public void DetermineWinner(List<Player> players)
        {
            if (CardsPlayed.Count == 4)
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

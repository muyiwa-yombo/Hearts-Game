using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> CollectedCards { get; set; } // Cards collected in the current round
        public int Score { get; set; } // Total score across all rounds
        public int RoundScore { get; set; } // Score for the current round

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            CollectedCards = new List<Card>();
            Score = 0;
            RoundScore = 0;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public Card PlayCard(int cardIndex)
        {
            Console.WriteLine("this is card index "+ cardIndex);
            if (cardIndex >= 0 && cardIndex <= Hand.Count)
            {
                if(cardIndex == Hand.Count)
                    cardIndex = Hand.Count - 1;
                Card card = Hand[cardIndex];
                Hand.RemoveAt(cardIndex);
                return card;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(cardIndex), "Invalid card index");
            }
        }

        public Player DetermineRoundWinner(Trick currentTrick, List<Player> players)
        {
            Card winningCard = null;
            Player roundWinner = null;

            for (int i = 0; i < currentTrick.CardsPlayed.Count; i++)
            {
                Card card = currentTrick.CardsPlayed[i];
                if (winningCard == null || (card.Suit == currentTrick.LeadingSuit && card.Value > winningCard.Value))
                {
                    winningCard = card;
                    roundWinner = players[i]; // Assuming the order of cards played matches the order of players
                }
            }

            return roundWinner;
        }
    }


}

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
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            Score = 0;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public Card PlayCard(int cardIndex)
        {
            if (cardIndex >= 0 && cardIndex < Hand.Count)
            {
                Card card = Hand[cardIndex];
                Hand.RemoveAt(cardIndex);
                return card;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid card index");
            }
        }
    }

}

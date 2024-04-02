using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int value = 2; value <= 14; value++)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public Card DealCard()
        {
            if (cards.Count > 0)
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
            else
            {
                throw new InvalidOperationException("Deck is empty");
            }
        }
    }

}

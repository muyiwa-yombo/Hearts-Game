using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public int Value { get; set; }

        public Card(Suit suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            string valueString;
            switch (Value)
            {
                case 11:
                    valueString = "Jack";
                    break;
                case 12:
                    valueString = "Queen";
                    break;
                case 13:
                    valueString = "King";
                    break;
                case 14:
                    valueString = "Ace";
                    break;
                default:
                    valueString = Value.ToString();
                    break;
            }

            return $"{valueString} of {Suit}";
        }
    }

}

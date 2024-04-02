using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    public class Scoring
    {
        public static int CalculateScore(Trick trick)
        {
            int score = 0;

            foreach (Card card in trick.CardsPlayed)
            {
                if (card.Suit == Suit.Hearts)
                {
                    score += 1;
                }
                else if (card.Suit == Suit.Spades && card.Value == 12) // Value 12 represents the Queen
                {
                    score += 13;
                }
            }

            return score;
        }

        public static int CalculateTotalScore(List<Trick> tricks)
        {
            int totalScore = 0;
            foreach (Trick trick in tricks)
            {
                totalScore += CalculateScore(trick);
            }
            return totalScore;
        }
    }

}

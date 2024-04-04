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

        public static void UpdateScores(List<Player> players, List<Trick> tricks)
        {
            int totalHearts = 0;
            int totalQueenSpades = 0;
            foreach (Trick trick in tricks)
            {
                Player winner = trick.Winner;
                int trickScore = CalculateScore(trick);
                winner.CollectedCards.AddRange(trick.CardsPlayed); // Assuming Player has a CollectedCards property
                winner.RoundScore += trickScore; // Assuming Player has a RoundScore property

                // Count total hearts and Queen of Spades for shooting the moon
                totalHearts += trick.CardsPlayed.Count(card => card.Suit == Suit.Hearts);
                totalQueenSpades += trick.CardsPlayed.Count(card => card.Suit == Suit.Spades && card.Value == 12);
            }

            // Check for Shooting the Moon
            bool shotTheMoon = totalHearts == 13 && totalQueenSpades == 1;
            if (shotTheMoon)
            {
                foreach (Player player in players)
                {
                    if (player.RoundScore == 26) // The player who shot the moon
                    {
                        player.Score += 0; // Shooting the moon results in zero points for the round
                    }
                    else
                    {
                        player.Score += 26; // Other players receive 26 points
                    }
                    player.RoundScore = 0; // Reset round score for next round
                }
            }
            else
            {
                foreach (Player player in players)
                {
                    player.Score += player.RoundScore; // Add round score to total score
                    player.RoundScore = 0; // Reset round score for next round
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearts
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; }
        public List<Trick> Tricks { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public int ScoreLimit { get; set; }
        public Player Winner { get; private set; }

        public Game(List<string> playerNames, int scoreLimit)
        {
            Players = new List<Player>();
            foreach (var name in playerNames)
            {
                Players.Add(new Player(name));
            }

            Deck = new Deck();
            Tricks = new List<Trick>();
            CurrentPlayerIndex = 0;
            ScoreLimit = scoreLimit;
        }

        public void StartGame()
        {
            Deck.Shuffle();
            DealCards();
            // Start the first trick
            PlayTrick();
        }

        private void DealCards()
        {
            for (int i = 0; i < 13; i++)
            {
                foreach (var player in Players)
                {
                    player.AddCardToHand(Deck.DealCard());
                }
            }
        }

        public void PlayTrick()
        {
            Trick trick = new Trick();

            for (int i = 0; i < Players.Count; i++)
            {
                // Assume PlayCard returns the card the player wants to play
                Card card = Players[CurrentPlayerIndex].PlayCard(0); // You'll need to implement PlayCard
                trick.AddCard(card, Players[CurrentPlayerIndex]);
                CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
            }

            // Determine the winner of the trick and update scores
            // You'll need to implement logic to determine the winner based on the rules of Hearts
            Player winner = trick.Winner;
            winner.Score += Scoring.CalculateScore(trick);

            Tricks.Add(trick);

            // Check if any player has reached the score limit
            if (Players.Any(player => player.Score >= ScoreLimit))
            {
                EndGame();
            }
            else
            {
                PlayTrick();
            }
        }

        private void EndGame()
        {
            // Determine the winner of the game based on the lowest score
            Winner = Players.OrderBy(player => player.Score).FirstOrDefault();
            // Handle the end of the game (e.g., display the winner, reset the game, etc.)
        }
    }

}

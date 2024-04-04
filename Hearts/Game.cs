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

    public Trick CurrentTrick { get; set; } // Add this line
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
        CurrentPlayerIndex = 1;
        ScoreLimit = scoreLimit;
    }

        public bool IsRoundOver()
        {
            // Check if all players have no cards left in their hands
            return Players.All(player => player.Hand.Count == 0);
        }

        public void StartGame()
    {
        Deck.Shuffle();
        DealCards();
            // Start the first trick
        DetermineStartingPlayer();
            PlayTrick();

        }

        public void UpdateScores()
        {
            foreach (var player in Players)
            {
                player.Score += player.CollectedCards.Count(card => card.Suit == Suit.Hearts);
                if (player.CollectedCards.Any(card => card.Suit == Suit.Spades && card.Value == 12))
                {
                    player.Score += 13;
                }
            }
        }

        public bool IsGameOver()
        {
            // Check if any player has reached or exceeded the score limit
            return Players.Any(player => player.Score >= ScoreLimit);
        }



        public void PlayTrick()
    {
            CurrentTrick = new Trick();

            for (int i = 0; i < Players.Count; i++)
            {
                Card card = Players[CurrentPlayerIndex].PlayCard(0); // Implement PlayCard in Player class
                CurrentTrick.AddCard(card, Players[CurrentPlayerIndex]);
                NextPlayer();
            }

            if (CurrentTrick.Winner != null)
            {
                CurrentTrick.DetermineWinner(Players);
                Player winner = CurrentTrick.Winner;
                winner.CollectedCards.AddRange(CurrentTrick.CardsPlayed); // Assuming Player has a CollectedCards property
                Tricks.Add(CurrentTrick);

                if (IsRoundOver())
                {
                    Scoring.UpdateScores(Players,Tricks);
                    if (IsGameOver())
                    {
                        EndGame();
                    }
                    else
                    {
                        StartNewRound();
                    }
                }
            }
        }

    private void EndGame()
    {

            Winner = Players.OrderBy(player => player.Score).FirstOrDefault();
    }
        public void NextPlayer()
        {
            // Move to the next player's turn
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
        }

        public void DealCards()
        {
            Deck.Shuffle();
            int cardsPerPlayer = Deck.cards.Count / Players.Count;

            for (int i = 0; i < cardsPerPlayer; i++)
            {
                foreach (var player in Players)
                {
                    player.AddCardToHand(Deck.DealCard());
                }
            }
        }
        public void DetermineStartingPlayer()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Hand.Any(card => card.Suit == Suit.Clubs && card.Value == 2))
                {
                    CurrentPlayerIndex = i;
                    break;
                }
            }
        }

        public void StartNewRound()
        {
            // Reset the game state for a new round
            foreach (var player in Players)
            {
                player.Hand.Clear();
                player.CollectedCards.Clear();
            }
            Deck.Shuffle();
            DealCards();
            // Determine the starting player for the new round
            // For example, the player holding the two of clubs
        }

        public Player DetermineRoundWinner(Trick currentTrick)
        {
            Card winningCard = null;
            Player roundWinner = null;


            for (int i = 0; i < currentTrick.CardsPlayed.Count; i++)
            {
                Card card = currentTrick.CardsPlayed[i];
                if (winningCard == null || (card.Suit == currentTrick.LeadingSuit && card.Value > winningCard.Value))
                {
                    winningCard = card;
                    roundWinner = Players[i]; // Assuming the order of cards played matches the order of players
                }
            }

            return roundWinner;
        }

        public void CompleteTrick()
        {



            // Display the round winner in the UI
            Player winner = CurrentTrick.Winner;
            winner.CollectedCards.AddRange(CurrentTrick.CardsPlayed);
            UpdateScores();

            // Prepare for the next trick
            CurrentTrick = new Trick();
            CurrentPlayerIndex = Players.IndexOf(winner); // The winner starts the next trick
        }

        public Player DetermineGameWinner()
        {
            return Players.OrderBy(player => player.Score).First();
        }



    }



}

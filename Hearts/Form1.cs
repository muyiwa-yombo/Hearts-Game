using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hearts
{
    public partial class Form1 : Form
    {

        private Game game;
        private List<ComboBox> cardSelectors;
        public Form1()
        {
            InitializeComponent();
            cardSelectors = new List<ComboBox> { cardList1, cardList2, cardList3, cardList4 };

        }

        private void StartNewGame()
        {
            // Initialize the game with player names and a score limit
            game = new Game(new List<string> { player1.Text, player2.Text, player3.Text, player4.Text }, 100);
            game.StartGame();

            // Update the UI with the dealt cards
            UpdatePlayerHandsUI();
        }

        private void UpdatePlayerHandsUI()
        {
            for (int i = 0; i < game.Players.Count; i++)
            {
                cardSelectors[i].Items.Clear();
                foreach (var card in game.Players[i].Hand)
                {
                    cardSelectors[i].Items.Add(card.ToString());
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        // Method to check if a string contains numbers
        private bool ContainsNumbers(string input)
        {
            return input.Any(char.IsDigit);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void startPlayer_Click(object sender, EventArgs e)
        {
            // Perform validation for player names
            // Check for duplicate names
            List<string> playerNames = new List<string>
    {
        player1.Text,
        player2.Text,
        player3.Text,
        player4.Text
    };

            if (playerNames.Distinct().Count() < 4)
            {
                // Display an error message if there are duplicate names
                MessageBox.Show("Please enter unique names for all players.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any of the player name textboxes are empty or contain numbers
            if (ContainsNumbers(player1.Text) ||
                ContainsNumbers(player2.Text) ||
                ContainsNumbers(player3.Text) ||
                ContainsNumbers(player4.Text))
            {
                // Display an error message if any player name contains numbers
                MessageBox.Show("Please enter a valid name for all players (No numbers please)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any of the player name textboxes are empty
            if (string.IsNullOrWhiteSpace(player1.Text) ||
                string.IsNullOrWhiteSpace(player2.Text) ||
                string.IsNullOrWhiteSpace(player3.Text) ||
                string.IsNullOrWhiteSpace(player4.Text))
            {
                // Display an error message if any player name is empty
                MessageBox.Show("Please enter a name for all players.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            game = new Game(playerNames, 100);

            // Transfer player names to game setup textboxes
            gameSetup1.Text = player1.Text;
            gameSetup2.Text = player2.Text;
            gameSetup3.Text = player3.Text;
            gameSetup4.Text = player4.Text;

            // Clear player name textboxes
            player1.Text = "";
            player2.Text = "";
            player3.Text = "";
            player4.Text = "";

            player1.Enabled = false;
            player2.Enabled = false;
            player3.Enabled = false;
            player4.Enabled = false;
            startPlayer.Enabled = false;

            cardList1.Enabled = true;
            cardList2.Enabled = true;
            cardList3.Enabled = true;
            cardList4.Enabled = true;


            
            // Enable "Deal 13 Cards" button and game setup textboxes
            DealCards.Enabled = true;

        }

        private void startGame_Click(object sender, EventArgs e)
        {
            game.StartGame();
            EnableCardSelectionForCurrentPlayer();
            button6.Enabled = true;

        }

        private void reShuffleCards_Click(object sender, EventArgs e)
        {
            // Shuffle the deck
            ShuffleDeck();

            // Re-deal the shuffled cards to players

        }

        private void dealCards(object sender, EventArgs e)
        {
            game.DealCards();
            UpdatePlayerHandsUI();
            startGame.Enabled = true;
            reShuffleCards.Enabled = true;
            
        }

        private void EnableCardSelectionForCurrentPlayer()
        {
            int currentPlayerIndex = game.CurrentPlayerIndex;
            foreach (var comboBox in cardSelectors)
            {
                comboBox.Enabled = false; // Disable all ComboBoxes
            }
            cardSelectors[currentPlayerIndex].Enabled = true; // Enable the ComboBox for the current player
        }

        private List<string> deck;

        // Method to initialize the deck with a standard set of 52 cards
        private void InitializeDeck()
        {
            deck = new List<string>();

            // Add all cards to the deck
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add(rank + " of " + suit);
                }
            }
        }

        // Shuffle the deck
        private void ShuffleDeck()
        {
            game.DealCards();
            UpdatePlayerHandsUI();
        }

        private void UpdatePlayerHandUI(int playerIndex, List<string> playerHand)
        {
            // Get the corresponding ComboBox for the player
            for (int i = 0; i < game.Players.Count; i++)
            {
                cardSelectors[i].Items.Clear();
                foreach (var card in game.Players[i].Hand)
                {
                    cardSelectors[i].Items.Add(card.ToString());
                }
            }
        }

        private void Game_GameEnded(object sender)
        {
            MessageBox.Show($"{game.Winner.Name} wins with a score of {game.Winner.Score}!", "Game Over");
            var playAgain = MessageBox.Show("Do you want to play another round?", "Game Over", MessageBoxButtons.YesNo);
            if (playAgain == DialogResult.Yes)
            {
                StartNewGame();
            }
            else
            {
                Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int playerIndex = game.CurrentPlayerIndex;
            ComboBox currentPlayerCardList = cardSelectors[playerIndex];
            int cardIndex = currentPlayerCardList.SelectedIndex;
            
            if (cardIndex >= 0  && !game.IsGameOver())
            {
                // Play the selected card
                Card playedCard = game.Players[playerIndex].PlayCard(cardIndex);


                // Add the played card to the current trick
                game.CurrentTrick.CardsPlayed.Add(playedCard);
                game.CurrentTrick.AddCard(playedCard, game.Players[playerIndex]);

                UpdatePlayedCardUI(playerIndex, playedCard);
                
                // Check if the trick is complete (all players have played a card)
                if (game.CurrentTrick.CardsPlayed.Count == game.Players.Count)
                {
                    // Determine the winner of the trick
                    game.CurrentTrick.DetermineWinner(game.Players);

                    // Display the round winner in the UI
                    DisplayRoundWinner(game.CurrentTrick.Winner);
                 
                    
                    // Move to the next player's turn
                    game.NextPlayer();
                    UpdateTurnIndicatorUI();

                    // Prepare for the next trick
                    game.Tricks.Add(game.CurrentTrick);
                    game.CurrentTrick = new Trick();

                    Scoring.UpdateScores(game.Players, game.Tricks);
                    UpdateScoreDisplay();
                }
                else
                {
                    // Move to the next player's turn
                    game.NextPlayer();
                    UpdateTurnIndicatorUI();
                }
            }
            else
            {
                MessageBox.Show("Please select a card to play.");
            }
        }

        private void UpdatePlayedCardUI(int playerIndex, Card playedCard)
        {
            // Update the UI to show the played card
            // For example, remove the played card from the player's ComboBox
            ComboBox currentPlayerCardList = cardSelectors[playerIndex];
            currentPlayerCardList.Items.RemoveAt(currentPlayerCardList.SelectedIndex);
            currentPlayerCardList.SelectedIndex = -1;

            // Additional UI updates to show the played card on the game board
        }

        private void UpdateTurnIndicatorUI()
{
    // Update the UI to indicate whose turn it is
    // For example, highlight the current player's UI elements
    foreach (var cardList in cardSelectors)
    {
        cardList.Enabled = false; // Disable all card selectors
    }
    cardSelectors[game.CurrentPlayerIndex].Enabled = true; // Enable the current player's card selector
}
        private void DisplayWinner(Player winner)
        {
            // Update the UI to show the winner's information
            richTextBox1.Text = $"{winner.Name} wins the game with a score of {winner.Score}!";

            // Optionally, ask the user if they want to play another game
            var playAgain = MessageBox.Show("Do you want to play another game?", "Play Again", MessageBoxButtons.YesNo);
            if (playAgain == DialogResult.Yes)
            {
                // Reset the game and UI for a new game
                
            }
            else
            {
                // Close the application or perform other cleanup
                this.Close();
            }
        }

        private void StartNewRound()
        {
            game.StartNewRound();
            UpdatePlayerHandsUI();
        }

        private void StartNextTrick()
        {
            game.CurrentTrick = new Trick();
            EnableCardSelectionForCurrentPlayer();
        }

        private void CompleteTrick()
        {
            // Update scores and collect cards
            game.UpdateScores();
            foreach (var player in game.Players)
            {
                player.CollectedCards.AddRange(game.CurrentTrick.CardsPlayed);
            }

            // Clear the current trick for the next one
            game.CurrentTrick.CardsPlayed.Clear();
        }

        private void DisplayRoundWinner(Player winner)
        {
            Console.WriteLine(winner.Name);
            MessageBox.Show($"{winner.Name} wins the round!");
            richTextBox1.Text += winner.Name + " wins the round";
            
            // If you have a label to display the round winner, you can update it like this:
            // roundWinnerLabel.Text = $"{winner.Name} wins the round!";
        }

        private void UpdateScoreDisplay()
        {
            score1Box.Text = game.Players[0].Score.ToString();
            score2Box.Text = game.Players[1].Score.ToString();
            score3Box.Text = game.Players[2].Score.ToString();
            score4Box.Text = game.Players[3].Score.ToString();

            score1.Text = game.Players[0].Name;
            score2.Text = game.Players[1].Name;
            score3.Text = game.Players[2].Name;
            score4.Text = game.Players[3].Name;
        }
    }
}

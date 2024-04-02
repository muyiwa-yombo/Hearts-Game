using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hearts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
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

        }

        private void reShuffleCards_Click(object sender, EventArgs e)
        {
            // Shuffle the deck
            ShuffleDeck();

            // Re-deal the shuffled cards to players
            dealCards_Click(sender, e)
        }

        private void dealCards(object sender, EventArgs e)
        {
            // Initialize the deck
            InitializeDeck();

            // Shuffle the deck
            ShuffleDeck();

            // Determine the number of cards to deal to each player
            int cardsPerPlayer = deck.Count / 4;

            // Deal cards to each player
            for (int i = 0; i < 4; i++)
            {
                // Get the appropriate range of cards for the current player
                List<string> playerHand = deck.GetRange(i * cardsPerPlayer, cardsPerPlayer);

                // Update the UI to display the player's hand in the corresponding ComboBox
                UpdatePlayerHandUI(i, playerHand);
            }
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
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        private void UpdatePlayerHandUI(int playerIndex, List<string> playerHand)
        {
            // Get the corresponding ComboBox for the player
            ComboBox comboBox = null;
            switch (playerIndex)
            {
                case 0:
                    comboBox = cardList1;
                    break;
                case 1:
                    comboBox = cardList2;
                    break;
                case 2:
                    comboBox = cardList3;
                    break;
                case 3:
                    comboBox = cardList4;
                    break;
            }

            // Clear the ComboBox before adding new cards
            comboBox.Items.Clear();

            // Add the cards to the ComboBox
            foreach (string card in playerHand)
            {
                comboBox.Items.Add(card);
            }
        }
    }
}

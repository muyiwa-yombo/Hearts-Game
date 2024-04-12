/* Program Name: Hearts Game
   Program Description: This is the Form Class for this Hearts Game
   File Name: Form.cs
   Program Authors: Group 5 
   Program Date: April 1st, 2024
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeartsCardGame
{
    public partial class HeartsGame : Form
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(0);
        private int trickCount = 0;
        private int handCount = 0;
        private int currentIndex = 0;
        private Deck gameDeck = new Deck();
        private HumanPlayer user = new HumanPlayer("You");
        private List<Player> players;
        private List<Button> CardButtons = new List<Button>();
        private List<Button> trickList = new List<Button>();
        private List<Card> currentTrick = new List<Card>();
        private int winningPoints;
        private string leadingSuit;
        private bool twoPlayerMode = false;
        private bool heartsBroken = false;

        public HeartsGame()
        {
            InitializeComponent();
            GameSetup();
            // attach the KeyDown event handler to the form
            this.KeyDown += (windowTitle_KeyDown);
        }

        private void SetDefaults()
        {
            DeleteTrick(trickList);
            DeleteTrick(CardButtons);
            trickCount = 0;
            handCount = 0;
            currentIndex = 0;
            GameSetup();
        }

        private void GameSetup()
        {
            gameDeck.BuildDeck();
            players = new List<Player>
            {
                user,
                new AIPlayer("AI Player 1"),
                new AIPlayer("AI Player 2"),
                new AIPlayer("AI Player 3")
            };
            Player1Label.Text = players[0].PlayerName + ":";
            Player2Label.Text = players[1].PlayerName + ":";
            if (!twoPlayerMode)
            {
                Player3Label.Text = players[2].PlayerName + ":";
                Player4Label.Text = players[3].PlayerName + ":";
            }
            DealCards();
            DisplayHand(user);
            int startIndex = FindLead(players);
            currentIndex = startIndex;
        }

        private void DisplayHand(HumanPlayer humanPlayer)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayHand(humanPlayer)));
                return;
            }

            HandFlowLayoutPanel.Controls.Clear(); // Clear existing card buttons
            var sortedHand = humanPlayer.PlayerHand.OrderBy(card => card.Suit).ThenBy(card => card.Value);
            foreach (Card card in sortedHand)
            {
                Button button = new Button();
                button.Text = card.ToString();
                button.Size = new Size(75, 125);
                button.Name = card.NameButton();
                button.Click += (sender, e) => SelectCard(button);
                button.Enabled = false;
                HandFlowLayoutPanel.Controls.Add(button);
                CardButtons.Add(button);
            }
           
            }
        

        private void DeleteCardFromHand(List<Button> cardButtons, Card cardToDelete)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DeleteCardFromHand(cardButtons, cardToDelete)));
                return;
            }
            foreach (Button button in cardButtons)
            {
                if (button.Name == cardToDelete.NameButton())
                {
                    if (button.Parent != null)
                    {
                        button.Parent.Controls.Remove(button);
                        button.Dispose();
                    }
                }
            }
        }

        private void ShowTrick(List<Card> trick)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowTrick(trick)));
                return;
            }
            foreach (Card card in trick)
            {
                Button button = new Button();
                button.Text = card.ToString();
                button.Size = new Size(75, 125);
                button.Name = card.NameButton();
                button.Enabled = false;
                TrickFlowLayoutPanel.Controls.Add(button);
                trickList.Add(button);
            }
        }

        private void DeleteTrick(List<Button> trickCards)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DeleteTrick(trickCards)));
                return;
            }
            foreach (Button button in trickCards)
            {
                if (button.Parent != null)
                {
                    button.Parent.Controls.Remove(button);
                    button.Dispose();
                }
            }
        }

        private void DealCards()
        {
           
            foreach (Player player in players)
            {
                if (twoPlayerMode == true)
                {
                    for (int I = 0; I < 26; I++)
                    {
                        player.AddCard(gameDeck.Deal());
                    }
                }
                else
                {
                    for (int I = 0; I < 13; I++)
                    {
                        player.AddCard(gameDeck.Deal());
                    }
                }
            }
        }

        private int FindLead(List<Player> players)
        {
            for (int index = 0; index < players.Count; index++)
            {
                Player player = players[index];
                Card twoOfClubs = player.PlayerHand.Find(card => card.Value == 2 && card.Suit == "Clubs");
                if (twoOfClubs != null)
                {
                    Console.WriteLine("Lead Has Been Found");
                    return index;
                }
            }
            return -1;
        }

        private async void CommenceGameplay()
        {
            bool winnerFound = false;
            Console.WriteLine("Entering While Loop");
            await Task.Run(async () =>
            {
                while (!winnerFound)
                {
                    await PlayTrick();
                    foreach (Player player in players)
                    {
                        if (player.PlayerPoints >= 100)
                        {
                            winnerFound = true;
                            break;
                        }
                    }
                }
            });
        }

        private async Task PlayTrick()
        {
            Card card;
            for (int index = 0; index < players.Count; index++)
            {
                Console.WriteLine("Playing Trick Number: " + (index + 1).ToString());
                card = await PlayCard(players[currentIndex]);
                currentTrick.Add(card);
                DeleteTrick(trickList);
                ShowTrick(currentTrick);
                if (leadingSuit == null)
                {
                    leadingSuit = card.Suit;
                }
                if (card.Suit == "Hearts")
                {
                    heartsBroken = true;
                }
                currentIndex = (currentIndex + 1) % players.Count;
            }
            DetermineTrickWinner();
        }

        private async Task<Card> PlayCard(Player player)
        {
            if (player.PlayerName == user.PlayerName)
            {
                Console.WriteLine("Human Player Turn");
                user.PlayCard(this, CardButtons, currentTrick, heartsBroken);
                await WaitForPlayerInput();
                return user.CardInPlay;
            }
            else
            {
                Console.WriteLine("AI Player Turn");
                await Task.Delay(2500);
                return player.PlayCard(currentTrick, heartsBroken);
            }
        }

        private async Task WaitForPlayerInput()
        {
            await semaphore.WaitAsync();
        }

        private void SelectCard(Button button)
        {
            foreach (Card card in user.PlayerHand)
            {
                if (button.Name == card.NameButton())
                {
                    user.CardInPlay = card;
                    semaphore.Release();
                }
            }
        }

        private void DetermineTrickWinner()
        {
            trickCount++;
            string winningSuit = leadingSuit;
            Card winningCard = currentTrick[0];
            winningPoints = 0;
            Player winningPlayer = null;
            foreach (Card card in currentTrick)
            {
                if (card.Suit == winningSuit && card.Value > winningCard.Value)
                {
                    winningCard = card;
                }
            }
            foreach (Card card in currentTrick)
            {
                winningPoints += card.PointValue;
            }
            winningPlayer = players.Find(player => player.PlayerHand.Contains(winningCard));
            winningPlayer.PlayerPoints += winningPoints;
            currentIndex = players.FindIndex(player => player.PlayerHand.Contains(winningCard));
            this.Invoke((MethodInvoker)delegate
            {
                MessageLabel.Text = winningPlayer.PlayerName + " Won The Trick With A Total Of " + winningPoints + " Points!";
            });
            foreach (Player player in players)
            {
                foreach (Card cardInQuestion in currentTrick)
                {
                    Card cardToDelete = player.PlayerHand.Find(card => card.Suit == cardInQuestion.Suit && card.Value == cardInQuestion.Value);
                    if (cardToDelete != null)
                    {
                        player.RemoveCard(cardToDelete);
                        if (player.PlayerName == user.PlayerName)
                        {
                            DeleteCardFromHand(CardButtons, cardToDelete);
                        }
                    }
                }
            }
            foreach (Player player in players)
            {
                if (player.PlayerHand.Count == 0)
                {
                    handCount++;
                    gameDeck.BuildDeck();
                    DealCards();
                    FindLead(players);
                    DisplayHand(user);
                    break;
                }
            }
            currentTrick.Clear();
            leadingSuit = null;
            this.Invoke((MethodInvoker)delegate
            {
                Score1TextBox.Text = players[0].PlayerPoints.ToString();
                Score2TextBox.Text = players[1].PlayerPoints.ToString();
                if (!twoPlayerMode)
                {
                    Score3TextBox.Text = players[2].PlayerPoints.ToString();
                    Score4TextBox.Text = players[3].PlayerPoints.ToString();
                }
                TrickNumTextBox.Text = trickCount.ToString();
                HandNumTextBox.Text = handCount.ToString();
            });
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            CommenceGameplay();
        }

        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            DeleteTrick(trickList);
            DeleteTrick(CardButtons);
            CardButtons.Clear(); // Clear the list of card buttons
            HandFlowLayoutPanel.Controls.Clear(); // Clear the hand flow layout panel
            trickCount = 0;
            handCount = 0;
            currentIndex = 0;
            heartsBroken = false; // Reset hearts broken status
            gameDeck = new Deck(); // Create a new deck
            GameSetup();

        }

        private void RulesButton_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommenceGameplay();
        }

        private void ResetGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void RulesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TrickFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HandFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayerInfoGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToPlay forms = new HowToPlay();  
            forms.ShowDialog();
            this.Hide();
        }

        private void startGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommenceGameplay();
        }

        private void resetGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Method for hot keys
        private void windowTitle_KeyDown(object sender, KeyEventArgs e)
        {
            // check if ctrl buttton is clicked on the user keyboard
            if (e.Control)
            {

                // CTRL+S - triggers the START GAME button.
                if (e.KeyCode == Keys.S)
                {
                    StartGameButton.PerformClick();
                }
                // CTRL+R - triggers the RESHUFFLE/RESET GAME button.
                else if (e.KeyCode == Keys.R)
                {
                    ResetGameButton.PerformClick();
                }
                // ALT+F4 - exits the application
                else if (e.Alt && e.KeyCode == Keys.F4)
                {
                    ExitButton.PerformClick();

                }
            }

        }




    }
}

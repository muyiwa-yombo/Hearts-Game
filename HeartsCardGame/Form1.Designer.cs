namespace HeartsCardGame
{
    partial class HeartsGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ResetGameButton = new System.Windows.Forms.Button();
            this.PlayerInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Score4TextBox = new System.Windows.Forms.TextBox();
            this.Player4Label = new System.Windows.Forms.Label();
            this.Score3TextBox = new System.Windows.Forms.TextBox();
            this.Player3Label = new System.Windows.Forms.Label();
            this.Score2TextBox = new System.Windows.Forms.TextBox();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Score1TextBox = new System.Windows.Forms.TextBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.GameInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.HandNumTextBox = new System.Windows.Forms.TextBox();
            this.TrickNumTextBox = new System.Windows.Forms.TextBox();
            this.TrickNumLabel = new System.Windows.Forms.Label();
            this.HandNumLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameMenuStrip = new System.Windows.Forms.MenuStrip();
            this.StartGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HandFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TrickFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.OptionsGroupBox.SuspendLayout();
            this.PlayerInfoGroupBox.SuspendLayout();
            this.GameInfoGroupBox.SuspendLayout();
            this.GameMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.StartGameButton);
            this.OptionsGroupBox.Controls.Add(this.ExitButton);
            this.OptionsGroupBox.Controls.Add(this.ResetGameButton);
            this.OptionsGroupBox.Location = new System.Drawing.Point(22, 735);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(1403, 129);
            this.OptionsGroupBox.TabIndex = 5;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Game Options";
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(6, 21);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(238, 91);
            this.StartGameButton.TabIndex = 6;
            this.StartGameButton.Text = "Start Round";
            this.toolTip1.SetToolTip(this.StartGameButton, "click to start game(CTRL+ S)");
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(1082, 21);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(238, 85);
            this.ExitButton.TabIndex = 35;
            this.ExitButton.Text = "Close Game";
            this.toolTip1.SetToolTip(this.ExitButton, "click to exit game(ALT + F4)");
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ResetGameButton
            // 
            this.ResetGameButton.Location = new System.Drawing.Point(572, 21);
            this.ResetGameButton.Name = "ResetGameButton";
            this.ResetGameButton.Size = new System.Drawing.Size(238, 91);
            this.ResetGameButton.TabIndex = 33;
            this.ResetGameButton.Text = "Reshuffle";
            this.toolTip1.SetToolTip(this.ResetGameButton, "click to reshuffle games(CTRL + R)");
            this.ResetGameButton.UseVisualStyleBackColor = true;
            this.ResetGameButton.Click += new System.EventHandler(this.ResetGameButton_Click);
            // 
            // PlayerInfoGroupBox
            // 
            this.PlayerInfoGroupBox.Controls.Add(this.NameLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.Score4TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.Player4Label);
            this.PlayerInfoGroupBox.Controls.Add(this.Score3TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.Player3Label);
            this.PlayerInfoGroupBox.Controls.Add(this.Score2TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.Player2Label);
            this.PlayerInfoGroupBox.Controls.Add(this.Score1TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.ScoreLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.Player1Label);
            this.PlayerInfoGroupBox.Location = new System.Drawing.Point(1030, 41);
            this.PlayerInfoGroupBox.Name = "PlayerInfoGroupBox";
            this.PlayerInfoGroupBox.Size = new System.Drawing.Size(420, 182);
            this.PlayerInfoGroupBox.TabIndex = 18;
            this.PlayerInfoGroupBox.TabStop = false;
            this.PlayerInfoGroupBox.Text = "Player Info";
            this.toolTip1.SetToolTip(this.PlayerInfoGroupBox, "Displays Game ScoreBoards");
            this.PlayerInfoGroupBox.Enter += new System.EventHandler(this.PlayerInfoGroupBox_Enter);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(15, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(44, 16);
            this.NameLabel.TabIndex = 32;
            this.NameLabel.Text = "Name";
            // 
            // Score4TextBox
            // 
            this.Score4TextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Score4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score4TextBox.Enabled = false;
            this.Score4TextBox.Location = new System.Drawing.Point(323, 138);
            this.Score4TextBox.Name = "Score4TextBox";
            this.Score4TextBox.ReadOnly = true;
            this.Score4TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score4TextBox.TabIndex = 31;
            // 
            // Player4Label
            // 
            this.Player4Label.AutoSize = true;
            this.Player4Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Player4Label.Location = new System.Drawing.Point(15, 150);
            this.Player4Label.Name = "Player4Label";
            this.Player4Label.Size = new System.Drawing.Size(0, 16);
            this.Player4Label.TabIndex = 30;
            // 
            // Score3TextBox
            // 
            this.Score3TextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Score3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score3TextBox.Enabled = false;
            this.Score3TextBox.Location = new System.Drawing.Point(323, 105);
            this.Score3TextBox.Name = "Score3TextBox";
            this.Score3TextBox.ReadOnly = true;
            this.Score3TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score3TextBox.TabIndex = 28;
            // 
            // Player3Label
            // 
            this.Player3Label.AutoSize = true;
            this.Player3Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Player3Label.Location = new System.Drawing.Point(15, 116);
            this.Player3Label.Name = "Player3Label";
            this.Player3Label.Size = new System.Drawing.Size(0, 16);
            this.Player3Label.TabIndex = 27;
            // 
            // Score2TextBox
            // 
            this.Score2TextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Score2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score2TextBox.Enabled = false;
            this.Score2TextBox.Location = new System.Drawing.Point(323, 70);
            this.Score2TextBox.Name = "Score2TextBox";
            this.Score2TextBox.ReadOnly = true;
            this.Score2TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score2TextBox.TabIndex = 25;
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Player2Label.Location = new System.Drawing.Point(15, 82);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(0, 16);
            this.Player2Label.TabIndex = 24;
            // 
            // Score1TextBox
            // 
            this.Score1TextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Score1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score1TextBox.Enabled = false;
            this.Score1TextBox.Location = new System.Drawing.Point(323, 37);
            this.Score1TextBox.Multiline = true;
            this.Score1TextBox.Name = "Score1TextBox";
            this.Score1TextBox.ReadOnly = true;
            this.Score1TextBox.Size = new System.Drawing.Size(72, 12);
            this.Score1TextBox.TabIndex = 22;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(338, 18);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(43, 16);
            this.ScoreLabel.TabIndex = 19;
            this.ScoreLabel.Text = "Score";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Player1Label.Location = new System.Drawing.Point(15, 48);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(0, 16);
            this.Player1Label.TabIndex = 21;
            // 
            // GameInfoGroupBox
            // 
            this.GameInfoGroupBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GameInfoGroupBox.Controls.Add(this.HandNumTextBox);
            this.GameInfoGroupBox.Controls.Add(this.TrickNumTextBox);
            this.GameInfoGroupBox.Controls.Add(this.TrickNumLabel);
            this.GameInfoGroupBox.Controls.Add(this.HandNumLabel);
            this.GameInfoGroupBox.Controls.Add(this.label2);
            this.GameInfoGroupBox.Location = new System.Drawing.Point(1030, 258);
            this.GameInfoGroupBox.Name = "GameInfoGroupBox";
            this.GameInfoGroupBox.Size = new System.Drawing.Size(420, 94);
            this.GameInfoGroupBox.TabIndex = 13;
            this.GameInfoGroupBox.TabStop = false;
            this.GameInfoGroupBox.Text = "Game Info";
            this.toolTip1.SetToolTip(this.GameInfoGroupBox, "Displays Card Status");
            // 
            // HandNumTextBox
            // 
            this.HandNumTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HandNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HandNumTextBox.Enabled = false;
            this.HandNumTextBox.Location = new System.Drawing.Point(121, 21);
            this.HandNumTextBox.Multiline = true;
            this.HandNumTextBox.Name = "HandNumTextBox";
            this.HandNumTextBox.ReadOnly = true;
            this.HandNumTextBox.Size = new System.Drawing.Size(100, 12);
            this.HandNumTextBox.TabIndex = 15;
            // 
            // TrickNumTextBox
            // 
            this.TrickNumTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TrickNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrickNumTextBox.Enabled = false;
            this.TrickNumTextBox.Location = new System.Drawing.Point(121, 60);
            this.TrickNumTextBox.Multiline = true;
            this.TrickNumTextBox.Name = "TrickNumTextBox";
            this.TrickNumTextBox.ReadOnly = true;
            this.TrickNumTextBox.Size = new System.Drawing.Size(100, 12);
            this.TrickNumTextBox.TabIndex = 17;
            // 
            // TrickNumLabel
            // 
            this.TrickNumLabel.AutoSize = true;
            this.TrickNumLabel.Location = new System.Drawing.Point(6, 61);
            this.TrickNumLabel.Name = "TrickNumLabel";
            this.TrickNumLabel.Size = new System.Drawing.Size(91, 16);
            this.TrickNumLabel.TabIndex = 16;
            this.TrickNumLabel.Text = "Trick Number:";
            // 
            // HandNumLabel
            // 
            this.HandNumLabel.AutoSize = true;
            this.HandNumLabel.Location = new System.Drawing.Point(12, 21);
            this.HandNumLabel.Name = "HandNumLabel";
            this.HandNumLabel.Size = new System.Drawing.Size(94, 16);
            this.HandNumLabel.TabIndex = 14;
            this.HandNumLabel.Text = "Hand Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 16;
            // 
            // GameMenuStrip
            // 
            this.GameMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.GameMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartGameToolStripMenuItem,
            this.ResetGameToolStripMenuItem});
            this.GameMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.GameMenuStrip.Name = "GameMenuStrip";
            this.GameMenuStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.GameMenuStrip.Size = new System.Drawing.Size(1468, 28);
            this.GameMenuStrip.TabIndex = 22;
            this.GameMenuStrip.Text = "CardsMenuStrip";
            // 
            // StartGameToolStripMenuItem
            // 
            this.StartGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem1,
            this.resetGameToolStripMenuItem1,
            this.exitGameToolStripMenuItem});
            this.StartGameToolStripMenuItem.Name = "StartGameToolStripMenuItem";
            this.StartGameToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.StartGameToolStripMenuItem.Text = "File";
            this.StartGameToolStripMenuItem.Click += new System.EventHandler(this.StartGameToolStripMenuItem_Click);
            // 
            // startGameToolStripMenuItem1
            // 
            this.startGameToolStripMenuItem1.Name = "startGameToolStripMenuItem1";
            this.startGameToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.startGameToolStripMenuItem1.Text = "Start Game";
            this.startGameToolStripMenuItem1.Click += new System.EventHandler(this.startGameToolStripMenuItem1_Click);
            // 
            // resetGameToolStripMenuItem1
            // 
            this.resetGameToolStripMenuItem1.Name = "resetGameToolStripMenuItem1";
            this.resetGameToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.resetGameToolStripMenuItem1.Text = "Reset Game";
            this.resetGameToolStripMenuItem1.Click += new System.EventHandler(this.resetGameToolStripMenuItem1_Click);
            // 
            // exitGameToolStripMenuItem
            // 
            this.exitGameToolStripMenuItem.Name = "exitGameToolStripMenuItem";
            this.exitGameToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.exitGameToolStripMenuItem.Text = "Exit Game";
            this.exitGameToolStripMenuItem.Click += new System.EventHandler(this.exitGameToolStripMenuItem_Click);
            // 
            // ResetGameToolStripMenuItem
            // 
            this.ResetGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.documentationToolStripMenuItem});
            this.ResetGameToolStripMenuItem.Name = "ResetGameToolStripMenuItem";
            this.ResetGameToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.ResetGameToolStripMenuItem.Text = "Help";
            this.ResetGameToolStripMenuItem.Click += new System.EventHandler(this.ResetGameToolStripMenuItem_Click);
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.howToPlayToolStripMenuItem.Text = "How To Play";
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // HandFlowLayoutPanel
            // 
            this.HandFlowLayoutPanel.Location = new System.Drawing.Point(22, 490);
            this.HandFlowLayoutPanel.Name = "HandFlowLayoutPanel";
            this.HandFlowLayoutPanel.Size = new System.Drawing.Size(1414, 239);
            this.HandFlowLayoutPanel.TabIndex = 23;
            this.toolTip1.SetToolTip(this.HandFlowLayoutPanel, "Displays all dealt cards");
            this.HandFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HandFlowLayoutPanel_Paint);
            // 
            // TrickFlowLayoutPanel
            // 
            this.TrickFlowLayoutPanel.Location = new System.Drawing.Point(32, 41);
            this.TrickFlowLayoutPanel.Name = "TrickFlowLayoutPanel";
            this.TrickFlowLayoutPanel.Size = new System.Drawing.Size(993, 372);
            this.TrickFlowLayoutPanel.TabIndex = 24;
            this.TrickFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TrickFlowLayoutPanel_Paint);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(265, 416);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(0, 16);
            this.MessageLabel.TabIndex = 25;
            // 
            // HeartsGame
            // 
            this.AcceptButton = this.StartGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(1468, 844);
            this.Controls.Add(this.PlayerInfoGroupBox);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.TrickFlowLayoutPanel);
            this.Controls.Add(this.HandFlowLayoutPanel);
            this.Controls.Add(this.GameInfoGroupBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GameMenuStrip);
            this.KeyPreview = true;
            this.Name = "HeartsGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hearts GamePlay";
            this.OptionsGroupBox.ResumeLayout(false);
            this.PlayerInfoGroupBox.ResumeLayout(false);
            this.PlayerInfoGroupBox.PerformLayout();
            this.GameInfoGroupBox.ResumeLayout(false);
            this.GameInfoGroupBox.PerformLayout();
            this.GameMenuStrip.ResumeLayout(false);
            this.GameMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ResetGameButton;
        private System.Windows.Forms.GroupBox PlayerInfoGroupBox;
        private System.Windows.Forms.TextBox Score4TextBox;
        private System.Windows.Forms.TextBox Score3TextBox;
        private System.Windows.Forms.TextBox Score2TextBox;
        private System.Windows.Forms.TextBox Score1TextBox;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.GroupBox GameInfoGroupBox;
        private System.Windows.Forms.TextBox HandNumTextBox;
        private System.Windows.Forms.TextBox TrickNumTextBox;
        private System.Windows.Forms.Label TrickNumLabel;
        private System.Windows.Forms.Label HandNumLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip GameMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ResetGameToolStripMenuItem;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.ToolStripMenuItem StartGameToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel HandFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel TrickFlowLayoutPanel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label Player4Label;
        private System.Windows.Forms.Label Player3Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


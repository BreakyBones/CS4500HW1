// DrawCard.cs
// This file is for the design of selecting four cards and viewing the 4 cards
//For the images, The background of the form is from google images while, the card backgrounds were a white box, so I had DALL-E generate one for me and I used that as the card background
//Default winforms settings and initialization, rest were simple functions only searched syntax
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS4500HW1
{
    public partial class DrawCard : Form
    {
        public Deck deck;
        private PictureBox[] selectedPictureBoxes = new PictureBox[4]; // Assuming 4 cards
        private string[] selectedSuits = new string[4]; // Holds the selected suit for each card
        private string[] selectedValues = new string[4]; // Holds the selected value for each card

        public DrawCard()
        {
            InitializeComponent();
            deck = new Deck();
            pictureBoxH1.Click += PictureBoxSuit_Click;
            pictureBoxD1.Click += PictureBoxSuit_Click;
            pictureBoxC1.Click += PictureBoxSuit_Click;
            pictureBoxS1.Click += PictureBoxSuit_Click;

            pictureBoxH2.Click += PictureBoxSuit_Click;
            pictureBoxD2.Click += PictureBoxSuit_Click;
            pictureBoxC2.Click += PictureBoxSuit_Click;
            pictureBoxS2.Click += PictureBoxSuit_Click;

            pictureBoxH3.Click += PictureBoxSuit_Click;
            pictureBoxD3.Click += PictureBoxSuit_Click;
            pictureBoxC3.Click += PictureBoxSuit_Click;
            pictureBoxS3.Click += PictureBoxSuit_Click;

            pictureBoxH4.Click += PictureBoxSuit_Click;
            pictureBoxD4.Click += PictureBoxSuit_Click;
            pictureBoxC4.Click += PictureBoxSuit_Click;
            pictureBoxS4.Click += PictureBoxSuit_Click;

            InitializeValueDropdowns();

            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
        private void InitializeValueDropdowns()
        {
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string value in values)
            {
                comboBox1.Items.Add(value);
                comboBox2.Items.Add(value);
                comboBox3.Items.Add(value);
                comboBox4.Items.Add(value);
            }

            // Set a default value for each ComboBox, if desired
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                int cardIndex = int.Parse(comboBox.Name.Substring(comboBox.Name.Length - 1)) - 1;
                selectedValues[cardIndex] = comboBox.SelectedItem.ToString();
            }
        }

        private void card1Confirm_Click(object sender, EventArgs e)
        {
            DisplaySelectedCard(0);
        }

        private void card2Confirm_Click(object sender, EventArgs e)
        {
            DisplaySelectedCard(1);
        }

        private void card3Confirm_Click(object sender, EventArgs e)
        {
            DisplaySelectedCard(2);
        }

        private void card4Confirm_Click(object sender, EventArgs e)
        {
            DisplaySelectedCard(3);
        }

        private void DisplaySelectedCard(int cardIndex)
        {
            if (string.IsNullOrEmpty(selectedSuits[cardIndex]) || string.IsNullOrEmpty(selectedValues[cardIndex]))
            {
                MessageBox.Show($"Please select both the suit and value for card {cardIndex + 1}.");
                return;
            }

            // Check for duplicate card selection
            for (int i = 0; i < selectedSuits.Length; i++)
            {
                // Skip the current card index
                if (i == cardIndex) continue;

                if (!string.IsNullOrEmpty(selectedSuits[i]) && !string.IsNullOrEmpty(selectedValues[i]) &&
                    selectedSuits[i] == selectedSuits[cardIndex] && selectedValues[i] == selectedValues[cardIndex])
                {
                    MessageBox.Show("Duplicate card selection detected. Please select a different card.");
                    return;
                }
            }

            // If no duplicates are found, proceed to display the card
            var cardToDisplay = deck.DealSelectedCards(new[] { selectedSuits[cardIndex] }, new[] { selectedValues[cardIndex] }).FirstOrDefault();
            if (cardToDisplay != null)
            {
                var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
                pictureBoxes[cardIndex].Image = cardToDisplay.CardImage;
                pictureBoxes[cardIndex].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show($"The selected card could not be found.");
            }
        }


        private void quit_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void draw_Click(object sender, EventArgs e)
        {
          

            // Make sure all suits and values have been selected
            for (int i = 0; i < selectedSuits.Length; i++)
            {
                if (string.IsNullOrEmpty(selectedSuits[i]) || string.IsNullOrEmpty(selectedValues[i]))
                {
                    MessageBox.Show($"Please select both the suit and value for card {i + 1}.");
                    return;
                }
            }

            for (int i = 0; i < selectedSuits.Length; i++)
            {
                if (selectedValues[i] == "Please select value")
                {
                    MessageBox.Show($"Please select 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, or A as the value for card {i + 1}.");
                    return;
                }
            }

            // This will test if the four cards are unique
            string card1 = selectedSuits[0] + selectedValues[0];
            string card2 = selectedSuits[1] + selectedValues[1];
            string card3 = selectedSuits[2] + selectedValues[2];
            string card4 = selectedSuits[3] + selectedValues[3];
            string[] cards = { card1, card2, card3, card4 };

            

            // Get the selected cards from the deck
            var selectedCards = deck.DealSelectedCards(selectedSuits, selectedValues);
            textBoxLog.AppendText(deck.Outlog + Environment.NewLine);
            
        }

        private void PictureBoxSuit_Click(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                // Extract card number (1-4) from the PictureBox name
                int cardNumber = int.Parse(pictureBox.Name.Substring(pictureBox.Name.Length - 1));

                // The index in the array is card number - 1
                int cardIndex = cardNumber - 1;

                // Extract the suit initial based on your naming convention
                char suitInitial = pictureBox.Name[pictureBox.Name.Length - 2];

                // Call method to clear previous selection for this specific card
                ClearPreviousSelection(cardIndex);

                // Set the selected suit
                selectedSuits[cardIndex] = GetSuitFromInitial(suitInitial);

                // Highlight the newly selected PictureBox for this specific card
                HighlightPictureBox(pictureBox, cardIndex);
            }
        }

        private void ClearPreviousSelection(int cardIndex)
        {
            if (selectedPictureBoxes[cardIndex] != null)
            {
                selectedPictureBoxes[cardIndex].BackColor = Color.Transparent; // Reset the previous selection
                selectedPictureBoxes[cardIndex].BorderStyle = BorderStyle.None; // Optionally reset any border style you might have set
            }
        }

        private void HighlightPictureBox(PictureBox pictureBox, int cardIndex)
        {
            // Clear highlight from the previous selection for this specific card
            if (selectedPictureBoxes[cardIndex] != null && selectedPictureBoxes[cardIndex] != pictureBox)
            {
                selectedPictureBoxes[cardIndex].BackColor = Color.White; //changed to white color so you can see the border easily
                selectedPictureBoxes[cardIndex].BorderStyle = BorderStyle.FixedSingle; //keeps border
            }

            // Highlight the new selection
            pictureBox.BackColor = Color.Gold;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;

            // Update the current selection
            selectedPictureBoxes[cardIndex] = pictureBox;
        }
        private string GetSuitFromInitial(char initial)
        {
            switch (initial)
            {
                case 'H': return "Hearts";
                case 'D': return "Diamonds";
                case 'C': return "Clubs";
                case 'S': return "Spades";
                default: return null;
            }
        }

    }
}
// End of file
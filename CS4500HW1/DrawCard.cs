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

            DealBtn.Visible = true;
            NextRoundBtn.Visible = false; // Hide the Next Round button initially
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
                // Check if SelectedItem is not null before calling ToString()
                if (comboBox.SelectedItem != null)
                {
                    selectedValues[cardIndex] = comboBox.SelectedItem.ToString();
                }
                else
                {
                    // Handle the case where SelectedItem is null, if needed
                    selectedValues[cardIndex] = string.Empty; // or another default/fallback value
                }
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

        // This is a "global" variable since I do not the equality to return a value each time but I need 
        // to have a value based on if any of the cards matched or not. This global variable holds that value.
        // 0 will mean that a card in the collection equaled another card
        public static int success = 0;
        public static int letsSee = 0;

        private void draw_Click(object sender, EventArgs e)
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

            if (pictureBoxes.Any(pb => pb.Image == null))
            {
                MessageBox.Show("Please confirm all cards!");
                return;

            }

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

            for (int i = 0; i < selectedSuits.Length; i++)
            {
                bool isRedCard = selectedSuits[i] == "Hearts" || selectedSuits[i] == "Diamonds";
                HighlightCardPictureBox(pictureBoxes[i], isRedCard);
            }



            // Get the selected cards from the deck
            var selectedCards = deck.DealSelectedCards(selectedSuits, selectedValues);
            textBoxLog.AppendText(deck.Outlog + Environment.NewLine);

            // Align the "Next Round" button over the "Deal" button
            NextRoundBtn.Location = DealBtn.Location;
            NextRoundBtn.Size = DealBtn.Size;

            DealBtn.Visible = false;
            NextRoundBtn.Visible = true;

        }

        private void NextRoundBtn_Click(object sender, EventArgs e)
        {
            // Reset selections, dropdowns, and any game state here
            ClearAllSelectionsAndDropdowns();

            // Toggle buttons visibility
            NextRoundBtn.Visible = false;
            DealBtn.Visible = true;
        }

        private void ClearAllSelectionsAndDropdowns()
        {
            // Reset combo box
            foreach (var comboBox in new[] { comboBox1, comboBox2, comboBox3, comboBox4 })
            {
                comboBox.SelectedIndex = 0; // Reset dropdowns
            }
            // Reset picture box
            foreach (var pictureBox in new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 })
            {
                pictureBox.Image = null;
                pictureBox.Tag = null;
                pictureBox.Invalidate();
            }
            // Iterate over all PictureBoxes and reset 
            var allSuitPictureBoxes = new[] {
            pictureBoxH1, pictureBoxD1, pictureBoxC1, pictureBoxS1,
                 pictureBoxH2, pictureBoxD2, pictureBoxC2, pictureBoxS2,
                 pictureBoxH3, pictureBoxD3, pictureBoxC3, pictureBoxS3,
                 pictureBoxH4, pictureBoxD4, pictureBoxC4, pictureBoxS4
                };

                foreach (var pictureBox in allSuitPictureBoxes)
                 {
                 pictureBox.BackColor = Color.White; 
                 pictureBox.BorderStyle = BorderStyle.FixedSingle; 
                }

            // Clear any stored selections from arrays (Just in case)
            Array.Clear(selectedSuits, 0, selectedSuits.Length);
            Array.Clear(selectedValues, 0, selectedValues.Length);
            selectedPictureBoxes = new PictureBox[4];



        }
        private void HighlightCardPictureBox(PictureBox pictureBox, bool isRedCard)
        {
            if (isRedCard)
            {
                // Attach a custom paint event handler to draw the highlight
                pictureBox.Paint += PictureBox_CustomPaint;
                pictureBox.Tag = "highlight"; // Use Tag to indicate the PictureBox should be highlighted
            }
            else
            {
                // Remove the custom paint event handler when not highlighted
                pictureBox.Paint -= PictureBox_CustomPaint;
                pictureBox.Tag = null;
            }
            pictureBox.Invalidate(); // Force the PictureBox to repaint
        }

        //Had chatGPT custom make this paint tint in the paint. The border was causing a lot of problems and did not look correct like the suit selections
        private void PictureBox_CustomPaint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Tag == "highlight")
            {
                // Use a semi-transparent color for the tint
                Color tintColour = Color.FromArgb(128, Color.Gold);

                // Fill a rectangle over the entire PictureBox with the semi-transparent color
                using (SolidBrush brush = new SolidBrush(tintColour))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
                }
            }
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
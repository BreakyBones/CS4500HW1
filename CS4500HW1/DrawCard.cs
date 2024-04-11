// DrawCard.cs
// This file is for the design of selecting four cards and viewing the 4 cards
//For the images, The background of the form is from google images while, the card backgrounds were a white box, so I had DALL-E generate one for me and I used that as the card background
//Default winforms settings and initialization, rest were simple functions only searched syntax
//Latest Revision: 03/22/2024 by Kanaan and Noor
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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


        string patternFile = Application.StartupPath + "LastWon.txt";

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
            if (string.IsNullOrEmpty(selectedSuits[cardIndex]) || string.IsNullOrEmpty(selectedValues[cardIndex]) 
                || selectedValues[cardIndex] == "Please select value")
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

        // This is the Deal! Button, it makes sure all values and cards are selected and confirmed and handles the logic for the actual selecting of dealer cards.
        // Created by Kanaan 
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
                if (string.IsNullOrEmpty(selectedSuits[i]) || string.IsNullOrEmpty(selectedValues[i]) || selectedValues[i] == "Please select value")
                {
                    MessageBox.Show($"Please select both the suit and value for card {i + 1}.");
                    return;
                }
            }
            //This is Mihir Bhakta, I added if statements to determine the pattern and I added other for loops for patterns 2-5 similar to
            //that of pattern 1, which was already here.
            //Make it set equal to the number from the LastWon.txt file later
            int patternNum = 5;
            //This is Mihir, I added this to try to read the patternumber from the file.
            //using (StreamReader srPattern = new StreamReader(patternFile))
            //{
            //    patternNum = int.Parse(srPattern.ReadToEnd());
            //}
            //If statements Pattern 1 Red cards
            if (patternNum == 0)
            {
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedSuits[i] == "Hearts" || selectedSuits[i] == "Diamonds";
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                }
            }
            //Added the same sort of thing for patterns 2-5 - Mihir
            //Pattern 2 All clubs
            if (patternNum == 1) 
            {
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedSuits[i] == "Clubs";
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                }
            }
            //Pattern 3 All Face Cards 
            if (patternNum == 2) 
            { 
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedValues[i] == "J" || selectedValues[i] == "Q" || selectedValues[i] == "K";
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                }
            }
            //Pattern 4 All Single Digits
            if (patternNum == 3)
            {
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedValues[i] == "2" || selectedValues[i] == "3" || selectedValues[i] == "4"
                        || selectedValues[i] == "5" || selectedValues[i] == "6" || selectedValues[i] == "7"
                        || selectedValues[i] == "8" || selectedValues[i] == "9";
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                }
            }
            //Pattern 5 All Single Digit Primes
            if (patternNum == 4)
            {
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedValues[i] == "2" || selectedValues[i] == "3"
                        || selectedValues[i] == "5" || selectedValues[i] == "7";

                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                }
            }
            // Pattern 6 Added by Grant on April 10
            if (patternNum == 5)
            {
                int highValue = 1;
                bool isArtDealerCard = false;

                // This retrieves the highest value of the cards.
                // It returns an integer string only which is why I use the switch statement to give 
                // a path to the actual value of the card
                highValue = deck.PatternSix(selectedSuits, selectedValues);
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    // If highest value card is a face value card or Ace.
                    if (highValue > 10)
                    {
                        switch (highValue)
                        {
                            case 11:
                                isArtDealerCard = selectedValues[i] == "J";
                                break;
                            case 12:
                                isArtDealerCard = selectedValues[i] == "Q";
                                break;
                            case 13:
                                isArtDealerCard = selectedValues[i] == "K";
                                break;
                            case 14:
                                isArtDealerCard = selectedValues[i] == "A";
                                break;
                        }
                    }
                    // If highest Value card is a numerical value card
                    if (highValue < 11)
                    {
                        isArtDealerCard = int.Parse(selectedValues[i]) == highValue;
                    }

                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                }

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

        // This is the code associated with the Next Round Button, on clicking it it resets all buttons to their previous states while keeping the History text box in tact
        // Created by Noor
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
        // On Dealer Selection of liked cards, highlight the cards and tint them to ensure that the user knows which cards the dealers liked
        // Created by Noor and Kanaan
        private void HighlightCardPictureBox(PictureBox pictureBox, bool isArtDealerCard)
        {
            if (isArtDealerCard)
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
        // Continuation of ressetting on next round button
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
// DrawCard.cs
// This file is for the design of selecting four cards and viewing the 4 cards
//For the images, The background of the form is from google images while, the card backgrounds were a white box, so I had DALL-E generate one for me and I used that as the card background
//Default winforms settings and initialization, rest were simple functions only searched syntax
//Latest Revision: 03/22/2024 by Kanaan and Noor
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        //Mihir - made patternNum to be used by both Deck.cs and DrawCard.cs instead of having 2 of the same thing.
        //and made a counter to keep track of rounds won for a pattern and if the round was won or not.
        public static int patternNum;
        public static int numCardsWon = 0;
        public static int roundsWon = 0;
        // bool isPatternWon = false;
        int fileCounter;


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
            //This is created by Mihir - it writes the pattern number to the file.
            using (StreamWriter swPattern = new StreamWriter(patternFile))
            {
                swPattern.Write(patternNum);
                //Closes the file, I hope
                swPattern.Close();
            }
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

            // Get the selected cards from the deck first so that I can see if the two hands are equal
            var selectedCards = deck.DealSelectedCards(selectedSuits, selectedValues);

            // This is created by Grant. If two hands are equal, at least change one of the cards and try again.
            if (Deck.equalHands == true)
            {
                MessageBox.Show($"Please make sure this hand does not equal any other hands/deals that were selected in this pattern. Try again");
                // Reset picture box
                foreach (var pictureBox in new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 })
                {
                    pictureBox.Image = null;
                    pictureBox.Tag = null;
                    pictureBox.Invalidate();
                }
                return;
            }

            //Created by mihir: reading the pattern number from LastWon.txt
            fileCounter++;
            if (fileCounter == 1)
            {
                using (StreamReader srPattern = new StreamReader(patternFile))
                {
                    patternNum = int.Parse(srPattern.ReadToEnd());
                    if (patternNum == 6)
                    {
                        //This is Mihir Bhakta. I used https://stackoverflow.com/questions/3036829/how-do-i-create-a-message-box-with-yes-no-choices-and-a-dialogresult
                        //to help me create this box that takes a yes or no from the user for the pattern number being 6.
                        DialogResult dialogResult = MessageBox.Show("You already won all the patterns for the Art Dealer.\r\nWould you like to start over again with the first pattern?", "Art Dealer", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            patternNum = 0;
                        }
                        else if (dialogResult == DialogResult.No)
                        {//This is Mihir Bhakta and I got this waiting time idea from https://stackoverflow.com/questions/10458118/wait-one-second-in-running-program
                            MessageBox.Show("Ok, goodbye!");
                            System.Threading.Thread.Sleep(5000);
                            Application.Exit();
                        }
                    }
                }
                // if(patternNum == 5)
            }



            Debug.Write("\npatternNum initial value read from file:" + patternNum + "\n");
            // isPatternWon = true;


            // Make sure all suits and values have been selected
            for (int i = 0; i < selectedSuits.Length; i++)
            {
                if (string.IsNullOrEmpty(selectedSuits[i]) || string.IsNullOrEmpty(selectedValues[i]) || selectedValues[i] == "Please select value")
                {
                    MessageBox.Show($"Please select both the suit and value for card {i + 1}.");
                    return;
                }
            }


            //This is Mihir, I added if statements to determine the pattern and I added other for loops for patterns 2-5 similar to
            //that of pattern 1, which was already here.

            // This is put by Grant here to catch a big bug. The bug was that some patterns were declared won even if they were not won.
            numCardsWon = 0;

            //If statements Pattern 1 Red cards
            if (patternNum == 0)
            {
                for (int i = 0; i < selectedSuits.Length; i++)
                {

                    bool isArtDealerCard = selectedSuits[i] == "Hearts" || selectedSuits[i] == "Diamonds";
                    Debug.Write("\n\nDoes this say that I selected the right card?" + isArtDealerCard + "\n");
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                    //Mihir: If the card is highlighted, it means it was selected so if all 4 get selected then user gets a win for a round
                    //if 2 wins, then user gets a win for the pattern and moves onto the next pattern
                    if (isArtDealerCard == true)
                    {
                        Debug.Write("This should only won if the above code is running and says true at the end of it\n\n");
                        numCardsWon++;
                        if (numCardsWon == 4) //All 4 cards were highlighted
                        {
                            numCardsWon = 0;
                            roundsWon++;
                            Debug.Write("\n\nroundswon:" + roundsWon + "\n\n");
                        }
                    }


                }
            }
            //Added the same sort of thing for patterns 2-5 - Mihir
            //Pattern 2 All clubs
            if (patternNum == 1)
            {
                Debug.Write("\npattern moved into CLUBS");
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedSuits[i] == "Clubs";
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                    //Mihir: If the card is highlighted, it means it was selected so if all 4 get selected then user gets a win for a round
                    //if 2 wins, then user gets a win for the pattern and moves onto the next pattern
                    if (isArtDealerCard == true)
                    {
                        numCardsWon++;
                        if (numCardsWon == 4) //All 4 cards were highlighted
                        {
                            numCardsWon = 0;
                            roundsWon++;
                            Debug.Write("\n\nroundswon:" + roundsWon + "\n\n");
                        }
                    }
                }
            }
            //Pattern 3 All Face Cards 
            if (patternNum == 2)
            {
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    bool isArtDealerCard = selectedValues[i] == "J" || selectedValues[i] == "Q" || selectedValues[i] == "K";
                    HighlightCardPictureBox(pictureBoxes[i], isArtDealerCard);
                    //Mihir: If the card is highlighted, it means it was selected so if all 4 get selected then user gets a win for a round
                    //if 2 wins, then user gets a win for the pattern and moves onto the next pattern
                    if (isArtDealerCard == true)
                    {
                        numCardsWon++;
                        if (numCardsWon == 4) //All 4 cards were highlighted
                        {
                            numCardsWon = 0;
                            roundsWon++;
                            Debug.Write("\nroundswon:" + roundsWon);
                        }
                    }
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
                    //Mihir: If the card is highlighted, it means it was selected so if all 4 get selected then user gets a win for a round
                    //if 2 wins, then user gets a win for the pattern and moves onto the next pattern
                    if (isArtDealerCard == true)
                    {
                        numCardsWon++;
                        if (numCardsWon == 4) //All 4 cards were highlighted
                        {
                            numCardsWon = 0;
                            roundsWon++;
                            Debug.Write("\n\nroundswon:" + roundsWon + "\n");
                        }
                    }
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
                    //Mihir: If the card is highlighted, it means it was selected so if all 4 get selected then user gets a win for a round
                    //if 2 wins, then user gets a win for the pattern and moves onto the next pattern
                    if (isArtDealerCard == true)
                    {
                        numCardsWon++;
                        if (numCardsWon == 4) //All 4 cards were highlighted
                        {
                            numCardsWon = 0;
                            roundsWon++;
                            Debug.Write("\n\nroundswon:" + roundsWon + "\n");
                        }
                    }
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
                    //Mihir: If the card is highlighted, it means it was selected so if all 4 get selected then user gets a win for a round
                    //if 2 wins, then user gets a win for the pattern and moves onto the next pattern
                    if (isArtDealerCard == true)
                    {
                        numCardsWon++;
                        if (numCardsWon == 4) //All 4 cards were highlighted
                        {
                            numCardsWon = 0;
                            roundsWon++;
                            Debug.Write("\n\nroundswon:" + roundsWon + "\n");
                        }
                    }
                }

            }
            // This is for adding text to the textbox in the corner
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


            Debug.Write("\nNumber of rounds won: " + roundsWon + "\n");
            //Created by Mihir - Upon clicking the button, make this value = true for the pattern to increase for hightling to work properly
            //This ALSO means the user won the pattern
            if (roundsWon >= 2)
            {
                FileStream clearContent = File.Open("CurrentPattern.txt", FileMode.Open);
                clearContent.SetLength(0);
                clearContent.Close(); // This flushes the content, too.
                roundsWon = 0;
                Debug.Write("user won this round, moving onto the next pattern");
                int current = patternNum + 1;
                //Mihir - telling the user they won a pattern or that they won the whole game.
                if (patternNum <= 4)
                {
                    MessageBox.Show("Congratulations! User Won pattern " + current + ". The old pattern is gone and The Art Dealer is now looking for a NEW pattern!");
                    // This puts the pattern winner message in the box that displays the history in the corner
                    textBoxLog.AppendText("USER WON PATTERN " + current + Environment.NewLine);
                    // This puts the pattern winner message in the textfile that contains history
                    using (StreamWriter sw = File.AppendText(Deck.logPath))
                    {
                        sw.WriteLine("USER WON PATTERN " + current + Environment.NewLine);
                    }

                }
                if (patternNum == 5)
                {
                    // This puts the pattern winner message in the box that displays the history in the corner
                    textBoxLog.AppendText("USER WON PATTERN " + current + Environment.NewLine);
                    // This puts the pattern winner message in the textfile that contains history
                    using (StreamWriter sw = File.AppendText(Deck.logPath))
                    {
                        sw.WriteLine("USER WON PATTERN " + current + Environment.NewLine);
                    }
                    //MessageBox.Show("WOW, Congratulations! Not only has the user won the pattern, the user has won every pattern, which means the user has won the WHOLE GAME!");
                    DialogResult dialogResult = MessageBox.Show("WOW, Congratulations! Not only has the user won the pattern, the user has won every pattern, which means the user has won the WHOLE GAME!\r\nWould you like to start over again with the first pattern?", "Art Dealer", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Debug.Write("It got to this point");
                        patternNum = -1;
                    }
                    else if (dialogResult == DialogResult.No)
                    {//This is Mihir Bhakta and I got this waiting time idea from https://stackoverflow.com/questions/10458118/wait-one-second-in-running-program
                        //This is Mihir, Fixed bug, now it will put in 6 into the file when user says no after winning the game instead of 5.
                        using(StreamWriter swPattern2 = new StreamWriter(patternFile))
                        {
                            swPattern2.Write(6);
                        }
                        MessageBox.Show("Ok, goodbye!");
                        System.Threading.Thread.Sleep(5000);
                        Application.Exit();
                    }
                }

                patternNum++;

            }
            // isPatternWon = false;

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
                pictureBox.Paint -= PictureBox_CustomPaint;
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

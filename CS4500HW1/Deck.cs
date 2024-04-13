// Deck.cs
// This subfile makes sure that four cards are selected before sending the information
// for those four cards and the date over to the external file, CardsDealt.txt.
// This subfile also makes sure that the image holds the correct image for the card.
// Latest Revision: 03/21/2024 by Kanaan and Noor
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;


namespace CS4500HW1
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();
        public static string logPath = Application.StartupPath + "CardsDealt.txt";

        public static string seeDuplicate = Application.StartupPath + "CurrentPattern.txt";

        //This is Mihir, I add another file here for LastWon.txt and used https://www.c-sharpcorner.com/article/c-sharp-write-to-file/ to help
        //Not sure if this works, but it would be code for making a LastWon.txt file
        public static string patternFile = Application.StartupPath + "LastWon.txt";

        public bool equalHands = false;


        string outlog = "";
        public string Outlog => outlog;

        public Deck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            // On startup create the Date in the log file for the session.
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy"));
            }



            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var values = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    var imageName = $"{value}_of_{suit}.png"; // Assuming image names are formatted like "2_of_Hearts.png"
                    var image = LoadCardImage(imageName);
                    cards.Add(new Card(suit, value, image));
                }
            }
        }


        //Method for loading card images by image name
        private Image LoadCardImage(string imageName)
        {
            try
            {
                // Path to the runtime directory of the application
                var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // Construct the path to the image, assuming the Images folder is copied to the output directory
                var imagePath = Path.Combine(assemblyPath ?? string.Empty, "Images", imageName);
                return Image.FromFile(imagePath);
            }
            catch (Exception ex)// random comment
            {
                // Handle exceptions or log them as needed
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }

        public int PatternSix(string[] selectedSuits, string[] selectedValues)
        {
            List<Card> dealtCards = new List<Card>();
            int highValue = 1; //highValue means highest rank found
            // First find highest value of the cards PATTERN 6. Authored by Grant
            for (int i = 0; i < selectedSuits.Length; i++) //changed i=1 to 0
            {
                // Map face card values to numbers
                string value = MapFaceCardValue(selectedValues[i]);
                string suit = selectedSuits[i];

                // Find the card with the matching suit and value
                Card cardToDeal = cards.FirstOrDefault(card => card.Suit == suit && card.Value == value);
                if (cardToDeal != null)
                {
                    //Hey this is Mihir, I edited this so it parses the integer value from the string so it's comparable to highValue.
                    if (int.Parse(cardToDeal.Value) > highValue)
                    {
                        highValue = int.Parse(cardToDeal.Value);
                    }
                }

            }
            return highValue;
        }
        // I am declaring some variables outside of DealSelectedCards since they are only to reset when a pattern is one.
        // Create the 2d string list

        // Co-opted this to do the actual legwork of Dealer Selection since it's no longer used to show cards anymore
        // Created by Kanaan
        public List<Card> DealSelectedCards(string[] selectedSuits, string[] selectedValues)
        {
            List<Card> dealtCards = new List<Card>();
            outlog = "";
            int highestValue = 1; //highValue means highest rank found
            // This is tested first since if the put after the others, pattern 5 and 6 could be used simultaneously.
            // Code: if value from LastWon.txt is five, then do PATTERN 6 which is for selecting the highest value cards
            // First find highest value of the cards PATTERN 6. Authored by Grant


            // Increment by one. When the for loop is done, This goes back to when is Pattern is won.
            // Everything that is related to lists or arrays, I used chatGPT since I have never worked with it before in C#
            List<string> cardHand = new List<string>();

            for (int i = 0; i < selectedSuits.Length; i++)
            {
                string value = MapFaceCardValue(selectedValues[i]);
                string suit = selectedSuits[i];
                // Map face card values to numbers
                if (selectedSuits.Length == 4)
                {
                    string thisCard = selectedValues[i] + selectedSuits[i];
                    cardHand.Add(thisCard);
                }





                // Find the card with the matching suit and value
                Card cardToDeal = cards.FirstOrDefault(card => card.Suit == suit && card.Value == value);


                if (cardToDeal != null)
                {
                    // if the value read from LastWon.txt is zero, then do the redCard option
                    // This needs code to read that value.
                    //Pattern 1
                    if (DrawCard.patternNum == 0)
                    {
                        if (cardToDeal.Suit == "Hearts" || cardToDeal.Suit == "Diamonds")
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    }
                    // end if for PATTERN 1
                    // Code: if value from LastWon.txt is one, then do PATTERN 2 which is for selecting clubs
                    if (DrawCard.patternNum == 1)
                    {
                        if (cardToDeal.Suit == "Clubs")
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    }
                    // end if for PATTERN 2
                    // Code: if value from LastWon.txt is two, then do PATTERN 3 which is for selecting face value cards
                    // 11 is for jack, 12 is for queen, and 13 is for king
                    if (DrawCard.patternNum == 2)
                    {
                        if (cardToDeal.Value == "11" || cardToDeal.Value == "12" || cardToDeal.Value == "13")
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    }
                    // end if for PATTERN 3
                    // Code: if value from LastWon.txt is three, then do PATTERN 4 which is for selecting single digit cards
                    if (DrawCard.patternNum == 3)
                    {
                        if (cardToDeal.Value == "2" || cardToDeal.Value == "3" || cardToDeal.Value == "4" ||
                        cardToDeal.Value == "5" || cardToDeal.Value == "6" || cardToDeal.Value == "7" ||
                        cardToDeal.Value == "8" || cardToDeal.Value == "9") //This is Mihir, I removed a parenthesis
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    }
                    // end if for PATTERN 4
                    // Code: if value from LastWon.txt is four, then do PATTERN 5 which is for selecting prime single digit cards
                    if (DrawCard.patternNum == 4)
                    {
                        if (cardToDeal.Value == "2" || cardToDeal.Value == "3" || cardToDeal.Value == "5" || cardToDeal.Value == "7")
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    }
                    // end if for PATTERN 5
                    // Code: if value from LastWon.txt is five, then do PATTERN 6 which is for selecting the highest value cards
                    if (DrawCard.patternNum == 5)
                    {
                        highestValue = PatternSix(selectedSuits, selectedValues);
                        if (int.Parse(cardToDeal.Value) == highestValue)
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    }
                    // I will run a crazy for loop when i = 3 to make sure no other rows in the 2-D list are equal to any other row
                    // I hope to learn how to access each element as I should.                
                }
                else
                {
                    // If a card is not found, write a message to the debug output
                    System.Diagnostics.Debug.WriteLine($"Card with suit {suit} and value {value} not found or already dealt.");
                }

            }

            if (selectedSuits.Length == 4)
            {
                // This stats the part of trying to see duplicate patterns
                cardHand.Sort();
                Debug.Write("SelectedSuits is four now \n \n");
                

                // Read all lines from the file into an array. This line and the next three lines are from ChatGPT
                string[] lines = File.ReadAllLines(seeDuplicate);
                

                // Get the number of lines in the file
                int numLines = lines.Length;
                Debug.Write(numLines);
                string eachCard;
                if (numLines == 0)
                {
                    foreach (string sortCard in cardHand)
                    {
                        using (StreamWriter sw = File.AppendText(seeDuplicate))
                        {
                            sw.WriteLine(sortCard);
                        }
                    }
                }
                else
                {
                    int numberHands = numLines / 4;
                    Debug.Write("\n\n" + numberHands + " ");
                    // Create a temporaroy list
                    List<string> tempCardHand = new List<string>();

                    for (int hand = 0; hand < (numberHands - 1); hand++)
                    {
                        int badFour = 0;
                        for (int carde = 0; carde < 4; carde++)
                        {
                            int index = hand * 4 + carde;
                            Debug.Write("\n Index is " + index + "This is the huge");
                            eachCard = lines[index];
                            Debug.Write(eachCard);
                            tempCardHand.Add(eachCard);
                        }
                        for (int element = 0; element < 4; element++)
                        {
                            if (tempCardHand[element] == cardHand[element])
                            {
                                badFour++;
                                Debug.Write("\n\n have this display 1t \n\n");
                            }
                        }
                        if (badFour == 4)
                        {
                            equalHands = true;
                            Debug.Write("Equal Hands. \n");
                        }
                    }
                    // Assuming badFour does not equal four and the process of checking the current hand to all previous hands
                    // we can now safely add this hand to the list of hands for the current pattern
                    foreach (string sortCard in cardHand)
                    {
                        using (StreamWriter sw = File.AppendText(seeDuplicate))
                        {
                            sw.WriteLine(sortCard);
                        }
                    }
                }
            }




            // Log the cards dealt
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(outlog);
            }
            // This below is uncommented for testing
            System.Diagnostics.Debug.WriteLine(outlog);

            // Check if the correct number of cards were dealt
            if (dealtCards.Count != selectedSuits.Length)
            {
                throw new InvalidOperationException("Not enough cards were dealt." + dealtCards.Count + "and" + selectedSuits.Length);
            }

            return dealtCards;
        }

        private string MapFaceCardValue(string value)
        {
            switch (value)
            {
                case "J": return "11";
                case "Q": return "12";
                case "K": return "13";
                case "A": return "14";
                default: return value; // For number cards, the value does not change
            }
        }

    }
}


﻿// Deck.cs
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


namespace CS4500HW1
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();
        string logPath = Application.StartupPath + "CardsDealt.txt";
        string outlog = "";
        public string Outlog => outlog;

        public Deck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            // On startup create the Date in the log file for the session.
            using (StreamWriter sw = File.AppendText(logPath)) {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy"));
            }
            
            

            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var values = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" ,"12", "13", "14" };

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
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }


        // Co-opted this to do the actual legwork of Dealer Selection since it's no longer used to show cards anymore
        // Created by Kanaan
        public List<Card> DealSelectedCards(string[] selectedSuits, string[] selectedValues)
        {
            List<Card> dealtCards = new List<Card>();
            outlog = ""int highValue = 1;
            // This is tested first since if the put after the others, pattern 5 and 6 could be used simultaneously.
            // Code: if value from LastWon.txt is five, then do PATTERN 6 which is for selecting the highest value cards
            // First find highest value of the cards
                for (int i = 1; i < selectedSuits.Length; i++)
                {
                    // Map face card values to numbers
                    string value = MapFaceCardValue(selectedValues[i]);
                    string suit = selectedSuits[i];
                    
                    // Find the card with the matching suit and value
                    Card cardToDeal = cards.FirstOrDefault(card => card.Suit == suit && card.Value == value);
                    if (cardToDeal != null)
                    {
                        if (cardToDeal.Value > highValue)
                        {
                            highValue = cardToDeal.Value;
                        }
                        // After the high value is calculated, the art dealer selects its cards here for Pattern 6.
                        if (i = selectedSuits.Length - 1)
                        {
                            if ((cardToDeal.Value == highValue)
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
                    }
                }



            for (int i = 0; i < selectedSuits.Length; i++)
            {
                // Map face card values to numbers
                string value = MapFaceCardValue(selectedValues[i]);
                string suit = selectedSuits[i];

                // Find the card with the matching suit and value
                Card cardToDeal = cards.FirstOrDefault(card => card.Suit == suit && card.Value == value);

                if (cardToDeal != null)
                {
                    // if the value read from LastWon.txt is zero, then do the redCard option
                    // This needs code to read that value.
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
                    // end if for PATTERN 1
                    // Code: if value from LastWon.txt is one, then do PATTERN 2 which is for selecting clubs

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
                    // end if for PATTERN 2
                    // Code: if value from LastWon.txt is two, then do PATTERN 3 which is for selecting face value cards
                        // 11 is for jack, 12 is for queen, and 13 is for king
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

                    // end if for PATTERN 3
                    // Code: if value from LastWon.txt is three, then do PATTERN 4 which is for selecting single digit cards
                        if ((cardToDeal.Value == "2" || cardToDeal.Value == "3" || cardToDeal.Value == "4" ||
                        cardToDeal.Value == "5" || cardToDeal.Value == "6" || cardToDeal.Value == "7" || 
                        cardToDeal.Value == "8" || cardToDeal.Value == "9")
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    // end if for PATTERN 4
                    // Code: if value from LastWon.txt is four, then do PATTERN 5 which is for selecting prime single digit cards
                        if ((cardToDeal.Value == "2" || cardToDeal.Value == "3" || cardToDeal.Value == "5" || cardToDeal.Value == "7")
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += "*" + cardToDeal.Log() + "*" + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                        else
                        {
                            dealtCards.Add(cardToDeal);
                            outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
                        }
                    // end if for PATTERN 5
                    // Code: if value from LastWon.txt is five, then do PATTERN 6 which is for selecting the highest value cards

                }
                else
                {
                    // If a card is not found, write a message to the debug output
                    System.Diagnostics.Debug.WriteLine($"Card with suit {suit} and value {value} not found or already dealt.");
                }
            }



                // Log the cards dealt
                using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(outlog);
            }

            System.Diagnostics.Debug.WriteLine(outlog);

            // Check if the correct number of cards were dealt
            if (dealtCards.Count != selectedSuits.Length)
            {
                throw new InvalidOperationException("Not enough cards were dealt.");
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


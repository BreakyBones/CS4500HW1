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

        public static bool equalHands = false;

        int somethingCounter = 0;


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

        // This does not execute all of PatternSix, but rather just finds the highest value which will be used for Pattern six
        // This part is the hardest part for pattern six.
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

        // Created by Grant on February 21
        // Pattern seven will see if all cards rise in ascending order for rank where Ace is the highest value then King, etc. down to two
        // Then make sure all cards are the same suit
        public bool PatternSeven(string[] selectedSuits, string[] selectedValues)
        {
            // I tried implementing this in the if statements for pattern seven, but I will make sure here that this code is run only if all cards are selected
            if (selectedValues.Length == 4)
            {
                // Mapping all values to numerical values since doing it in an if statement looks ugly
                int firstValue = int.Parse(MapFaceCardValue(selectedValues[0]));
                
                int secondValue = int.Parse(MapFaceCardValue(selectedValues[1]));
                int thirdValue = int.Parse(MapFaceCardValue(selectedValues[2]));
                int fourthValue = int.Parse(MapFaceCardValue(selectedValues[3]));

                Debug.Write("\n\nnumber value: " + Deck.MapFaceCardValue(selectedValues[0]) + "\n");
                // This if statement makes sure the values rise in ascending order
                if (firstValue < secondValue && secondValue < thirdValue && thirdValue < fourthValue)
                {
                    Debug.Write("\nThe cards rise in ascending order if this is reached.\n");
                    // This if statement makes sure the cards are the same suit
                    if (selectedSuits[0] == selectedSuits[1] && selectedSuits[1] == selectedSuits[2] && selectedSuits[2] == selectedSuits[3])
                    {
                        Debug.Write("\nThis round is won\n");
                        return true;
                    }
                }
                Debug.Write("\nThis round is lost\n");
                // If this point is reached, the correct match is not found so return false in the line two after this one.
            }
            return false;
        }

        // Created by Grant on February 21
        // Pattern eight will see if the cards after sorting increase by a value of two each time for all four cards. Ace's value is 14 here
        // The suit does not matter and neither the order
        public bool PatternEight(string[] selectedSuits, string[] selectedValues)
        {
            // Only run this function 
            if (selectedSuits.Length == 4)
            {
                // Sort the cards before checking if each value increases by two 
                List<int> cardValue = new List<int>();

                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    int value = int.Parse(MapFaceCardValue(selectedValues[i]));
                    cardValue.Add(value);
                }
                cardValue.Sort();
                // This lengthy if statement makes sure each value is separated to another value by two
                if ((cardValue[1] - cardValue[0]) == 2 && (cardValue[2] - cardValue[1]) == 2 && (cardValue[3] - cardValue[2]) == 2)
                {
                    Debug.Write("\n\nThis round is won\n\n");
                    return true;
                }
                Debug.Write("\nThis round is lost\n");
            }
            return false;
        }
        // Created by Grant on February 21
        // Pattern nine involves trying to find any combination of cards that adds to 11.
        public static bool[] PatternNine(string[] selectedSuits, string[] selectedValues)
        {
            bool[] eachCard = { false, false, false, false };
            if (selectedSuits.Length == 4)
            {
                // Create a list that holds the value of each card where the order does matter
                List<int> cardValue = new List<int>();
                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    int value = int.Parse(MapFaceCardValueForAceOne(selectedValues[i]));
                    cardValue.Add(value);
                }

                // Now do eleven if statements.
                for (int i = 1; i < selectedSuits.Length; i++)
                {
                    // Does the first card plus the second, third, or fourth card equal 11?
                    if (cardValue[0] + cardValue[i] == 11)
                    {
                        eachCard[0] = true;
                        eachCard[i] = true;
                    }
                }

                for (int i = 2; i < selectedSuits.Length; i++)
                {
                    // Does the second card plus the third or fourth card equal 11?
                    if (cardValue[1] + cardValue[i] == 11)
                    {
                        eachCard[1] = true;
                        eachCard[i] = true;
                    }
                }

                // Does the third card plus the fourth card equal 11
                if (cardValue[2] + cardValue[3] == 11)
                {
                    eachCard[2] = true;
                    eachCard[3] = true;
                }

                // Does the first card plus the second card plus the third card equal 11?
                if (cardValue[0] + cardValue[1] + cardValue[2] == 11)
                {
                    eachCard[0] = true;
                    eachCard[1] = true;
                    eachCard[2] = true;
                }
                // Does the first card plus the third card plus the fourth card equal 11?
                if (cardValue[0] + cardValue[2] + cardValue[3] == 11)
                {
                    eachCard[0] = true;
                    eachCard[2] = true;
                    eachCard[3] = true;
                }

                // Does the second card plus the third card plus the fourth card equal 11?
                if (cardValue[1] + cardValue[2] + cardValue[3] == 11)
                {
                    eachCard[1] = true;
                    eachCard[2] = true;
                    eachCard[3] = true;
                }
                // Does the first card plus the second card plus the fourth card equal 11?
                if (cardValue[0] + cardValue[1] + cardValue[3] == 11)
                {
                    eachCard[0] = true;
                    eachCard[1] = true;
                    eachCard[3] = true;
                }

                // Do all the cards added together equal 11?
                if (cardValue[0] + cardValue[1] + cardValue[2] + cardValue[3] == 11)
                {
                    eachCard[0] = true;
                    eachCard[1] = true;
                    eachCard[2] = true;
                    eachCard[3] = true;
                }


                return eachCard;
            }
            // I will only call this function when selectedSuits.Length is four so that this does not return otherwise.
            // This last return statement is so that no errors are thrown.
            return eachCard;
        }

        // Created by Grant on February 21
        // Pattern ten is like pattern eight and will have very similar code. Only the inner if statement will check for two eights
        // and two aces instead. I will sort it for ease.
        public bool PatternTen(string[] selectedSuits, string[] selectedValues)
        {
            // Only run this function 
            if (selectedSuits.Length == 4)
            {
                // Sort the cards before checking if each value increases by two 
                List<int> cardValue = new List<int>();

                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    int value = int.Parse(MapFaceCardValue(selectedValues[i]));
                    cardValue.Add(value);
                }
                cardValue.Sort();

                // This if statement makes sure there are two eights and two aces
                if (cardValue[0] == 8 && cardValue[1] == 8 && cardValue[2] == 14 && cardValue[3] == 14)
                {
                    Debug.Write("\n\nThis round is won\n\n");
                    return true;
                }
                Debug.Write("\nThis round is lost\n");
            }
            return false;
        }

        // Created by Grant on February 21
        // Pattern eleven checks to see if the cards include a jack, queen, king, and Ace in all of the same suit.
        public bool PatternEleven(string[] selectedSuits, string[] selectedValues)
        {
            // Only run this function 
            if (selectedSuits.Length == 4)
            {
                // Sort the cards before checking if each value increases by two 
                List<int> cardValue = new List<int>();

                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    int value = int.Parse(MapFaceCardValue(selectedValues[i]));
                    cardValue.Add(value);
                }
                cardValue.Sort();

                // This if statement makes sure there is on Jack (11), Queen (12), King (13), and Ace (14)
                if (cardValue[0] == 11 && cardValue[1] == 12 && cardValue[2] == 13 && cardValue[3] == 14)
                {
                    if (selectedSuits[0] == selectedSuits[1] && selectedSuits[1] == selectedSuits[2] && selectedSuits[2] == selectedSuits[3])
                    {
                        Debug.Write("\n\nThis round is won\n\n");
                        return true;
                    }
                }
                Debug.Write("\nThis round is lost\n");
            }
            return false;
        }

        // Created by Grant on February 21
        // Pattern twelve checks to see if there are two black jacks and two of any other aces
        public bool PatternTwelve(string[] selectedSuits, string[] selectedValues)
        {
            // Only run this function 
            if (selectedSuits.Length == 4)
            {
                int numBlackJacks = 0;
                // I will first make sure both of the black jacks are present
                for (int x = 0; x < selectedSuits.Length; x++)
                {
                    if (selectedSuits[x] == "Clubs" || selectedSuits[x] == "Spades")
                    {
                        if (selectedValues[x] == "J")
                        {
                            numBlackJacks++;
                        }
                    }
                }

                // This next part is for making sure there are two aces.
                // Sort the cards before checking if each value increases by two 
                List<int> cardValue = new List<int>();

                for (int i = 0; i < selectedSuits.Length; i++)
                {
                    int value = int.Parse(MapFaceCardValue(selectedValues[i]));
                    cardValue.Add(value);
                }
                cardValue.Sort();

                // This if statement makes sure the last two cards are aces along with the first two jacks
                if (cardValue[2] == 14 && cardValue[3] == 14 && numBlackJacks == 2)
                {
                    Debug.Write("\n\nThis round is won\n\n");
                    return true;
                }
                Debug.Write("\nThis round is lost\n");
            }
            return false;
        }



        // Co-opted this to do the actual legwork of Dealer Selection since it's no longer used to show cards anymore
        // Created by Kanaan
        public List<Card> DealSelectedCards(string[] selectedSuits, string[] selectedValues)
        {
            //added this counter to make sure it does not get the file pattern num every single time.
            somethingCounter++;
            if (somethingCounter == 1)
            {
                using (StreamReader srPattern = new StreamReader(patternFile))
                {
                    DrawCard.patternNum = int.Parse(srPattern.ReadToEnd());
                }
            }
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
                // Once all four cards have a suit and a value, add these four cards to the list cardHand that will be used to check
                // if two different hands are equal
                if (selectedSuits.Length == 4)
                {
                    string thisCard = selectedValues[i] + selectedSuits[i];
                    cardHand.Add(thisCard);
                }
            }

            // I had to add this if statement since this code is supposed to only run when the user clicks Deal instead of Confirm
            // Then this if statement states the whole part of trying to see duplicate patterns
            if (selectedSuits.Length == 4)
            {
                cardHand.Sort();
                Debug.Write("SelectedSuits is four now \n \n");


                // Read all lines from the file into an array. This line and the next three lines are from ChatGPT
                string[] lines = File.ReadAllLines(seeDuplicate);


                // Get the number of lines in the file, which also represent all previous cards selected.
                int numLines = lines.Length;
                Debug.Write("\n\nnumber of pervious entries is ");
                Debug.Write(numLines);
                Debug.Write("\n");
                string eachCard;
                // This if statement is so that equality checking is skipped if this is the first hand dealt for this pattern
                if (numLines < 4)
                {
                    // The next three lines are to double-check that file is empty since users may edit it by accident.
                    FileStream clearContent = File.Open("CurrentPattern.txt", FileMode.Open);
                    clearContent.SetLength(0);
                    clearContent.Close();
                    Debug.Write("\n\n I only want to see you one time per pattern");
                    // Add each item to the textfile CurrentPattern.txt
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
                    // This number represent the number of hands dealt so far
                    int numberHands = numLines / 4;
                    Debug.Write("\n\n" + numberHands + " ");
                    // Create a temporary list that hold each previous hand dealt
                    List<string> tempCardHand = new List<string>();

                    for (int hand = 0; hand < numberHands; hand++)
                    {
                        // It will be bad if this value reaches 4
                        int badFour = 0;
                        // I initialize the two values here since I noticed bugs when I initialized them in the for loop.
                        int carde = 0;
                        int element = 0;
                        // This for loop adds will make sure each previous hand takes a turn being compared to current hand.
                        for (carde = 0; carde < 4; carde++)
                        {
                            // This index will eventually all previous cards dealt if no hands equal the current hand.
                            int index = hand * 4 + carde;
                            Debug.Write("\n Index is " + index + "\n\n");
                            eachCard = lines[index];
                            Debug.Write(eachCard);
                            tempCardHand.Add(eachCard);
                        }
                        // This for loop will see if one the previous hands equal the current hand
                        for (element = 0; element < 4; element++)
                        {
                            if (tempCardHand[element] == cardHand[element])
                            {
                                badFour++;
                                Debug.Write("\n\n have this display each time \n\n");
                            }
                        }
                        // Clear the contents from the list that holds a previous hand since that hand is done being used for comparison
                        tempCardHand.Clear();

                        // If true, then the previous hand equals the current hand
                        if (badFour == 4)
                        {
                            equalHands = true;
                            Debug.Write("Equal Hands. \n");
                            // dealtCards = null;
                            // End the entire method here since two separate hands are unfortunately equal
                            return dealtCards;
                        }
                        // This else was added to help stop a bug where equalHands was set to true when it was supposed to be false
                        else
                        {
                            equalHands = false;
                            Debug.Write("not Equal Hands. \n");

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

            for (int i = 0; i < selectedSuits.Length; i++)
            {
                 string value = MapFaceCardValue(selectedValues[i]);
                 string suit = selectedSuits[i];
                 // Find the card with the matching suit and value
                 Card cardToDeal = cards.FirstOrDefault(card => card.Suit == suit && card.Value == value);


                if (cardToDeal != null)
                {
                    // if the value read from LastWon.txt is zero, then do the redCard option
                    // This needs code to read that value.
                    //Pattern 1
                    if (DrawCard.patternNum == 12)
                    {
                        DrawCard.patternNum = 0;
                    }
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
                    // If pattern seven is tested
                    if (DrawCard.patternNum == 6)
                    {
                        bool test = PatternSeven(selectedSuits, selectedValues);
                        if (test == true)
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
                    // If the Art Dealer is on Pattern 8
                    if (DrawCard.patternNum == 7)
                    {
                        bool test = PatternEight(selectedSuits, selectedValues);
                        if (test == true)
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
                    // If Art Dealer is on number nine
                    if (DrawCard.patternNum == 8)
                    {                    
                        bool[] cardsSelected = PatternNine(selectedSuits, selectedValues);
                        if (cardsSelected[i] == true)
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
                    // If the Art Dealer is on Pattern 10
                    if (DrawCard.patternNum == 9)
                    {
                        bool test = PatternTen(selectedSuits, selectedValues);
                        if (test == true)
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
                    // If Art Dealer is on pattern 11
                    if (DrawCard.patternNum == 10)
                    {
                        bool test = PatternEleven(selectedSuits, selectedValues);
                        if (test == true)
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
                    // If Art Dealer is on pattern 12
                    if (DrawCard.patternNum == 11)
                    {
                        bool test = PatternTwelve(selectedSuits, selectedValues);
                        if (test == true)
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
                else
                {
                    // If a card is not found, write a message to the debug output
                    System.Diagnostics.Debug.WriteLine($"Card with suit {suit} and value {value} not found or already dealt.");
                }

            }





            // Log the cards dealt when all are dealt
            if (selectedSuits.Length == 4)
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine(outlog);
                }
            }
            // This below is uncommented for testing
            System.Diagnostics.Debug.WriteLine(outlog);

            // Check if the correct number of cards were dealt
            if (dealtCards.Count != selectedSuits.Length)
            {
                Debug.Write("\ndealtCards count is: "+dealtCards.Count);
                Debug.Write("\nselectedsuits length is: " + selectedSuits.Length);
                MessageBox.Show("All cards needs to be selected and confirmed before selecting Deal");
                // throw new InvalidOperationException("Not enough cards were dealt." + dealtCards.Count + "and" + selectedSuits.Length);
            }

            return dealtCards;
        }

        public static string MapFaceCardValue(string value)
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

        public static string MapFaceCardValueForAceOne(string value)
        {
            switch (value)
            {
                case "J": return "11";
                case "Q": return "12";
                case "K": return "13";
                case "A": return "1";
                default: return value; // For number cards, the value does not change
            }
        }
    }
}


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
        string logPath = Application.StartupPath + "DealtCards.txt";
        string outlog = "";
       
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

        public List<Card> DealSelectedCards(string[] selectedSuits, string[] selectedValues)
        {
            List<Card> dealtCards = new List<Card>();
            outlog = "";

            for (int i = 0; i < selectedSuits.Length; i++)
            {
                // Map face card values to numbers
                string value = MapFaceCardValue(selectedValues[i]);
                string suit = selectedSuits[i];

                // Find the card with the matching suit and value
                Card cardToDeal = cards.FirstOrDefault(card => card.Suit == suit && card.Value == value);

                if (cardToDeal != null)
                {
                    dealtCards.Add(cardToDeal);
                    outlog += cardToDeal.Log() + (i < selectedSuits.Length - 1 ? "," : "");
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


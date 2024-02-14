using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


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

        //Method for loading dealing cards
        public List<Card> Deal(int count)
        {
            List<Card> dealtCards = new List<Card>();
            HashSet<int> dealtIndices = new HashSet<int>(); // To track indices of dealt cards

            for (int i = 0; i < count; i++)
            {
                int cardIndex;
                do
                {
                    cardIndex = random.Next(cards.Count);
                } while (dealtIndices.Contains(cardIndex)); // Keep searching until a unique index is found

                dealtIndices.Add(cardIndex); // Mark this card index as dealt
                dealtCards.Add(cards[cardIndex]);

                // Log the cards to string for later use
                if (i == count - 1)
                {
                    outlog = outlog + cards[cardIndex].Log();
                }
                else { outlog = outlog + cards[cardIndex].Log() + ","; }
            }
            // Write the logged cards to the log file
            using(StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(outlog);
            }
            System.Diagnostics.Debug.WriteLine(outlog);
            outlog = "";
            return dealtCards;
        }


    }
}


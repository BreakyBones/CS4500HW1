using CS4500HW1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;
using System.Drawing;

namespace CS4500HW1
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        public Deck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
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
                // Assuming images are stored in a folder named "CardImages" within your project's output directory
                var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var imagePath = Path.Combine(assemblyPath, "CardImages", imageName);
                return Image.FromFile(imagePath);
            }
            catch
            {
                // Handle exceptions or return a default image
                return null;
            }
        }

        //Method for loading dealing cards
        public List<Card> Deal(int count)
        {
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                int cardIndex = random.Next(cards.Count);
                dealtCards.Add(cards[cardIndex]);
            }
            return dealtCards;
        }


    }
}


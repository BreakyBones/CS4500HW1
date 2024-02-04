using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS4500HW1
{
    public partial class Form1 : Form
    {
        public Deck deck;
        public Form1()
        {
            InitializeComponent();
            deck = new Deck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cards = deck.Deal(4); // Deal 4 random cards
            DisplayCards(cards); // Display these cards on the form
        }

        private void DisplayCards(List<Card> cards)
        {
            if (cards.Count >= 4)
            {
                // Assuming cards.Count will be exactly 4 as you're dealing 4 cards
                pictureBox1.Image = cards[0].CardImage;
                pictureBox2.Image = cards[1].CardImage;
                pictureBox3.Image = cards[2].CardImage;
                pictureBox4.Image = cards[3].CardImage;

                // Set the SizeMode to ensure images fit nicely in the PictureBoxes
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                // Handle the case where fewer than 4 cards are dealt (optional)
                MessageBox.Show("Not enough cards were dealt.");
            }
        }
    }
}

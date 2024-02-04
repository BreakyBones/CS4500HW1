using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CS4500HW1
{
    public class Card
    {

        //We need a class for the cards that will hold its suit, value and image. (Random value will be the one that pulls the image)
        public string Suit { get; private set; }
        public string Value { get; private set; }
        public Image CardImage { get; private set; }

        public Card(string suit, string value, Image cardImage)
        {
            Suit = suit;
            Value = value;
            CardImage = cardImage;
        }
    }
}

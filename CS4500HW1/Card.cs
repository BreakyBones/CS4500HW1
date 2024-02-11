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

        // This is the string that will output to the file
        public string CardOut;

        public Card(string suit, string value, Image cardImage)
        {
            Suit = suit;
            Value = value;
            CardImage = cardImage;

            // Take the first Suit Letter and then stick the Value onto it
            char suitLet = suit[0];
            string valueLet;
            switch(value)
            {
                case "11":
                    valueLet = "J";
                    break;
                case "12":
                    valueLet = "Q";
                    break;
                case "13":
                    valueLet = "K";
                    break;
                case "14":
                    valueLet = "A";
                    break;
                default:
                    valueLet = value;
                    break;
            }

            CardOut = suitLet + valueLet;
        }
    }
}

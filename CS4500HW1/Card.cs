// This makes sure that the values of 11, 12, 13, 14 are associated with J, Q, K, A respectively

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

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
                    CardOut = valueLet + suitLet;
                    break;
                case "12":
                    valueLet = "Q";
                    CardOut = valueLet + suitLet;
                    break;
                case "13":
                    valueLet = "K";
                    CardOut = valueLet + suitLet;
                    break;
                case "14":
                    valueLet = "A";
                    CardOut = valueLet + suitLet;
                    break;
                default:
                    valueLet = value;
                    CardOut = suitLet + valueLet;
                    break;
            }

            
        }
        
        // returns the CardOut string
        public string Log()
        {
            return CardOut;
        }
    }
}

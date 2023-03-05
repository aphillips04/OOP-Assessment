using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        private int _value;
        private int _suit;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value >= 1 && value <= 13)
                {
                    _value = value;
                }
                else
                {
                    throw new Exception("Value must be between 1 and 13");
                }
            }
        }
        public int Suit
        {
            get
            {
                return _suit;
            }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    _suit = value;
                }
                else
                {
                    throw new Exception("Suit must be between 1 and 4");
                }
            }
        }

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}

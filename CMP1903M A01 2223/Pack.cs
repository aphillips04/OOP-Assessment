using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> pack;

        public Pack()
        {
            pack = new List<Card>();
            int v, s;
            for (s = 1; s <= 4; s++)
            {
                for (v = 1; v <= 13; v++)
                {
                    pack.Add(new Card(v, s));
                }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            if (typeOfShuffle == 1)
            {
                // Do Fisher-Yates shuffle
                return true;
            }
            else if (typeOfShuffle == 2)
            {
                // Do Riffle shuffle
                return true;
            }
            else if (typeOfShuffle == 3)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("invalid shuffle type");
            }

        }
        public Card deal()
        {
            //Deals one card
            return new Card(1, 1);

        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            return new List<Card>();
        }
    }
}

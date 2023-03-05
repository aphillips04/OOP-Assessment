using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private List<Card> _pack;

        public List<Card> pack
        {
            get { return _pack; }
            set {  }
        }

        public Pack()
        {
            _pack = new List<Card>();
            int v, s;
            for (s = 1; s <= 4; s++)
            {
                for (v = 1; v <= 13; v++)
                {
                    _pack.Add(new Card(v, s));
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
        public Card dealCard()
        {
            //Deals one card
            if (_pack.Count == 0)
            {
                throw new EmptyPackException("pack is empty");
            }
            Card card = _pack[0];
            Console.WriteLine(card);
            _pack.RemoveAt(0);
            return card;

        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            if (_pack.Count == 0)
            {
                throw new EmptyPackException("pack is empty");
            }
            else if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal negative amount of cards");
            } else if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal zero cards");
            } else if (amount > _pack.Count)
            {
                throw new ArgumentOutOfRangeException("cannot deal more cards than in the pack");
            }
            List<Card> cards = _pack.GetRange(0, amount);
            _pack.RemoveRange(0, amount);
            return cards;
        }
    }
}

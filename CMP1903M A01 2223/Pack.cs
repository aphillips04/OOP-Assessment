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
                List<Card> left = pack.GetRange(0, pack.Count / 2);
                int rightCount = pack.Count - left.Count;
                List<Card> right = pack.GetRange(pack.Count / 2, rightCount);
                Console.WriteLine($"l={left.Count} - r={right.Count}");

                List<Card> shuffled = new List<Card>();
                int i;
                for (i = 0; i < left.Count; i++)
                {
                    shuffled.Add(right[i]);
                    shuffled.Add(left[i]);
                }
                if (shuffled.Count != pack.Count)
                {
                    shuffled.Add(right[i]);
                }
                _pack = shuffled;
                return true;
            }
            else if (typeOfShuffle == 3)
            {
                // Do no shuffle
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
            if (pack.Count == 0)
            {
                throw new EmptyPackException("pack is empty");
            }
            Card card = pack[0];
            Console.WriteLine(card);
            pack.RemoveAt(0);
            return card;

        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            if (pack.Count == 0)
            {
                throw new EmptyPackException("pack is empty");
            }
            else if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal negative amount of cards");
            } else if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("cannot deal zero cards");
            } else if (amount > pack.Count)
            {
                throw new ArgumentOutOfRangeException("cannot deal more cards than in the pack");
            }
            List<Card> cards = pack.GetRange(0, amount);
            pack.RemoveRange(0, amount);
            return cards;
        }
    }
}
